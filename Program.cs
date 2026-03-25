var builder = WebApplication.CreateBuilder(args);

// ✅ Dynamic Port (Render)
var port = Environment.GetEnvironmentVariable("PORT") ?? "5000";
builder.WebHost.UseUrls($"http://0.0.0.0:{port}");

// ✅ Services
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy => policy.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ✅ Middleware
app.UseCors("AllowAll");

// Swagger (keep always enabled for demo)
app.UseSwagger();
app.UseSwaggerUI();

// ❌ Remove this for Render
// app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
