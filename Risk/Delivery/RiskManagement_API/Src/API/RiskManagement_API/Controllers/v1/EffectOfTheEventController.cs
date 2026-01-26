using _4EPlatform.Application.Features.EffectOfTheEvent.Command.Delete;
using _4EPlatform.Application.Features.EffectOfTheEvent.Command.Post;
using _4EPlatform.Application.Features.EffectOfTheEvent.Command.Put;
using _4EPlatform.Application.Features.EffectOfTheEvent.Query.EffectOfTheEvent;
using _4EPlatform.Application.Features.EffectOfTheEvent.Query.GetAllEffectOfTheEvent;

namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
    public class EffectOfTheEventController : BaseController
    {
        private readonly IMediator _mediator;
        public EffectOfTheEventController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("PostEffectOfTheEvent")]
        public async Task<ResponseDTO> PostEffectOfTheEvent([FromForm] PostEffectOftheEventDto dto)
        {
            return await _mediator.Send(new PostEffectOfTheEventcommand(dto));
        }
        [HttpPut("PutEffectOfTheEvent")]
        public async Task<ResponseDTO> PutEffectOfTheEvent(Guid id,[FromForm] putEffectoftheEventDto dto)
        {
            return await _mediator.Send(new PutEffectOfTheEventyCommand(id,dto));
        }

        [HttpDelete("DeleteEffectOfTheEvent")]
        public async Task<ResponseDTO> DeleteEffectOfTheEvent(Guid id)
        {
            return await _mediator.Send(new DeleteEffectOfTheEventCommand(id));
        }

        [HttpGet("GetAllEffectOfTheEvent")]
        public async Task<ResponseDTO> GetAllEffectOfTheEvent([FromQuery] GetAllEffectOfTheEventQuery query)
        {
            return await _mediator.Send(query);
        }


        [HttpGet("GetEffectOfTheEventById/{Id}")]
        public async Task<ResponseDTO> GetEffectOfTheEventById(Guid Id)
        {
            return await _mediator.Send(new GetEffectOfTheEventByIdQuery(Id));
        }


    }
}
