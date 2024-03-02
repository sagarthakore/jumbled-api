using Microsoft.AspNetCore.Http;

namespace Jumbled_API;

public class Startup(IConfiguration configuration)
{
    public IConfiguration Configuration { get; } = configuration;

    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<IJumbledService, JumbledService>();
        services.AddSingleton<IScrabbleService, ScrabbleService>();
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseEndpoints(endpoints => endpoints.MapGet("/", async context => await context.Response.WriteAsync("Jumbled API")));

        app.UseCors(x => x.AllowAnyOrigin());

        app.UseEndpoints(endpoints => endpoints.MapControllers());
    }
}
