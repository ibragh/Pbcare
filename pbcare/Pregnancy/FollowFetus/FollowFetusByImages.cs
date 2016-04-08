using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace pbcare
{
	public class FollowFetusByImages :  ContentPage
	{
		public FollowFetusByImages ()
		{
			this.Title = "متابعة الحمل الأسبوعي";
			BackgroundImage = "mainPB.jpg";

			string msg = "لا تحاولي مسح البقع الداكنة من على أنفك ووجنتيك وجبهتك." +
			             " إنها ليست أوساخًا—بل هي حالة شائعة في " +
			             "الحمل تسمى الكلف أو \"قناع الحمل.\" الهرمونات هي السبب في ظهور تلك البقع، وتعاني منها بعض السيدات الحوامل وليس كلهن." +
			             " كذلك فإن هرمونات الحمل مسؤولة عن ظهور الخط الأسود، وهو خط غامق يظهر من أسفل السرة إلى عظمة العانة";

			Label WeekLabel = new Label {
				Text = "الأسبوع ١٩",
				FontSize = 50,
				HorizontalOptions = LayoutOptions.Center, TextColor = Color.Red
			};
			Label messageLabel = new Label { 
				Text = msg,
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center,
			};

			Content = new  StackLayout {
				Children = {
					WeekLabel,
					messageLabel
				}

			};
		}
	}
	public class FollowFetusByImages2 :  ContentPage
	{
		public FollowFetusByImages2 ()
		{
			this.Title = "متابعة الحمل الأسبوعي";
			string msg = "لا تحاولي مسح البقع الداكنة من ا تحاولي مسح البقع الداكنة من على أنفك ووجنتيهوعلى أنفك ووجنتيهو خط غامق يظهر من أسفل السرة إلى عظمة العانة";

			Label WeekLabel = new Label {
				Text = "الأسبوع ٢٠ ",
				FontSize = 50,
				HorizontalOptions = LayoutOptions.Center, TextColor = Color.Red
			};
			Label messageLabel = new Label { 
				Text = msg,
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center,
			};

			Content = new  StackLayout {
				Children = {
					WeekLabel,
					messageLabel
				}

			};
		}
	}
	public class FollowFetusByImages1 :  ContentPage
	{
		public FollowFetusByImages1 ()
		{
			this.Title = "متابعة الحمل الأسبوعي";
			string msg = "لا تحا مسح اجبهتك." +
				" إنها ليست أوساخًا—بل هي حالة شائعة في " +
				"الحمل تسمى الكلف أو \"قنسيدات الحوامل وليس كلهن." +
				" كذلك فإن هرمونات الحمل مسؤولة عن ظهور الخط الأسود، وهو خط غامق يظهر من أسفل السرة إلى عظمة العانة";

			Label WeekLabel = new Label {
				Text = "الأسبوع ١٨",
				FontSize = 50,
				HorizontalOptions = LayoutOptions.Center, TextColor = Color.Red
			};
			Label messageLabel = new Label { 
				Text = msg,
				FontSize = 20,
				HorizontalOptions = LayoutOptions.Center,
			};

			Content = new  StackLayout {
				Children = {
					WeekLabel,
					messageLabel
				}

			};
		}
	}
}

