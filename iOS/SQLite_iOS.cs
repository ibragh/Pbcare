using System;
using System.IO;
using Xamarin.Forms;
using pbcare.iOS;


[assembly:Dependency (typeof(SQLite_iOS))]
namespace pbcare.iOS
{
	public class SQLite_iOS : ISQLite
	{
		public SQLite_iOS ()
		{
		}

		public SQLite.SQLiteConnection GetConnection ()
		{

			var sqliteFilename = "pbcare.db";
//			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal); // Documents folder
//			string libraryPath = Path.Combine (documentsPath, "..", "Library"); // Library folder
//			var path = Path.Combine (libraryPath, sqliteFilename);


			var path = "/Users/ibrahim/Projects/pbcare_resources/pbcare.db";
			// This is where we copy in the prepopulated database

			if (!File.Exists (path)) {
				File.Copy (sqliteFilename, path);
			}

			var conn = new SQLite.SQLiteConnection (path);

			// Return the database connection 
			return conn;
		}



	}
}


