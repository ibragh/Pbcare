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
			this.messege = msg;
		}

		public string week { private set; get; }

		public string messege { private set; get; }

	}
}


