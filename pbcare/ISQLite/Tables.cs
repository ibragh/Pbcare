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

	public class BabyMonthlyTable
	{
		public int month { private set; get; }

		public string info { private set; get; }

		public BabyMonthlyTable ()
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
	public class FetusWeeklyTable
	{
		public int week { get; set; }

		public string info { get; set; }

		public FetusWeeklyTable ()
		{
		}

	}
	public class Months
	{
		public int month { get; set; }

		public string Info { get; set; }

		public Months ()
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

	public class vaccinationTable
	{
		public int VaccinationID { get; set; }

		public string name { get; set; }

		public string info { get; set; }

		public int time { get; set; }

		public vaccinationTable ()
		{
		}
			
	}

	public class ChildVaccinations
	{
		public string mother  { get; set; }
		public string ChildName { get; set; }

		public int VaccinationID { get; set; }

		public int isTaken { get; set; }

		public ChildVaccinations()
		{
		}
	}
}

