using System;
using Core.Entities;
using Core.Helpers;
using Data.Repositoriesofmethods.Concrete;

namespace Presentation.Services
{
	public class AdminService
	{
		private readonly AdminRepository _adminRepository;
		public AdminService()
		{
			_adminRepository = new AdminRepository();
		}

		public Admin Authorize()
		{


		LoginDescription: ConsoleHelper.WriteWithColor("||||||||||||||||||LogIn||||||||||||||||||", ConsoleColor.DarkCyan);
		
			ConsoleHelper.WriteWithColor("*************************Enter Username:*************************", ConsoleColor.DarkCyan);
			string username = Console.ReadLine();


			ConsoleHelper.WriteWithColor("*************************Enter Password:*************************", ConsoleColor.DarkCyan);
			string password = Console.ReadLine();

			var admin = _adminRepository.GetByUsernameAndPassword(username, password);
			if (admin is null)
			{


				ConsoleHelper.WriteWithColor("Username or password is incorrect!", ConsoleColor.Red);
			
				goto LoginDescription;


			}

			return admin;







        }
	}
}

