using Mapster;
using Microsoft.EntityFrameworkCore;
using Ppt23.API.Data;
using Ppt23.Shared;

var builder = WebApplication.CreateBuilder(args);
var corsAllowedOrigin = builder.Configuration.GetSection("CorsAllowedOrigins").Get<string[]>();
string dbPath = builder.Configuration.GetValue<string>("sqliteDbPath");

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<PptDbContext>(opt => opt.UseSqlite($"FileName={dbPath}"));

builder.Services.AddCors(corsOptions => corsOptions.AddDefaultPolicy(policy =>
    policy.WithOrigins(corsAllowedOrigin)
    .WithMethods("GET", "POST", "DELETE", "PUT")
    .AllowAnyHeader()
));

var app = builder.Build();
app.UseCors();

app.Services.CreateScope().ServiceProvider
  .GetRequiredService<PptDbContext>()
  .Database.Migrate();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Get seznamu
app.MapGet("/vybaveni", (PptDbContext _db) =>
{

    Console.WriteLine($"Pocet vybaveni v db: {_db.Vybavenis.Count()}");
    return _db.Vybavenis.ToList();
});

// Novy item v seznamu
app.MapPost("/vybaveni", (VybaveniVm prichoziModel, PptDbContext _db) =>
{

    prichoziModel.Id = Guid.Empty;
    var en = prichoziModel.Adapt<Vybaveni>();

    _db.Vybavenis.Add(en);
    _db.SaveChanges();

    return prichoziModel.Id;
});

// Smazani zaznamu v seznamu
app.MapDelete("/vybaveni/{Id}", (Guid Id, PptDbContext _db) =>
{
    var item = _db.Vybavenis.SingleOrDefault(x => x.Id == Id);

    if (item == null)
        return Results.NotFound("Tato položka nebyla nalezena!!");

    _db.Vybavenis.Remove(item);
    _db.SaveChanges();

    return Results.Ok();
}
);

// Uprava itemu v seznamu
app.MapPut("/vybaveni/{Id}", (Vybaveni en, Guid Id, PptDbContext _db) =>
{
    var vybranyModel = _db.Vybavenis.SingleOrDefault(x => x.Id == Id);
    if (vybranyModel == null)
    {
        return Results.NotFound("This item cannot be found!");
    }

    else
    {
        en.Id = Id;

        _db.Vybavenis.Entry(vybranyModel).CurrentValues.SetValues(en);
        _db.SaveChanges();
        return Results.Ok();
    }
});

app.MapGet("/vybaveni/{x}", (string x, PptDbContext _db) =>
{
    List<RevizeViewModel> seznam = new List<RevizeViewModel>();

    for (int i = 0; i < _db.Vybavenis.Count(); i++)
    {

        var vybavenisAsList = _db.Vybavenis.ToList();

        if (vybavenisAsList.ElementAt(i).NAME.Contains(x))
            {

                RevizeViewModel nalezen = new RevizeViewModel();

                nalezen.Id = vybavenisAsList.ElementAt(i).Id;
                nalezen.Name = vybavenisAsList.ElementAt(i).NAME;
                
                var en = nalezen.Adapt<Revize>();
                seznam.Add(nalezen);
                _db.Revizes.Add(en);
            }
        }
    _db.SaveChanges();
    return seznam;
});


app.Run();