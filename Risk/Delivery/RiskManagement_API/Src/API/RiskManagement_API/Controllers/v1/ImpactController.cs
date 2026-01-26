
namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
    public class ImpactController : BaseController
    {
        private readonly IMediator _mediator;
        public ResponseDTO _responseDto;

        public ImpactController(IMediator mediator)
        {
            _mediator = mediator;
            _responseDto = new ResponseDTO();
        }


        [HttpPost("PostImpact")]
        public async Task<ResponseDTO> PostImpact([FromForm] ImpactPostDto command) => await _mediator.Send(new PostImpactCommand(command));

        [HttpPut("PutImpact")]
        public async Task<ResponseDTO> PutImpact(Guid Id, [FromForm] ImpactPutDto command) => await _mediator.Send(new PutImpactCommand(Id, command));

        [HttpDelete("DeleteImpact")]
        public async Task<ResponseDTO> DeleteImpact([FromForm] DeleteImpactCommand command) => await _mediator.Send(command);

        [HttpGet("GetAllImpact")]
        public async Task<ResponseDTO> GetAllImpact([FromQuery] GetAllImpactQuery query) => await _mediator.Send(query);
        [HttpGet("GetImpactbyid")]
        public async Task<ResponseDTO> GetLK_Satgebyid([FromQuery] GetImpactbyidQuery query) => await _mediator.Send(query);

    }
}
