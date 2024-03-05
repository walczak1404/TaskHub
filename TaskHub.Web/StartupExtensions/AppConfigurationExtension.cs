namespace TaskHub.Web.StartupExtensions
{
    public static class AppConfigurationExtension
    {
        public static WebApplication ConfigureApp(this WebApplication app, WebApplicationBuilder builder)
        {
            if(builder.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            } else
            {
                app.UseExceptionHandler("/Error");
            }


            app.UseHsts();
            app.UseHttpsRedirection();

            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();

            return app;
        }
    }
}
