


namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
    public class ImplementationStatusController : BaseController
    {
        private readonly IMediator _mediator;
        public ResponseDTO _responseDto;

        public ImplementationStatusController(IMediator mediator)
        {
            _mediator = mediator;
            _responseDto = new ResponseDTO();
        }


        [HttpPost("PostImplementationStatus")]
        public async Task<ResponseDTO> PostImplementationStatus([FromForm] ImplementationStatusPostDto command) => await _mediator.Send(new PostImplementationStatusCommand(command));

        [HttpPut("PutImplementationStatus")]
        public async Task<ResponseDTO> PutImplementationStatus(Guid Id, [FromForm] ImplementationStatusPutDto command) => await _mediator.Send(new PutImplementationStatusCommand(Id, command));

        [HttpDelete("DeleteImplementationStatus")]
        public async Task<ResponseDTO> DeleteImplementationStatus([FromForm] DeleteImplementationStatusCommand command) => await _mediator.Send(command);

        [HttpGet("GetAllImplementationStatus")]
        public async Task<ResponseDTO> GetAllImplementationStatus([FromQuery] GetAllImplementationStatusQuery query) => await _mediator.Send(query);
        [HttpGet("GetImplementationStatusbyid")]
        public async Task<ResponseDTO> GetLK_Satgebyid([FromQuery] GetImplementationStatusbyidQuery query) => await _mediator.Send(query);

    }
}
