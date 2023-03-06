using System;
using Core.Entities;

namespace Data.Repositoriesofmethods.Concrete
{
	public interface IAdminRepository
	{
		Admin GetByUsernameAndPassword(string username, string password);

	}
}

