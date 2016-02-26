using System;
using Xamarin.Forms;
using System.Collections.Generic;
using SQLite;

namespace pbcare
{
	
	public class User
	{
		[PrimaryKey,AutoIncrement]
		public int ID { get; set; }

		public string Email { get; set; }

		public string Password { get; set; }

		public string Username { get; set; }

		//[Ignore]
		public List<Child> MyChilren = new List<Child> ();


		public User ()
		{
			
		}
		
	}

}