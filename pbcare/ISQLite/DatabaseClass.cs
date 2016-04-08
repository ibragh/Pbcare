using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Linq;
using SQLite;
using System.Diagnostics;
using System.Globalization;

namespace pbcare
{
	public class DatabaseClass
	{
		public SQLiteConnection DB;

		public DatabaseClass ()
		{

			DB = DependencyService.Get<ISQLite> ().GetConnection (); 
			DB.CreateTable<User> ();
			DB.CreateTable<Child> ();
			DB.CreateTable<PregnancyDuedateTable> ();
			DB.CreateTable<PregnancyWeeklyTable> ();
			DB.CreateTable<UserLoggedIn> ();
		}
		// check if user is logged in previasly... will chgange it later
		public bool checkUserLoggedin ()
		{
			string DueDate="";
			try {
				
				var RigrsterdUser = DB.Table<UserLoggedIn> ().Where (i => i.loggedIn == 1).FirstOrDefault ();
				if (RigrsterdUser != null) {
					/* Retreve Email from Database */
					pbcareApp.u.Email = RigrsterdUser.email;
					pbcareApp.IsUserLoggedIn = true ;
					/* Retreve DueDate from Database */
					DueDate = DB.Table<PregnancyDuedateTable> ().Where (i => i.email == pbcareApp.u.Email).FirstOrDefault ().dueDate;
					/*Convert DueDate string to a valid DateTime*/
					pbcareApp.FinaldueDate = DateTime.ParseExact(DueDate, "ddMMyyyy", null).Date;
					return true; // User has logged in before

				} else {
					return false; // User has NOT logged in before
				}
			} catch (Exception ex) {
				Debug.WriteLine (DueDate+"********************************************************************* : "+ex.ToString ());
				return false;
			}
		}

		public void InsertUserLoggedin (bool status)
		{
			UserLoggedIn u = new UserLoggedIn ();
			if (status) {
				u.loggedIn = 1; // will delete it later
				u.email = pbcareApp.u.Email;
				DB.Insert (u);
			} else {
				DB.DeleteAll<UserLoggedIn>();
			}

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

				// check if user is registred
				if (DB.Table<User> ().Where (c => c.Email == email).FirstOrDefault () != null) {
					// check if the account is not already rigesterd..
					// if so, and user want do edit, there is another way to do that
					if (DB.Table<PregnancyDuedateTable> ().Where (c => c.email == email).FirstOrDefault () != null) {
						return 1;
					// user is ready to store a new DueDate
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

		public List<Child> gitChildren(string email)
		{
			
			try{
				return  DB.Table<Child> ().Where (c => c.mother == email).ToList();
			}
			catch(Exception ex){
				return null ;
			}
		}


		public Child gitChild(string name , string email){
		
			try{
				return DB.Table<Child>().Where (c => c.name == name && c.mother == email).FirstOrDefault();
			}
			catch(Exception ex){
				return null;
			}
		}

		public List<vaccinationTable> gitVaccinations()
		{
			try{
				return DB.Table<vaccinationTable>().ToList();
			}
			catch(Exception ex){
				return null;
			}
		}
	
	}
}

