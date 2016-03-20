using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.Diagnostics;

namespace pbcare
{
	public class DatabaseClass
	{
		public SQLiteConnection DB;

		public DatabaseClass ()
		{

			DB = DependencyService.Get<ISQLite> ().GetConnection (); 
			DB.CreateTable<User> ();
			DB.CreateTable<PregnancyDuedateTable> ();
			DB.CreateTable<PregnancyWeeklyTable> ();
		}

		// check login in email & password are match in db
		public bool checkLogin (string email, string password)
		{

			if (DB.Table<User> ().Where (user => user.Email == email && user.Password == password).FirstOrDefault () != null) {
				return true;
			} else {
				return false;
			}
		}

		// check signup entries
		public bool signup (string email, string password, string name)
		{
			try {
				if (DB.Table<User> ().Where (user => user.Email == email).FirstOrDefault () != null) {
					return false;
				} else {
					User u = new User ();
					u.Email = email;
					u.Password = password;
					u.name = name;
					DB.Insert (u);
					return true;
				}
			} catch (Exception ex) {
				Debug.WriteLine (ex.ToString ());
				return false;
			} 
		}

		public int AddPregnancyToDB (string email, string date)
		{
			try {
				User u = new User ();
				u.Email = email;

				// check if user i is registred
				if (DB.Table<User> ().Where (c => c.Email == email).FirstOrDefault () != null) {
					// check if the account is not already rigesterd..
					// if so, and user want do edit, there is another way to do that
					if (DB.Table<PregnancyDuedateTable> ().Where (c => c.email == email).FirstOrDefault () != null) {
						return 1;
						// check if due date on this account is not an empty string
//					} else if (DB.Table<PregnancyDuedateTable> ().Where (c => c.email == email && c.dueDate != "").FirstOrDefault () == null) {
//						return 2;
					} else {
						PregnancyDuedateTable p = new PregnancyDuedateTable ();
						p.email = email;
						p.dueDate = date;
						DB.Insert (p);
						return 99;
					}

				} else {

					return 0;
				}

			} catch (Exception ex) {
				Debug.WriteLine (ex.ToString ());
				return -1;
			} 
		}

		public string  InsertIntoPregnancyWeekly (int WeekNumber)
		{
			try {
				// 
				var PregnancyWeek = DB.Table<PregnancyWeeklyTable> ().Where (c => c.week == WeekNumber).FirstOrDefault ();
				if (PregnancyWeek != null) {
					return PregnancyWeek.info;
				} else {
					return "المعلومة غير محفوظة في الداتابيس";
				}

			} catch (Exception ex) {
				Debug.WriteLine (ex.ToString ());
				return ex.ToString ();
			}


		}

	
	}
}

