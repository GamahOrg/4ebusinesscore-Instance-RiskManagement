using _4EPlatform.Application.Services;
using _4EPlatform.PermissionsGroupingChecker;
using _4EPlatform.PremessionRegister;
using _4EPlatform_RiskManagement_API.Extention;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddUnitOfWorkRepository();
builder.Services.AddDiServices();
builder.Services.AddGrpcReflection();
builder.Services.AddGrpc();
//builder.Services.AddGrpcReflection();

builder.WebHost.ConfigureKestrel(options =>
{
    options.Listen(IPAddress.Any, 7299, o => o.Protocols = HttpProtocols.Http2);

    // ADDED THIS LINE to fix the problem
    options.Listen(IPAddress.Any, 5039, o => o.Protocols = HttpProtocols.Http1);

});

builder.Services.AddDbContext<AppDBContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    options.EnableSensitiveDataLogging(true);
});

builder.Services.AddGrpcReflection();// Optional: Use for Postman / gRPC testing
builder.Services.AddLocalizationOptions();
Log.Logger = new LoggerConfiguration()
      .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri("http://elasticsearch:9200"))
      {
          AutoRegisterTemplate = true,
          AutoRegisterTemplateVersion = AutoRegisterTemplateVersion.ESv6
      }).CreateLogger();
builder.Host.UseSerilog();
builder.Services.AddControllers();

var logger = new LoggerConfiguration()
          .ReadFrom.Configuration(builder.Configuration)
          .Enrich.FromLogContext()
          .CreateLogger();
builder.Host.UseSerilog(logger);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddUserManagementGrpcClient(builder.Configuration["GrpcServiceSettings:UserManagmentUrl"]);
builder.Services.AddTicktingSystemGrpcClients(builder.Configuration["GrpcServiceSettings:TicketingSystemUrl"]);
builder.Services.AddTicketingSystemGrpcClients(builder.Configuration["GrpcServiceSettings:TicketingUrl"]);

builder.Services.AddCPAggregatorGrpcClients(builder.Configuration["GrpcServiceSettings:ControlPanelAggUrl"]);
builder.Services.AddHostedService<AddPermissionsMiddleware>();
builder.Services.AddScoped<PermissionsGroupingCheckerMiddleware, PermissionsGroupingCheckerMiddleware>();
#region Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "RiskManagement APIs Reference",
    });

    c.AddSecurityDefinition(
    "token",
    new OpenApiSecurityScheme
    {
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer",
        In = ParameterLocation.Header,
        Name = HeaderNames.Authorization
    }
        );
    c.AddSecurityRequirement(
    new OpenApiSecurityRequirement
    {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "token"
                            },
                        },
                        Array.Empty<string>()
                    }
    }
        );
});
#endregion
builder.Services.AddSwaggerGen();
builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IntegrationRequestService>(); // Fixed the syntax error by using the correct method overload
builder.Services.AddRateLimitings(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowCors",
        builder =>
        {
            builder
            .AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:3000")
            .SetIsOriginAllowed((host) => true)
            .AllowCredentials();
        });
});

builder.Services.AddVersioning();
builder.Services.AddGrpc();

builder.Services.AddAuthentication("Bearer")
      .AddJwtBearer("Bearer", options =>
      {
          // the name of your api resources   
          options.Audience = "UserManagementServer";
          /// identity server url                    
          options.Authority = builder.Configuration.GetValue<string>("IdentityUrl");
          options.RequireHttpsMetadata = false;
      });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ResourceOwnerPolicy", policy =>
    {
        policy.AddAuthenticationSchemes("Bearer");
        policy.RequireClaim("scope", "4EMicroServices"); // Require scope associated with Resource Owner Password token
    });

    options.AddPolicy("ClientCredentialsPolicy", policy =>
    {
        policy.AddAuthenticationSchemes("Bearer");
        policy.RequireClaim("scope", "CPAggregatorAPI"); // Require scope associated with Client Credentials token
    });
});



var app = builder.Build();
// Configure the HTTP request pipeline.
//if (app.Environment.IsDevelopment())
//{
app.UseSwagger();
app.UseSwaggerUI();
//}
#region Localization Middleware
var options = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(options.Value);
#endregion
using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<AppDBContext>();
    var serviceProvider = serviceScope.ServiceProvider;
    if (!serviceScope.ServiceProvider.GetService<AppDBContext>().AllMigrationsApplied())
    {
        serviceScope.ServiceProvider.GetService<AppDBContext>().Migrate();
    }
    ContextSeed.Seed(dbContext, serviceProvider,builder.Configuration);
}

//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")),
//    RequestPath = "/wwwroot"
//});
//app.MapGrpcReflectionService();
app.UseCors("AllowCors");
app.UseMiddleware<PermissionsGroupingCheckerMiddleware>();
app.UseStaticFiles();
//app.UseAuthorization();
app.UseMiddleware<GlobalExceptionHandler>();
app.MapControllers();
app.UseSerilogRequestLogging();
app.AddMapGrpcServicesApp();
app.UseRateLimiter();
app.MapGrpcReflectionService();
app.MapGrpcService<RiskUserService>().EnableGrpcWeb().RequireCors("AllowCors");
app.MapGrpcService<RiskDynamicService>();

app.Run();
