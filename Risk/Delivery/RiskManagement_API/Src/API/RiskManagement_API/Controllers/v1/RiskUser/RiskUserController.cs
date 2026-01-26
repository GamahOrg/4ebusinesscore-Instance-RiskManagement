
namespace _4EPlatform_RiskManagement_API.Controllers.v1.RiskUser
{
    public class RiskUserController : BaseController
    {
        private readonly IMediator _mediator;

        public RiskUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("PostRiskUser")]
        public async Task<ResponseDTO> PostRiskUser([FromForm] PostRiskuserDto command)
        {
            return await _mediator.Send(new PostRiskUserCommand(command));
        }


        [HttpPut("PutRiskUser")]
        public async Task<ResponseDTO> PutRiskUser(Guid Id, [FromForm]  PutriskuserDto command)
        {
            return await _mediator.Send(new PutRiskUserCommand(Id, command));
        }
        [HttpDelete("DeleteRiskUser")]
        public async Task<ResponseDTO> DeleteRiskUser([FromForm] DeleteRiskUserCommand DeleteRiskUserCommand)
        {
            return await _mediator.Send(DeleteRiskUserCommand);
        }


    }
}