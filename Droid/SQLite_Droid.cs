using System;
using System.IO;
using Xamarin.Forms;
using pbcare.Droid;

[assembly:Dependency (typeof(SQLite_Droid))]
namespace pbcare.Droid
{
	public class SQLite_Droid : ISQLite
	{
		public SQLite_Droid ()
		{
		}

		public SQLite.SQLiteConnection GetConnection ()
		{
			string docs = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
			string databaseFilePath = Path.Combine(docs, "pbcare.db");
			//var path = "/Users/ibrahim/Projects/pbcare_resources/pbcare.db";
			// This is where we copy in the prepopulated database

			var conn = new SQLite.SQLiteConnection (databaseFilePath);

			// Return the database connection 
			return conn;

		}
	}
}




