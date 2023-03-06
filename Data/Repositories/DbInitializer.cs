using System;
using Core.Entities;
using Core.Helpers;
using Data.Contexts;

namespace Data.Repositories
{
	public static class DbInitializer
	{

		static int id;

		public static void SeedAdmins()
		{

			var admins = new List<Admin>
			{


				new Admin
				{

					Id = ++id,
					Username = "Fatima",
					Password = PasswordHasher.Encrypt("28081997"),



				},

				new Admin
				{


					Id = ++id,
					Username = "Azer",
					Password = PasswordHasher.Encrypt("20071997"),


				},

				new Admin
				{

					Id = ++id,
					Username = "Kenan",
					Password = PasswordHasher.Encrypt("123"),

				}




			};

			DbContext.Admins.AddRange(admins);

		}


	}
}

