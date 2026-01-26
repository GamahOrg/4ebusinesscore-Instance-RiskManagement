
namespace _4EPlatform_RiskManagement_API.MiddleWares
{
    public class GlobalExceptionHandler : IMiddleware
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        private readonly ResponseDTO _responseDto;
        private readonly IHostEnvironment _host;
        private readonly IStringLocalizer<SharedResource> _sharedLocalizer;

        public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger,
                IHostEnvironment host, IStringLocalizer<SharedResource> sharedLocalizer)
        {
            _logger = logger;
            _responseDto = new ResponseDTO();
            _host = host;
            _sharedLocalizer = sharedLocalizer;
        }

        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            try
            {
                await next.Invoke(context);
            }
            catch (Exception ex)
            {

                _logger.LogError($"Error occurred while processing the request Message:{ex.Message}, StackTrace:{ex.StackTrace}");
                _responseDto.StatusEnum = StatusEnum.Exception;
                _responseDto.Message = _host.IsDevelopment() ? $"{ex?.InnerException?.Message}"
                    : _sharedLocalizer["AnErrorOccurredPleaseContactSystemAdministrator"];
                var serializedResponse = JsonSerializer.Serialize(_responseDto);
                await context.Response.WriteAsync(serializedResponse);

            }
        }
    }
}
