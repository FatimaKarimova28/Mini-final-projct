using System.Text;
using Core.Constants;
using Core.Helpers;
using Data.Repositories;
using Presentation.Services;

namespace Presentation
{


    public static class Program
    {


        private readonly static AdminService _adminService;
        private readonly static OwnerService _ownerService;
        private readonly static DrugstoreService _drugstoreService;
        private readonly static DruggistService _druggistService;
        private readonly static DrugService _drugService;


        static Program()
        {
            Console.OutputEncoding = Encoding.UTF8;
            DbInitializer.SeedAdmins();
            _adminService = new AdminService();
            _ownerService = new OwnerService();
            _drugstoreService = new DrugstoreService();
            _druggistService = new DruggistService();
            _drugService = new DrugService();

        }


        static void Main()
        {



            ConsoleHelper.WriteWithColor("<<<<<<<<<<<<<<<<<<<<Welcome>>>>>>>>>>>>>>>>>", ConsoleColor.Cyan);


            Thread.Sleep(1000);
       

                        AuthorizeDescription: var admin = _adminService.Authorize();
                            if (admin is not null)
                            {
                                ConsoleHelper.WriteWithColor($"=*=*=*=*=*=*=*=Welcome, {admin.Username}=*=*=*=*=*=*=*=", ConsoleColor.Magenta);
                                Thread.Sleep(1000);
                                while (true)
                                {


                                    ConsoleHelper.WriteWithColor("---------------Main Menu---------------", ConsoleColor.Magenta);

                                MainMenuDescription: ConsoleHelper.WriteWithColor("0 - Logout", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("1 - Owner", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("2 - Drugstores", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("3 - Druggists", ConsoleColor.DarkYellow);
                                    ConsoleHelper.WriteWithColor("4 - Drugs", ConsoleColor.DarkYellow);


                                     int number;
                                     bool isSucceeded = int.TryParse(Console.ReadLine(), out number);
                                    if (!isSucceeded)
                                    {

                                        ConsoleHelper.WriteWithColor("Inputed number is not correct format!", ConsoleColor.Red);
                                        Thread.Sleep(1000);
                                        goto MainMenuDescription;



                                    }

                                    else
                                    {


                                        switch (number)
                                        {

                                            case (int)MainMenuOptions.Logout:
                                                goto AuthorizeDescription;

                                            case (int)MainMenuOptions.Owner:

                                                while (true)
                                                {


                                                    Console.WriteLine("    ");
                                                OwnerDescription: ConsoleHelper.WriteWithColor("0 - Back to the Main Menu", ConsoleColor.Blue);
                                                    ConsoleHelper.WriteWithColor("1 - Create an owner", ConsoleColor.Blue);
                                                    ConsoleHelper.WriteWithColor("2 - Update an owner", ConsoleColor.Blue);
                                                    ConsoleHelper.WriteWithColor("3 - Get All owners", ConsoleColor.Blue);
                                                    ConsoleHelper.WriteWithColor("4 - Delete an owner", ConsoleColor.Blue);

                                                    Console.WriteLine("   ");
                                                    ConsoleHelper.WriteWithColor("^^^^^^^^^^^^^^Select Option^^^^^^^^^^^^^^", ConsoleColor.DarkMagenta);
                                                    isSucceeded = int.TryParse(Console.ReadLine(), out number);
                                                    if (!isSucceeded)
                                                    {

                                                        ConsoleHelper.WriteWithColor("Inputed nnumber is not correct format!", ConsoleColor.Red);



                                                    }

                                                    else
                                                    {

                                                        switch (number)
                                                        {



                                                            case (int)OwnerOptions.BackToTheMainMenu:
                                                                goto MainMenuDescription;

                                                            case (int)OwnerOptions.CreateAnOwner:
                                                              _ownerService.Create();

                                                                break;

                                                            case (int)OwnerOptions.UpdateAnOwner:
                                                              _ownerService.Update();
                                                                break;

                                                            case (int)OwnerOptions.GetAllOwner:
                                                             _ownerService.GetAll();
                                                                break;

                                                            case (int)OwnerOptions.DeleteanOwner:
                                                               _ownerService.Delete();
                                                                break;



                                                            default:
                                                                ConsoleHelper.WriteWithColor("Inputed number is not exist!", ConsoleColor.Red);
                                                                goto OwnerDescription;



                                                        }


                                                    }


                                                }
                                                break;

                                            case (int)MainMenuOptions.Drugstores:

                                                while (true)
                                                {


                                                    Console.WriteLine("   ");

                                                DrugstoreDescription: ConsoleHelper.WriteWithColor("0 - Back to the Main Menu", ConsoleColor.DarkMagenta);
                                                    ConsoleHelper.WriteWithColor("1 - Create a Drugstore", ConsoleColor.DarkMagenta);
                                                    ConsoleHelper.WriteWithColor("2 - Update a Drugstore", ConsoleColor.DarkMagenta);
                                                    ConsoleHelper.WriteWithColor("3 - Delete a Drugstore", ConsoleColor.DarkMagenta);
                                                    ConsoleHelper.WriteWithColor("4 - Get All Drugstores", ConsoleColor.DarkMagenta);
                                                    ConsoleHelper.WriteWithColor("5 - Get All Drugstores By Owner", ConsoleColor.DarkMagenta);
                                                    ConsoleHelper.WriteWithColor("6 - Sale", ConsoleColor.DarkMagenta);



                                                    Console.WriteLine("   ");
                                                    ConsoleHelper.WriteWithColor("^^^^^^^^^^^^^^Select Option^^^^^^^^^^^^^^", ConsoleColor.DarkMagenta);
                                                    isSucceeded = int.TryParse(Console.ReadLine(), out number);
                                                    if (!isSucceeded)
                                                    {

                                                        ConsoleHelper.WriteWithColor("Inputed nnumber is not correct format!", ConsoleColor.Red);



                                                    }

                                                    else
                                                    {

                                                        switch (number)
                                                        {



                                                            case (int)DrugstoreOptions.BackToTheMainMenu:
                                                                goto MainMenuDescription;

                                                            case (int)DrugstoreOptions.CreateADrugstore:
                                                             _drugstoreService.Create();
                                                                break;

                                                            case (int)DrugstoreOptions.UpdateADrugstore:
                                                            _drugstoreService.Update();
                                                                break;

                                                            case (int)DrugstoreOptions.DeleteADrugstore:
                                                            _drugstoreService.Delete();
                                                                break;

                                                            case (int)DrugstoreOptions.GetAllDrugstores:
                                                           _drugstoreService.GetAll();
                                                                break;
                                                            case (int)DrugstoreOptions.GetAllDrugstoresByOwner:
                                                              _drugstoreService.GetAllByOwner();
                                                                break;
                                                            case (int)DrugstoreOptions.Sale:
                                                            _drugstoreService.Sale();
                                                                break;


                                                            default:
                                                                ConsoleHelper.WriteWithColor("Inputed number is not exist!", ConsoleColor.Red);
                                                                goto DrugstoreDescription;



                                                        }


                                                    }


                                                }
                                                break;

                                            case (int)MainMenuOptions.Druggists:
                                                while (true)
                                                {
                                                    Console.WriteLine("   ");

                                                DruggistDescription: ConsoleHelper.WriteWithColor("0 - Back to the Main Menu", ConsoleColor.Yellow);
                                                    ConsoleHelper.WriteWithColor("1 - Create a Druggist", ConsoleColor.Yellow);
                                                    ConsoleHelper.WriteWithColor("2 - Update a Druggist", ConsoleColor.Yellow);
                                                    ConsoleHelper.WriteWithColor("3 - Get All Druggists", ConsoleColor.Yellow);
                                                    ConsoleHelper.WriteWithColor("4 - Get All Druggists By Drugstore", ConsoleColor.Yellow);
                                                    ConsoleHelper.WriteWithColor("5 - Delete a Druggist", ConsoleColor.Yellow);



                                                    Console.WriteLine("   ");
                                                    ConsoleHelper.WriteWithColor("^^^^^^^^^^^^^^Select Option^^^^^^^^^^^^^^", ConsoleColor.DarkMagenta);
                                                    isSucceeded = int.TryParse(Console.ReadLine(), out number);
                                                    if (!isSucceeded)
                                                    {

                                                        ConsoleHelper.WriteWithColor("Inputed nnumber is not correct format!", ConsoleColor.Red);



                                                    }

                                                    else
                                                    {

                                                        switch (number)
                                                        {



                                                            case (int)DruggistOptions.BackToTheMainMenu:
                                                                goto MainMenuDescription;

                                                            case (int)DruggistOptions.CreateADruggist:
                                                            _druggistService.Create();
                                                                break;

                                                            case (int)DruggistOptions.UpdateADruggist:
                                                             _druggistService.Update();
                                                                break;

                                                            case (int)DruggistOptions.GetAllDruggists:
                                                             _druggistService.GetAll();
                                                                break;

                                                            case (int)DruggistOptions.GetAllDruggistsByDrugstore:
                                                              _druggistService.GetAllByDrugStore();
                                                                break;
                                                            case (int)DruggistOptions.DeleteADruggist:
                                                              _druggistService.Delete();
                                                                break;



                                                            default:
                                                                ConsoleHelper.WriteWithColor("Inputed number is not exist!", ConsoleColor.Red);
                                                                goto DruggistDescription;



                                                        }


                                                    }






                                                }

                                                break;

                                            case (int)MainMenuOptions.Drugs:
                                                while (true)
                                                {

                                                    Console.WriteLine("   ");

                                                DrugDescription: ConsoleHelper.WriteWithColor("0 - Back to the Main Menu", ConsoleColor.DarkCyan);
                                                    ConsoleHelper.WriteWithColor("1 - Create a Drug", ConsoleColor.DarkCyan);
                                                    ConsoleHelper.WriteWithColor("2 - Update a Drug", ConsoleColor.DarkCyan);
                                                    ConsoleHelper.WriteWithColor("3 - Get All Drugs", ConsoleColor.DarkCyan);
                                                    ConsoleHelper.WriteWithColor("4 - Get All Drugs By Drugstore", ConsoleColor.DarkCyan);
                                                      ConsoleHelper.WriteWithColor("5 - Filter", ConsoleColor.DarkCyan);
                                                    ConsoleHelper.WriteWithColor("6 - Delete a Drug", ConsoleColor.DarkCyan);



                                                    Console.WriteLine("   ");
                                                    ConsoleHelper.WriteWithColor("^^^^^^^^^^^^^^Select Option^^^^^^^^^^^^^^", ConsoleColor.DarkMagenta);
                                                    isSucceeded = int.TryParse(Console.ReadLine(), out number);
                                                    if (!isSucceeded)
                                                    {

                                                        ConsoleHelper.WriteWithColor("Inputed nnumber is not correct format!", ConsoleColor.Red);



                                                    }



                                                    else
                                                    {

                                                        switch (number)
                                                        {



                                                            case (int)DrugOptions.BackToTheMainMenu:
                                                                goto MainMenuDescription;

                                                            case (int)DrugOptions.CreateADrug:
                                                               _drugService.Create();
                                                                break;

                                                            case (int)DrugOptions.UpdateADrug:
                                                              _drugService.Update();
                                                                break;

                                                            case (int)DrugOptions.GetAllDrugs:
                                                              _drugService.GetAll();
                                                                break;

                                                            case (int)DrugOptions.GetAllDrugsByDrugstore:
                                                               _drugService.GetAllByDrugStore();
                                                                break;
                                                            case (int)DrugOptions.Filter:
                                                                 _drugService.Filter();
                                                                break;
                                                            case (int)DrugOptions.DeleteADrug:
                                                               _drugService.Delete();
                                                                break;



                                                            default:
                                                                ConsoleHelper.WriteWithColor("Inputed number is not exist!", ConsoleColor.Red);
                                                                goto DrugDescription;



                                                        }


                                                    }









                                                }



                                                break;


                                                

                                        }
                                       




                                    }


                                }



                            }








                       



        }



    }

}
