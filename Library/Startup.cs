namespace Library
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseStaticFiles();   // добавляем поддержку статических файлов

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("Hello World!!!!");
            });
        }
    }
}
