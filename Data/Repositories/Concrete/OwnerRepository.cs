using System;
using Core.Entities;
using Data.Contexts;
using Data.Repositoriesofmethods.Abstract;

namespace Data.Repositoriesofmethods.Concrete
{
    public class OwnerRepository : IOwnerRepository
    {
        public List<Owner> GetAll()
        {
            return DbContext.Owners;
        }

        public Owner Get(int id)
        {
            return DbContext.Owners.FirstOrDefault(o => o.Id == id);
        }

        

     
        public void Update(Owner owner)
        {
            var dbOwner = DbContext.Owners.FirstOrDefault(o => o.Id == owner.Id);
            if (dbOwner != null)
            {

                dbOwner.Name = owner.Name;
                dbOwner.Surname = owner.Surname;
                dbOwner.Drugstores = owner.Drugstores;

            }
        }

        public void Delete(Owner owner)
        {
            DbContext.Owners.Remove(owner);
        }

        public void Create(Owner owner)
        {
            DbContext.Owners.Add(owner);
        }
    }
}

