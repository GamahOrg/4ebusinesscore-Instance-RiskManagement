using _4EPlatform.Application.Features.RisksFilterFeature.Command.Delete;
using _4EPlatform.Application.Features.RisksFilterFeature.Command.Post;
using _4EPlatform.Application.Features.RisksFilterFeature.Query.GetAllGetRisksFilter;
using _4EPlatform.Application.Features.RisksFilterFeature.Query.GetRisksFilterByUserId;

namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
 
    public class RisksFilterController : BaseController
    {
        private readonly IMediator _mediator;
        public ResponseDTO _responseDto;

        public RisksFilterController(IMediator mediator)
        {
            _mediator = mediator;
            _responseDto = new ResponseDTO();
        }

        [HttpPost("PostRisksfilter")]
        public async Task<ResponseDTO> PostRisksfilter([FromForm] RisksFilterControllerDto dto)
        => await _mediator.Send(new PostRisksFilterCommand(dto));


        [HttpDelete("DeleteRisksfilter")]
        public async Task<ResponseDTO> DeleteProcessingPlan(Guid UserId)
        {
            return await _mediator.Send(new DeleteRisksFilterCommand { UserId = UserId });
        }
        [HttpGet("GetAllRisksFilter")]
        public async Task<ResponseDTO> GetAllRisksFilter([FromQuery] GetAllRisksFilterQuery query)
        {
            return await _mediator.Send(query);
        }
        [HttpGet("GetRisksFilterByUserId")]
        public async Task<ResponseDTO> GetRisksFilterByUserId()
        {
            return await _mediator.Send(new GetRisksFilterByUserIdQuery());
        }


    }
}
