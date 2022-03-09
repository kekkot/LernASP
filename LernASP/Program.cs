using LernASP.data.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using LernASP.data;
using LernASP.data.Repository;
using LernASP.data.Internal_models;

var builder = WebApplication.CreateBuilder(args);// Билдер настраивает всю конфигурацию приложения
builder.Services.AddTransient<IAllDetails, DetailRepository>();//Интерфейс IAllDetails реализуется в MockDetails
builder.Services.AddTransient<IdetailsCategory, CategoryRepository>();//Интерфейс IdetailsCategory реализуется в MockCategory
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCart.GetCart(sp));
builder.Services.AddMvc();
string connection = builder.Configuration.GetConnectionString("DefaultConnection"); //Получаем строку подключения из файла конфигурации
builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connection)); //Добавляем контекст в качестве сервиса в приложение
builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build(); //Создаем объект WebApplication

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) //Если мы в дебаге
{
    app.UseExceptionHandler("/Home/Error");//Показ ошибок
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); //Добавляет специальный заголовок ответа для повышения безопасности
}

app.UseDeveloperExceptionPage(); //Отобразить страницу с ошибками
app.UseStatusCodePages(); //Отобразить код страницу
//app.UseMvcWithDefaultRoute(); //Много всего, к примеру отслеживание URL адреса
app.UseStaticFiles(); //Использование статических файлов
app.UseSession();

app.UseRouting();//Пока хз что это, чисто из комментов на ютубе, чтоб работало
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

//app.MapGet("/", () => "Hello World!");//MapGet первым параметром принимет путь, по которому обратится приложение
//Вторым параметром принимает обработчик запроса по этому маршруту в виде функции

//Самопальное говно
/*var routeBuilder = new RouteBuilder(app);
routeBuilder.MapRoute("default", "Home/Index/{id?}");
routeBuilder.MapRoute(name: "categoryFilter", template: "Details/{action}/{category?}", defaults: new {Controller="Details", action="list"});
app.UseRouter(routeBuilder.Build());*/

app.Run(async (context) =>
{
    var response = context.Response; //Создам объект типа HttpContext
    response.Headers.ContentLanguage = "ru-RU"; //Устанавливает заголовок Content-length для вывода кириллицы
    response.Headers.ContentType = "text/plain; charset=utf-8"; //Устанавливаем заголовок ContentType для кодировки
});
using(var scope = app.Services.CreateScope())
{
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DbObjects.Initial(content);
}
app.Run(); //Запуск приложения
