using System;
using Core.Entities;

namespace Data.Repositoriesofmethods.Abstract
{
	public interface IRepository<T> where T:BaseEntity
	{

		List<T> GetAll();

		void Create(T item);

		T Get(int id);

	

		void Update(T item);

		void Delete(T item);

		
	}
}

