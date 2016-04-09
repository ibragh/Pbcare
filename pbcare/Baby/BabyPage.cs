using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;

namespace pbcare
{
	public class BabyPage : ContentPage
	{
		
		public static List<Child> MyChilren = new List<Child>(); 
		ListView childrenList = new ListView {
			RowHeight = 60
		};

		public BabyPage()
		{
			this.Title = "أطفالي";



			MyChilren = pbcareApp.Database.gitChildren (pbcareApp.u.Email);
			Debug.WriteLine (pbcareApp.u.Email+"******************************************");

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
				Padding = new Thickness(10,20,10 ,53),
				Children = {  
					childrenList ,
					l,
					AddChild
				}
			};

		}

		protected override void OnAppearing ()
		{
			
			childrenList.ItemsSource = MyChilren;
			base.OnAppearing ();


		}

	}
}


