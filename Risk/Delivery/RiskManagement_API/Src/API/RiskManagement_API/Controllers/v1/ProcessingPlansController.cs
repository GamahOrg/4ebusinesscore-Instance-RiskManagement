

using _4EPlatform.Application.Features.Control.Command.Delete;
using _4EPlatform.Application.Features.ProcessingPlans.Command.Delete;

namespace _4EPlatform_RiskManagement_API.Controllers.v1
{

    public class ProcessingPlansController : BaseController
    {
        private readonly IMediator _mediator;
        public ProcessingPlansController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("PostProcessingPlans")]
        public async Task<ResponseDTO> PostProcessingPlans([FromBody] ProcessingPlansControllerDto dto)
         => await _mediator.Send(new PostProcessingPlansCommand(dto));


        [HttpDelete("DeleteProcessingPlan")]
        public async Task<ResponseDTO> DeleteProcessingPlan (Guid id)
        {
            return await _mediator.Send(new DeleteProcessingPlansCommand { ProcessingPlanId = id});
        }

    }
}
