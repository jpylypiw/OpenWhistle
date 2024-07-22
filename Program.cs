using Microsoft.AspNetCore.Http.Features;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Get max file size env
var maxFileSizeEnv = Environment.GetEnvironmentVariable("OPENWHISTLE_FILEUPLOAD_MAXFILESIZE");
var maxFileSize = maxFileSizeEnv != null
                      ? int.Parse(maxFileSizeEnv) * 1024 * 1024
                      : 128 * 1024 * 1024;
// set form file upload length limit
builder.Services.Configure<FormOptions>(options => { options.MultipartBodyLengthLimit = maxFileSize; });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
