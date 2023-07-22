﻿using CLINICAL.Applicaiton.Dtos;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery
{
    public class GetAllAnalysisQuery:IRequest<BaseResponse<IEnumerable<GetAllAnalysisReponseDto>>>
    {
    }
}
