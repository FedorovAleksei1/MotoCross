using Moto.Domain.Dto;
using System.Collections.Generic;

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
