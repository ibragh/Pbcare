using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace pbcare
{
	public class DatabaseClass
	{
		public SQLiteConnection DB;

		public DatabaseClass ()
		{

			DB = DependencyService.Get<ISQLite> ().GetConnection ();

		}

		public bool checkLogin (string email, string password)
		{

			if (DB.Table<User> ().Where (user => user.Email == email && user.Password == password).FirstOrDefault () != null) {
				return true;
			} else {
				return false;
			}
		}

		public bool signup (string email, string password, string name)
		{
			if (DB.Table<User> ().Where (user => user.Email == email ).FirstOrDefault () != null) {
				return false;
			} else {
				User u = new User ();
				u.Email = email;
				u.Password = password;
				u.name = name;
				DB.Insert (u);
				return true;
			}

		}

		public int AddPregnancyToDB (string email, string date)
		{
			try {
				User u = new User ();
				u.Email = email;

				// check it user i is registred
				if (DB.Table<User> ().Where (c => c.Email == email).FirstOrDefault () != null) {
					// check if the account is not already rigesterd..
					// if so, and user want do edit, there is another way to do that
					if (DB.Table<PregnancyDuedate> ().Where (c => c.Email == email).FirstOrDefault () != null) {
						return 1;
						// check if due date on this account is not an empty string
					} else if (DB.Table<PregnancyDuedate> ().Where (c => c.Email == email && c.dueDate == "").FirstOrDefault () == null) {
						return 2;
					} else {
						PregnancyDuedate p = new PregnancyDuedate ();
						p.Email = email;
						p.dueDate = date;
						DB.Insert (p);
						return 99;
					}

				} else {

					return 0;
				}

			} catch (Exception ex) {
				return -1;
			} 
		}
	}
}

