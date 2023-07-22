using AutoMapper;
using CLINICAL.Applicaiton.Dtos;
using CLINICAL.Application.Interface;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery
{
    public class GetAllAnalysisHandler : IRequestHandler<GetAllAnalysisQuery, BaseResponse<IEnumerable<GetAllAnalysisReponseDto>>>
    {
        private readonly IAnalysisDal _analysisDal;
        private readonly IMapper _mapper;

        public GetAllAnalysisHandler(IAnalysisDal analysisDal,IMapper mapper)
        {
            _analysisDal = analysisDal;
            _mapper = mapper;
        }
        public async Task<BaseResponse<IEnumerable<GetAllAnalysisReponseDto>>> Handle(GetAllAnalysisQuery request, CancellationToken cancellationToken)
        {
            var response=new BaseResponse<IEnumerable<GetAllAnalysisReponseDto>>();
            try
            {
                var analysis = await _analysisDal.ListAnalysis();
                if (analysis is not null)
                {
                    response.IsSuccess = true;
                    response.Data=_mapper.Map<IEnumerable<GetAllAnalysisReponseDto>>(analysis);
                    response.Message = "sorgu başarılı";
                }
            }
            catch (Exception ex)
            {
                response.Message=ex.Message;
            }
            return response;
        }
    }
}
