using System;
using Core.Entities;
using Data.Contexts;
using Data.Repositoriesofmethods.Abstract;

namespace Data.Repositoriesofmethods.Concrete
{
    public class DrugstoreRepository : IDrugstoreRepository
    {

        public List<Drugstore> GetAll()
        {
            return DbContext.Drugstores;
        }

        public Drugstore Get(int id)
        {
            return DbContext.Drugstores.FirstOrDefault(d => d.Id == id);
        }



       



        public void Update(Drugstore drugstore)
        {
            var dbDrugstore = DbContext.Drugstores.FirstOrDefault(d => d.Id == drugstore.Id);
            if (dbDrugstore is not null)
            {

                dbDrugstore.Name = drugstore.Name;
                dbDrugstore.Adress = drugstore.Adress;
                dbDrugstore.Number = drugstore.Number;
                dbDrugstore.Owner = drugstore.Owner;
                dbDrugstore.Email = drugstore.Email;
                dbDrugstore.Druggists = drugstore.Druggists;
                dbDrugstore.Drugs = drugstore.Drugs;


            }


        }



        public void Delete(Drugstore drugstore)
        {
            DbContext.Drugstores.Remove(drugstore);

        }

        public bool IsDublicateEmail(string email)
        {
            return DbContext.Drugstores.Any(d => d.Email == email);
        }

        public void GetAllDrugstoresByOwner(Owner owner)
        {
            DbContext.Drugstores.FirstOrDefault(d => d.Owner == owner);
        }

        public void Create(Drugstore drugstore)
        {
            DbContext.Drugstores.Add(drugstore);
        }
    }
}
