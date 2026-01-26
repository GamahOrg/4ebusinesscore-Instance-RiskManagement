


namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
    public class TypeTreatmentPlanController : BaseController
    {
        private readonly IMediator _mediator;
        public ResponseDTO _responseDto;

        public TypeTreatmentPlanController(IMediator mediator)
        {
            _mediator = mediator;
            _responseDto = new ResponseDTO();
        }


        [HttpPost("PostTypeTreatmentPlan")]
        public async Task<ResponseDTO> PostTypeTreatmentPlan([FromForm] TypeTreatmentPlanPostDto command) => await _mediator.Send(new PostTypeTreatmentPlanCommand(command));

        [HttpPut("PutTypeTreatmentPlan")]
        public async Task<ResponseDTO> PutTypeTreatmentPlan(Guid Id, [FromForm] TypeTreatmentPlanPutDto command) => await _mediator.Send(new PutTypeTreatmentPlanCommand(Id, command));

        [HttpDelete("DeleteTypeTreatmentPlan")]
        public async Task<ResponseDTO> DeleteTypeTreatmentPlan([FromForm] DeleteTypeTreatmentPlanCommand command) => await _mediator.Send(command);

        [HttpGet("GetAllTypeTreatmentPlan")]
        public async Task<ResponseDTO> GetAllTypeTreatmentPlan([FromQuery] GetAllTypeTreatmentPlanQuery query) => await _mediator.Send(query);
        [HttpGet("GetTypeTreatmentPlanbyid")]
        public async Task<ResponseDTO> GetLK_Satgebyid([FromQuery] GetTypeTreatmentPlanbyidQuery query) => await _mediator.Send(query);

    }
}
