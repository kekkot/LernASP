using LernASP.data.Interface;
using LernASP.data.mocks;

var builder = WebApplication.CreateBuilder(args);// Билдер настраивает всю конфигурацию приложения
builder.Services.AddTransient<IAllDetails, MockDetails>();//Интерфейс IAllDetails реализуется в MockDetails
builder.Services.AddTransient<IdetailsCategory, MockCategory>();//Интерфейс IdetailsCategory реализуется в MockCategory
builder.Services.AddMvc();
var app = builder.Build(); //Создаем объект WebApplication

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) //Если мы в дебаге
{
    app.UseExceptionHandler("/Home/Error");//Показ ошибок
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDeveloperExceptionPage(); //Отобразить страницу с ошибками
app.UseStatusCodePages(); //Отобразить код страницу
//app.UseMvcWithDefaultRoute(); //Много всего, к примеру отслеживание URL адреса
app.UseStaticFiles(); //Использование статических файлов

app.UseRouting();//Пока хз что это, чисто из комментов на ютубе, чтоб работало
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

//app.MapGet("/", () => "Hello World!");//MapGet первым параметром принимет путь, по которому обратится приложение
//Вторым параметром принимает обработчик запроса по этому маршруту в виде функции

app.Run(); //Запуск приложения
