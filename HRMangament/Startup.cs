using HRMangament.Domain.AccessLayer.Employees;
using HRMangament.Domain.Attendances.AccessLayer;
using HRMangament.Domain.Attendances.Services;
using HRMangament.Domain.EmployeesShiftses.AccessLayer;
using HRMangament.Domain.EmployeesShiftses.Services;
using HRMangament.Domain.Organizationses.AccessLayer;
using HRMangament.Domain.Organizationses.Services;
using HRMangament.Domain.Services.Employees;
using HRMangament.Domain.Shiftses.AccessLayer;
using HRMangament.Domain.Shiftses.Services;
using HRMangament.Domain.Userses.AccessLayer;
using HRMangament.Domain.Userses.Services;
using HRMangament.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HRMangament
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<HrContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));


            services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<HrContext>();

            services.AddIdentityServer()
                .AddApiAuthorization<ApplicationUser, HrContext>();

            services.AddAuthentication()
                .AddIdentityServerJwt();
            services.AddControllersWithViews();
            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            services.AddRazorPages();
            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddDbContext<HrContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
           
            services.AddScoped<IGetEmployees,GetEmployees>();
            services.AddScoped<IDeleteEmployee, DeleteEmployee>();
            services.AddScoped<IAddEmployee, AddEmployee>();
            services.AddScoped<IGetEmployeeById, GetEmployeeById>();
            services.AddScoped<IUpdateEmployee, UpdateEmployee>();
            services.AddScoped<IEmployeeDataAdapter, EmployeeDataAdapter>();
            //-----------------------------------------------------------------------
            services.AddScoped<IAttendanceDataAdapter, AttendanceDataAdapter>();
            services.AddScoped<IAddAttendance, AddAttendance>();
            services.AddScoped<IDeleteAttendance, DeleteAttendance>();
            services.AddScoped<IGetAttendanceById, GetAttendanceById>();
            services.AddScoped<IGetAttendance, GetAttendances>();
            services.AddScoped<IUpdateAttendance, UpdateAttendance>();
            //-----------------------------------------------------------------------
            services.AddScoped<IOrganizationsDataAdapter, OrganizationsDataAdapter>();
            services.AddScoped<IAddOrganization, AddOrganization>();
            services.AddScoped<IDeleteOrganization, DeleteOrganization>();
            services.AddScoped<IGetOrganizationById, GetOrganizationById>();
            services.AddScoped<IGetOrganizations, GetOrganizations>();
            services.AddScoped<IUpdateOrganization, UpdateOrganization>();

            //-----------------------------------------------------------------------
            services.AddScoped<IEmployeesShiftsDataAdapter, EmployeesShiftsDataAdapter>();
            services.AddScoped<IAddEmployeesShifts, AddEmployeesShifts>();
            services.AddScoped<IDeleteEmployeesShifts, DeleteEmployeesShifts>();
            services.AddScoped<IGetEmployeesShifts, GetEmployeesShifts>();
            services.AddScoped<IGetEmployeesShiftById, GetEmployeesShiftsById>();
            services.AddScoped<IUpdateEmployeesShifts, UpdateEmployeesShifts>();
            //-----------------------------------------------------------------------
            services.AddScoped<IAddShift, AddShift>();
            services.AddScoped<IDeleteShift, DeleteShift>();
            services.AddScoped<IGetShiftById, GetShiftById>();
            services.AddScoped<IGetShifts, GetShifts>();
            services.AddScoped<IUpdateShift, UpdateShift>();
            services.AddScoped<IShiftsDataAdapter, ShiftsDataAdapter>();
            //-----------------------------------------------------------------------
            services.AddScoped<IUsersDataAdapter, UsersDataAdapter>();
            services.AddScoped<IDeleteUser, DeleteUser>();
            services.AddScoped<IGetUsers, GetUsers>();
            services.AddScoped<IUpdateUser, UpdateUser>();
            services.AddScoped<IAddUser, AddUser>();
            services.AddScoped<IGetUserById, GetUserById>();

            //-----------------------------------------------------------------------
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            if (!env.IsDevelopment())
            {
                app.UseSpaStaticFiles();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseIdentityServer();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapRazorPages();
            });

            app.UseSpa(spa =>
            {
                // To learn more about options for serving an Angular SPA from ASP.NET Core,
                // see https://go.microsoft.com/fwlink/?linkid=864501

                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                    //spa.UseProxyToSpaDevelopmentServer("http://localhost:5001");
                }
            });
        }
    }
}
