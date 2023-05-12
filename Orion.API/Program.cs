using Microsoft.AspNetCore.Mvc.Infrastructure;
using Orion.API.Errors;
using Orion.API.Filters;
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

 /*   app.Map("/error", (HttpContext httpContext) =>
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        return Results.Problem();
    });*/

    app.UseHttpsRedirection();

    app.MapControllers();

    app.Run();
}
