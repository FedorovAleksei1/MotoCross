using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Core.Services.OperationUserService
{
    public interface IOperationUserService
    {
        IEnumerable<OperationUserDto> ListOperationsUser(string userId);
        
        void AddOperation(int operationUserId, OperationDto operationDto);

        void AddBalans(OperationUserDto OperationbalansDto);

        void ResetBalans(OperationUserDto resetOperationBalansDto);

        OperationUserDto GetOperationByOrder(int orderId);
    }
}
