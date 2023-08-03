using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moto.Core.Services.AdminService.AdminImportantService
{
    public interface IAdminImportantService
    {
        IEnumerable<ImportantDto> ListImportansDto();

        ImportantDto GetImportanById(int id);
        void CreateImportant(ImportantDto importanDto);
        void EditImportan(ImportantDto importanDto);
        void DeleteImportan(int id);

    }
}
