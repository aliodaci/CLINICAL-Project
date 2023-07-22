﻿using AutoMapper;
using CLINICAL.Applicaiton.Dtos;
using CLINICAL.Applicaiton.Dtos.Analysis.Response;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using CLINICAL.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using CLINICAL.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLINICAL.Application.UseCase.Mappings
{
    public class AnalysisMappingProfile:Profile
    {
        public AnalysisMappingProfile()
        {
            CreateMap<Analysis,GetAllAnalysisReponseDto>()
                .ForMember(x=>x.StateAnalysis,x=>x.MapFrom(y=>y.State==1?"Aktif":"Pasif"))
                .ReverseMap();
            CreateMap<Analysis,GetAnalysisByIdResponseDto>().ReverseMap();
            CreateMap<CreateAnalysisCommand,Analysis>().ReverseMap();
            CreateMap<UpdateAnalysisCommand,Analysis>().ReverseMap();

        }
    }
}
