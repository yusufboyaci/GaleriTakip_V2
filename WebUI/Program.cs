using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
var app = builder.Build();


app.UseHttpsRedirection();
//wwroot
app.UseStaticFiles();

//node_modules
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
    RequestPath = new PathString("/vendor")
});
app.UseRouting();

app.UseAuthentication();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Login}/{action=Login}/{id?}"
    );
app.Run();
