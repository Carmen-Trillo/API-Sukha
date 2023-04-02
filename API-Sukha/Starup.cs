namespace API_Sukha
{
    public class Starup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            // Configura el soporte para la sesión de usuario
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(30);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Agrega soporte para la sesión de usuario
            app.UseSession();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

    }
}
