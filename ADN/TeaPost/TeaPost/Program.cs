var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Login 
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "Country",
    pattern: "{area:exists}/{controller=LOC_Country}/{action=LOC_CountryList}/{id?}");

app.MapControllerRoute(
    name: "State",
    pattern: "{area:exists}/{controller=LOC_State}/{action=LOC_StateList}/{id?}");

app.MapControllerRoute(
    name: "City",
    pattern: "{area:exists}/{controller=LOC_City}/{action=LOC_CityList}/{id?}");

app.MapControllerRoute(
    name: "Shop",
    pattern: "{area:exists}/{controller=Shop}/{action=ShopList}/{id?}");

app.MapControllerRoute(
    name: "MST_User",
    pattern: "{area:exists}/{controller=SEC_User}/{action=UserList}/{id?}");

app.MapControllerRoute(
    name: "Tea",
    pattern: "{area:exists}/{controller=Tea}/{action=TeaList}/{id?}");

app.MapControllerRoute(
    name: "Snack",
    pattern: "{area:exists}/{controller=Snack}/{action=SnackList}/{id?}");

app.MapControllerRoute(
    name: "Franchise",
    pattern: "{area:exists}/{controller=Franchise}/{action=FranchiseList}/{id?}");

app.MapControllerRoute(
    name: "Order",
    pattern: "{area:exists}/{controller=Order}/{action=OrderList}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
