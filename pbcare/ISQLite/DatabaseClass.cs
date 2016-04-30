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
			DB.CreateTable<Baby> ();
			DB.CreateTable<PregnancyDuedateTable> ();
			DB.CreateTable<PregnancyWeeklyTable> ();
			DB.CreateTable<FetusWeeklyTable> ();
			DB.CreateTable<UserLoggedIn> ();
			DB.CreateTable<BabyMonthlyTable> ();
			DB.CreateTable<ChildVaccinations> ();
		}
		//=============================================================================================
		// User Methods

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
					var _user = DB.Table<User> ().Where (c => c.Email == pbcareApp.u.Email).FirstOrDefault ();
					pbcareApp.u.isPregnant = _user.isPregnant;
					pbcareApp.u.name = _user.name; 
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
					Debug.WriteLine ("******************** :" + ex.ToString ());
					return true;
				} else {
					return false;
				}
			}
		}

		public void User_Loggedin (bool status)
		{
			try {
				UserLoggedIn u = new UserLoggedIn ();
				if (status) {
					u.loggedIn = 1; // will delete it later
					u.email = pbcareApp.u.Email;
					DB.Insert (u);
				} else {
					DB.DeleteAll<UserLoggedIn> ();
				}
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}
		}

		// check login in email & password are match in db
		public bool checkLogin (string email, string password)
		{
			
				int dbr = DependencyService.Get<DBRemoteConnection> ().Login (email, password); // remotly
				
				if (dbr == 1) {
					string name = "";
					MessagingCenter.Subscribe<DBRemoteConnection, string> (this, "1", (mysender, arg) => {
						Debug.WriteLine ("aaaaaaaa user name = " + arg);
						name = arg;
					});
					add_UserLocally (email, password, name);
					return true;
				} else {
					var Logeduser = DB.Table<User> ().Where (user => user.Email == email && user.Password == password).FirstOrDefault ();
					if (Logeduser != null) {
						return true;
					} else {
						return false;
					}
				}

		}

		public User get_User (string email)
		{
			return DB.Table<User> ().Where (user => user.Email == email).FirstOrDefault ();
		}
		public bool add_UserLocally (string email, string password, string name)
		{
			try {
				if (DB.Table<User> ().Where (user => user.Email == email).FirstOrDefault () != null) {
					return false;
				} else {
					User u = new User ();
					u.Email = email;
					u.Password = password;
					u.name = name;
					u.isPregnant = 0;
					u.isSensorOn = 0;
					DB.Insert (u); // locally
					return true;
				}
			} catch (SQLiteException ex) {
				Debug.WriteLine ("****&&&^^^ Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return false;

			} catch (Exception ex) {
				Debug.WriteLine ("**** Method id: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return false;
			} 
		}

		// check signup entries
		public bool add_User (string email, string password, string name)
		{
			try {
				if (DB.Table<User> ().Where (user => user.Email == email).FirstOrDefault () != null) {
					return false;
				} else {
					User u = new User ();
					u.Email = email;
					u.Password = password;
					u.name = name;
					u.isPregnant = 0;
					u.isSensorOn = 0;
					DB.Insert (u); // locally
					int dbr = DependencyService.Get<DBRemoteConnection> ().CreateUser (name, email, password); // remotly
					Debug.WriteLine (dbr + " return value from db remotly create");
					if (dbr == 0) {
						return false;
					}
					return true;
				}
			} catch (SQLiteException ex) {
				Debug.WriteLine ("****&&&^^^ Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return false;

			} catch (Exception ex) {
				Debug.WriteLine ("**** Method id: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return false;
			} 
		}

		//
		public void update_IsPregnant (int PregnancyStatus)
		{
			try {
				DB.Query<User> ("UPDATE User Set isPregnant  = ? WHERE email = ? ", PregnancyStatus, pbcareApp.u.Email);
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}
		}

		public void update_UserName (string newName)
		{
			try {

				DB.Query<User> ("UPDATE User Set name = ? WHERE email = ? ", newName, pbcareApp.u.Email);

			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}
		}

		public void update_Password (string newPass)
		{

			try {
				DB.Query<User> ("UPDATE User Set Password = ? WHERE email = ? ", newPass, pbcareApp.u.Email);

			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}
		}

		public void updateSensorOn (int status)
		{
			try {
				DB.Query<User> ("UPDATE User Set isSensorOn = ? WHERE email = ? ", status, pbcareApp.u.Email);

			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}
		}
		// ============================================================================================================
		//Prgnancy Methods
		public int AddPregnancy (string email, string date)
		{

			try {
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

		public string GetDueDate ()
		{
			try {
				return DB.Table<PregnancyDuedateTable> ().Where (i => i.email == pbcareApp.u.Email).FirstOrDefault ().dueDate;
			} catch (Exception ex) {
				Debug.WriteLine ("**** Method id: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return "false";
			}
		}

		public void removeDueDate ()
		{
			try {
				DB.Query<PregnancyDuedateTable> ("DELETE FROM PregnancyDuedateTable WHERE email = ?", pbcareApp.u.Email);
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}
		}



		public string  getPregnancyWeeks (int WeekNumber)
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

		public string  getFetusWeeks (int WeekNumber)
		{
			try {
				// 
				var PregnancyWeek = DB.Table<FetusWeeklyTable> ().Where (c => c.week == WeekNumber).FirstOrDefault ();
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
		//==============================================================================
		// CHild Methods ...

		public bool AddChild (Baby child)
		{
			try {
				DB.Insert (child);
				return true;

				Debug.WriteLine ("**** Method is: " + this.ToString ());

			} catch (SQLiteException ex) {
				Debug.WriteLine ("****&&&^^^ Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return false;

			} catch (Exception ex) {
				Debug.WriteLine ("****111111^^^ Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return false;
			}
		}

		public bool RemoveChild (string child)
		{
			try {
				DB.Query<Baby> ("DELETE FROM Baby WHERE ChildName = ? and mother = ? ", child, pbcareApp.u.Email);
				return true; 

			} catch (Exception ex) {
				Debug.WriteLine ("****111111^^^ Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return false;
			}
		}

		public Baby getChildInfo (string name, string email)
		{

			try {
				return DB.Table<Baby> ().Where (c => c.ChildName == name && c.mother == email).FirstOrDefault ();

			} catch (Exception ex) {
				Debug.WriteLine ("****fffff Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return null;
			}
		}


		public string  getChildMonth (int MonthNumber)
		{
			try {
				
				var month = DB.Table<BabyMonthlyTable> ().Where (c => c.month == MonthNumber).FirstOrDefault ();
				if (month != null) {
					return month.info;
				} else {
					return "المعلومة غير محفوظة في قاعدة البيانات ";
				}

			} catch (Exception ex) {
				//Debug.WriteLine ("**** Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return ex.ToString ();
			}


		}

		public List<Baby> getChildren (string email)
		{

			try {
				return  DB.Table<Baby> ().Where (c => c.mother == email).ToList ();
			} catch (Exception ex) {
				Debug.WriteLine ("**** Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return null;
			}
		}

		//===============================================================
		// vaccinations mthods ....

		public List<vaccinationTable> getVaccinationsList ()
		{
			try {
				return DB.Table<vaccinationTable> ().ToList ();
			} catch (Exception ex) {
				Debug.WriteLine ("**** Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return null;
			}
		}

		public int is_vaccination_taken (int VID, string childName)
		{
			try {
				var isTakeIt = DB.Table<ChildVaccinations> ().Where (v => v.VaccinationID == VID && v.ChildName == childName && v.mother == pbcareApp.u.Email).FirstOrDefault ().isTaken;
				if (isTakeIt == 1) {
					return 1;
				} else {
					return 0;
				}
			} catch (Exception ex) {
				return 0;
				Debug.WriteLine (ex.Message);
			}
		}

		public void set_CV_Sechduale (string childName)
		{
			ChildVaccinations CV = new ChildVaccinations ();
			var VaccinationList = DB.Table<vaccinationTable> ().ToArray ();
			for (var i = 0; i < VaccinationList.Length; i++) {
				CV.mother = pbcareApp.u.Email;
				CV.ChildName = childName;
				CV.VaccinationID = VaccinationList [i].VaccinationID;
				CV.isTaken = 0;
				DB.Insert (CV);
			}
		}

		public bool delete_CV_Sechduale (string oldChildName)
		{
			try {
				DB.Query<ChildVaccinations> ("DELETE FROM ChildVaccinations WHERE ChildName = ? and mother = ? ", oldChildName, pbcareApp.u.Email);
				return true;

			} catch (Exception ex) {
				Debug.WriteLine ("****4444 Method is: " + this.ToString () + " Exeption is :" + ex.ToString ());
				return false;
			}
		}

		public void update_IsTaken (int isTakenCase, int VID, string childName)
		{
			try {
				
				DB.Query<ChildVaccinations> ("UPDATE ChildVaccinations Set isTaken = ? WHERE VaccinationID = ? ", isTakenCase, VID);
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}
		}

		public int getVaccinationDate (int VID)
		{
			try {
				return DB.Table<vaccinationTable> ().Where (v => v.VaccinationID == VID).FirstOrDefault ().time;
			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
				return 000;
			}
		}

		public void Update_childName_inChildVaccinationTable (string newName, string oldName)
		{
			try {

				DB.Query<ChildVaccinations> ("UPDATE ChildVaccinations Set ChildName = ? WHERE ChildName = ? and mother = ?", newName, oldName, pbcareApp.u.Email);

			} catch (Exception ex) {
				Debug.WriteLine (ex.Message);
			}
		}


	}
}
