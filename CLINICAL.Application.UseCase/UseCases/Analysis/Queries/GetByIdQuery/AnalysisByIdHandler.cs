using AutoMapper;
using CLINICAL.Applicaiton.Dtos.Analysis.Response;
using CLINICAL.Application.Interface;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery
{
    public class AnalysisByIdHandler : IRequestHandler<GetAnalysisByIdQuery, BaseResponse<GetAnalysisByIdResponseDto>>
    {
        private readonly IAnalysisDal _analysisDal;
        private readonly IMapper _mapper;
        public AnalysisByIdHandler(IAnalysisDal analysisDal,IMapper mapper)
        {
            _analysisDal = analysisDal;
            _mapper = mapper;
        }
        public async Task<BaseResponse<GetAnalysisByIdResponseDto>> Handle(GetAnalysisByIdQuery request, CancellationToken cancellationToken)
        {
            var response=new BaseResponse<GetAnalysisByIdResponseDto>();
            try
            {
                var analysis=await _analysisDal.GetAnalysisById(request.AnalysisId);
                if (analysis == null)
                {
                    response.IsSuccess = false;
                    response.Message = "Kayıt bulunamadı.";
                    return response;
                }
                response.IsSuccess = true;
                response.Data = _mapper.Map<GetAnalysisByIdResponseDto>(analysis);
                response.Message = "sorgu başarılı";
            }
            catch (Exception ex)
            {
                response.Message=ex.Message;
            }
            return response;
        }
    }
}
