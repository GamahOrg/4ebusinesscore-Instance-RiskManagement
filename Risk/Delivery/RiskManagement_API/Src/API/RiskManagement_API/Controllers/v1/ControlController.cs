using _4EPlatform.Application.Features.Control.Command.Delete;
using _4EPlatform.Application.Features.Control.Command.Post;
using _4EPlatform.Application.Features.Control.Command.Put;
using _4EPlatform.Application.Features.Control.Query.GetAllCategory;
using _4EPlatform.Application.Features.Control.Query.GetCategoryById;

namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
    public class ControlController : BaseController
    {
        private readonly IMediator _mediator;
        public ControlController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("PostControl")]
        public async Task<ResponseDTO> PostControl([FromForm] PostControlDto dto)
        {
            return await _mediator.Send(new PostControlcommand(dto));
        }
        [HttpPut("PutControl")]
        public async Task<ResponseDTO> PutControl(Guid id , [FromForm] PutControlDto dto)
        {
            return await _mediator.Send(new PutControlCommand( id, dto));
        }

        [HttpDelete("DeleteControl")]
        public async Task<ResponseDTO> DeleteControl(Guid id)
        {
            return await _mediator.Send(new DeleteControlCommand(id));
        }

        [HttpGet("GetAllControl")]
        public async Task<ResponseDTO> GetAllControl([FromQuery] GetControlQuery query)
        {
            return await _mediator.Send(query);
        }


        [HttpGet("GetControlById/{Id}")]
        public async Task<ResponseDTO> GetControlById(Guid Id)
        {
            return await _mediator.Send(new GetControlByIdQuery(Id));
        }


    }
}
