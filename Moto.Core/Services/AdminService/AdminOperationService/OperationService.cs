using AutoMapper;
using Domain.Dto;
using MotoCross.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Core.Services.AdminService.AdminOperationService
{
    public class OperationService : IOperationService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        public OperationService(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        

        public void Create(OperationDto operationDto)
        {
            
        }

        public OperationDto GetByDictionaryId(int dictionaryTypeId)
        {
           var operation = _context.Operations.Where(o =>o.DictionaryTypeId == dictionaryTypeId).AsEnumerable();
            return _mapper.Map<OperationDto>(operation);
        }

       
    }
}
