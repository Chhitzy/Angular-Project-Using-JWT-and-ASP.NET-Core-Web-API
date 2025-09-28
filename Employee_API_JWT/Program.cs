using Employee_API_JWT;
using Employee_API_JWT.Identity;
using Employee_API_JWT.ServiceContract;
using Employee_API_JWT.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
string cs = builder.Configuration.GetConnectionString("conStr");
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<ApplicationDbContext>(options =>options.UseSqlServer(cs,b =>b.MigrationsAssembly("Employee_API_JWT")));

//Add Services to the Container

builder.Services.AddTransient<IRoleStore<ApplicationRole>, ApplicationRoleStore>();
builder.Services.AddTransient<UserManager<ApplicationUser>, ApplicationUserManager>();
builder.Services.AddTransient<SignInManager<ApplicationUser>, ApplicationSignInManager>();
builder.Services.AddTransient<RoleManager<ApplicationRole>, ApplicationRoleManager>();
builder.Services.AddTransient<IUserStore<ApplicationUser>, ApplicationUserStore>();
builder.Services.AddTransient<IUserService,UserService>();
builder.Services.AddIdentity<ApplicationUser, ApplicationRole>()
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddUserStore<ApplicationUserStore>()
.AddUserManager<ApplicationUserManager>()
.AddRoleManager<ApplicationRoleManager>()
.AddSignInManager<ApplicationSignInManager>()
.AddRoleStore<ApplicationRoleStore>()
.AddDefaultTokenProviders();

builder.Services.AddScoped<ApplicationRoleStore>();
builder.Services.AddScoped<ApplicationUserStore>();

builder.Services.AddCors(options =>
    options.AddPolicy(name: "MyPolicy",
    builder=>
    {
        builder.WithOrigins("http://localhost:4200/").AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    }
    
    )
);
//builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>ConfigureSwaggerOptions>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyPolicy");

app.UseAuthorization();
IServiceScopeFactory serviceScopeFactory = app.Services.GetRequiredService<IServiceScopeFactory>();
//using (IServiceScope scope = serviceScopeFactory.CreateScope())
//{
//    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<ApplicationRole>>();
//    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

//    //Roles
//    if (!await roleManager.RoleExistsAsync("Admin")){
//        var role = new ApplicationRole();
//        role.Name = "Admin";
//        await roleManager.CreateAsync(role);
//    }

//    if (!await roleManager.RoleExistsAsync("Employee"))
//    {
//        var role = new ApplicationRole();
//        role.Name = "Employee";
//        await roleManager.CreateAsync(role);
//    }

//    //Create Users

//    if(await userManager.FindByNameAsync("Admin" ) == null)
//    {
//        var user = new ApplicationUser();
//        user.UserName = "Amit";
//        user.Email = "Admin@gmail.com";
//        var chKUser = await userManager.CreateAsync(user, "Admin@123");

//        if (chKUser.Succeeded)
//        {
//            await userManager.AddToRoleAsync(user, "Admin");
//        }
//    }
//}

app.MapControllers();

app.Run();
