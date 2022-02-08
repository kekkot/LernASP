using LernASP.data.Interface;
using LernASP.data.mocks;

var builder = WebApplication.CreateBuilder(args);// ������ ����������� ��� ������������ ����������
builder.Services.AddTransient<IAllDetails, MockDetails>();//��������� IAllDetails ����������� � MockDetails
builder.Services.AddTransient<IdetailsCategory, MockCategory>();//��������� IdetailsCategory ����������� � MockCategory
builder.Services.AddMvc();
var app = builder.Build(); //������� ������ WebApplication

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment()) //���� �� � ������
{
    app.UseExceptionHandler("/Home/Error");//����� ������
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseDeveloperExceptionPage(); //���������� �������� � ��������
app.UseStatusCodePages(); //���������� ��� ��������
//app.UseMvcWithDefaultRoute(); //����� �����, � ������� ������������ URL ������
app.UseStaticFiles(); //������������� ����������� ������

app.UseRouting();//���� �� ��� ���, ����� �� ��������� �� �����, ���� ��������
app.UseEndpoints(endpoints =>
{
    endpoints.MapDefaultControllerRoute();
});

//app.MapGet("/", () => "Hello World!");//MapGet ������ ���������� �������� ����, �� �������� ��������� ����������
//������ ���������� ��������� ���������� ������� �� ����� �������� � ���� �������

app.Run(); //������ ����������
