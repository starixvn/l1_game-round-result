using FluentValidation;
using GameRoundResult.Core.Services;
using GameRoundResult.Web.Requests;

namespace GameRoundResult.Web.Validators
{
    public class RetrieveEndRoundInfoRequestValidator : AbstractValidator<RetrieveEndRoundInfoRequest>
    {
        public RetrieveEndRoundInfoRequestValidator()
        {
            RuleFor(x => x.GameRoundId).GreaterThan(0).WithErrorCode(EndRoundInfoError.SB1002.ErrorCode).WithMessage(EndRoundInfoError.SB1002.ErrorDescription);
            RuleFor(x => x.PlayerId).GreaterThan(0).WithErrorCode(EndRoundInfoError.SB1004.ErrorCode).WithMessage(EndRoundInfoError.SB1004.ErrorDescription);
        }
    }
}