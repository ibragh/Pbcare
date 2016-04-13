using System;
using Xamarin.Forms;

namespace pbcare
{
	public class Child 
	{
		
		public string mother { get; set; }
		public string ChildName { get; set; }
		public string birthDate { get; set; }
		public string gender { get; set;}


		public Child (){
//			this.name = n;
//			this.gender = g;
		}

	}

	public class ChildInfo : ContentPage 
	{
		public ChildInfo(Child c){
			
			Title = c.ChildName;

			Label name = new Label {
				Text = c.ChildName
			};

			DateTime birthdate = DateTime.ParseExact (c.birthDate, "ddMMyyyy", null);
			TimeSpan difference = birthdate - DateTime.Now.AddDays (-1);

			double PastDays = (720 - (int)difference.TotalDays);
			int old = (int)Math.Ceiling (PastDays / 30);

			Label info = new Label {
				Text = ""+ old
			};

			Content = new StackLayout {
				Children = {
					name, info
				}
			};
		}
	}


}

