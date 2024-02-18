using CRUD_Empleados_Backend.Interfaces;
using CRUD_Empleados_Backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IDapperContext>(s => new DapperContext(builder.Configuration));
builder.Services.AddScoped<IAreaTrabajo, AreaTrabajoService>();
builder.Services.AddScoped<IPais, PaisService>();
builder.Services.AddScoped<ITipoDocumento, TipoDocumentoService>();
builder.Services.AddScoped<IEmpleado, EmpleadoService>();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Se añade las políticas de CORS para que solo acepte las peticiones del origen del frontend
builder.Services.AddCors(options => options.AddPolicy("CorsPolicy",
    policy =>
    {
        policy
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin()
              .WithExposedHeaders("Content-Disposition");
    }
));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();