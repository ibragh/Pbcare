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

		public int isPregnant { get; set; }

		public int isSensorOn { get; set; }


		public User ()
		{
			
		}

	}

}