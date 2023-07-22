using AutoMapper;
using CLINICAL.Application.Interface;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity=CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand
{
    public class CreateAnalysisHandler : IRequestHandler<CreateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalysisDal _analysisDal;
        private readonly IMapper _mapper;
        public CreateAnalysisHandler(IAnalysisDal analysisDal,IMapper mapper)
        {
            _analysisDal = analysisDal;
            _mapper = mapper;
        }
        public async Task<BaseResponse<bool>> Handle(CreateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response=new BaseResponse<bool>();
            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                response.Data=await _analysisDal.AnalysisRegister(analysis);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "kayıt başarılı";
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
