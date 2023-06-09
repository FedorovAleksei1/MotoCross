using Domain.Dto;
using System.Collections.Generic;

namespace MotoCross.Services.MotoService
{
    public interface IMotoService
    {
        IEnumerable<MotoDto> GetAllByUserId(string userId);

		void Create(IEnumerable<MotoDto> motosDto);
    }
}
