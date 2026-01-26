
using _4EPlatform.Application.Features.RiskManger.Command.Delete;
using _4EPlatform.Application.Features.RiskManger.Command.Post;
using _4EPlatform.Application.Features.RiskManger.Command.Put;

namespace _4EPlatform_RiskManagement_API.Controllers.v1.RiskManger
{
    public class RiskMangerController : BaseController
    {
        private readonly IMediator _mediator;

        public RiskMangerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("PostRiskManger")]
        public async Task<ResponseDTO> PostRiskManger([FromBody] List<PostMangersRiskDto> command)
        {
            return await _mediator.Send(new PostMangersRiskCommand(command));
        }


        [HttpPut("PutRiskManger")]
        public async Task<ResponseDTO> PutRiskManger(Guid Id, [FromBody]  List<PutriskMangerDto> command)
        {
            return await _mediator.Send(new PutRiskMangerCommand(Id, command));
        }

        [HttpDelete("DeleteRiskManger")]
        public async Task<ResponseDTO> DeleteRiskManger([FromForm] DeleteRiskMangerCommand DeleteRiskMangerCommand)
        {
            return await _mediator.Send(DeleteRiskMangerCommand);
        }


    }
}