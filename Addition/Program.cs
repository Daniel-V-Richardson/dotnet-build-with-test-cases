using Sentry;

namespace Jenkins_build
{
    public class Program
    {
        public static void Main(string[] args)
        {

            using (SentrySdk.Init(options =>
            {
                options.Dsn = "https://9eb6b1fc6123e07a2875df4c80f82f05@o4505747039846400.ingest.sentry.io/4505747044368384";
                options.Debug = true;
               
                options.AutoSessionTracking = true;

                options.IsGlobalModeEnabled = false;
                
                options.CaptureFailedRequests = true;

                options.EnableTracing = true;

                options.TracesSampleRate = 0.1;
            }))
            {
                var builder = WebApplication.CreateBuilder(args);
                builder.WebHost.UseSentry();

                builder.Services.AddRazorPages();

                var app = builder.Build();
                app.UseSentryTracing(); 


                if (!app.Environment.IsDevelopment())
                {
                    app.UseExceptionHandler("/Error");
                }

                app.UseStaticFiles();

                app.UseRouting();

                app.UseAuthorization();

                app.MapRazorPages();


                app.Run();
            }
        }
    }
}