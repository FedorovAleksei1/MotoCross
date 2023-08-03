using Domain.Dto;
using System.Collections.Generic;

namespace MotoCross.Services.MotoService
{
    public interface IMotoService
    {
        IEnumerable<MotoDto> GetAllByUserId(string userId);

        void Create(MotoDto motoDto);

        void Update(MotoDto motoDto);
        void Delete(int id);

        void Create(IEnumerable<MotoDto> motosDto);
    }
}
