using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Fritz.ResourceManagement.Web
{

	public static class ExtensionMethods
	{

		public static int? GetPersonId(this System.Security.Claims.ClaimsPrincipal claimsPrincipal)
		{

			return claimsPrincipal.GetClaimValueAsInt(Data.MyUser.Claims.PERSONID);

		}

		public static int? GetClaimValueAsInt(this System.Security.Claims.ClaimsPrincipal claimsPrincipal, string claimName)
		{

			var outValue = claimsPrincipal.Claims
				.First(c => c.Type == claimName)?.Value;

			if (string.IsNullOrEmpty(outValue)) return null;

			return int.Parse(outValue);

		}

		public static DbContextOptionsBuilder UseMyDatabase(this DbContextOptionsBuilder options, IConfiguration config = null)
		{
			options.UseSqlite(config.GetConnectionString("sqlitedb"));
			return options;
		}

		public static DbContextOptionsBuilder UseMyDatabase(this DbContextOptionsBuilder options, string connectionString)
		{
			options.UseSqlite(connectionString);
			return options;
		}


	}

}
