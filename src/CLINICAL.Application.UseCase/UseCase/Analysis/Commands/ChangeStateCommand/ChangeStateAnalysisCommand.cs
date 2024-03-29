﻿using CLINICAL.Application.UseCase.Commons.Bases;
using MediatR;

namespace CLINICAL.Application.UseCase.UseCase.Analysis.Commands.ChangeStateCommand
{
    public class ChangeStateAnalysisCommand : IRequest<BaseResponse<bool>>
    {
        public int AnalysisId { get; set; }
        public int State { get; set; }
    }
}
