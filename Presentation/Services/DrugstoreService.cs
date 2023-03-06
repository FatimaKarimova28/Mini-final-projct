using System;
using Core.Entities;
using Core.Extentions;
using Core.Helpers;
using Data.Repositoriesofmethods.Abstract;
using Data.Repositoriesofmethods.Concrete;

namespace Presentation.Services
{
    public class DrugstoreService
    {
        private readonly OwnerRepository _ownerRepository;
        private readonly OwnerService _ownerService;
        private readonly DrugRepository _drugRepository;
        private readonly DrugstoreRepository _drugstoreRepository;




        public DrugstoreService()
        {
            _ownerRepository = new OwnerRepository();
            _ownerService = new OwnerService();
            _drugRepository = new DrugRepository();
            _drugstoreRepository = new DrugstoreRepository();

        }


        int id;
        public void GetAll()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count == 0)
            {


                ConsoleHelper.WriteWithColor("There is no any drugstores!", ConsoleColor.Red);

            }
            else
            {

                ConsoleHelper.WriteWithColor("All drugstores:", ConsoleColor.Magenta);
                foreach (var drugstore in drugstores)
                {

                    ConsoleHelper.WriteWithColor($" Id: {drugstore.Id} \n Name: {drugstore.Name} \n Adress: {drugstore.Adress} \n Number: {drugstore.Number} \n Email: {drugstore.Email} \n Owner: {drugstore.Owner.Id} {drugstore.Owner.Name} ", ConsoleColor.Magenta);

                }



            }


        }

        public void Create()
        {


            if (_ownerRepository.GetAll().Count == 0)
            {

                ConsoleHelper.WriteWithColor("First you must create a owner!", ConsoleColor.Red);


            }

            else
            {
                id++;

                ConsoleHelper.WriteWithColor("----------------Enter name of thr Drugstore:-----------------", ConsoleColor.DarkYellow);
                string name = Console.ReadLine();



                ConsoleHelper.WriteWithColor("<<<<<<<<<<<<Enter adress:>>>>>>>>>>", ConsoleColor.Yellow);
                string adress = Console.ReadLine();


            DrugstoreNumberDescription: ConsoleHelper.WriteWithColor("<<<<<<<<<<Enter drugstore's number", ConsoleColor.Yellow);
                string number = Console.ReadLine();

                if (!number.IsCorrectMobileNumber())
                {

                    ConsoleHelper.WriteWithColor("Number is not correct format!", ConsoleColor.Red);

                    goto DrugstoreNumberDescription;

                }



            DrugstoreEmailDescription: ConsoleHelper.WriteWithColor("<<<<<<<<<<<<<Enter Email:>>>>>>>>>>>>>>", ConsoleColor.Yellow);
                string email = Console.ReadLine();
                if (!email.IsEmail())
                {
                    ConsoleHelper.WriteWithColor("Email is not correct format!", ConsoleColor.Red);
                    Thread.Sleep(1000);
                    goto DrugstoreEmailDescription;



                }
                if (_drugstoreRepository.IsDublicateEmail(email))
                {
                    ConsoleHelper.WriteWithColor("This email is already used!", ConsoleColor.Red);
                    Thread.Sleep(1000);
                    goto DrugstoreEmailDescription;
                }


                _ownerService.GetAll();

            OwnerDescription: ConsoleHelper.WriteWithColor("Enter Id of owner", ConsoleColor.Cyan);

                int idOwner;
                bool isSucceeded = int.TryParse(Console.ReadLine(), out idOwner);
                if (!isSucceeded)
                {

                    ConsoleHelper.WriteWithColor("Id is not correct format!", ConsoleColor.Red);
                    goto OwnerDescription;




                }

                var drugstoreOwner = _ownerRepository.Get(idOwner);
                if (drugstoreOwner is null)
                {

                    ConsoleHelper.WriteWithColor("There is no any owner!", ConsoleColor.Red);
                    goto OwnerDescription;


                }

                var dbDrugstore = new Drugstore
                {

                    Id = id,
                    Name = name,
                    Adress = adress,
                    Number = number,
                    Email = email,
                    Owner = drugstoreOwner,





                };



                _drugstoreRepository.Create(dbDrugstore);

                ConsoleHelper.WriteWithColor($" Id: {dbDrugstore.Id} \n  Name: {dbDrugstore.Name} \n Adress: {dbDrugstore.Adress} \n Number: {dbDrugstore.Number} \n Email: {dbDrugstore.Email} \n Owner name: {dbDrugstore.Owner.Name} - successfully created", ConsoleColor.Green);








            }

        }

        public void Update()
        {

            if (_drugstoreRepository.GetAll().Count != 0)
            {

                GetAll();


            DrugstoreDescription: ConsoleHelper.WriteWithColor("Enter drugstore's Id:", ConsoleColor.Cyan);
                int id;
                bool isSucceeded = int.TryParse(Console.ReadLine(), out id);
                if (!isSucceeded)
                {


                    ConsoleHelper.WriteWithColor("Id is not correct fornat!", ConsoleColor.Red);
                    goto DrugstoreDescription;

                }

                var drugstore = _drugstoreRepository.Get(id);
                if (drugstore is null)
                {

                    ConsoleHelper.WriteWithColor("There is no any drugstore in this id", ConsoleColor.Red);

                    goto DrugstoreDescription;

                }

                ConsoleHelper.WriteWithColor("Enter new Name:", ConsoleColor.Cyan);
                string name = Console.ReadLine();
                ConsoleHelper.WriteWithColor("Enter new adress", ConsoleColor.Cyan);
                string adress = Console.ReadLine();

            DrugstoreNumberDescription: ConsoleHelper.WriteWithColor("<<<<<<<<<<Enter new drugstore's number", ConsoleColor.Yellow);
                string number = Console.ReadLine();

                if (!number.IsCorrectMobileNumber())
                {

                    ConsoleHelper.WriteWithColor("Number is not correct format!", ConsoleColor.Red);

                    goto DrugstoreNumberDescription;

                }

            EmailDescription: ConsoleHelper.WriteWithColor("<<<<<<<<<<Enter new drugstore's email", ConsoleColor.Yellow);
                string email = Console.ReadLine();
                if (!email.IsEmail())
                {

                    ConsoleHelper.WriteWithColor("Email is not correct format!", ConsoleColor.Red);
                    goto EmailDescription;

                }

                if (_drugstoreRepository.IsDublicateEmail(email))
                {

                    ConsoleHelper.WriteWithColor("Email has already been esed!", ConsoleColor.Red);
                    goto EmailDescription;



                }

                _ownerService.GetAll();

            OwnerDescription: ConsoleHelper.WriteWithColor("Enter Id of the Owner", ConsoleColor.Cyan);
                int idOwner;
                isSucceeded = int.TryParse(Console.ReadLine(), out idOwner);
                if (!isSucceeded)
                {

                    ConsoleHelper.WriteWithColor("Id is not correct format!", ConsoleColor.Red);
                    goto OwnerDescription;


                }


                var newOwner = _ownerRepository.Get(idOwner);
                if (newOwner is null)
                {
                    ConsoleHelper.WriteWithColor("There is no any owner", ConsoleColor.Red);
                    goto OwnerDescription;


                }

                drugstore.Name = name;
                drugstore.Adress = adress;
                drugstore.Number = number;
                drugstore.Email = email;
                drugstore.Owner = _ownerRepository.Get(idOwner);
                _drugstoreRepository.Update(drugstore);
                ConsoleHelper.WriteWithColor($"Id: {drugstore.Id} \n Name: {drugstore.Name} \n Adress: {drugstore.Adress} \n Number: {drugstore.Number} \n Email: {drugstore.Email} \n Owner: {drugstore.Owner.Name} \n - is successfully updated!", ConsoleColor.Green);

            }

            else
            {

                ConsoleHelper.WriteWithColor("There is no any drugstore to update!", ConsoleColor.Red);

            }

        }


        public void Delete()
        {
            var drugstores = _drugstoreRepository.GetAll();
            if (drugstores.Count == 0)
            {


                ConsoleHelper.WriteWithColor("Thre is no any drugstore!", ConsoleColor.Red);


            }

            else
            {
                GetAll();

                foreach (var drugstore in drugstores)
                {
                    ConsoleHelper.WriteWithColor($" Id:{drugstore.Id} \n Name: {drugstore.Name}\n Owner: {drugstore.Owner}", ConsoleColor.Cyan);
                }


                ConsoleHelper.WriteWithColor("=================Enter drugstore's Id:===============", ConsoleColor.DarkMagenta);
                int id;
                bool isSuccuded = int.TryParse(Console.ReadLine(), out id);
                if (!isSuccuded)
                {

                    ConsoleHelper.WriteWithColor("Id is not correct format!", ConsoleColor.Red);



                }

                var dbDrugstore = _drugstoreRepository.Get(id);
                if (dbDrugstore is null)
                {


                    ConsoleHelper.WriteWithColor("There is no any drugstore!", ConsoleColor.Red);


                }

                _drugstoreRepository.Delete(dbDrugstore);
                ConsoleHelper.WriteWithColor($" {dbDrugstore.Id} {dbDrugstore.Name} - is successfully deleted", ConsoleColor.Green);








            }








        }




        public void GetAllByOwner()
        {
            if (_drugstoreRepository.GetAll().Count == 0)
            {
                ConsoleHelper.WriteWithColor("There is no drugStore", ConsoleColor.Red);
            }
            else
            {
                _ownerService.GetAll();

            OwnerIdDescription: ConsoleHelper.WriteWithColor("Choose owner Id", ConsoleColor.Cyan);
                int ownerId;
                bool issucceeded = int.TryParse(Console.ReadLine(), out ownerId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Owner Id is not in a correct format", ConsoleColor.Red);
                    goto OwnerIdDescription;
                }

                var owner = _ownerRepository.Get(ownerId);
                if (owner is null)
                {
                    ConsoleHelper.WriteWithColor("There is no owner in this id", ConsoleColor.Red);
                    goto OwnerIdDescription;
                }

                var drugStores = _drugstoreRepository.GetAll().Where(s => s.Owner == owner);
                if (drugStores.Count() == 0)
                {
                    ConsoleHelper.WriteWithColor("This owner does not have any drugstores", ConsoleColor.Red);
                    goto OwnerIdDescription;
                }

                foreach (var drugStore in drugStores)
                {
                    ConsoleHelper.WriteWithColor($"Id: {drugStore.Id}, Name: {drugStore.Name},Address: {drugStore.Adress}, ContactNumber: {drugStore.Number}, Email: {drugStore.Email}, OwnerId: {drugStore.Owner.Id}", ConsoleColor.Cyan);
                }
            }
        }

        public void Sale()
        {
        SaleDescription: if (_drugRepository.GetAll().Count != 0)
            {
                ConsoleHelper.WriteWithColor("--All Drugs--", ConsoleColor.Blue);
                var drugs = _drugRepository.GetAll();
                foreach (var drug in drugs)
                {
                    ConsoleHelper.WriteWithColor($"Id: {drug.Id}, Name: {drug.Name}, Price: {drug.Price}, Count: {drug.Count}, Drugstore Id: {drug.Drugstore.Id}, DrugStore Name: {drug.Drugstore.Name}", ConsoleColor.Cyan);
                }

            DrugDescription: ConsoleHelper.WriteWithColor("Enter Id of the drug which you want to sell:", ConsoleColor.Blue);
                int drugId;
                bool issucceeded = int.TryParse(Console.ReadLine(), out drugId);
                if (!issucceeded)
                {
                    ConsoleHelper.WriteWithColor("Drug Id is not in a correct format!", ConsoleColor.Red);
                    goto DrugDescription;
                }

                var saleDrug = _drugRepository.Get(drugId);
                if (saleDrug is null)
                {
                    ConsoleHelper.WriteWithColor("There is not any drug in this id!", ConsoleColor.Red);
                    goto DrugDescription;
                }

                if (saleDrug.Count != 0)
                {


                    ConsoleHelper.WriteWithColor("Enter quantity that you want to sell:", ConsoleColor.Blue);
                    int quantity;
                    issucceeded = int.TryParse(Console.ReadLine(), out quantity);
                    if (!issucceeded)
                    {
                        ConsoleHelper.WriteWithColor("Quantity is not in a correct format!", ConsoleColor.Red);
                        goto DrugDescription;
                    }

                    if (quantity <= 0)
                    {
                        ConsoleHelper.WriteWithColor("Quantity should be more than 0!", ConsoleColor.Red);
                        goto DrugDescription;
                    }

                    if (quantity < saleDrug.Count && quantity == 1)
                    {
                        saleDrug.Count -= quantity;
                        ConsoleHelper.WriteWithColor($"{quantity} drug is sold", ConsoleColor.Green);
                    }

                    if (quantity < saleDrug.Count && quantity != 1)
                    {
                        saleDrug.Count -= quantity;
                        ConsoleHelper.WriteWithColor($"{quantity} drugs are sold", ConsoleColor.Green);
                    }

                    if (quantity > saleDrug.Count)
                    {
                    SelectionDescription: ConsoleHelper.WriteWithColor($"We have only {saleDrug.Count} drugs. Do you want to get them? 1) yes, 2) not", ConsoleColor.Red);
                        int selection;
                        issucceeded = int.TryParse(Console.ReadLine(), out selection);
                        if (!issucceeded)
                        {
                            ConsoleHelper.WriteWithColor("Selection is not in a correct format", ConsoleColor.Red);
                            goto SelectionDescription;
                        }

                        if (!(selection == 1 || selection == 2))
                        {
                            ConsoleHelper.WriteWithColor("There is not any selection like that", ConsoleColor.Red);
                            goto SelectionDescription;
                        }

                        if (selection == 1)
                        {
                            var commonPrice = saleDrug.Price * saleDrug.Count;
                            ConsoleHelper.WriteWithColor($"all of that drugs have been sold. Common price is {commonPrice}", ConsoleColor.Green);

                            saleDrug.Count = 0;
                        }
                    }

                    if (quantity == saleDrug.Count)
                    {
                        saleDrug.Count = 0;
                        var commonPrice = saleDrug.Price * quantity;
                        ConsoleHelper.WriteWithColor($"All of that drugs have been sold. Common price is {commonPrice}", ConsoleColor.Green);
                    }
                }
                else
                {
                    ConsoleHelper.WriteWithColor("All of this drug had been sold!", ConsoleColor.Red);
                }
            }

            else
            {
                ConsoleHelper.WriteWithColor("There is not any drug to sell!", ConsoleColor.Red);
            }
        }
    }
}
