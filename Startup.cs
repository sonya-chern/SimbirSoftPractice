using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication.Library.Context;
using Microsoft.EntityFrameworkCore;
using WebApplication.Library.Repositories;
using WebApplication.Library.Services;
using WebApplication.Library.Models;


namespace WebApplication.Library
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<GenreRepository>();
            services.AddTransient<PersonRepository>();
            services.AddTransient<AuthorRepository>();
            services.AddTransient<BookRepository>();
            services.AddTransient<LibraryCardRepository>();
            services.AddTransient<ILibraryService<Author>, AuthorService>();
            services.AddTransient<ILibraryService<Person>, PersonService>();
            services.AddTransient<ILibraryService<Genre>, GenreService>();
            services.AddTransient<ILibraryService<Book>, BookService>();
            services.AddTransient<ILibraryService<LibraryCard>, LibraryCardService>();

            var connectionString = Configuration.GetSection("ConnectionStrings:DefaultConnection").Value;
            var alterConnectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<LibraryContext>(options => options.UseSqlServer(connectionString));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "api/{controller}/{id?}");
            });

        }
    }
}
