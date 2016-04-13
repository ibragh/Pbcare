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
			DB.CreateTable<BabyMonthlyTable> ();
			DB.CreateTable<ChildVaccinations> ();

		}
		// check if user is logged in previasly... will chgange it later
		public bool checkUserLoggedin ()
		{
			string DueDate = "";
			try {
				if (DB.Table<UserLoggedIn> ().Where (i => i.loggedIn == 1).FirstOrDefault () != null) {
					var RigrsterdUser = DB.Table<UserLoggedIn> ().Where (i => i.loggedIn == 1).FirstOrDefault ();
				
					Debug.WriteLine (" RigrsterdUser loggedIn *************** : " + RigrsterdUser.loggedIn.ToString ());

					/* Retreve Email from Database */
					pbcareApp.u.Email = RigrsterdUser.email;
					Debug.WriteLine (" RigrsterdUser email ************ : " + RigrsterdUser.email);
					pbcareApp.IsUserLoggedIn = true;
					/* Retreve DueDate from Database */
					if (GetDueDate () != "false") {
						DueDate = GetDueDate ();
						Debug.WriteLine (" DueDate ************ : " + DueDate.ToString ());
						/*Convert DueDate string to a valid DateTime*/
						pbcareApp.FinaldueDate = DateTime.ParseExact (DueDate, "ddMMyyyy", null).Date;
					}

					return true; // User has logged in before

				} else {
					return false; // User has NOT logged in before
				}

			} catch (Exception ex) {
				if (pbcareApp.IsUserLoggedIn) {
					Debug.WriteLine ("******************** :"+ex.ToString ());
					return true;
				}else{
				return false;
					}
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
				DB.DeleteAll<UserLoggedIn> ();
			}

		}

		public string GetDueDate ()
		{
			try {
				return DB.Table<PregnancyDuedateTable> ().Where (i => i.email == pbcareApp.u.Email).FirstOrDefault ().dueDate;
			} catch (Exception ex) {
				Debug.WriteLine ("**** Method id: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return "false";
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
				Debug.WriteLine ("**** Method id: " + this.ToString () + " Exeption is :" + ex.ToString ());
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
				Debug.WriteLine ("**** Method id: " + this.ToString () + " Exeption is :" + ex.ToString ());
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
				Debug.WriteLine ("**** Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return ex.ToString ();
			}


		}

		public List<Child> getChildrenFromDB (string email)
		{
			
			try {
				return  DB.Table<Child> ().Where (c => c.mother == email).ToList ();
			} catch (Exception ex) {
				Debug.WriteLine ("**** Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return null;
			}
		}

		public bool AddChildToDB (Child child)
		{
			try {
//				Child c = new Child ();
//				c.mother = child.mother;
//				c.name = child.name;
//				c.birthDate= child.birthDate;
//				c.gender = child.gender;
				DB.Insert (child);
				return true;

				Debug.WriteLine ("**** Method is: " + this.ToString ());

			} catch(Exception ex){
				Debug.WriteLine ("****&&&^^^ Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return false;
			}
		}
		public Child getChildFromDB (string name, string email)
		{
		
			try {
				return DB.Table<Child> ().Where (c => c.ChildName == name && c.mother == email).FirstOrDefault ();
			} catch (Exception ex) {
				Debug.WriteLine ("**** Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return null;
			}
		}

		public List<vaccinationTable> getVaccinationsFromDB ()
		{
			try {
				return DB.Table<vaccinationTable> ().ToList ();
			} catch (Exception ex) {
				Debug.WriteLine ("**** Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return null;
			}
		}

		public bool getVaccinaton(int VID, string childName)
		{
			var isTakeIt =  DB.Table<ChildVaccinations> ().Where( v => v.VaccinationID == VID && v.ChildName == childName && v.mother == pbcareApp.u.Email ).FirstOrDefault().isTaken;
			if (isTakeIt == 1) {
				return true;
			} else {
				return false;
			}
		}

		public void insertChildVaccinations(string childName)
		{
			ChildVaccinations CV = new ChildVaccinations ();
			var VaccinationList = DB.Table<vaccinationTable> ().ToArray ();
			for(var i = 0; i < VaccinationList.Length; i++){
				CV.mother = pbcareApp.u.Email;
				CV.ChildName = childName;
				CV.VaccinationID = VaccinationList [i].VaccinationID;
				CV.isTaken = 0;
				DB.Insert (CV);
			}
		}

		public void updateIsTaken(bool isTakenCase , int VID , string childName){
			int takeVacc;

			if(isTakenCase){
				takeVacc = 1 ;
			}else{
				takeVacc = 0;
			}

			DB.Query<ChildVaccinations> ("UPDATE ChildVaccinations Set isTaken  = ? WHERE ChildName = ? and VaccinationID = ?", takeVacc, childName, VID);
		}

		public int getVaccinationDate(int VID)
		{
			return DB.Table<vaccinationTable> ().Where(v => v.VaccinationID == VID).FirstOrDefault().time;
		}
//		public string  InsertIntoBabyMonthly (int MonthNumber)
//		{
//			try {
//				// 
//				var BabyMonth = DB.Table<BabyMonthlyTable> ().Where (c => c.month == MonthNumber).FirstOrDefault ();
//				if (BabyMonth != null) {
//					return BabyMonth.info;
//				} else {
//					return "المعلومة غير محفوظة في الداتابيس";
//				}
//
//			} catch (Exception ex) {
//				Debug.WriteLine ("**** Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
//				return ex.ToString ();
//			}
//
//		}
	
	}
}

