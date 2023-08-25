using InventoryAppEFCore.DataLayer;
using InventoryAppEFCore.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<InventoryAppEfCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Session6")));

builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);
builder.Services.AddScoped<DBInitializer>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var context = services.GetRequiredService<DBInitializer>();

        await context.SeedAsync();

        //Computed Columns
        context.ComputedColumnSql();

        //UDF - Scalar
        context.CreateScalarUdfForProductsCountByStatus();

        //UDF - Table-Valued
        context.CreateTableValuedUdf();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
