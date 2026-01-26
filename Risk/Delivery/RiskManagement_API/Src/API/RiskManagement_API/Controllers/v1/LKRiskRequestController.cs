
using _4EPlatform.Application.Features.LookUps.LKRiskRequest.Command.Delete;
using _4EPlatform.Application.Features.LookUps.LKRiskRequest.Command.Post;
using _4EPlatform.Application.Features.LookUps.LKRiskRequest.Command.Put;
using _4EPlatform.Application.Features.LookUps.LKRiskRequest.Query.GetAll;
using _4EPlatform.Application.Features.LookUps.LKRiskRequest.Query.GetById;

namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
    public class LKRiskRequestController : BaseController
    {
        private readonly IMediator _mediator;
        public ResponseDTO _responseDto;

        public LKRiskRequestController(IMediator mediator)
        {
            _mediator = mediator;
            _responseDto = new ResponseDTO();
        }

        [HttpPost("PostLKRiskRequest")]
        public async Task<ResponseDTO> PostLKRiskRequest([FromForm] LKRiskRequestPostDto command) => await _mediator.Send(new PostLKRiskRequestCommand(command));

        [HttpPut("PutLKRiskRequest")]
        public async Task<ResponseDTO> PutLKRiskRequest(int Id, [FromForm] LKRiskRequestPutDto command) => await _mediator.Send(new PutLKRiskRequestCommand(Id, command));

        [HttpDelete("DeleteLKRiskRequest")]
        public async Task<ResponseDTO> DeleteLKRiskRequest([FromForm] DeleteLKRiskRequestCommand command) => await _mediator.Send(command);

        [HttpGet("GetAllLKRiskRequest")]
        public async Task<ResponseDTO> GetAllLKRiskRequest([FromQuery] GetAllLKRiskRequestQuery query) => await _mediator.Send(query);

        [HttpGet("GetLKRiskRequestById")]
        public async Task<ResponseDTO> GetLKRiskRequestById([FromQuery] GetLKRiskRequestByIdQuery query) => await _mediator.Send(query);
    }
}
