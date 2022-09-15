﻿var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddRazorPages()
    .AddRazorRuntimeCompilation();

// Add logic data access components
#if ACCOUNT_ON
builder.Services.AddTransient<QTHungryDogs.Logic.Contracts.IDataAccess<QTHungryDogs.Logic.Entities.Account.Role>, QTHungryDogs.Logic.Controllers.Account.RolesController>();
#endif

// Add session cookie
builder.Services.AddSession(options =>
{
    options.Cookie.IsEssential = true;
    options.Cookie.Name = $".{nameof(QTHungryDogs)}.Session";
    // Set a short timeout for easy testing.
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});

QTHungryDogs.AspMvc.Program.BeforeBuild(builder);

var app = builder.Build();

QTHungryDogs.AspMvc.Program.AfterBuild(app);

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
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
