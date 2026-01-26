

namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
    public class RiskCriteriaController : BaseController
    {
        private readonly IMediator _mediator;
        public ResponseDTO _responseDto;

        public RiskCriteriaController(IMediator mediator)
        {
            _mediator = mediator;
            _responseDto = new ResponseDTO();
        }


        [HttpPost("PostRiskCriteria")]
        public async Task<ResponseDTO> PostRiskCriteria([FromForm] RiskCriteriaPostDto command) => await _mediator.Send(new PostRiskCriteriaCommand(command));

        [HttpPut("PutRiskCriteria")]
        public async Task<ResponseDTO> PutRiskCriteria(Guid Id, [FromForm] RiskCriteriaPutDto command) => await _mediator.Send(new PutRiskCriteriaCommand(Id, command));

        [HttpDelete("DeleteRiskCriteria")]
        public async Task<ResponseDTO> DeleteRiskCriteria([FromForm] DeleteRiskCriteriaCommand command) => await _mediator.Send(command);

        [HttpGet("GetAllRiskCriteria")]
        public async Task<ResponseDTO> GetAllRiskCriteria([FromQuery] GetAllRiskCriteriaQuery query) => await _mediator.Send(query);
        [HttpGet("GetRiskCriteriabyid")]
        public async Task<ResponseDTO> GetLK_Satgebyid([FromQuery] GetRiskCriteriabyidQuery query) => await _mediator.Send(query);

        [HttpGet("GetRiskCriteriaMatrix")]
        public async Task<ResponseDTO> GetRiskCriteriaMatrix() => await _mediator.Send(new GetRiskCriteriaMatrixQuery());

    }
}
