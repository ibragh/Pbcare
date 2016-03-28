using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Acr.Notifications;

namespace pbcare
{
	public partial class PregnancyPage : ContentPage
	{
		public PregnancyPage ()
		{
			Button AddPregnancy = new Button {Text = "إضافة حمل",
				TextColor = Color.FromHex ("#F7F7F7"),
				WidthRequest = 200,
				FontAttributes = FontAttributes.Bold,
				BackgroundColor = Color.FromHex ("#FF2A68"),
				BorderColor = Color.FromHex ("#FF2A68"), 
				BorderWidth = 1,
			};
			Button FollowPregnancy = new Button {Text = "متابعة حملي ",
				TextColor = Color.FromHex ("#F7F7F7"),
				FontAttributes = FontAttributes.Bold,
				WidthRequest = 200,
				BackgroundColor = Color.FromHex ("#FF2A68"),
				BorderColor = Color.FromHex ("#FF2A68"),
				BorderWidth = 1,
			};
			Button FollowFetusImages = new Button {Text = "متابعة تطور الجنين بالصور",
				TextColor = Color.FromHex ("#F7F7F7"),
				FontAttributes = FontAttributes.Bold,
				WidthRequest = 200,
				BackgroundColor = Color.FromHex ("#FF2A68"),
				BorderColor = Color.FromHex ("#FF2A68"),
				BorderWidth = 1,
			
			};
			Button FollowFetusWeekly = new Button {Text = "متابعة تطور الجنين بالأسابيع",
				TextColor = Color.FromHex ("#F7F7F7"),
				FontAttributes = FontAttributes.Bold,
				WidthRequest = 200,
				BackgroundColor = Color.FromHex ("#FF2A68"),
				BorderColor = Color.FromHex ("#FF2A68"),
				BorderWidth = 1,
				
			};

			AddPregnancy.Clicked += AddPregnancyClicked;
			FollowPregnancy.Clicked += FollowPregnancyWeeklyClicked ;
			FollowFetusImages.Clicked += FollowFetusByImagesClicked ;
			FollowFetusWeekly.Clicked += FollowFetusWeeklyClicked ;

			StackLayout NewUser = new StackLayout {
				VerticalOptions = LayoutOptions.Center, Padding = 20,
				Children = {
					AddPregnancy,

				}
			};
			StackLayout RigesteredUser = new StackLayout {
				VerticalOptions = LayoutOptions.Center, Padding = 20,
				Children = {
					FollowPregnancy,
					FollowFetusImages,
					FollowFetusWeekly
				}
			};

			if (pbcareApp.FinaldueDate.GetHashCode() == 0) {
				Content = NewUser;
			} else {
				Content = RigesteredUser;
			}
		}

		public void AddPregnancyClicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new AddPregnancyPage ());
		}

		public void FollowPregnancyWeeklyClicked (object sender, EventArgs e)
		{


			Navigation.PushAsync (new FollowPregnancy ());
		}

		public void FollowFetusByImagesClicked (object sender, EventArgs e)
		{
			// Only for testing
			sendNotification ();
			Navigation.PushAsync (new FollowFetusByImages ());
		}

		public void FollowFetusWeeklyClicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new FollowFetusWeekly ());
		}

		public void sendNotification ()
		{
			Notifications.Instance.Send ("ABC", "I got a notification", when: TimeSpan.FromSeconds (20));

		}

	}
}

