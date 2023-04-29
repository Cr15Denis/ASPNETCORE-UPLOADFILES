using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.FileProviders;
using Microsoft.Net.Http.Headers;
using System.Globalization;
using System.IO.Pipelines;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
    //options.FormatterMappings.SetMediaTypeMappingForFormat("ContentType", MediaTypeHeaderValue.Parse("application/octet-stream"));
});
builder.Services.AddMvc();  
//builder.Services.AddResponseCompression(options =>
//{
//    IEnumerable<string> MimeTypes = new[]
// {
//         // General
//         "text/plain",
//         "text/html",
//         "text/css",
//         "font/woff2",
//         "application/javascript",
//         "image/x-icon",
//         "image/png",
//         "image/jpeg",
//         "image/jpg"
//     };

//    options.EnableForHttps = true;
//    options.MimeTypes = MimeTypes;
//    options.Providers.Add<GzipCompressionProvider>();
//    options.Providers.Add<BrotliCompressionProvider>();

//});
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

//app.UseStaticFiles()

app.UseStaticFiles(new StaticFileOptions()
 {
     FileProvider = new PhysicalFileProvider(Path.Combine(@"D:/", "PruebasImagenes")),
     RequestPath = new PathString("/UploadFile/Files"),

 });

//.UseStaticFiles(new StaticFileOptions
//{
//    DefaultContentType = "application/json",
//    ServeUnknownFileTypes = true,
//    OnPrepareResponse = context =>
//    {
//        // Cache static file for 1 year
//        if (!string.IsNullOrEmpty(context.Context.Request.Query["v"]))
//        {
//            context.Context.Response.Headers.Add("cache-control", new[] { "public,max-age=31536000" });
//            context.Context.Response.Headers.Add("Expires", new[] { DateTime.UtcNow.AddDays(1).ToString("R") }); // Format RFC1123
//        }
//    }
//});

//app.UseStaticFiles(new StaticFileOptions
//{
//    OnPrepareResponse = ctx =>
//    {
//        // Requires the following import:
//        // using Microsoft.AspNetCore.Http;
//        ctx.Context.Response.Headers.Append("Cache-Control", "public,max-age=600");
//    }
//});

//app.UseResponseCompression();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

//app.UseStaticFiles(); // For the wwwroot folder




//const string cacheMaxAge = "604800";
//app.UseStaticFiles(new StaticFileOptions
//{
//    FileProvider = new PhysicalFileProvider(@"D:\PruebasImagenes"),
//    RequestPath = "/img",
//    ServeUnknownFileTypes = true,
//    //OnPrepareResponse = ctx =>
//    //{
//    //    // using Microsoft.AspNetCore.Http;
//    //    ctx.Context.Response.Headers.Append("Cache-Control", $"public, max-age={cacheMaxAge}");
//    //}


//});
app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=DisplayImage}/{action=Index}");



app.Run();
