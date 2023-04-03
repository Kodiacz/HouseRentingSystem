var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<HouseRentingDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddControllersWithViews(opt =>
{
    opt.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
});
builder.Services.AddDefaultIdentity<ApplicationUser>(opt =>
{
    opt.SignIn.RequireConfirmedAccount = false;
    opt.Password.RequiredLength = 0;
    opt.Password.RequireDigit = false;
    opt.Password.RequireLowercase = false;
    opt.Password.RequireUppercase = false;
    opt.Password.RequireNonAlphanumeric = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<HouseRentingDbContext>();

builder.Services.ConfigureApplicationCookie(opt =>
{
    opt.LoginPath = "/Identity/Account/Login";
});

builder.Services.AddAutoMapper(
    typeof(IHouseService).Assembly,
    typeof(HomeController).Assembly);

builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IHouseService, HouseService>();
builder.Services.AddTransient<IAgentService, AgentService>();
builder.Services.AddTransient<IStatisticsService, StatisticsService>();
builder.Services.AddTransient<IRentService, RentService>();

var app = builder.Build();

app.SeedAdmin();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error/500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "Areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "House Details",
        pattern: "/House/Details/{id}/{information}",
        defaults: new { Controller = "House", Action = "Details" });


    endpoints.MapDefaultControllerRoute();
    endpoints.MapRazorPages();
});

app.MapDefaultControllerRoute();
app.MapRazorPages();

app.Run();
