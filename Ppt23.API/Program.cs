using Ppt23.Shared;
using System.Collections.Generic;
using System.Security.Cryptography;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
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

app.UseHttpsRedirection();
List<VybaveniVm> seznamVybaveni = new List<VybaveniVm>();


app.MapGet("/vybaveni", () =>
    {
        VybaveniVm vybaveni = new VybaveniVm();
        seznamVybaveni.Add(vybaveni);

        return seznamVybaveni;
    }).WithOpenApi();

app.MapPost("/vybaveni", (VybaveniVm prichoziModel) =>
{
    Guid newId = Guid.NewGuid();
    prichoziModel.Id = newId;
    seznamVybaveni.Insert(0, prichoziModel);
});

app.MapDelete("/vybaveni/{Id}", (Guid Id) =>
{
    var item = seznamVybaveni.SingleOrDefault(x => x.Id == Id);
    if (item == null)
        return Results.NotFound("Tato položka nebyla nalezena!!");
    seznamVybaveni.Remove(item);
    return Results.Ok();
}
);

app.MapPut("/vybaveni/{Id}", (VybaveniVm? upravenyModel, Guid Id) =>
{
    var vybranyModel = seznamVybaveni.SingleOrDefault(x => x.Id == Id);
    if (vybranyModel == null)
    {
        return Results.NotFound("This item cannot be found!");
    }
    else
    {
        upravenyModel.Id = Id;
        int index = seznamVybaveni.IndexOf(vybranyModel);
        seznamVybaveni.Remove(vybranyModel);
        seznamVybaveni.Insert(index, upravenyModel);
        return Results.Ok();
    }
    //upravenyModel = seznamVybaveni.SingleOrDefault(x => x.Id == Id);
    //int index = seznamVybaveni.IndexOf(upravenyModel);
    //seznamVybaveni.Remove(upravenyModel);
    //seznamVybaveni.Insert(index, upravenyModel);
});

app.MapGet("/vybaveni/{Id}", (Guid Id) =>
{
    VybaveniVm? hledany = seznamVybaveni.SingleOrDefault(x => x.Id == Id);
    return hledany;
});


app.Run();