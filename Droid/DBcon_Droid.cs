using System;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using pbcare.Droid;
using System.Data;
using Xamarin.Forms;

[assembly:Dependency (typeof(DBcon_Droid))]
namespace pbcare.Droid
{
	public class DBcon_Droid : DBRemoteConnection
	{
		MySqlConnection sqlconn;
		int lastID;
		string name;

		public int CreateUser (string name, string email, string pass )
		{
			try {
				// To prevent Exeption (No data is available for encoding 1252.)
				// https://components.xamarin.com/view/mysql-plugin
				new I18N.West.CP1252 (); 

				MySqlConnection sqlconn;
				string connsqlstring = "Database=pbcareMySQL;Data Source=us-cdbr-azure-west-c.cloudapp.net;User Id=b2aa2cc8b1637c;Password=b1aa0157; charset=utf8";
				sqlconn = new MySqlConnection (connsqlstring);
				System.Diagnostics.Debug.WriteLine (sqlconn.ToString ());
				sqlconn.Open ();

				String lastIDCmmd = "SELECT max(uid) FROM mybb_users";
				MySqlCommand nsqlcmd = new MySqlCommand (lastIDCmmd, sqlconn);
				var result = nsqlcmd.ExecuteScalar ();
				System.Diagnostics.Debug.WriteLine ("********* INt ID " + result);
				if (result != null) {
					lastID = Convert.ToInt32 (result);
					System.Diagnostics.Debug.WriteLine ("Last id = " + lastID);
				}
				lastID = lastID + 10;
				try{
				string queryString = "insert into users_mothers(email, Password, name, isPregnant, isSensorOn)" +
					"values ('" +email+"' , '"+pass+"','"+name+"',"+0+","+ 1 +") \n "; 
				
				MySqlCommand sqlcmd = new MySqlCommand (queryString, sqlconn);
				sqlcmd.ExecuteScalar ();
				System.Diagnostics.Debug.WriteLine (queryString);

				}catch(MySqlException ex){
					return 2;
				}
				sqlconn.Close ();	
				return 1;

			}catch(MySqlException ex){
				System.Diagnostics.Debug.WriteLine ("slslslsl 3 : " + ex.ToString ());
				return 2;

			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine ("slslslsl  : " + ex.ToString());
				return 0;
			}
		}

		public User Login (string email, string pass)
		{
			try {
				// To prevent Exeption (No data is available for encoding 1252.)
				// https://components.xamarin.com/view/mysql-plugin
				new I18N.West.CP1252 (); 

				MySqlConnection sqlconn;
				string connsqlstring = "Database=pbcareMySQL;Data Source=us-cdbr-azure-west-c.cloudapp.net;User Id=b2aa2cc8b1637c;Password=b1aa0157; charset=utf8";

				//string connsqlstring = "Server=104.209.43.4;Port=3306;database=pbcareMySQL;Uid=b2aa2cc8b1637c;Pwd=b1aa0157;charset=utf8";

				sqlconn = new MySqlConnection (connsqlstring);
				System.Diagnostics.Debug.WriteLine (sqlconn.ToString ());
				sqlconn.Open ();

				String lastIDCmmd = "SELECT * FROM pbcaremysql.users_mothers where email = '" + email + "' and Password = '" + pass + "'";

				User u = new User();

				using (MySqlCommand command = new MySqlCommand(lastIDCmmd, sqlconn))
				{
					
					using (MySqlDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							u.Email = reader.GetValue(0).ToString();
							u.name = reader.GetValue(2).ToString();
							u.isPregnant = (int) reader.GetValue(3);
							u.isSensorOn = (int) reader.GetValue(4);

							sqlconn.Close ();
							return u ;
						}
					}
				}
				sqlconn.Close ();
				return null ;


			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine ("saud" +ex.Message);
				return null ;
			}
		}

		public int CheckUser (string email)
		{
			try{
				MySqlConnection sqlconn;
				string connsqlstring = "Database=pbcareMySQL;Data Source=us-cdbr-azure-west-c.cloudapp.net;User Id=b2aa2cc8b1637c;Password=b1aa0157; charset=utf8";

				sqlconn = new MySqlConnection (connsqlstring);
				System.Diagnostics.Debug.WriteLine (sqlconn.ToString ());
				sqlconn.Open ();

				String lastIDCmmd = "SELECT * FROM pbcaremysql.users_mothers where email = '" + email + "'";
									
				MySqlCommand nsqlcmd = new MySqlCommand (lastIDCmmd, sqlconn);
				var result = nsqlcmd.ExecuteScalar ();
				if (result != null) {
					sqlconn.Close ();	
					return 0;
				} else {
					sqlconn.Close ();	
					return 1;
				}
			} catch (Exception ex) {
				return 2;
			}
		}

