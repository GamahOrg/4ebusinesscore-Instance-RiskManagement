

using _4EPlatform.Application.Features.RemainRiskFeature.Query.GetAllRemainRisk;

namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
    public class RemainRiskController : BaseController
    {
        private readonly IMediator _mediator;
        public RemainRiskController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("PostRemainRisk")]
        public async Task<ResponseDTO> PostRemainRisk([FromForm] PostRemainRiskDTO dto)
        {
            return await _mediator.Send(new PostRemainRiskCommand(dto));
        }

        [HttpGet("GetAllRemainRisks")]
        public async Task<ResponseDTO> GetAllRemainRisks([FromQuery] GetAllRemainRiskQuery query)
        {
            return await _mediator.Send(query);
        }

    }
}
