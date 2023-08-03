using Moto.Domain.Dto;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Moto.Core.Services.AdminService.AdminEventService
{
    public interface IAdminEventService
    {
        IEnumerable<EventDto> ListAdminEventsDto();

        EventDto GetAdminEventById(int id);
        void CreateAdminEvent(EventDto eventDto);
        void EditAdminEvent(EventDto eventDto, IFormFile photo);
        void DeleteAdminEvent(int id);

    }
}
