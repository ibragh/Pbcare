using System;
using System.IO;
using Xamarin.Forms;
using pbcare.Droid;

[assembly:Dependency (typeof(SQLite_Droid))]
namespace pbcare.Droid
{
	public class SQLite_Droid : ISQLite
	{
		public SQLite_Droid (){}
		public SQLite.SQLiteConnection GetConnection ()
		{
			var sqliteFilename = "pbcare.db";
			string documentsPath = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal); // Documents folder
			var path = Path.Combine(documentsPath, sqliteFilename);
			// Create the connection
			var conn = new SQLite.SQLiteConnection(path);
			// Return the database connection
			return conn;

		}
	}
}