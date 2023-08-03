using Domain.Dto;
using System.Collections.Generic;

namespace Moto.Web.Areas.Admin.ViewModel
{
    public class UserViewModel
    {
        public UserDto User { get; set; }
        public BalansDto Balans { get; set; }
        

        public List<OperationUserDto> OpeartionUser { get; set; }
    }
}
