using Azure.Data.Tables;
using Azure;
using IBAS_kantine.Models;

var builder = WebApplication.CreateBuilder(args);

// Define connection settings
var tableName = "Kantinemenuen";
var connectionString = "DefaultEndpointsProtocol=https;EndpointSuffix=core.windows.net;AccountName=kantinemenu;AccountKey=k8e2i5D35mLn7NMlaWIxmzrtzrweux+M4mrP2QScHTeXkcV3/v69WkwOq6GvaIlOAD6UgDu8d0r2+ASt5tDs4Q==;BlobEndpoint=https://kantinemenu.blob.core.windows.net/;FileEndpoint=https://kantinemenu.file.core.windows.net/;QueueEndpoint=https://kantinemenu.queue.core.windows.net/;TableEndpoint=https://kantinemenu.table.core.windows.net/";

// Register TableClient as a singleton service
builder.Services.AddSingleton<TableClient>(new TableClient(connectionString, tableName));

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