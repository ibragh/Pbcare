using System;
using Xamarin.Forms;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace pbcare
{
	public class DatabaseClass
	{
		private SQLiteConnection DB;
		//static locker so that we can use that to prevent race condtion or conflict
		static object locker = new object ();

		public DatabaseClass ()
		{
			DB = DependencyService.Get<ISQLite> ().GetConnection ();
			DB.CreateTable<User> ();
		}

		public int saveUser (User user)
		{
			
			lock (locker) {
				if (user.ID != 0) {
					DB.Update (user);
					return user.ID;
				} else {
					return DB.Insert (user);
				}
			}

		}

		public IEnumerable<User> GetUsers ()
		{
			lock (locker) {
				return (from c in DB.Table<User> ()
				        select c).ToList ();
			}

		}

		public User getUser (int id)
		{

			lock (locker) {
				return DB.Table<User> ().Where (c => c.ID == id)
					.FirstOrDefault ();
			}
		}

		public int deleteUser (int id)
		{
			lock (locker) {
				return DB.Delete<User> (id);
			}
		}

	
	}
}

