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

		public int CreateUser (string name, string email, string pass)
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
				//string queryString = "insert into myusers values(\""+email+"\",\""+name+"\",\""+pass+"\")";
				string queryString = "insert into mybb_users(uid, username, password, salt, loginkey, email, postnum, " +
					"threadnum, avatar, " +
					"avatardimensions, avatartype, usergroup, additionalgroups, displaygroup, usertitle, regdate," +
					" lastactive, lastvisit, lastpost, website, icq, aim, yahoo, skype, google, birthday, " +
					"birthdayprivacy, signature, allownotices, hideemail, subscriptionmethod, invisible, receivepms, " +
					"receivefrombuddy, pmnotice, pmnotify, buddyrequestspm, buddyrequestsauto, threadmode, " +
					"showimages, showvideos, showsigs, showavatars, showquickreply, showredirect, ppp, tpp, daysprune," +
					" dateformat, timeformat, timezone, dst, dstcorrection, buddylist, ignorelist, style, away, " +
					"awaydate, returndate, awayreason, pmfolders, notepad, referrer, referrals, reputation, regip, " +
					"lastip, language, timeonline, showcodebuttons, totalpms, unreadpms, warningpoints, " +
					"moderateposts, moderationtime, suspendposting, suspensiontime, suspendsignature, " +
					"suspendsigtime, coppauser, classicpostbit, loginattempts, usernotes, sourceeditor)" +
					// Values of this query
					"Values" +
					"('" + lastID + "', '" + name + "', '" + pass + "', '', '', '" + email + "'," +
					" '0', '0', '', ''," +
					" '0', '5', '', '0', '', '1461437167', '1461437167', '1461437167', '0', '', '', ''," +
					" '', '', '', '', 'all', '', '1', '0', '0', '0', '1', '0', '1', '0', '1', '0', 'linear'," +
					" '1', '1', '1', '1', '1', '1', '0', '0', '0', '', '', '0', '0', '2', '', '', '0', '0'," +
					" '0', '0', '', '', '', '2', '0', '0', '', '', '', '46', '1', '0', '0', '0', '0', '0'," +
					" '0', '0', '0', '0', '0', '0', '1', '', '0')\n";
				MySqlCommand sqlcmd = new MySqlCommand (queryString, sqlconn);
				sqlcmd.ExecuteScalar ();
				System.Diagnostics.Debug.WriteLine (queryString);

				sqlconn.Close ();	
				return 1;
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine (ex.Message);
				return 0;
			}
		}

		public int Login (string email, string pass)
		{
			try {
				// To prevent Exeption (No data is available for encoding 1252.)
				// https://components.xamarin.com/view/mysql-plugin
				new I18N.West.CP1252 (); 

				MySqlConnection sqlconn;
				string connsqlstring = "Database = pbcareMySQL; Data Source = us-cdbr-azure-west-c.cloudapp.net; User Id = b2aa2cc8b1637c; Password=b1aa0157;";
				//string connsqlstring = "Server=104.209.43.4;Port=3306;database=pbcareMySQL;Uid=b2aa2cc8b1637c;Pwd=b1aa0157;charset=utf8";

				sqlconn = new MySqlConnection (connsqlstring);
				System.Diagnostics.Debug.WriteLine (sqlconn.ToString ());
				sqlconn.Open ();

				String lastIDCmmd = "SELECT username FROM pbcaremysql.mybb_users where email = '" + email + "' and password = '" + pass + "'";
				MySqlCommand nsqlcmd = new MySqlCommand (lastIDCmmd, sqlconn);
				var result = nsqlcmd.ExecuteScalar ();
				System.Diagnostics.Debug.WriteLine ("********* INt ID " + result);
				if (result == null) {
					sqlconn.Close ();	
					return 0;
				} else {
					name = result.ToString ();
					MessagingCenter.Send<pbcareApp, string> ((pbcareApp)Application.Current, "1", name);

					sqlconn.Close ();	
					return 1;
				}
			} catch (Exception ex) {
				System.Diagnostics.Debug.WriteLine (ex.Message);
				return 0;
			}
		}
	}
	/*
		public List<String> LoadAllItemFromMySQL ()
		{
			List<String> products = new List<String> ();
			try {
				GetConnection (true);
				DataSet tickets = new DataSet ();
				string queryString = "select item.NAME from ITEM as item";
				MySqlDataAdapter adapter = new MySqlDataAdapter (queryString, sqlconn);
				adapter.Fill (tickets, "Item");
				foreach (DataRow row in tickets.Tables["Item"].Rows) {
					products.Add (row [0].ToString ());
				}

				sqlconn.Close ();
			} catch (Exception e) {
				Console.Write (e.Message);
			}
			return products;
		}
	}
	*/
}

