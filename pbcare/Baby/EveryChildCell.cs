using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace pbcare
{
	public class EveryChildCell : ViewCell
	{
		public static INavigation Navigation { get; set; }
		public EveryChildCell ()
		{
			var childName = new Label {
				Text = "Label 1",
				TextColor = Color.Black ,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold
			};
			childName.SetBinding(Label.TextProperty, "name");

			var childGender = new Label {
				Text = "Label 2",
				TextColor = Color.Black ,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
			};
			childGender.SetBinding(Label.TextProperty, "gender");

			var info = new Button { 
				Image = "infoLogo.png",
				BackgroundColor = Color.Transparent,
				WidthRequest = 45,
				HeightRequest = 50,
				BorderRadius = 100 ,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center
			};

			info.SetBinding(Button.CommandParameterProperty, "name");
			info.Clicked += (sender, e) => {
				var b = (Button) sender;
//				var t = b.CommandParameter;
//				Child c = pbcareApp.Database.getChildFromDB(t+"" , pbcareApp.u.Email);
				((ListView)((StackLayout)b.ParentView).ParentView).Navigation.PushAsync(new FollowBabyMonthly());

			};
			var vacc = new Button { 
				Image = "vaccinationLogo.png",
				BackgroundColor = Color.Transparent,
				WidthRequest = 45,
				HeightRequest = 50,
				BorderRadius = 100 ,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				VerticalOptions = LayoutOptions.Center
			};

			vacc.SetBinding(Button.CommandParameterProperty, "name");
			vacc.Clicked += (sender, e) => {
				var b = (Button)sender;
				var t = b.CommandParameter;
				Child c = pbcareApp.Database.getChildFromDB (t + "", pbcareApp.u.Email);
				((ListView)((StackLayout)b.ParentView).ParentView).Navigation.PushAsync(new VaccinationList(c));
			};

			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness (15, 5, 5, 15),

				Children = {

					new StackLayout {
						Padding = new Thickness (15, 5, 5, 15),
						Orientation = StackOrientation.Vertical,
						Children = { childName, childGender }
					},
					vacc , info
				}
			};
		}
	}
}


