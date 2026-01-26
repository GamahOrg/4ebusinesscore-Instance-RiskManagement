

namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
    public class ProbabilityOfEffectivenesController : BaseController
    {
        private readonly IMediator _mediator;
        public ProbabilityOfEffectivenesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("PostProbabilityOfEffectivenes")]
        public async Task<ResponseDTO> PostProbabilityOfEffectivenes([FromForm] ProbabilityOfEffectivenesPostDto command)
        {
            return await _mediator.Send(new PostProbabilityOfEffectivenescommand(command));
        }
        [HttpPut("PutProbabilityOfEffectivenes")]
        public async Task<ResponseDTO> PutProbabilityOfEffectivenes(Guid Id, [FromForm] ProbabilityOfEffectivenesPutDto command)
        {
            return await _mediator.Send(new PutProbabilityOfEffectivenesCommand(Id, command));
        }

        [HttpDelete("DeleteProbabilityOfEffectivenes")]
        public async Task<ResponseDTO> DeleteProbabilityOfEffectivenes([FromForm] DeleteProbabilityOfEffectivenesCommand ProbabilityOfEffectivenescommand)
        {
            return await _mediator.Send(ProbabilityOfEffectivenescommand);
        }

        [HttpGet("GetAllProbabilityOfEffectivenes")]
        public async Task<ResponseDTO> GetAllProbabilityOfEffectivenes([FromQuery] GetAllProbabilityOfEffectivenesQuery query )
        {
            return await _mediator.Send(query);
        }


        [HttpGet("GetProbabilityOfEffectivenes/{Id}")]
        public async Task<ResponseDTO> GetProbabilityOfEffectivenes(Guid Id)
        {
            return await _mediator.Send(new GetProbabilityOfEffectivenesByIdQuery { ProbabilityOfEffectivenesId = Id });
        }


    }
}
