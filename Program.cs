using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using WebApplication.Library.Context;

namespace WebApplication.Library
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();

            var builder = new ConfigurationBuilder();
            // ��������� ���� � �������� ��������
            builder.SetBasePath(Directory.GetCurrentDirectory());
            // �������� ������������ �� ����� appsettings.json
            builder.AddJsonFile("appsettings.json");
            // ������� ������������
            var config = builder.Build();
            // �������� ������ �����������
            string connectionString = config.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>();
            var options = optionsBuilder
                .UseSqlServer(connectionString)
                .Options;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

    }
}
