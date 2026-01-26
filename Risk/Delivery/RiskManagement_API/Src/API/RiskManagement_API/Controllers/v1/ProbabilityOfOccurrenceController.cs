


namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
    public class ProbabilityOfOccurrenceController : BaseController
    {
        private readonly IMediator _mediator;
        public ResponseDTO _responseDto;

        public ProbabilityOfOccurrenceController(IMediator mediator)
        {
            _mediator = mediator;
            _responseDto = new ResponseDTO();
        }


        [HttpPost("PostProbabilityOfOccurrence")]
        public async Task<ResponseDTO> PostProbabilityOfOccurrence([FromForm] ProbabilityOfOccurrencePostDto command) => await _mediator.Send(new PostProbabilityOfOccurrenceCommand(command));

        [HttpPut("PutProbabilityOfOccurrence")]
        public async Task<ResponseDTO> PutProbabilityOfOccurrence(Guid Id, [FromForm]  ProbabilityOfOccurrencePutDto command) => await _mediator.Send(new PutProbabilityOfOccurrenceCommand(Id, command));

        [HttpDelete("DeleteProbabilityOfOccurrence")]
        public async Task<ResponseDTO> DeleteProbabilityOfOccurrence([FromForm] DeleteProbabilityOfOccurrenceCommand command) => await _mediator.Send(command);

        [HttpGet("GetAllProbabilityOfOccurrence")]
        public async Task<ResponseDTO> GetAllProbabilityOfOccurrence([FromQuery] GetAllProbabilityOfOccurrenceQuery query) => await _mediator.Send(query);
        [HttpGet("GetProbabilityOfOccurrencebyid")]
        public async Task<ResponseDTO> GetLK_Satgebyid([FromQuery] GetProbabilityOfOccurrencebyidQuery query) => await _mediator.Send(query);

    }
}
