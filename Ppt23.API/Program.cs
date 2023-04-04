using Ppt23.Shared;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(corsOptions => corsOptions.AddDefaultPolicy(policy =>
    policy.WithOrigins("https://localhost:1111")
    .WithMethods("GET", "POST", "DELETE", "PUT")
    .AllowAnyHeader()
));

var app = builder.Build();
app.UseCors();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
List<VybaveniVm> seznamVybaveni = new List<VybaveniVm>();
seznamVybaveni.Clear();

for(int i = 0; i < 5; i++)
{
    
    seznamVybaveni.Add(new VybaveniVm());
}


app.MapGet("/vybaveni", () => seznamVybaveni);

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
    if (vybranyModel == null || upravenyModel == null)
    {
        return Results.NotFound("This item cannot be found!");
    }

    else
    {
        upravenyModel.Id = Id;
        int index = seznamVybaveni.IndexOf(vybranyModel);

        seznamVybaveni.Remove(vybranyModel);
        seznamVybaveni.Insert(index, upravenyModel);

        return Results.Ok(upravenyModel);
    }
});

//app.MapGet("/vybaveni/{Id}", (Guid Id) =>
//{
//    VybaveniVm? hledany = seznamVybaveni.SingleOrDefault(x => x.Id == Id);
//    return hledany;
//});

app.MapGet("/vybaveni/{x}", (string x) =>
{
    List<RevizeViewModel> seznam = new List<RevizeViewModel>();
    
    for (int i = 0; i < seznamVybaveni.Count(); i++)
    {
        if (seznamVybaveni[i].NAME.Contains(x))
        {
            RevizeViewModel nalezen = new RevizeViewModel();
            nalezen.Id = seznamVybaveni[i].Id;
            nalezen.Name = seznamVybaveni[i].NAME;
            seznam.Add(nalezen);
        }
    }
    return seznam;
});


app.Run();