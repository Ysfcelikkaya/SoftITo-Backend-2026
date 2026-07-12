var builder = WebApplication.CreateBuilder(args);

// 1. MVC Servislerini Ekle
builder.Services.AddControllersWithViews();

// =================== YENİ EKLENENLER ===================
// 2. Kurye (HttpClient) tanımlaması (API'lere gidecek araç)
builder.Services.AddHttpClient();

// 3. Hafıza (Session) Tanımlaması (Token'ı tarayıcıda tutmak için)
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(2); // 2 saat boş kalırsa çıkış yap
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

// 4. Çerez (Cookie) Güvenliği (Kilitli sayfalara izinsiz girmeyi engeller)
builder.Services.AddAuthentication("CookieAuth").AddCookie("CookieAuth", options =>
{
    options.LoginPath = "/Auth/Login"; // Giriş yapmayanları bu sayfaya atar
});
// ========================================================

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// =================== YENİ EKLENENLER ===================
app.UseSession(); // Hafızayı aç
app.UseAuthentication(); // Önce kimlik sor
// ========================================================

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    //pattern: "{controller=Home}/{action=Index}/{id?}");
pattern: "{controller=Landing}/{action=Index}/{id?}");

app.Run();