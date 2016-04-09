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
			this.Title = "حملي";


			Button AddPregnancy = new Button {
				Text = "إضافة حمل",
				Image = "plus.png",
				BorderRadius = 30,
				HorizontalOptions = LayoutOptions.Start,
				TextColor = Color.FromHex ("#F7F7F7"),
				WidthRequest = 200,
				FontAttributes = FontAttributes.Bold,
				BackgroundColor = Color.FromHex ("#000080"),
				BorderColor = Color.FromHex ("#000080"),
				BorderWidth = 1,
			};
			Button FollowPregnancy = new Button {
				Text = "متابعة حملي ",
				Image = "pregnant.png",
				BorderRadius = 30,
				HorizontalOptions = LayoutOptions.End,
				TextColor = Color.FromHex ("#F7F7F7"),
				FontAttributes = FontAttributes.Bold,
				WidthRequest = 200,
				BackgroundColor = Color.FromHex ("#000080"),
				BorderColor = Color.FromHex ("#000080"),
				BorderWidth = 2,
			};
			Button FollowFetusImages = new Button {
				Text = "متابعة تطور الجنين بالصور",
				Image = "fetus.png",
				BorderRadius = 30,
				HorizontalOptions = LayoutOptions.Start,
				TextColor = Color.FromHex ("#F7F7F7"),
				FontAttributes = FontAttributes.Bold,
				WidthRequest = 200,
				BackgroundColor = Color.FromHex ("#000080"),
				BorderColor = Color.FromHex ("#000080"),
				BorderWidth = 2,
			
			};
			Button FollowFetusWeekly = new Button {
				Text = "متابعة تطور الجنين بالأسابيع",
				Image = "fetus.png",
				BorderRadius = 30,
				HorizontalOptions = LayoutOptions.End,
				TextColor = Color.FromHex ("#F7F7F7"),
				FontAttributes = FontAttributes.Bold,
				WidthRequest = 200,
				BackgroundColor = Color.FromHex ("#000080"),
				BorderColor = Color.FromHex ("#000080"),
				BorderWidth = 2 ,
				
			};

			AddPregnancy.Clicked += AddPregnancyClicked;
			FollowPregnancy.Clicked += FollowPregnancyWeeklyClicked;
			FollowFetusImages.Clicked += FollowFetusByImagesClicked;
			FollowFetusWeekly.Clicked += FollowFetusWeeklyClicked;


			Content = new StackLayout {
				VerticalOptions = LayoutOptions.Center, Padding = 20,
				Children = {
				//	la,
					AddPregnancy,
					FollowPregnancy,
					FollowFetusImages,
					FollowFetusWeekly,
				}
			};

		}

		public void AddPregnancyClicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new AddPregnancyPage ());
		}

		public void FollowPregnancyWeeklyClicked (object sender, EventArgs e)
		{

			if(pbcareApp.FinaldueDate.GetHashCode() == 0){
				DisplayAlert ("Error","You should Add pregnancy","OK");
			}else{
				sendNotification ();
				Navigation.PushAsync (new FollowPregnancy ());
			}
		}

		public void FollowFetusByImagesClicked (object sender, EventArgs e)
		{
			if (pbcareApp.FinaldueDate.GetHashCode() == 0) {
				DisplayAlert ("Error", "You should Add pregnancy", "OK");
			} else {
				// Only for testing

				Navigation.PushAsync (new FollowFetusByImages ());
			}
		}

		public void FollowFetusWeeklyClicked (object sender, EventArgs e)
		{
			if (pbcareApp.FinaldueDate.GetHashCode() == 0) {
				DisplayAlert ("Error", "You should Add pregnancy", "OK");
			} else {
				Navigation.PushAsync (new FollowFetusWeekly ());
			}
		}

		public void sendNotification ()
		{
			Notifications.Instance.Send ("Notification","I got notification for ABCD",when: TimeSpan.FromSeconds (2));
		}

	}
}

