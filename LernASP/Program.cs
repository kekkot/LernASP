using LernASP.data.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using LernASP.data;
using LernASP.data.Repository;
using LernASP.data.Internal_models;

var builder = WebApplication.CreateBuilder(args);// ������ ����������� ��� ������������ ����������
builder.Services.AddTransient<IAllDetails, DetailRepository>();//��������� IAllDetails ����������� � MockDetails
builder.Services.AddTransient<IdetailsCategory, CategoryRepository>();//��������� IdetailsCategory ����������� � MockCategory
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp => ShopCart.GetCart(sp));
builder.Services.AddMvc();
string connection = builder.Configuration.GetConnectionString("DefaultConnection"); //�������� ������ ����������� �� ����� ������������
builder.Services.AddDbContext<AppDBContent>(options => options.UseSqlServer(connection)); //��������� �������� � �������� ������� � ����������
builder.Services.AddMemoryCache();
builder.Services.AddSession();

var app = builder.Build(); //������� ������ WebApplication

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) //���� �� � ������
{
    app.UseExceptionHandler("/Home/Error");//����� ������
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts(); //��������� ����������� ��������� ������ ��� ��������� ������������
}

app.UseDeveloperExceptionPage(); //���������� �������� � ��������
app.UseStatusCodePages(); //���������� ��� ��������
//app.UseMvcWithDefaultRoute(); //����� �����, � ������� ������������ URL ������
app.UseStaticFiles(); //������������� ����������� ������
app.UseSession();

app.UseRouting();//���� �� ��� ���, ����� �� ��������� �� �����, ���� ��������
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

//app.MapGet("/", () => "Hello World!");//MapGet ������ ���������� �������� ����, �� �������� ��������� ����������
//������ ���������� ��������� ���������� ������� �� ����� �������� � ���� �������

//����������� �����
/*var routeBuilder = new RouteBuilder(app);
routeBuilder.MapRoute("default", "Home/Index/{id?}");
routeBuilder.MapRoute(name: "categoryFilter", template: "Details/{action}/{category?}", defaults: new {Controller="Details", action="list"});
app.UseRouter(routeBuilder.Build());*/

app.Run(async (context) =>
{
    var response = context.Response; //������ ������ ���� HttpContext
    response.Headers.ContentLanguage = "ru-RU"; //������������� ��������� Content-length ��� ������ ���������
    response.Headers.ContentType = "text/plain; charset=utf-8"; //������������� ��������� ContentType ��� ���������
});
using(var scope = app.Services.CreateScope())
{
    AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
    DbObjects.Initial(content);
}
app.Run(); //������ ����������
