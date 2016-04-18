using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace pbcare
{
	public class FollowFetusByImages :  CarouselPage
	{
		public FollowFetusByImages ()
		{

			this.Title = "متابعة الحمل الأسبوعي";
			BackgroundColor = Color.White; //Color.FromRgb (197, 255, 255);
			int CurrentWeek = pbcareApp.CurrentWeek (pbcareApp.FinaldueDate);

			string[] images = new string[41];
			for (int i = 1; i < images.Length; i++) {
				images [i] = "fetus"+i+".png";
			}

			fetusImages[] FetusImages = new fetusImages[41];
			for (int i = 1; i < FetusImages.Length; i++) {
				FetusImages[i] = new fetusImages("الأسبوع "+i,images[i]);
			}
			this.ItemsSource = FetusImages;
			this.ItemTemplate = new DataTemplate (typeof(fetuseImagesPage));
			// selected week .. so her preganncy week will
			// be the first screen will appear 
			this.SelectedItem = ((fetusImages[])ItemsSource);

	}
}
	//================================================
		public class fetusImages
		{
		public string month { set; get; }

		public string image { set; get; }
			public fetusImages ()
			{
			}
		public fetusImages(string m, string img)
			{
				this.month = m;
			this.image = img ;
			}
			
		}

	//==========================================================
	public class fetuseImagesPage : ContentPage
	{
		Label monthLabel ;
		Image ImageLabel ;

		public fetuseImagesPage ()
		{

			monthLabel = new Label {
				FontSize = 50,
				HorizontalOptions = LayoutOptions.Center, 
				TextColor = Color.FromHex("#5069A1"),
			};

			ImageLabel = new Image { 
				
			};

			monthLabel.SetBinding (Label.TextProperty, "month");
			ImageLabel.SetBinding (Image.SourceProperty, "image");


		}

		protected override void OnAppearing ()
		{

			this.Content = new StackLayout {
				Padding = 20,
				Spacing = 20 ,
				Children = {
					monthLabel, ImageLabel
				}
			};
		}
	}
}