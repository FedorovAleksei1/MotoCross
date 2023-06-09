using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.ImportantService
{
    public interface IImportantService
    {

        public List<ImportantDto> ListImportantsDto();
        ImportantDto GetImportantById (int id);
    }
}
