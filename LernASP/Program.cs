using LernASP.data.Interface;
using LernASP.data.mocks;

var builder = WebApplication.CreateBuilder(args);// ������ ����������� ��� ������������ ����������
builder.Services.AddTransient<IAllDetails, MockDetails>();//��������� IAllDetails ����������� � MockDetails
builder.Services.AddTransient<IdetailsCategory, MockCategory>();//��������� IdetailsCategory ����������� � MockCategory
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



app.MapGet("/", () => "Hello World!");//MapGet ������ ���������� �������� ����, �� �������� ��������� ����������
//������ ���������� ��������� ���������� ������� �� ����� �������� � ���� �������

app.Run(); //������ ����������