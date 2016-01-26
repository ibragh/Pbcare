using System;
using Xamarin.Forms;

namespace pbacre
{
	public class mainmenu : ContentPage
	{
		// this integer for testing.. because there will be diffrent content for diffrent reasons
		int s = 1;
		public mainmenu ()
		{
			
		
				Title = "Pregnancy & Baby Care";

				var PregnancyInfo = new Button { HorizontalOptions = LayoutOptions.Center,
					BorderWidth = 1,
					Text = "Pregnancy Care",
					//Command = new Command((obj) => Navigation.PushAsync(new dueDate()))
				};
				var BabyCareInfo = new Button {
					HorizontalOptions = LayoutOptions.Center,
					BorderWidth = 1,
					Text = "Baby Care",
					//Command = new Command((obj) => Navigation.PushAsync(new babyInfo()))
				};
				var Community = new Button {
					HorizontalOptions = LayoutOptions.Center,
					BorderWidth = 1,
					Text = "Community",
					//Command = new Command((obj) => Navigation.PushAsync(new community()))

				};
				var Pregnancy = new Button {
					HorizontalOptions = LayoutOptions.Center,
					BorderWidth = 1,
					Text = "Pregnancy Care",
					//Command = new Command((obj) => Navigation.PushAsync(new HomePage(CarouselLayout.IndicatorStyleEnum.Pregnancy)))

				};
				var BabyCare = new Button {
					HorizontalOptions = LayoutOptions.Center,
					BorderWidth = 1,
					Text = "Baby Care",
					//Command = new Command((obj) => Navigation.PushAsync(new HomePage(CarouselLayout.IndicatorStyleEnum.Baby)))
				};

				var stack1 = new StackLayout {
					Orientation = StackOrientation.Vertical,
					VerticalOptions = LayoutOptions.Center,
					Spacing = 20,
					Children = {
						PregnancyInfo,
						BabyCareInfo,
						Community
					}
				};
				var stack2 = new StackLayout {
					Orientation = StackOrientation.Vertical,
					VerticalOptions = LayoutOptions.Center,
					Spacing = 20,
					Children = {
						Pregnancy,
						BabyCareInfo,
						Community
					}
				};
				var stack3 = new StackLayout {
					Orientation = StackOrientation.Vertical,
					VerticalOptions = LayoutOptions.Center,
					Spacing = 20,
					Children = {
						PregnancyInfo,
						BabyCare,
						Community
					}
				};
				var stack4 = new StackLayout {
					Orientation = StackOrientation.Vertical,
					VerticalOptions = LayoutOptions.Center,
					Spacing = 20,
					Children = {
						Pregnancy,
						BabyCare,
						Community
					}
				};

			// here we will use the integer (s) to specify which content we want.. depending on user info
				switch(s){

				case 1: // There is no record 
					Content = stack1;
					break;
				case 2: // there is Pregnancy record only
					Content = stack2;
					break;
				case 3: // there is baby record only
					Content = stack3;
					break;
				case 4: // there are records for baby and pregnancy
					Content = stack4;
					break;


				}
		}
	}
}

