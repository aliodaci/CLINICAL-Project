using AutoMapper;
using CLINICAL.Application.Interface;
using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand
{
    public class DeleteAnalysisHandler : IRequestHandler<DeleteAnalysisCommand, BaseResponse<bool>>
    {
        private readonly IAnalysisDal _analysisDal;
        private readonly IMapper _mapper;

        public DeleteAnalysisHandler(IAnalysisDal analysisDal, IMapper mapper)
        {
            _analysisDal = analysisDal;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(DeleteAnalysisCommand request, CancellationToken cancellationToken)
        {
            var response=new BaseResponse<bool>();
            try
            {
                response.Data=await _analysisDal.AnalysisRemove(request.AnalysisId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = $"{request.AnalysisId} kaydı silindi";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
