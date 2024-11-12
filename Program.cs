using Azure.Data.Tables;
using Azure.Identity;

var builder = WebApplication.CreateBuilder(args);

// Define connection settings
var tableName = "Kantinemenuen";
var storageAccountUrl = new Uri("https://kantinemenu.table.core.windows.net");
// Register TableClient as a singleton service
builder.Services.AddSingleton<TableClient>(new TableClient(storageAccountUrl, tableName, new DefaultAzureCredential()));

// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();