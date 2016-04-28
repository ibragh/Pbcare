using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace pbcare
{
	public class EveryChildCell : ViewCell
	{
		bool Locked = false ;
		public static INavigation Navigation { get; set; }
		public EveryChildCell ()
		{
			var childName = new Label {
				Text = "Label 1",
				TextColor = Color.White ,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start,

			};
			childName.SetBinding(Label.TextProperty, "ChildName");

			var childGender = new Label {
				Text = "Label 2",
				TextColor = Color.White ,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.Center,

			};
			childGender.SetBinding(Label.TextProperty, "gender");

			var info = new Button { 
				Image = "infoLogo.png",
				BackgroundColor = Color.Transparent,
				WidthRequest = 45,
				HeightRequest = 50,
				BorderRadius = 100 ,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Center
			};

			info.SetBinding(Button.CommandParameterProperty, "ChildName");
			info.Clicked += (sender, e) => {
				if(!Locked){
					Locked = true ;
					var b = (Button) sender;
					var t = b.CommandParameter;
					Baby c = pbcareApp.Database.getChildInfo(t+"" , pbcareApp.u.Email);
					((ListView)((StackLayout)b.ParentView).ParentView).Navigation.PushAsync(new FollowBabyMonthly(c));
				}
			};
			var vacc = new Button { 
				Image = "vaccinationLogo.png",
				BackgroundColor = Color.Transparent,
				WidthRequest = 45,
				HeightRequest = 50,
				BorderRadius = 100 ,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				VerticalOptions = LayoutOptions.Center
			};

			vacc.SetBinding(Button.CommandParameterProperty, "ChildName");
			vacc.Clicked += (sender, e) => {
				if(!Locked){
					Locked = true ;
					var b = (Button)sender;
					var t = b.CommandParameter;
					Baby c = pbcareApp.Database.getChildInfo (t + "", pbcareApp.u.Email);
					((ListView)((StackLayout)b.ParentView).ParentView).Navigation.PushAsync(new VaccinationList(c));
				}
			};

			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				Padding = new Thickness (15, 5, 10, 15),

				Children = {
					info, vacc ,

					new StackLayout {
						Spacing = 1,
						Padding = new Thickness (15, 5, 35, 15),
						Orientation = StackOrientation.Vertical,
						Children = { childName, childGender }
					},

				}
			};
		}

		protected override void OnAppearing ()
		{
			Locked = false ; 
		}
	}
}


