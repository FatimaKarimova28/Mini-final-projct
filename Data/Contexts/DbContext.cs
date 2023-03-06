﻿using System;
using Core.Entities;

namespace Data.Contexts
{
	public static class DbContext
	{
		static DbContext()
		{
			Admins = new List<Admin>();

			Drugs = new List<Drug>();

			Druggists = new List<Druggist>();

			Owners = new List<Owner>();

			Drugstores = new List<Drugstore>();

		}

		public static List<Admin> Admins { get; set; }

		public static List<Drug> Drugs { get; set; }

		public static List<Druggist> Druggists { get; set; }

		public static List<Owner> Owners { get; set; }

		public static  List<Drugstore> Drugstores { get; set; }


	}
}

