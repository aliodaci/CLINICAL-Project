using AutoMapper;
using CLINICAL.Application.Interface;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity = CLINICAL.Domain.Entities;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand
{
    public class UpdateAnalysisHandler : IRequestHandler<UpdateAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalysisDal _analysisDal;
        private readonly IMapper _mapper;

        public UpdateAnalysisHandler(IAnalysisDal analysisDal, IMapper mapper)
        {
            _analysisDal = analysisDal;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response=new BaseResponse<bool>();
            try
            {
                var analysis = _mapper.Map<Entity.Analysis>(request);
                response.Data=await _analysisDal.AnalysisEdit(analysis);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Güncelleme Başarılı";
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
