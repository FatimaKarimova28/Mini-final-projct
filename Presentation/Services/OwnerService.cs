using System;
using System.Collections.Generic;
using Core.Entities;
using Core.Helpers;
using Data.Repositoriesofmethods.Concrete;

namespace Presentation.Services
{
	public class OwnerService
	{
		private readonly OwnerRepository _ownerRepository;
		
		public OwnerService()
		{
			_ownerRepository = new OwnerRepository();
			
		}

		int id;
		public void GetAll()
		{

			var owners = _ownerRepository.GetAll();
			if (owners.Count == 0)
			{

				ConsoleHelper.WriteWithColor("There is no any owner!", ConsoleColor.Red);


			}

			else

			{

                ConsoleHelper.WriteWithColor("*****************ALL OWNERS:******************", ConsoleColor.Magenta);

                foreach (var owner in owners)
				{

					

					ConsoleHelper.WriteWithColor($"Id: {owner.Id} \n Fullname: {owner.Name} {owner.Surname} \n ", ConsoleColor.DarkYellow);


				}



			}

            

        }

		public void Create()
		{
			id++; 
			 ConsoleHelper.WriteWithColor("<*<*<*<*Enter Name:*>*>*>*>", ConsoleColor.DarkYellow);
			string name = Console.ReadLine();
			

			ConsoleHelper.WriteWithColor("<*<*<*<*Enter Surname:*>*>*>*>", ConsoleColor.DarkYellow);
            string surname = Console.ReadLine();




			var owner = new Owner
			{
				Id = id,
				Name = name,
				Surname = surname,
				


			};

			_ownerRepository.Create(owner);
			ConsoleHelper.WriteWithColor($" Owner successfully created with: \n Id: {owner.Id} \n Fullname: {owner.Name} {owner.Surname}", ConsoleColor.Green);





		}

		public void Update()
		{
			if (_ownerRepository.GetAll().Count != 0)
			{
				GetAll();



			OwnerIdDescription: ConsoleHelper.WriteWithColor("******************Enter Owner's ID:******************", ConsoleColor.Magenta);
				int id;
				bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
				if (!isSucceeded)
				{
					ConsoleHelper.WriteWithColor("Inputed ID is not correct format!", ConsoleColor.Red);
					Thread.Sleep(1000);
					goto OwnerIdDescription;




				}

				var owner = _ownerRepository.Get(id);
				if (owner is null)
				{

					ConsoleHelper.WriteWithColor("There is no any owner in this Id!", ConsoleColor.Red);
					Thread.Sleep(1000);
					goto OwnerIdDescription;


				}

				ConsoleHelper.WriteWithColor("<<<<<<<<<<<<<<<<<<Enter new Name:>>>>>>>>>>>>>>>>", ConsoleColor.Magenta);
				string name = Console.ReadLine();

				ConsoleHelper.WriteWithColor("<<<<<<<<<<<<<<<<Enter new Surname:>>>>>>>>>>>>>>", ConsoleColor.Magenta);
				string surname = Console.ReadLine();

				owner.Name = name;
				owner.Surname = surname;

				_ownerRepository.Update(owner);
				ConsoleHelper.WriteWithColor($"{owner.Name} {owner.Surname} - is successfully updated", ConsoleColor.Green);

			}

			else
			{


				ConsoleHelper.WriteWithColor("There is not any owner to update", ConsoleColor.Red);


			}

		}




	

		public void Delete()
		{
			

			if (_ownerRepository.GetAll().Count == 0)
			{

				ConsoleHelper.WriteWithColor("There is no owners!", ConsoleColor.Red);



			}

			else
			{
                GetAll();

            OwnerIdDescription: ConsoleHelper.WriteWithColor("=================Enter Owner's Id:===============", ConsoleColor.DarkMagenta);
				int id;
				bool isSuccuded = int.TryParse(Console.ReadLine(), out id);
				if (!isSuccuded)
				{

					ConsoleHelper.WriteWithColor("Id is not correct format!", ConsoleColor.Red);
					Thread.Sleep(1000);
					goto OwnerIdDescription;


				}

				var owner = _ownerRepository.Get(id);
				if (owner is null)
				{


					ConsoleHelper.WriteWithColor("There is no any owner!", ConsoleColor.Red);


				}

				_ownerRepository.Delete(owner);
				ConsoleHelper.WriteWithColor($" {owner.Name} {owner.Surname} - is successfully deleted", ConsoleColor.Green);

			}



		}
	}
}

