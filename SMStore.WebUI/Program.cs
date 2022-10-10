using SMStore.Data;
using SMStore.Service.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DatabaseContext>(); // DbContext i ekliyoruz 

builder.Services.AddScoped(typeof(IRepository<>),typeof(Repository<>)); // kendi yazdığımız repository servisini burada uygulama ekliyoruz burada eklelemden projede kullanamya kalkarsak hata alırız!!!


// .Net Core ile birlikte 3 farklı depency Injection yöntemi varsayılan olarak kullanmamıza sunulmuştur
// Dependency Injection Yöntemleri : 
// 1-AddSingleTon : Bu yöntem kullanırsak oluşturmak istediğimiz nesneden 1 tane oluşturulur ve her istediğimizde bu nesne bize gönderilirü
// 2-Addtransient : Oluşturulması istenen nesneden her istek için yeni 1 tane oluşturulur
// 3- AddScoped : Oluşturulması istenen nesne için gelen isteğe bakılarak nesne daha önceden oluşturulmuşsa onu oluşturulmamışsa yeni bir tane oluşturup gönderir


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();


 app.MapControllerRoute(
           name: "Admin",
           pattern: "{area:exists}/{controller=Main}/{action=Index}/{id?}"
         );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
