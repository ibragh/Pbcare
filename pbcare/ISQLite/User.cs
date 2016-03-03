using System;
using Xamarin.Forms;
using System.Collections.Generic;
using SQLite;

namespace pbcare
{
	
	public class User
	{
		public string Email { get; set; }

		public string Password { get; set; }

		public string name { get; set; }

		//[Ignore]
		//	public List<Child> MyChilren = new List<Child> ();


		public User ()
		{

		}

	}
	public class PregnancyDuedate
	{
		public string Email { get; set; }

		public string dueDate { get; set; }

		public PregnancyDuedate ()
		{

		}

	}

}