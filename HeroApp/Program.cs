var builder = WebApplication.CreateBuilder(args);
//Cors
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          /*
                          policy.WithOrigins("https://localhost")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();]*/
                          policy.SetIsOriginAllowed(origin=> new Uri(origin).Host == "localhost")
                                                  .AllowAnyHeader()
                                                  .AllowAnyMethod();
                      });
});


// Add services to the container.

builder.Services.AddControllers();
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

//Cors
app.UseCors(MyAllowSpecificOrigins);


app.UseHttpsRedirection();

//app.UseAuthorization();

app.MapControllers();

app.Run();
