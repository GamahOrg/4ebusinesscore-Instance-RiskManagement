

namespace _4EPlatform_RiskManagement_API.Controllers.v1.Category
{
    public class SubCategoryController : BaseController
    {
        private readonly IMediator _mediator;

        public SubCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("PostSubCategory")]
        public async Task<ResponseDTO> PostSubCategory(PostSubCategoryCommand dtos)
        {
            return await _mediator.Send(dtos);
        }
        [HttpPut("PutSubCategory")]
        public async Task<ResponseDTO> PutSubCategory( Guid Id, [FromForm] PutSubcategoryDto command)
        {
            return await _mediator.Send(new PutSubCategoryCommand(Id, command));
        }
        [HttpDelete("DeleteSubCategory")]
        public async Task<ResponseDTO> DeleteSubCategory(Guid Id)
        {
            return await _mediator.Send(new DeleteSubCategoryCommand { SubCategoryId = Id});
        }
        [HttpGet("GetAllSubCategorybyCategoryid")]
        public async Task<ResponseDTO> GetAllSubCategorybyCategoryid([FromQuery] GetAllSubCategorybyCategoryidQuery dto)
        {
            return await _mediator.Send(dto);
        }
        [HttpGet("GetSubCategoryById")]
        public async Task<ResponseDTO> GetSubCategoryById(Guid id)
        {
            return await _mediator.Send(new GetSubCategoryByIdQuery { SubCategoryId = id});
        }
    }
}