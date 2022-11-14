using System.Reflection;
using System.Text.Json.Serialization;
using Api.Services.Appointment;
using Api.Services.Article;
using Api.Services.Comment;
using Api.Services.Employee;
using Api.Services.EmployeePosition;
using Api.Services.User;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;

namespace Api.Host;

public class Startup
{
    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", isEnabled: true);

        DefaultFilesOptions options = new DefaultFilesOptions();
        options.DefaultFileNames.Clear();
        options.DefaultFileNames.Add("index.html");

        app.UseDefaultFiles(options);
        app.UseStaticFiles();

        app.UseHttpsRedirection();
        app.UseRouting();
        app.UseAuthorization();

        app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(_ => true)
            .AllowCredentials());

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }
    
    // This method gets called by the runtime. Use this method to add services to the container.
    public void ConfigureServices(IServiceCollection services)
    {
        services.Configure<ForwardedHeadersOptions>(
            options =>
            {
                options.ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto;

                options.KnownNetworks.Clear();
                options.KnownProxies.Clear();
            }
        );

        AddServices(services);
        AddControllersOfOtherAssemblies(services);

        services
            .AddControllers()
            .AddJsonOptions(
                x =>
                {
                    x.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                }
            );
    }

    private void AddServices(IServiceCollection services)
    {
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IAppointmentService, AppointmentService>();
        services.AddScoped<IArticleService, ArticleService>();
        services.AddScoped<IEmployeeService, EmployeeService>();
        services.AddScoped<IEmployeePositionService, EmployeePositionService>();
        services.AddScoped<ICommentService, CommentService>();
    }

    private void AddControllersOfOtherAssemblies(IServiceCollection services)
    {
        IList<ApplicationPart> appParts = services.AddControllers().PartManager.ApplicationParts;
        
        foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            try
            {
                bool containsControllers = assembly.GetExportedTypes()
                    .Any(x => !x.IsGenericTypeDefinition && !x.IsAbstract &&
                              typeof(ControllerBase).IsAssignableFrom(x));

                if (containsControllers)
                {
                    appParts.Add(new AssemblyPart(assembly));
                }
            }
            catch
            {
                // ignored
            }
        }
    }
}