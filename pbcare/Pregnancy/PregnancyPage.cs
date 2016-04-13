using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Acr.Notifications;

namespace pbcare
{
	public partial class PregnancyPage : ContentPage
	{
		Image welcomeLogo , plus;
		Button AddPregnancy, FollowPregnancy, FollowFetusImages, FollowFetusWeekly, finishPreg_  ;
		Image s = new Image { Source = "notPregnant2.png" };
		Image s2 = new Image { Source = "arrows.png" };

		public PregnancyPage ()
		{
			this.Title = "حملي";
			BackgroundColor = Color.FromRgb (94, 196, 225);

			 welcomeLogo = new Image { 
				Source = ""
			};

			plus = new Image{ 
				Source= "plus.png ",
				HorizontalOptions = LayoutOptions.End,
			};

			AddPregnancy = new Button1 {
				Text = "إضافة حمل",
				//Image = "plus.png",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
			};
			FollowPregnancy = new Button {
				Text = " حــمــلــي ",
				//Image = "pregnant.png",
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Button)),
				//TextColor = Color.FromRgb (238, 238, 238),
				TextColor = Color.White, //Color.FromRgb (238, 238, 238),
				BackgroundColor = Color.FromRgb (59, 89, 153),
				BorderColor = Color.Black, // Color.FromRgb(127,127,127),
				BorderWidth = 5,
				BorderRadius = 0 ,
			};
			finishPreg_ = new Button1 {
				Text = "تــــمت الــولادة",
				TextColor = Color.White,
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
				HeightRequest = 40 ,
				BorderWidth = 1,
				BorderRadius = 0 ,
			};
			FollowFetusImages = new Button {
				Text = "متابعةالجنين بالصور",
				//Image = "fetus.png",
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Button)),
				TextColor = Color.White, //Color.FromRgb (238, 238, 238),
				BackgroundColor = Color.FromRgb (59, 89, 153),
				BorderColor = Color.FromRgb (59, 89, 153),
				BorderWidth = 1,
				BorderRadius = 0 ,
			};
			FollowFetusWeekly = new Button {
				Text = "متابعةالجنين بالأسابيع",
				//Image = "fetus.png",
				FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Button)),
				TextColor = Color.White, //Color.FromRgb (238, 238, 238),
				//WidthRequest = 200,
				BackgroundColor = Color.FromRgb (59, 89, 153),
				BorderColor = Color.FromRgb (59, 89, 153),
				BorderWidth = 1,
				BorderRadius = 0 ,
			};

			AddPregnancy.Clicked += AddPregnancyClicked;
			FollowPregnancy.Clicked += FollowPregnancyWeeklyClicked;
			FollowFetusImages.Clicked += FollowFetusByImagesClicked;
			FollowFetusWeekly.Clicked += FollowFetusWeeklyClicked;
			finishPreg_.Clicked += pregnancyFinished ;

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

		public void pregnancyFinished(object sender, EventArgs e){
			//ToolbarItems.Add (plusButton);
		}
		public void sendNotification ()
		{
			Notifications.Instance.Send ("Notification","I got notification for ABCD",when: TimeSpan.FromSeconds (2));
		}


		protected override void OnAppearing()
		{
			
			if(pbcareApp.FinaldueDate.GetHashCode() == 0){

				Content = new StackLayout {
					HorizontalOptions = LayoutOptions.FillAndExpand,
					VerticalOptions = LayoutOptions.Start,
					Padding = new Thickness (20, 50 ,20 , 30),
					Spacing = 20 ,
					Children = {
						s , 
						AddPregnancy
//						new Label {
//							Text = "لإضافة حمل الرجاء الضغط على + في أعلى الصفحة ",
//							TextColor = Color.White, // Color.FromHex("#FFA4C1"),
//							FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
//							FontAttributes = FontAttributes.Bold
//						}
					}
				};

			}else{
				ToolbarItems.Remove (plusButton);

				Content =  new StackLayout {
					
					Orientation = StackOrientation.Vertical,
					Padding = new Thickness(0,0,0,50),
					VerticalOptions = LayoutOptions.FillAndExpand,
					Children = {
						new StackLayout{
							Orientation = StackOrientation.Horizontal,
							Padding = 10,
							Spacing = 0,
							Children = {
								FollowPregnancy,
								FollowFetusImages,
								FollowFetusWeekly,

							}
						},
						finishPreg_
					}
				};
			}
		}
			
	}
}

