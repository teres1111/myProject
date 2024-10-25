
using ProjectAccounting.Extention;

namespace ProjectAccounting
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configextension = new ConfigExtention(configuration: builder.Configuration);
            configextension.ConfigureServices(builder.Services);


            var app = builder.Build();


            configextension.Configure(app, app.Environment);
            app.MapControllers();


            app.Run();
        }
    }
}