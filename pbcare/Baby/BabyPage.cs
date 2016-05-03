using System;
using System.Collections.Generic;
using Xamarin.Forms;
using System.Diagnostics;

namespace pbcare
{
	public class BabyPage : ContentPage
	{
		public static Label message = new Label{
			TextColor = Color.White,
			FontSize = Device.GetNamedSize(NamedSize.Medium ,typeof(Label)),
			FontAttributes = FontAttributes.Bold,
			HorizontalOptions = LayoutOptions.Center				 

		};

		Button AddChild ;
		ListView childrenList = new ListView {
			RowHeight = 60
		};
		bool Locked = false ;

		public BabyPage()
		{
			StyleId = "BabyPage";
			Title = "أطفالي";

			BackgroundColor = Color.FromRgb (94, 196, 225);

			childrenList.ItemTemplate = new DataTemplate (typeof(EveryChildCell));
			childrenList.SeparatorColor = Color.White;
			childrenList.BackgroundColor = Color.Transparent;
			childrenList.ItemSelected += (sender, e) => {
				((ListView)sender).SelectedItem = null; 
			};
			childrenList.ItemTapped += (Sender, Event) => {
				
				Baby c = (Baby)Event.Item;
				if(!Locked){
					Locked = true;
					EditChild (c); 
				}
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
				if(!Locked)
				{
					Locked = true;
					pushAddBaby(); 
				}
			};

		}

		/* Calculate Current Month */
		public static int CurrentMonth (string birth)
		{
			DateTime birthDate = DateTime.ParseExact (birth , "ddMMyyyy", null);
			TimeSpan difference = DateTime.Now.AddDays (0) - birthDate ;
			double PastDays = ((int)difference.TotalDays );
			if(PastDays == 0){
				return 1;

			}else{
				return (int)Math.Ceiling ((PastDays/30) );
			}
		}

		async void pushAddBaby(){
			await Navigation.PushAsync(new AddBaby());
			Locked = false ;
		}
		async void EditChild(Baby c ){
			var answer = await DisplayActionSheet  (c.ChildName , "إلغاء" , null , "تعديل", "حــذف");

			if (answer.Equals ("تعديل")) {
				await Navigation.PushAsync (new EditBaby (c));
			} else if (answer.Equals ("حــذف")) {
				var isDeleted = await DisplayAlert (" حــذف " + c.ChildName, "هل تريد تأكيد حــذف " + c.ChildName + " ؟ ", "نعم", "لا");

				if (isDeleted){
					pbcareApp.Database.RemoveChild (c.ChildName);
					pbcareApp.Database.delete_CV_Sechduale (c.ChildName);
			}
				}	
			Locked = false;
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

			if(childrenNum.Count == 0){
				BabyPage.message.Text = "ليس لديك أطفال مسجلين    \n للإضافة الرجاء الضغط على + ";

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


