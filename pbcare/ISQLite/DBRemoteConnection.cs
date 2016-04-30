using System;

namespace pbcare
{
	public interface DBRemoteConnection
	{
		int CreateUser(string name,string email,string pass);
		int Login(string email,string pass);
	}
}

