using System;

namespace pbcare
{

	public class PregnancyDuedateTable
	{
		public string email { get; set; }

		public string dueDate { get; set; }

		public PregnancyDuedateTable ()
		{
		}

	}

	public class PregnancyWeeklyTable
	{
		public int week { get; set; }

		public string info { get; set; }

		public PregnancyWeeklyTable ()
		{
		}

	}

	public class UserLoggedIn
	{
		public int loggedIn { get; set; }

		public string email { get; set; }

		public UserLoggedIn ()
		{
		}

	}
}

