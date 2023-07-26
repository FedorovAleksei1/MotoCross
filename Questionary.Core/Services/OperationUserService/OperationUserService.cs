using AutoMapper;
using Domain.Dto;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using MotoCross.Data;
using MotoCross.Services.UserService;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.OperationUserService
{
    public class OperationUserService : IOperationUserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUserService _userService;
        public OperationUserService(ApplicationDbContext context, IMapper mapper, IUserService userService)
        {
            _context = context;
            _mapper = mapper;
            _userService = userService;
        }
        public IEnumerable<OperationUserDto> ListOperationsUser(string userId)
        {
            var operationsuser = _context.OperationsUser.Where(o => o.UserId == userId).OrderByDescending(x=>x.Id).AsEnumerable();
            var operationuserDto = _mapper.Map<IEnumerable<OperationUserDto>>(operationsuser);
            return operationuserDto;
        }

        public void AddOperation(int operationUserId, OperationDto operationDto)
        {

            var operationUser = _context.OperationsUser.Include(o => o.Operations).FirstOrDefault(p => p.Id == operationUserId);
            if (operationUser != null)
                operationUser.Operations.ToList().Add(_mapper.Map<Operation>(operationDto));
            _context.Add(operationUser);
            _context.SaveChanges();

        }

        public void AddBalans(OperationUserDto OperationbalansDto)
        {
            if (OperationbalansDto == null)
                throw new Exception("Такой операции не сущесвтует");

            var useroperationbalans = _context.Balanses.FirstOrDefault(u => u.UserId== OperationbalansDto.UserId);

            useroperationbalans.BalansMoney += OperationbalansDto.Price;
            OperationbalansDto.NameCustomer="Пополнено";

            _context.Add(_mapper.Map<OperationUser>(OperationbalansDto));
            _context.Update(useroperationbalans);
            _context.SaveChanges();
        }

        public void ResetBalans(OperationUserDto resetOperationBalansDto)
        {
            if (resetOperationBalansDto == null)
                throw new Exception("Такой операции не сущесвтует");
            
            var useroperationbalans = _context.Balanses.FirstOrDefault(u => u.UserId == resetOperationBalansDto.UserId);
            if(useroperationbalans == null)
            {
                _context.Balanses.Add(new Balans
                {
                    BalansMoney = 0,
                    UserId = resetOperationBalansDto.UserId,
                    CreateDate = DateTime.Now,
                    DatePutMoney = DateTime.Now,
                    Operation = _context.Operations.FirstOrDefault(x => x.Id == 2)
                }) ;
                _context.SaveChanges();
            }
            useroperationbalans=_context.Balanses.FirstOrDefault(u => u.UserId == resetOperationBalansDto.UserId);
            useroperationbalans.BalansMoney -= resetOperationBalansDto.Price;
            resetOperationBalansDto.NameCustomer="Списано";

            _context.Add(_mapper.Map<OperationUser>(resetOperationBalansDto));
            _context.Update(useroperationbalans);
            _context.SaveChanges();
        }



        public OperationUserDto GetOperationByOrder(int orderId)
        {
            var operationsuser = _context.OperationsUser.FirstOrDefault(o => o.OrderId == orderId);

            var operationuserDto = _mapper.Map<OperationUserDto>(operationsuser);
            return operationuserDto;
        }


        

    }
}
