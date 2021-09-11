using System;
using ModuleServicePOS.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ModuleServicePOS
{
    public static class SeedMethod
    {
        // dbInitializer
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var serviceScope = serviceProvider.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();

                // auto migration
                context.Database.Migrate();

                // Seed the database.
                InitializeUserAndRoles(context);
            }
        }
        private static void InitializeUserAndRoles(ApplicationContext context)
        {
            // init user and roles  
        }
    }
}
