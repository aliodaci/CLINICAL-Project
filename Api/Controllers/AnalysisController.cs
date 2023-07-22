﻿using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery;
using CLINICAL.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery;
using CLINICAL.Domain.Entities;
using CLINICAL.Persistence.Context;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ListAnalysis()
        {
            var response=await _mediator.Send(new GetAllAnalysisQuery());
            return Ok(response);   
        }

        [HttpGet("{analysisId:int}")]
        public async Task<IActionResult> AnalysisById(int analysisId)
        {
            var response = await _mediator.Send(new GetAnalysisByIdQuery() { AnalysisId = analysisId });
            return Ok(response);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> RegisterAnalysis([FromBody] CreateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HttpPut("Edit")]
        public async Task<IActionResult> EditAnalysis([FromBody] UpdateAnalysisCommand command)
        {
            var response=await _mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("Remove/{analysisId:int}")]
        public async Task<IActionResult> RemoveAnalysis(int analysisId)
        {
            var response=await _mediator.Send(new DeleteAnalysisCommand() { AnalysisId = analysisId });
            return Ok(response);
        }
    }
}
