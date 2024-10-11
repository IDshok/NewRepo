namespace Ddtatest.Configuration
{
    public static class Cors
    {
        public static IServiceCollection AddApplicationCors(this IServiceCollection services)
        {
            services.AddCors(builder =>
            {
                builder.AddDefaultPolicy(pol =>
                {
                    pol.AllowAnyHeader();
                    pol.AllowAnyMethod();
                    pol.AllowAnyOrigin();
                });
            });
            return services;
        }

        public static void UseApplicationCors(this IApplicationBuilder app)
        {
            app.UseCors();
        }
    }
}
