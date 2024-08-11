using BussinessLogic.IService;
using BussinessLogic.MailService;
using BussinessLogic.MappingProfile;
using BussinessLogic.Service;
using DataAccess.DAO;
using DataAccess.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//AutoMapper
builder.Services.AddAutoMapper(typeof(MappingProfile));
//DbContext
builder.Services.AddDbContext<DataAccessContext>();

builder.Services.AddSingleton<ICartService, CartService>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();
builder.Services.AddSingleton<AddressService>();
builder.Services.AddSingleton<OrderService>();
builder.Services.AddSingleton<SendMailService>();

builder.Services.AddSingleton<CartDAO>();
builder.Services.AddSingleton<UserDAO>();
builder.Services.AddSingleton<ProductDAO>();
builder.Services.AddSingleton<CategoryDAO>();
builder.Services.AddSingleton<AddressDAO>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder =>
{
    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