		public int checkDueDate(string email){
			try{
				MySqlConnection sqlconn;
				string connsqlstring = "Database=pbcareMySQL;Data Source=us-cdbr-azure-west-c.cloudapp.net;User Id=b2aa2cc8b1637c;Password=b1aa0157; charset=utf8";

				sqlconn = new MySqlConnection (connsqlstring);
				System.Diagnostics.Debug.WriteLine (sqlconn.ToString ());
				sqlconn.Open ();

				String lastIDCmmd = "SELECT email FROM pbcaremysql.PregnancyDuedateTable where email = '" + email + "'";
				MySqlCommand sqlcmd = new MySqlCommand (lastIDCmmd, sqlconn);
				var result = sqlcmd.ExecuteScalar ();
				System.Diagnostics.Debug.WriteLine (lastIDCmmd);
				if(result != null ){
					sqlconn.Close();
					return 0;
				}else{
					return 1 ;
				}
			} catch (Exception ex) {
				return 2;
			}
		}
			
		public int addDueDate(string email , string date){


			try{
				MySqlConnection sqlconn;
				string connsqlstring = "Database=pbcareMySQL;Data Source=us-cdbr-azure-west-c.cloudapp.net;User Id=b2aa2cc8b1637c;Password=b1aa0157; charset=utf8";

				sqlconn = new MySqlConnection (connsqlstring);
				System.Diagnostics.Debug.WriteLine (sqlconn.ToString ());
				sqlconn.Open ();
				try{
					string lastIDCmmd = "insert into PregnancyDuedateTable(email, dueDate)" +
						"values ('" +email+"' , '"+date+"') \n "; 
					
					MySqlCommand sqlcmd = new MySqlCommand (lastIDCmmd, sqlconn);
					sqlcmd.ExecuteScalar ();
					System.Diagnostics.Debug.WriteLine (lastIDCmmd);

				}catch(MySqlException ex){
					return 2;
				}
				sqlconn.Close ();	
				return 1;

				}catch (Exception ex) {
					System.Diagnostics.Debug.WriteLine ("slslslsl  : " + ex.ToString());
					return 0;
				}	
		}

		public int removeDueDate(string email){
			try{
				MySqlConnection sqlconn;
				string connsqlstring = "Database=pbcareMySQL;Data Source=us-cdbr-azure-west-c.cloudapp.net;User Id=b2aa2cc8b1637c;Password=b1aa0157; charset=utf8";

				sqlconn = new MySqlConnection (connsqlstring);
				System.Diagnostics.Debug.WriteLine (sqlconn.ToString ());
				sqlconn.Open ();
				try{
					string lastIDCmmd = "DELETE FROM PregnancyDuedateTable WHERE email = '"+ email +"'"; 

					MySqlCommand sqlcmd = new MySqlCommand (lastIDCmmd, sqlconn);
					sqlcmd.ExecuteScalar ();
					System.Diagnostics.Debug.WriteLine (lastIDCmmd);

				}catch(MySqlException ex){
					return 2;
				}
				sqlconn.Close ();	
				return 1;

			}catch(MySqlException ex){
				System.Diagnostics.Debug.WriteLine ("slslslsl 3 : " + ex.ToString ());
				return 2;

			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine ("slslslsl  : " + ex.ToString());
				return 0;
			}	
		}

		public string getDueDate(string email){
			try{
				MySqlConnection sqlconn;
				string connsqlstring = "Database=pbcareMySQL;Data Source=us-cdbr-azure-west-c.cloudapp.net;User Id=b2aa2cc8b1637c;Password=b1aa0157; charset=utf8";

				sqlconn = new MySqlConnection (connsqlstring);
				System.Diagnostics.Debug.WriteLine (sqlconn.ToString ());
				sqlconn.Open ();

				String lastIDCmmd = "SELECT dueDate FROM pbcaremysql.PregnancyDuedateTable where email = '" + email + "'";
				MySqlCommand sqlcmd = new MySqlCommand (lastIDCmmd, sqlconn);
				var result = sqlcmd.ExecuteScalar ();
				System.Diagnostics.Debug.WriteLine (lastIDCmmd);
				if(result != null ){
					sqlconn.Close();
					return result.ToString();
				}else{
					return "False" ;
				}
			} catch (Exception ex) {
				return "False2";
			}
		}

}
}



