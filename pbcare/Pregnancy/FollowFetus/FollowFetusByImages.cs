﻿using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace pbcare
{
	public class FollowFetusByImages :  CarouselPage
	{
		public FollowFetusByImages ()
		{

			this.Title = "متابعة الجنين بالصور";
			BackgroundColor = Color.White; //Color.FromRgb (197, 255, 255);
			int CurrentWeek = PregnancyPage.CurrentWeek(pbcareApp.FinaldueDate);

			string[] images;
			if (CurrentWeek > 30) {
				images = new string[40 -(CurrentWeek - 1)];
			} else {
				images = new string[10];
			}

			int img = CurrentWeek; 
			int i = 0;
			while(i < images.Length){
				images [i] = "fetus"+img+".jpg";
				img++;
				i++;
			}

			fetusImages[] FetusImages;
			if (CurrentWeek > 30) {
				FetusImages = new fetusImages[40 -(CurrentWeek - 1)];

			} else {
				FetusImages = new fetusImages[10];
			}
			int img2 = CurrentWeek; 
			int j = 0;
			while(j < FetusImages.Length){
				FetusImages[j] = new fetusImages("الأسبوع "+img2,images[j]);
				img2++;
				j++;
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