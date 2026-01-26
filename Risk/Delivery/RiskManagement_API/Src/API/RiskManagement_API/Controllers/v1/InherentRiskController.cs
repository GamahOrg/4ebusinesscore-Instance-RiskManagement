

using _4EPlatform.Application.Features.InherentRiskFeature.Query.GetAllInherentRisk;

namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
    public class InherentRiskController : BaseController
    {
        private readonly IMediator _mediator;
        public InherentRiskController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("PostInherentRisk")]
        public async Task<ResponseDTO> PostInherentRisk([FromForm] PostInherentRiskDTO dto)
        {
            return await _mediator.Send(new PostInherentRiskCommand(dto));
        }

        [HttpGet("GetAllInherentRisks")]
        public async Task<ResponseDTO> GetAllInherentRisks([FromQuery] GetAllInherentRiskQuery query)
        {
            return await _mediator.Send(query);
        }

    }
}
