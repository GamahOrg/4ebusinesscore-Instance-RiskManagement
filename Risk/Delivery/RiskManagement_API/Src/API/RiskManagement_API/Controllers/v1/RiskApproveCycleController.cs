using _4EPlatform.Application.Features.RiskApproveCycle.Command.Delete;
using _4EPlatform.Application.Features.RiskApproveCycle.Command.Post;
using _4EPlatform.Application.Features.RiskApproveCycle.Command.PostRiskCustomApprovalCycle;
using _4EPlatform.Application.Features.RiskApproveCycle.Command.Put;
using _4EPlatform.Application.Features.RiskApproveCycle.Command.PutDynamicCycle;
using _4EPlatform.Application.Features.RiskApproveCycle.Command.UpdateLKRequestStatus;
using _4EPlatform.Application.Features.RiskApproveCycle.Query.GetAll;
using _4EPlatform.Application.Features.RiskApproveCycle.Query.GetAllApprovalCycleByRiskId;
using _4EPlatform.Application.Features.RiskApproveCycle.Query.GetAllRiskCustomApprovalCycle;
using _4EPlatform.Application.Features.RiskApproveCycle.Query.GetAllWithRequestStatus;
using _4EPlatform.Application.Features.RiskApproveCycle.Query.GetById;
using _4EPlatform.Application.Features.RiskApproveCycle.Query.GetTempData;

namespace _4EPlatform_RiskManagement_API.Controllers.v1
{
    public class RiskApproveCycleController : BaseController
    {
        private readonly IMediator _mediator;
        public ResponseDTO _responseDto;

        public RiskApproveCycleController(IMediator mediator)
        {
            _mediator = mediator;
            _responseDto = new ResponseDTO();
        }

        [HttpPost("PostRiskApproveCycle")]
        public async Task<ResponseDTO> PostRiskApproveCycle([FromForm] RiskApproveCyclePostDto command) => await _mediator.Send(new PostRiskApproveCycleCommand(command));

        [HttpPost("PostRiskCustomApprovalCycle")]
        public async Task<ResponseDTO> PostRiskCustomApprovalCycle([FromForm] PostRiskCustomApprovalCycleDto command) => await _mediator.Send(new PostRiskCustomApprovalCycleCommand(command));


        [HttpPut("PutRiskApproveCycle")]
        public async Task<ResponseDTO> PutRiskApproveCycle(Guid Id, [FromForm] RiskApproveCyclePutDto command) => await _mediator.Send(new PutRiskApproveCycleCommand(Id, command));

        [HttpPut("PutDynamicCycle")]
        public async Task<ResponseDTO> PutDynamicCycle(Guid requestInstanceId, Guid ingeratedId ,ServiceType serviceType, RequestStatus requestStatus) => await _mediator.Send(new PutDynamicCycleCommand(ingeratedId, requestInstanceId, serviceType, requestStatus));


        [HttpPut("UpdateLKRequestStatus")]
        public async Task<ResponseDTO> UpdateLKRequestStatus(Guid? Id, [FromForm] UpdateLKRequestStatusDto command) => await _mediator.Send(new UpdateLKRequestStatusCommand(Id, command));


        [HttpDelete("DeleteRiskApproveCycle")]
        public async Task<ResponseDTO> DeleteRiskApproveCycle([FromForm] DeleteRiskApproveCycleCommand command) => await _mediator.Send(command);

        [HttpGet("GetAllRiskApproveCycle")]
        public async Task<ResponseDTO> GetAllRiskApproveCycle([FromQuery] GetAllRiskApproveCycleQuery query) => await _mediator.Send(query);

        [HttpGet("GetAllRiskApproveCycleGetAllWithRequestStatus")]
        public async Task<ResponseDTO> GetAllRiskApproveCycleGetAllWithRequestStatus([FromQuery] GetAllRiskApproveCycleWithRequestStatusQuery query) => await _mediator.Send(query);

        [HttpGet("GetAllApprovalCycleByRiskId")]
        public async Task<ResponseDTO> GetAllApprovalCycleByRiskId([FromQuery] GetAllApprovalCycleByRiskIdQuery query) => await _mediator.Send(query);

        [HttpGet("GetAllRiskCustomApprovalCycle")]
        public async Task<ResponseDTO> GetAllRiskCustomApprovalCycle([FromQuery] GetAllRiskCustomApprovalCycleQuery query) => await _mediator.Send(query);

        [HttpGet("GetRiskApproveCycleById")]
        public async Task<ResponseDTO> GetRiskApproveCycleById([FromQuery] GetRiskApproveCycleByIdQuery query) => await _mediator.Send(query);

        [HttpGet("GetOldData")]
        public async Task<ResponseDTO> GetTempData([FromQuery] GetTempDataQuery query) => await _mediator.Send(query);


    }
}