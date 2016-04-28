using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;

namespace pbcare
{
	public class BabyPage : ContentPage
	{
		Button AddChild ;
		ListView childrenList = new ListView {
			RowHeight = 60
		};
		bool Locked = true ;

		public BabyPage()
		{
			StyleId = "BabyPage";
			Title = "أطفالي";

			BackgroundColor = Color.FromRgb (94, 196, 225);

			childrenList.ItemTemplate = new DataTemplate (typeof(EveryChildCell));
			childrenList.SeparatorColor = Color.White;
			childrenList.BackgroundColor = Color.Transparent;
			childrenList.ItemTapped += (Sender, Event) => {
				Baby c = (Baby)Event.Item;
				if(Locked){
					
					EditChild (c); 
				}
			};

			childrenList.ItemSelected +=  (Sender, Event) => {
				((ListView)Sender).SelectedItem = null; 
			};

			AddChild = new Button {
				Text = " + ",
				FontAttributes = FontAttributes.None,
				FontSize = 40,
				TextColor = Color.White,
				WidthRequest = 63,
				HeightRequest= 63,
				BackgroundColor = Color.FromHex("#FFA4C1"),
				VerticalOptions = LayoutOptions.End,
				HorizontalOptions = LayoutOptions.Center,
				BorderColor = Color.FromHex("#FFA4C1"),
				BorderWidth = 1 ,
				BorderRadius = 30
			};

		


			AddChild.Clicked += (sender, e) => {
				Navigation.PushAsync(new AddBaby());

			};

		}

		/* Calculate Current Month */
		public static int CurrentMonth (string birth)
		{
			DateTime birthDate = DateTime.ParseExact (birth , "ddMMyyyy", null);
			TimeSpan difference = DateTime.Now.AddDays (-1) - birthDate ;
			double PastDays = ((int)difference.TotalDays ); 
			return (int)Math.Ceiling ((PastDays/30) );

		}
		
		async void EditChild(Baby c ){
			
			Locked = false;
			var answer = await DisplayActionSheet  (c.ChildName , "إلغاء" , null , "تعديل", "حــذف");

			if(answer.Equals("تعديل")){
				await Navigation.PushAsync (new EditBaby (c));
			}

			else if(answer.Equals("حــذف")){
				var isDeleted = await DisplayAlert (" حــذف "+c.ChildName , "هل تريد تأكيد حــذف "+c.ChildName+" ؟ ", "نعم", "لا");

				if (isDeleted)
					pbcareApp.Database.RemoveChild (c);
				}	
			Locked = true;
			OnAppearing ();
		}

		protected override void OnAppearing ()
		{			
			base.OnAppearing ();
			var childrenNum = pbcareApp.Database.getChildren(pbcareApp.u.Email);
			childrenList.ItemsSource = childrenNum;

			Image c = new Image {
				Source = "children.png"
			};

			Label message = new Label {
				Text = "ليس لديك أطفال مسجلين    \n للإضافة الرجاء الضغط على + ",
				TextColor = Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium ,typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center				 
					
			};
			if(childrenNum.Count == 0){
				Content = new ScrollView {
					Content = new StackLayout {
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center,
						Spacing = 20,
						Padding = new Thickness (0, 20, 0, 40),
						Children = { 
							c,
							message,
							AddChild
						}
					}
				};
			}else{
				Content = new ScrollView {
					Content = new StackLayout {
						VerticalOptions= LayoutOptions.FillAndExpand,
						Padding = new Thickness (0, 20, 0, 40),
						Children = { 
							childrenList,
							AddChild
						}
					}
				};
			}
		}
			

	}
}


