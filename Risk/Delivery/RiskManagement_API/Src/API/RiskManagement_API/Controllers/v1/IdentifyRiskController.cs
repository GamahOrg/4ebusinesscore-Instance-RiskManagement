using _4EPlatform.Application.Features.IdentifyRiskFeature.Command.Delete;
using _4EPlatform.Application.Features.IdentifyRiskFeature.Command.Post;
using _4EPlatform.Application.Features.IdentifyRiskFeature.Command.Put;

namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
    public class IdentifyRiskController : BaseController
    {
        private readonly IMediator _mediator;
        public IdentifyRiskController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("PostIdentifyRisk")]
        public async Task<ResponseDTO> PostIdentifyRisk([FromForm] PostIdentifyRiskDTO dto)
        {
            return await _mediator.Send(new PostIdentifyRiskCommand(dto));
        }
        [HttpPut("PutIdentifyRisk/{Id}")]
        public async Task<ResponseDTO> PutIdentifyRisk(Guid Id, [FromForm] PutIdentifyRiskDTO dto)
        {
            return await _mediator.Send(new PutIdentifyRiskCommand(Id, dto));
        }
        [HttpDelete("DeleteIdentifyRisk/{Id}")]
        public async Task<ResponseDTO> DeleteIdentifyRisk(Guid Id)
        {
            return await _mediator.Send(new DeleteIdentifyRiskCommand { Id = Id });
        }
    }
}
