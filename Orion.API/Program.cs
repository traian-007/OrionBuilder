using Microsoft.AspNetCore.Mvc.Infrastructure;
using Orion.API.Common.Errors;
using Orion.Application;
using Orion.Ifrastructure;

var builder = WebApplication.CreateBuilder(args);
{
    builder.Services
        .AddApplication()
        .AddInfrastructure(builder.Configuration);

    // builder.Services.AddControllers(options => options.Filters.Add<ErrorHandlingFilterAttribute>());
    builder.Services.AddControllers();

    builder.Services.AddSingleton<ProblemDetailsFactory, OrionProblemDetailsFactory>();
}

var app = builder.Build();
{
    /* app.UseMiddleware<ErrorHandlingMiddleware>();*/
    app.UseExceptionHandler("/error");

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}
