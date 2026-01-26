using _4EPlatform.Application.Protos;
using _4EPlatform.Application.Services;
using ControlPanel.UserManagement.Protos;
using MicroBlocks.Application;
using RiskManagement.Application.Protos.Risk;
using System;
using TicketingSystem.Application.Proto.Item;

namespace _4EPlatform_RiskManagement_API.Extention
{
    public static class ServiceExtension
    {

        public static void AddMapGrpcServicesApp(this WebApplication app)
        {
            app.MapGrpcService<RiskService>().EnableGrpcWeb().RequireCors("AllowCors");
            app.MapGrpcService<HistoryService>().EnableGrpcWeb().RequireCors("AllowCors");
            //app.MapGrpcService<>();
        }

        public static void AddUnitOfWorkRepository(this IServiceCollection services)
        {
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
            services.AddScoped(typeof(IGRepository<>), typeof(GRepository<>));
        }


        public static void AddTicktingSystemGrpcClients(
  this IServiceCollection services,
  string TicketingSystemOperationServicesUrl)
        {
            services.AddGrpcServiceClient<Serviceintegrationservice.ServiceintegrationserviceClient>(TicketingSystemOperationServicesUrl);
            //services.AddGrpcServiceClient<UserProtoService.UserProtoServiceClient>(UserManagmentUrl);

        }
  
        public static void AddDiServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ApplicationLayer));
            //builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddMediatR(typeof(ApplicationLayer));
            services.AddScoped<GlobalExceptionHandler, GlobalExceptionHandler>();
            services.AddScoped(typeof(IResponseHelper), typeof(ResponseHelper));
            services.AddSingleton<ITokenService, TokenService>();
        }

        public static void AddRateLimitings(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRateLimiter(options =>
            {
                var rateLimitSection = configuration.GetSection("RateLimit");
                var permitLimit = rateLimitSection.GetValue<int>("PermitLimit");
                var queueLimit = rateLimitSection.GetValue<int>("QueueLimit");
                var windowSeconds = rateLimitSection.GetValue<int>("WindowSeconds");
                options.AddFixedWindowLimiter("FixedWindowPolicy", opt =>
                {
                    opt.Window = TimeSpan.FromSeconds(windowSeconds);
                    opt.PermitLimit = permitLimit;
                    opt.QueueLimit = queueLimit;
                    opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                }).RejectionStatusCode = 429;
            });
        }

        public static void AddVersioning(this IServiceCollection services)
        {
            services.AddApiVersioning().AddApiExplorer(options =>
            {
                // Add the versioned API explorer, which also adds IApiVersionDescriptionProvider service
                // note: the specified format code will format the version as "'v'major[.minor][-status]"
                options.GroupNameFormat = "'v'VVV";

                // note: this option is only necessary when versioning by url segment. the SubstitutionFormat
                // can also be used to control the format of the API version in route templates
            });
        }
        public static void AddLocalizationOptions(this IServiceCollection services)
        {
            #region Localization
            services.AddLocalization(opt =>
            {
                opt.ResourcesPath = "";
            });

            services.Configure<RequestLocalizationOptions>(options =>
            {
                List<CultureInfo> supportedCultures = new List<CultureInfo>{
            new CultureInfo("en-US"),
            new CultureInfo("de-DE"),
            new CultureInfo("fr-FR"),
            new CultureInfo("ar")};

                options.DefaultRequestCulture = new RequestCulture("ar");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });

            #endregion
        }
    }
}
