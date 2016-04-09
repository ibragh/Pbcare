using System;

namespace pbcare
{
	public class BabyMonthly
	{
		public BabyMonthly ()
		{
		}
		public BabyMonthly(string m, string msg)
		{
			this.month = m;
			this.message = msg;
		}
		public string month { private set; get; }

		public string message { private set; get; }
	}
}

