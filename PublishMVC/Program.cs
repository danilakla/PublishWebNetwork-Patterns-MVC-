using Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Pattern.AbstractFactory.Interface;
using Pattern.AbstractFactory.Factory;
using Pattern.Builder;
using PublishMVC.Middleware;
using Pattern.Adapter;
using Pattern.Decorator;
using Pattern.Stratage.Interface;
using Pattern.Stratage;
using Pattern.Stratage.Class;
using Pattern.State;
using Pattern.Memento;

var order = new Order();

Console.WriteLine($"State: {order.CurrentState}");

order.TakeAction(Order.Action.Start);
Console.WriteLine($"State: {order.CurrentState}");

order.TakeAction(Order.Action.Start);
Console.WriteLine($"State: {order.CurrentState}");

order.TakeAction(Order.Action.Accelerate);
Console.WriteLine($"State: {order.CurrentState}");

order.TakeAction(Order.Action.Stop);
Console.WriteLine($"State: {order.CurrentState}");


Console.WriteLine("_---------------------");
var empl = new Employee { Age = 10, Name = "Danila", Phone = "+33233232" };
var emplMan = new EmployeeManager();
emplMan.AddMemento(empl.Create());
Console.WriteLine($"{empl.Name} {empl.Age}");
empl.Name = "some name";
emplMan.AddMemento(empl.Create());
Console.WriteLine($"{empl.Name} {empl.Age}");
empl.Undo(emplMan.GetMemento());
empl.Undo(emplMan.GetMemento());

Console.WriteLine($"{empl.Name} {empl.Age}");












var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PublishDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConntectionString")
    ));

AdapterBook book=new AdapterBook();

builder.Services.AddSingleton<IPublishCatalogAbstractFactory, PublishCatalogAbstractFactory>();




builder.Services.AddScoped<ISave,DataTxt >();

builder.Services.AddSingleton<IDataSave, DataSave>();
builder.Services.AddSingleton<ICake, VanillaCake>();


builder.Services.AddSingleton<ICakeMessageDecorator, CakeMessageDecorator>();

builder.Services.AddSingleton<IUser>(new User.UserBuilder()
	.WithName("John")
	.WithAddress("123 Street")
	.Build());

builder.Services.AddControllersWithViews();
builder.Services.AddAuthentication(
    CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(
    options =>
    {
        options.LoginPath = "/auth/auth/registration";
        options.ExpireTimeSpan= TimeSpan.FromMinutes(30);
    }
    );
   
var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
app.UseRequestLoger();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Reader}/{controller=Home}/{action=Index}/{id?}");

app.Run();
