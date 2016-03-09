using System;
using SQLite;
namespace pbcare
{
	public interface ISQLite
	{
		SQLiteConnection GetConnection ();
	}
}

