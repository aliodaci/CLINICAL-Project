using CLINICAL.Applicaiton.Dtos.Analysis.Response;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery
{
    public class GetAnalysisByIdQuery:IRequest<BaseResponse<GetAnalysisByIdResponseDto>>
    {
        public int AnalysisId { get; set; }
    }
}
