using Microsoft.OpenApi;
using mxaddress.Application;
using mxaddress.Infrastructure;
using mxaddress.Infrastructure.Extensions;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddInfrastructure();
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationAssemblyMarker).Assembly));

builder.Services.AddControllers();

builder.Services.AddSwaggerGen(
	c =>
	{
		c.SwaggerDoc("v1", new OpenApiInfo { Title = "MX Address API", Version = "v1" });

		c.AddSecurityDefinition(
			"Bearer", new OpenApiSecurityScheme
			{
				In = ParameterLocation.Header,
				Description = "Por favor ingresa el token JWT con 'Bearer {token}'",
				Name = "Authorization",
				Type = SecuritySchemeType.ApiKey
			}
		);
	}
);

WebApplication app = builder.Build();

await app.Services.InitializeDatabaseAsync();

app.MapControllers();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "v1"));

app.UseHttpsRedirection();

app.Run();