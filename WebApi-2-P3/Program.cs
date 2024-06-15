using DTOs;
using LogicaAplicacion.CasosUso;
using LogicaAplicacion.InterfacesCU;
using LogicaDatos.Repositorios;
using LogicaNegocio.InterfacesRepositorios;

namespace WebApi_2_P3
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllers();

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddScoped<ICUBuscarPorId<DTOMovimientoTipo>, CUBuscarMovimientoTipo>();
            builder.Services.AddScoped<ICUAlta<DTOMovimientoTipo>, CUAltaMovimientoTipo>();
            builder.Services.AddScoped<ICUListado<DTOMovimientoTipo>, CUListadoMovimientoTipo>();
            builder.Services.AddScoped<ICUBaja, CUBajaMovimientoTipo>();
            builder.Services.AddScoped<ICUModificar<DTOMovimientoTipo>, CUModificarMovimienoTipo>();

            builder.Services.AddScoped<IRepositorioArticulo, RepositorioArticulo>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioMovimientoTipo, RepositorioMovimientoTipo>();
            builder.Services.AddScoped<IRepositorioMovimientoStock, RepositorioMovimientoStock>();
            builder.Services.AddScoped<IRepositorioParametro, RepositorioParametro>();

            builder.Services.AddDbContext<DBContext>();

            
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
