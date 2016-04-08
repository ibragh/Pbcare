using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace pbcare
{
	public class BabyPage : ContentPage
	{
		
		public static List<Child> MyChilren = new List<Child>(); 

		public BabyPage()
		{
			this.Title = "طفلي";
			BackgroundImage = "mainPB.jpg";
			ListView childrenList = new ListView {
				RowHeight = 60
			};

			MyChilren =  pbcareApp.Database.gitChildren ("A@a");

		
			childrenList.ItemsSource = MyChilren;
			childrenList.ItemTemplate = new DataTemplate (typeof(EveryChildCell));
			childrenList.SeparatorColor = Color.Black;
			childrenList.ItemSelected +=  (Sender, Event) => {
				((ListView)Sender).SelectedItem = null; 
			};

			var l = new Label {
				Text = "" + pbcareApp.u.Email
			};

			var AddChild = new Button {
				Text = "إضافة طفـــل",
				TextColor = Color.White,
				FontSize = 15,
				BackgroundColor = Color.FromHex ("#FF2A68"),
				VerticalOptions = LayoutOptions.End
			};

			AddChild.Clicked += (sender, e) => {
				Navigation.PushAsync(new AddBaby());

			};

			Content = new StackLayout {
				VerticalOptions= LayoutOptions.FillAndExpand,
				Padding = new Thickness(10,20,10 ,20),
				Children = {  
					childrenList ,
					l,
					AddChild
				}
			};

		}

	}
}


