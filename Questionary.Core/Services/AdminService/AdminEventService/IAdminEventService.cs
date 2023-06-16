using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.AdminService.AdminEventService
{
    public interface IAdminEventService
    {
        IEnumerable<EventDto> ListAdminEventsDto();

        EventDto GetAdminEventById(int id);
        void CreateAdminEvent(EventDto eventDto);
        void EditAdminEvent(EventDto eventDto);
        void DeleteAdminEvent(int id);

    }
}
