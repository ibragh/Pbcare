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
		bool Locked = false ;

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
				StyleId = "AddDuDate"
			};
			FollowPregnancy = new Button {
				Text = " حــمــلــي ",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
				StyleId = "FollowPregnancy"
			};

			FollowFetusImages = new Button {
				Text = "متابعة الجنين بالصور",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
				StyleId = "FollowFetusImages"
			};

			FollowFetusWeekly = new Button {
				Text = "متابعة الجنين بالأسابيع",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
				StyleId = "FollowFetusWeekly"
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
			TimeSpan difference = dueDate - DateTime.Now.AddDays (0);
			// for calculating the past days of pregnancy
			double PastDays = (280 - (int)difference.TotalDays); 
			return (int)Math.Ceiling ((PastDays/7));

		}

		async public void AddPregnancyClicked (object sender, EventArgs e)
		{
			if(!Locked){
				Locked = true;
				await Navigation.PushAsync (new AddPregPage ());
		}
		}

		async public void FollowPregnancyWeeklyClicked (object sender, EventArgs e)
		{
			if(!Locked){
				Locked = true;
				await Navigation.PushAsync (new FollowPregnancy ());
			}
		}

		async public void FollowFetusByImagesClicked (object sender, EventArgs e)
		{
			if(!Locked){
				Locked = true;
				await Navigation.PushAsync (new FollowFetusByImages ());
			}
		}

		async public void FollowFetusWeeklyClicked (object sender, EventArgs e)
		{
			if(!Locked){
				Locked = true;
				await Navigation.PushAsync (new FollowFetusWeekly ());
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
			Locked = false;
			base.OnAppearing ();
			Label message = new Label {
				Text = "مرحـــبا " + pbcareApp.u.name + " ...",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.Center,
			};
			if(pbcareApp.u.isPregnant == 0){
				
				Label message2 = new Label {
					Text = "لا يوجد حمل مسجل ...                \n تستطيعي تسجيل حملك بالضغط على زر الإضافة",
					TextColor = Color.White,
					HorizontalOptions = LayoutOptions.Center
				};

				Content = new StackLayout {
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.Start,
					Padding = new Thickness (20, 50 ,20 , 30),
					Spacing = 20 ,
					Children = {
						message,
						message2,
						s , 
						AddPregnancy,
					}
				};

			}else{
				string DueDate = pbcareApp.Database.GetDueDate ();
				pbcareApp.FinaldueDate = DateTime.ParseExact (DueDate, "ddMMyyyy", null).Date;

				Label showDueDate = new Label{
					Text = " موعد ولادتك المتوقع هـو ",
					TextColor = Color.White,
					FontAttributes = FontAttributes.Bold,
					HorizontalOptions = LayoutOptions.Center
				};

				Label showDueDate2 = new Label{
					Text = pbcareApp.FinaldueDate.Day + " / " + pbcareApp.FinaldueDate.Month + " / " +pbcareApp.FinaldueDate.Year ,
					TextColor = Color.White,
					FontAttributes = FontAttributes.Bold,
					HorizontalOptions = LayoutOptions.Center
				};
				Content =  new ScrollView {
					Content = new StackLayout {
						Padding = new Thickness(20 ,40,20,20),
						VerticalOptions = LayoutOptions.FillAndExpand,
						Spacing = 10 ,
						Children = {
							message,
							FollowPregnancy,
							FollowFetusImages,
							FollowFetusWeekly,
							finishPreg_,
							showDueDate,
							showDueDate2
						}
					}
				};
			}

		}
	}
}

