using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;

namespace pbcare
{
	public class BabyPage : ContentPage
	{

	
		ListView childrenList = new ListView {
			RowHeight = 60
		};
		public BabyPage()
		{
			Title = "أطفالي";

			ToolbarItem plus = new ToolbarItem {
				Icon = "plus2.png",
				Command = new Command (() => Navigation.PushAsync (new AddBaby()))
			};

			ToolbarItems.Add(plus);


			BackgroundImage = null ;
			BackgroundColor = Color.FromRgb (94, 196, 225);

			childrenList.ItemTemplate = new DataTemplate (typeof(EveryChildCell));
			childrenList.SeparatorColor = Color.White;
			childrenList.BackgroundColor = Color.Transparent;

			childrenList.ItemSelected +=  (Sender, Event) => {
				((ListView)Sender).SelectedItem = null; 
			};

//			var AddChild = new Button {
//				Text = "إضافة طفـــل",
//				Image = "plus.png",
//				TextColor = Color.White,
//				FontSize = 15,
//				WidthRequest = 200,
//				HeightRequest = 65,
//				BackgroundColor = Color.FromHex ("#FF2A68"),
//				VerticalOptions = LayoutOptions.End,
//				FontAttributes = FontAttributes.Bold,
//				BorderRadius = 30 ,
//				BorderWidth = 4
//			};
//					
//			AddChild.Clicked += (sender, e) => {
//				Navigation.PushAsync(new AddBaby());
//
//			};

			Content = new StackLayout {
				VerticalOptions= LayoutOptions.FillAndExpand,
				Padding = new Thickness(0, 20, 0, 20),
				Children = {  
					childrenList ,
					//AddChild
				}
			};

		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			childrenList.ItemsSource = pbcareApp.Database.getChildrenFromDB(pbcareApp.u.Email);

		}
			

	}
}


