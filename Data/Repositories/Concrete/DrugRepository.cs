using System;
using Core.Entities;
using Data.Contexts;
using Data.Repositoriesofmethods.Abstract;

namespace Data.Repositoriesofmethods.Concrete
{
    public class DrugRepository : IDrugRepository
    {
        public List<Drug> GetAll()
        {
            return DbContext.Drugs;
        }

        public Drug Get(int id)
        {
            return DbContext.Drugs.FirstOrDefault(d => d.Id == id);
        }

     

        public void Update(Drug drug)
        {
            var dbDrug = DbContext.Drugs.FirstOrDefault(d => d.Id == drug.Id);
            if (dbDrug is not null)
            {

                dbDrug.Name = drug.Name;
                dbDrug.Price = drug.Price;
                dbDrug.Count = drug.Count;
                dbDrug.Drugstore = drug.Drugstore;




            }
        }


        public void Delete(Drug drug)
        {
            DbContext.Drugs.Remove(drug);
        }

        public void Create(Drug drug)
        {
            DbContext.Drugs.Add(drug);
        }
    }
}

