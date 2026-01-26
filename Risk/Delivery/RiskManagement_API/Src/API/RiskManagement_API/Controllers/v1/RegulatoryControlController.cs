

namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
    public class RegulatoryControlController : BaseController
    {
        private readonly IMediator _mediator;
        public RegulatoryControlController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("PostRegulatoryControl")]
        public async Task<ResponseDTO> PostRegulatoryControl([FromForm] PostRegulatoryControlDTO dto)
        {
            return await _mediator.Send(new PostRegulatoryControlCommand(dto));
        }

    }
}
