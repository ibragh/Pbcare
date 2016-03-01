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


		public DatabaseClass (){

			DB = DependencyService.Get<ISQLite> ().GetConnection ();

		}

		public bool checkLogin(string email,string password){
			
			 
			if (DB.Table<User> ().Where (user => user.Email == email && user.Password == password).FirstOrDefault() != null) {
				return true;
			} else {
				return false;
			}
		}

		public bool signup(string email,string password,string name){
			User u = new User ();
			u.Email = email;
			u.Password = password;
			u.name = name;
			if (DB.Table<User> ().Where (user => user.Email == email && user.Password == password).FirstOrDefault() != null) {
				return false;
			} else {
				DB.Insert (u);
				return true;
			}

		}

	
	}
}

