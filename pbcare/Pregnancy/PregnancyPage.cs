using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Acr.Notifications;
using System.Diagnostics;

namespace pbcare
{
	public partial class PregnancyPage : ContentPage
	{
		
		Button AddPregnancy, FollowPregnancy, FollowFetusImages, FollowFetusWeekly, finishPreg_  ;
		Image s = new Image { Source = "notPregnant2.png" };

		public PregnancyPage ()
		{
			this.Title = "حملي";
			BackgroundColor = Color.FromRgb (94, 196, 225);

			AddPregnancy = new Button {
				Text = "إضافة حمل",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
			};
			FollowPregnancy = new Button {
				Text = " حــمــلــي ",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
			};

			FollowFetusImages = new Button {
				Text = "متابعة الجنين بالصور",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
			};

			FollowFetusWeekly = new Button {
				Text = "متابعة الجنين بالأسابيع",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
			};

			finishPreg_ = new Button {
				Text = "تــــمت الــولادة",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#5069A1"),
				BorderColor = Color.FromHex("#5069A1"),
			};

			AddPregnancy.Clicked += AddPregnancyClicked;
			FollowPregnancy.Clicked += FollowPregnancyWeeklyClicked;
			FollowFetusImages.Clicked += FollowFetusByImagesClicked;
			FollowFetusWeekly.Clicked += FollowFetusWeeklyClicked;
			finishPreg_.Clicked += OnAlertYesNoClicked ;

		}


		public void AddPregnancyClicked (object sender, EventArgs e)
		{
			Navigation.PushAsync (new AddPregPage ());
		}

		public void FollowPregnancyWeeklyClicked (object sender, EventArgs e)
		{

			if(pbcareApp.u.isPregnant == 0){
				DisplayAlert ("Error","You should Add pregnancy","OK");
			}else{
				Navigation.PushAsync (new FollowPregnancy ());
			}
		}

		public void FollowFetusByImagesClicked (object sender, EventArgs e)
		{
			if (pbcareApp.u.isPregnant == 0) {
				DisplayAlert ("Error", "You should Add pregnancy", "OK");
			} else {
				Navigation.PushAsync (new FollowFetusByImages ());
			}
		}

		public void FollowFetusWeeklyClicked (object sender, EventArgs e)
		{
			if (pbcareApp.u.isPregnant == 0) {
				DisplayAlert ("Error", "You should Add pregnancy", "OK");
			} else {
				Navigation.PushAsync (new FollowFetusWeekly ());
			}
		}

		async void OnAlertYesNoClicked (object sender, EventArgs e)
		{
			var answer = await DisplayAlert ("تمت الولادة  ", "هل أنتي متأكدة من إنهاء جميع معلومات الحمل الحالي و أن الولادة قد تمت ؟ ", "نعم", "لا");
			Debug.WriteLine ("Answer: " + answer);

			if (answer == true) {
				pbcareApp.u.isPregnant = 0;
				pbcareApp.Database.updateIsPregnant (0);
				pbcareApp.Database.removeDueDate ();
				await DisplayAlert ("ألف مبروك ","حمداً لله على سلامتك","إضافة مولودك");
				await Navigation.PushAsync (new AddBaby ());
			}
		}

		protected override void OnAppearing()
		{
			
			if(pbcareApp.u.isPregnant == 0){

				Content = new StackLayout {
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.Start,
					Padding = new Thickness (20, 50 ,20 , 30),
					Spacing = 20 ,
					Children = {
						s , 
						AddPregnancy
					}
				};

			}else{
				Content =  new ScrollView {
					Content = new StackLayout {
						Padding = new Thickness(20 ,40,20,20),
						VerticalOptions = LayoutOptions.FillAndExpand,
						Children = {
									FollowPregnancy,
									FollowFetusImages,
									FollowFetusWeekly,
									finishPreg_
						}
					}
				};
			}
		}
	}
}

