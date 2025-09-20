using Sre.K8s;

var builder = WebApplication.CreateBuilder(args).AddSreK8s(options => {});
var app = builder.Build().UseSreK8s();

app.MapGet("/hello", () => "World!");
app.MapGet("/fail", () => {throw new Exception("DB_FAIL: Something went wrong.");});

app.Run();