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
			Title = "طفلي";
			BackgroundImage = null ;
		
			childrenList.ItemTemplate = new DataTemplate (typeof(EveryChildCell));
			childrenList.SeparatorColor = Color.Black;
			childrenList.BackgroundColor = Color.Transparent;

			childrenList.ItemSelected +=  (Sender, Event) => {
				((ListView)Sender).SelectedItem = null; 
			};

			var AddChild = new Button {
				Text = "إضافة طفـــل",
				Image = "plus.png",
				TextColor = Color.White,
				FontSize = 15,
				WidthRequest = 200,
				HeightRequest = 65,
				BackgroundColor = Color.FromHex ("#FF2A68"),
				VerticalOptions = LayoutOptions.End,
				FontAttributes = FontAttributes.Bold,
				BorderRadius = 30 ,
				BorderWidth = 4
			};
					
			AddChild.Clicked += (sender, e) => {
				Navigation.PushAsync(new AddBaby());

			};

			Content = new StackLayout {
				VerticalOptions= LayoutOptions.FillAndExpand,
				Padding = new Thickness(10,20,0 ,53),
				Children = {  
					childrenList ,
					AddChild
				}
			};

		}
		protected override void OnAppearing ()
		{
			base.OnAppearing ();
			NavigationPage.SetHasNavigationBar (this, false);
			childrenList.ItemsSource = pbcareApp.Database.getChildrenFromDB(pbcareApp.u.Email);

		}
			

	}
}


