using Dtos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ICharacterDto, InMemoryCharacterDto>();
builder.Services.AddSingleton<ICache, InMemoryCache>();
builder.Services.AddSingleton<IAuthenticationFactory, AuthenticationFactory>();
//builder.Services.AddKeyedSingleton<ICache, BigCache>("big");
//builder.Services.AddKeyedSingleton<ICache, SmallCache>("small");
//builder.Services.AddKeyedSingleton<ICharacterDto, InMemoryCharacterDto>("char_in_memory");
//builder.Services.AddTransient<ICharacterDto, InMemoryCharacterDto>();
//builder.Services.AddScoped<ICharacterDto, InMemoryCharacterDto>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.Run();
