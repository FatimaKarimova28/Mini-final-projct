using System;
using Core.Entities;
using Data.Contexts;
using Data.Repositoriesofmethods.Abstract;

namespace Data.Repositoriesofmethods.Concrete
{
    public class DruggistRepository : IDruggistRepository
    {


        public List<Druggist> GetAll()
        {
            return DbContext.Druggists;
        }


        public Druggist Get(int id)
        {
            return DbContext.Druggists.FirstOrDefault(d => d.Id == id);
        }

      

        public void Update(Druggist druggist)
        {
            var dbDruggist = DbContext.Druggists.FirstOrDefault(d => d.Id == druggist.Id);
            if (dbDruggist is not null)
            {

                dbDruggist.Name = druggist.Name;
                dbDruggist.Surname = druggist.Surname;
                dbDruggist.Age = druggist.Age;
                dbDruggist.Experience = druggist.Experience;
                dbDruggist.Drugstore = druggist.Drugstore;



            }
        }

        public void Delete(Druggist druggist)
        {
            DbContext.Druggists.Remove(druggist);
        }

        public void Create(Druggist druggist)
        {
            DbContext.Druggists.Add(druggist);
        }
    }
}

