WebApplication app = WebApplication.Create();

app.Urls.Add("http://localhost:3000");
app.Urls.Add("http://*:3000");

Superhero hero = new Superhero();
hero.Name = "Shrek";
hero.Power = 900;
hero.Sexy = true;

app.MapGet("/", Answer);
app.MapGet("/superhero/", () => { return hero; });


app.Run();


static string Answer()
{
    return "Shrek is love";
}