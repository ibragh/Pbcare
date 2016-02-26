using System;

namespace pbcare
{
	public class Child
	{
		//public Image ChildImage { get; set; }
		public string name { get; set; }
		//public DatePicker birthDate { get; set; }
		public string gender { get; set;}

		public Child (string n , string g){
			this.name = n;
			this.gender = g;
		}

	}

}

