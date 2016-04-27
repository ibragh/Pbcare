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
			finishPreg_.Clicked += Pregnancy_Finished ;

		}

		/* Calculate Current Week */
		public static int CurrentWeek (DateTime dueDate)
		{
			TimeSpan difference = dueDate - DateTime.Now.AddDays (-1);
			// for calculating the past days of pregnancy
			double PastDays = (280 - (int)difference.TotalDays); 
			return (int)Math.Ceiling ((PastDays/7));

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

		async void Pregnancy_Finished (object sender, EventArgs e)
		{
			var answer = await DisplayAlert ("تمت الولادة  ", "هل أنتي متأكدة من إنهاء جميع معلومات الحمل الحالي و أن الولادة قد تمت ؟ ", "نعم", "لا");
			Debug.WriteLine ("Answer: " + answer);

			if (answer == true) {
				pbcareApp.u.isPregnant = 0;
				pbcareApp.Database.update_IsPregnant (0);
				pbcareApp.Database.removeDueDate ();
				var cancel = await DisplayAlert (" ألف مبــروك و الحمدلله على سلامتك يا "+ pbcareApp.u.name ,"هل تريدين إضافة مولودك ؟ ", "لا", "نــعم ");
				if (!cancel) {
					await Navigation.PushAsync (new AddBaby ());
				} else {
					OnAppearing ();
				}
		}
		}
		protected override void OnAppearing()
		{
			base.OnAppearing ();
	
			if(pbcareApp.u.isPregnant == 0){

				Content = new StackLayout {
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.Start,
					Padding = new Thickness (20, 50 ,20 , 30),
					Spacing = 20 ,
					Children = {
						s , 
						AddPregnancy,
						new Label {
							Text = pbcareApp.u.isPregnant + ""
						}
					}
				};

			}else{
				Label showDueDate = new Label{
					Text = " موعد ولادتك المتوقع هـو "+ pbcareApp.Database.GetDueDate(),
					TextColor = Color.White,
					FontAttributes = FontAttributes.Bold,
					HorizontalOptions = LayoutOptions.Center
				};
				Content =  new ScrollView {
					Content = new StackLayout {
						Padding = new Thickness(20 ,40,20,20),
						VerticalOptions = LayoutOptions.FillAndExpand,
						Children = {
									FollowPregnancy,
									FollowFetusImages,
									FollowFetusWeekly,
									finishPreg_,
									showDueDate
						}
					}
				};
			}

		}
	}
}

