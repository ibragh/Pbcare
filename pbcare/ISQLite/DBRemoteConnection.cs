using System;
using System.Collections.Generic;

namespace pbcare
{
	public interface DBRemoteConnection
	{
		int CreateUser(string name,string email,string pass);
		User Login(string email,string pass);
		int CheckUser (string email);
		int checkDueDate(string email);
		int addDueDate(string email, string dueDate);
		int removeDueDate(string email);
		string getDueDate(string email);


	}
}

