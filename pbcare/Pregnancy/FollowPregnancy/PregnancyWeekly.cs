using System;
using Xamarin.Forms;

namespace pbcare
{
	public class PregnancyWeekly
	{
		public PregnancyWeekly ()
		{

		}
		public PregnancyWeekly(string w, string msg)
		{
			this.week = w;
			this.message = msg;
		}

		public string week { private set; get; }

		public string message { private set; get; }

	}
}


