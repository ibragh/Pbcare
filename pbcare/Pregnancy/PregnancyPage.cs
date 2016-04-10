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
			BackgroundImage = "back.png";

			var welcomeLogo = new Image{ 
				Source = "logo.png"
			};

			Button AddPregnancy = new Button {
				Text = "إضافة حمل",
				Image = "plus.png",
				TextColor = Color.FromRgb(238,238,238),
				BackgroundColor = Color.FromRgb(59,89,153),
				BorderColor = Color.FromRgb(59,89,153),
				BorderWidth = 1,
			};
			Button FollowPregnancy = new Button {
				Text = "متابعة حملي ",
				Image = "pregnant.png",
				TextColor = Color.FromRgb(238,238,238),
				BackgroundColor = Color.FromRgb(59,89,153),
				BorderColor = Color.FromRgb(59,89,153),
				BorderWidth = 2,
			};
			Button FollowFetusImages = new Button {
				Text = "متابعة تطور الجنين بالصور",
				Image = "fetus.png",
				TextColor = Color.FromRgb(238,238,238),
				BackgroundColor = Color.FromRgb(59,89,153),
				BorderColor = Color.FromRgb(59,89,153),
				BorderWidth = 2,
			
			};
			Button FollowFetusWeekly = new Button {
				Text = "متابعة تطور الجنين بالأسابيع",
				Image = "fetus.png",
				TextColor = Color.FromRgb(238,238,238),
				WidthRequest = 200,
				BackgroundColor = Color.FromRgb(59,89,153),
				BorderColor = Color.FromRgb(59,89,153),
				BorderWidth = 2 ,
				
			};

			AddPregnancy.Clicked += AddPregnancyClicked;
			FollowPregnancy.Clicked += FollowPregnancyWeeklyClicked;
			FollowFetusImages.Clicked += FollowFetusByImagesClicked;
			FollowFetusWeekly.Clicked += FollowFetusWeeklyClicked;


			Content = new ScrollView{

				Content = new StackLayout {
				Orientation = StackOrientation.Vertical,
				Padding = new Thickness(30,20,30,0),
				VerticalOptions = LayoutOptions.FillAndExpand,
				Children = {
					welcomeLogo,
					new StackLayout{
							Padding = new Thickness(0,10,0,20),
							Children = {
									AddPregnancy,
									FollowPregnancy,
									FollowFetusImages,
									FollowFetusWeekly,

										}
									}
				     	}
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

