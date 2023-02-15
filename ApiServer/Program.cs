WebApplication app = WebApplication.Create();

app.Urls.Add("http://localhost:3000");
app.Urls.Add("http://*:3000");

List<Superhero> heroes = new();
heroes.Add(new() { Name = "Shrek", Power = 99999999 });
heroes.Add(new() { Name = "Donkey", Power = 999999 });
heroes.Add(new() { Name = "Pickles", Power = 999999999 });

app.MapGet("/", Answer);
app.MapGet("/superhero/", () => { return heroes; });
app.MapGet("/superhero/{num}", (int num) => { if (num >= 0 && num < heroes.Count) return Results.Ok(heroes[num]); return Results.NotFound(); });


app.MapPost("/superhero/", (Superhero h) =>
{
    if (heroes.Find(x => x.Name == h.Name) != null)
    {
        return Results.BadRequest();
    }
    heroes.Add(h);
    return Results.Ok();
});
app.Run();


static string Answer()
{
    return "Shrek is love";
}