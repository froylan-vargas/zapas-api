using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Moq;
using Zapas.Data;
using zapas.Tests.Helpers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Zapas.Data.Models;
using Microsoft.AspNetCore.Identity;
using Zapas.Controllers;

namespace zapas.Tests.Controllers
{
	public class SeedControllerTest
	{
		/// <summary>
		/// Test the CreateDefaultUsers() method
		/// </summary>
		[Fact]
		public async Task CreateDefaultUsers()
		{
			var options = new
				DbContextOptionsBuilder<ApplicationDbContext>()
					.UseInMemoryDatabase(databaseName: "zapas")
					.Options;
			var mockEnv = Mock.Of<IWebHostEnvironment>();
            var mockConfiguration = new Mock<IConfiguration>();
            mockConfiguration.SetupGet(x => x[It.Is<string>(s => s ==
				"DefaultPasswords:RegisteredUser")]).Returns("M0ckP$$word");
			mockConfiguration.SetupGet(x => x[It.Is<string>(s => s ==
				"DefaultPasswords:Administrator")]).Returns("M0ckP$$word");
			using var context = new ApplicationDbContext(options);
            var roleManager = IdentityHelper.GetRoleManager(
                new RoleStore<IdentityRole>(context));
            var userManager = IdentityHelper.GetUserManager(
                new UserStore<ApplicationUser>(context));
            var controller = new SeedController(
                context,
                roleManager,
                userManager,
                mockEnv,
                mockConfiguration.Object
                );
            ApplicationUser user_Admin = null!;
            ApplicationUser user_User = null!;
            ApplicationUser user_NotExisting = null!;
            await controller.CreateDefaultUsers();
            user_Admin = await userManager.FindByEmailAsync(
                "foreverunning@outlook.com");
            user_User = await userManager.FindByEmailAsync(
                "froylan.vargas.gomez@gmail.com");
            user_NotExisting = await userManager.FindByEmailAsync(
                "notexisting@email.com");
            Assert.NotNull(user_Admin);
            Assert.NotNull(user_User);
            Assert.Null(user_NotExisting);
        }
	}
}

