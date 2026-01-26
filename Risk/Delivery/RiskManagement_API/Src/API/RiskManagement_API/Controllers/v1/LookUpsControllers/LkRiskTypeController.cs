using _4EPlatform.Application.Features.LookUps.LK_RiskType.Command.Post;
using _4EPlatform.Application.Features.LookUps.LK_RiskType.Query;
using _4EPlatform.Application.Features.LookUps.LKRiskType.Command.Delete;
using _4EPlatform.Application.Features.LookUps.LKRiskType.Command.Post;
using _4EPlatform.Application.Features.LookUps.LKRiskType.Command.Put;

namespace _4EPlatform_RiskManagement_API.Controllers.v1.LookUpsControllers
{
    public class LkRiskTypeController : BaseController
    {
        private readonly IMediator _mediator;
        public LkRiskTypeController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllLkRiskQuery")]
        public async Task<ResponseDTO> GetAllLkRiskQuery()
        {
            return await _mediator.Send(new GetAllLkRiskTypeQuery());
        }

        [HttpPost("PostLK_RiskType")]
        public async Task<ResponseDTO> PostLK_RiskType([FromForm]  PostRisktypeDto dto)
        {
            return await _mediator.Send(new PostLkRiskCommand(dto));
        }
        [HttpPut("PutLK_RiskType")]
        public async Task<ResponseDTO> PutLK_RiskType(int Id ,[FromForm] PutLk_RisktypeDto Dto)
        {
            return await _mediator.Send(new PutLK_RiskTypeCommand(Dto,Id));
        }
        [HttpDelete("DeleteLK_RiskType")]
        public async Task<ResponseDTO> DeleteLK_RiskType(int Id)
        {
            return await _mediator.Send(new DeleteLK_RiskTypeCommand(Id));
        }
    }
}