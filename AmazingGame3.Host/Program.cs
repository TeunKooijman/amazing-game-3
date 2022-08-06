using AmazingGame3.Host.Communication;
using AmazingGame3.Infrastructure;

namespace AmazingGame3.Host
{
    public class Program
    {
        public static void Main(string[] args)
        {
            WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

            builder.Services.AddRazorPages();
            builder.Services.AddSignalR();
            builder.Services.AddSingleton<IColorParser, ColorParser>();
            builder.Services.AddSingleton<ISignalRConsoleAdapterFactory, SignalRConsoleAdapterFactory>();
            builder.Services.AddSingleton<GameHubState>();

            WebApplication app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.MapRazorPages();
            app.MapHub<GameHub>("/game");
            app.Run();
        }
    }
}