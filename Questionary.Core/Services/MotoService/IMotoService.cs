using Domain.Dto;
using System.Collections.Generic;

namespace MotoCross.Services.MotoService
{
    public interface IMotoService
    {
        void Create(List<MotoDto> motosDto);
    }
}
