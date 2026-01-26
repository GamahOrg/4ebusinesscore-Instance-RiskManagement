


namespace _4EPlatform_RiskManagement_API.Controllers.v1.Category
{
    public class CategoryController : BaseController
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("PostCategory")]
        public async Task<ResponseDTO> PostCategory([FromForm] PostCategoryDto Dto)
        {
            return await _mediator.Send(new Postcategorycommand(Dto));
        }
        [HttpPut("PutCategory")]
        public async Task<ResponseDTO> PutCategory(Guid id, [FromForm] PutCategoryDto Dto)
        {
            return await _mediator.Send(new PutCategoryCommand( id, Dto));
        }
        [HttpDelete("DeleteCategory")]
        public async Task<ResponseDTO> DeleteCategory(Guid id)
        {
            return await _mediator.Send(new DeleteCategoryCommand { CategoryId = id});
        }
        [HttpGet("GetAllCategory")]
        public async Task<ResponseDTO> GetAllCategory([FromQuery] GetAllCategoryQuery query)
        {
            return await _mediator.Send(query);
        }
        [HttpGet("GetCategoryById")]
        public async Task<ResponseDTO> GetCategoryById(Guid id)
        {
            return await _mediator.Send(new GetCategoryByIdQuery { CategoryId = id});
        }
    }
}
