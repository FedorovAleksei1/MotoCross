﻿using Domain.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionary.Core.Services.AdminService.AdminOperationService
{
    public interface IOperationService
    {
       
        OperationDto GetByDictionaryId(int dictionaryTypeId);
        void Create(OperationDto operationDto);
    }
}
