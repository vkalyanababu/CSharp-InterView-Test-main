using SportScore.API.Data;
using SportScore.API.Repositories;
using SportsScorePredictor;

namespace SportScore.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSingleton<InMemoryHistoricalScoresData>();
            builder.Services.AddScoped<IHistoricalScoresRepository, HistoricalScoresRepository>();
            //Add whichever sports is needed
            //this is just one example of replacing the sports strategy
            //we can also use factory method in client class to dynamically decide which sport strategy to use
            builder.Services.AddScoped<AbstractGameStrategy, VolleyballStrategy>();
            //builder.Services.AddScoped<AbstractGameStrategy, SquashStrategy>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Sports Score API V1");
                    c.RoutePrefix = string.Empty; // Serve the Swagger UI at the root URL
                });
            }

            // app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}