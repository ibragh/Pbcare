using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace pbcare
{
	public class VaccinationList : ContentPage
	{
		bool Locked = false ;

		public static List<vaccinationTable> Vaccinations = new List<vaccinationTable>(); 

		ListView vaccinationList = new ListView {
			RowHeight = 40
		};
		public VaccinationList (Baby c)
		{
			this.Title = "تطعيمات "+ c.ChildName ;
			BackgroundColor = Color.FromRgb (94, 196, 225);

			Vaccinations =  pbcareApp.Database.getVaccinationsList();
		
			vaccinationList.ItemsSource = Vaccinations;
			vaccinationList.ItemTemplate = new DataTemplate (typeof(EveryVaccinationCell));
			vaccinationList.BackgroundColor = Color.Transparent;
			vaccinationList.SeparatorColor = Color.White;
			vaccinationList.ItemSelected += (sender, e) => {
				((ListView)sender).SelectedItem = null; 
			};

			vaccinationList.ItemTapped +=  (Sender, Event) => {
				
				if(!Locked)
				{
					Locked = true;
					var V = (vaccinationTable)Event.Item;
					Navigation.PushAsync(new VaccinationInfoView(V, c));
				}
			};

			Content = new StackLayout {
				VerticalOptions= LayoutOptions.FillAndExpand,
				Padding = new Thickness(0, 10, 0, 10 ),
				Children = {  
					vaccinationList
				}
			};
		}

		protected override void OnAppearing ()
		{
			Locked = false ;
		}
	}

	//-------------------------------------------------------
	public class VaccinationInfoView : ContentPage
	{
		Label VName, isTakenLabel ;
		Button isTakenButton ;
		int isTaken ;
		vaccinationTable V ;
		Baby C ;

		public VaccinationInfoView (vaccinationTable v, Baby c)
		{
			this.Title = "تطعيمات "+ c.ChildName ;
			this.V = v;
			this.C = c;
			BackgroundColor = Color.FromRgb (197, 255, 255);
			VName = new Label{ 
				Text = V.name,
				TextColor = Color.FromHex("#5069A1"),
				FontSize = Device.GetNamedSize(NamedSize.Large , typeof(Label)),
				HorizontalOptions = LayoutOptions.EndAndExpand,
				VerticalOptions = LayoutOptions.Center,

			};
			isTakenButton = new Button {
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				BorderRadius = 100,
				WidthRequest = 45,
				HeightRequest = 50,
			};


			isTakenLabel = new Label {
				TextColor = Color.FromHex("#5069A1"),
				FontAttributes = FontAttributes.Bold,
				VerticalOptions = LayoutOptions.Center,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label))
			};


			isTakenButton.Clicked += (sender, e) => {
				if(isTaken == 1){
					pbcareApp.Database.update_IsTaken(0, V.VaccinationID, c.ChildName);
					isTakenButton.Image = "X.png";
					isTakenButton.BackgroundColor = Color.Transparent;
					isTakenLabel.Text = "لم يتم أخذها";
					isTaken = 0;
				}else if(isTaken == 0 ){
					pbcareApp.Database.update_IsTaken(1, V.VaccinationID, c.ChildName);
					isTakenButton.Image = "right.png";
					isTakenButton.BackgroundColor = Color.Transparent;
					isTakenLabel.Text = "تم أخذها";
					isTaken = 1;

				}
			};

			var VInfo = new Label{ 
				Text = V.info ,
				TextColor = Color.FromHex("#5069A1"),
				FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
				HorizontalOptions = LayoutOptions.End
			};

			int when = pbcareApp.Database.getVaccinationDate (V.VaccinationID);
			DateTime Vacc_Time = DateTime.ParseExact (c.birthDate, "ddMMyyyy", null).AddMonths(when);

			var date = new Label{ 
				Text = "تاريخ أخذها    :      " + Vacc_Time.Year +" / "+ Vacc_Time.Month + " / " + Vacc_Time.Day ,
				TextColor = Color.FromHex("#FFA4C1"),
				FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Center
			};

			Content = new StackLayout {
				
				Padding = new Thickness(0,20,0,0),
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { 
					new StackLayout{
						BackgroundColor = Color.FromHex("#FFA4C1"),
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.FillAndExpand,
						Padding = new Thickness(20,0,20,20),
						Children={
							 isTakenLabel, isTakenButton, VName
						}
					},
					new StackLayout{
						Padding = new Thickness(0,0 , 0, 0),
						Children = {
							date
						}
					},
					new ScrollView{
						
						Content = new StackLayout{
							HorizontalOptions = LayoutOptions.End,
							Padding = new Thickness(10, 5, 10, 10),
							Spacing = 2,
							Children = {
								VInfo
							}
						}
					}
				}
			};
		}

		protected override void OnAppearing ()
		{
			isTaken = pbcareApp.Database.is_vaccination_taken (V.VaccinationID, C.ChildName);

			if(isTaken == 1){
				isTakenButton.Image = "right.png";
				isTakenButton.BackgroundColor = Color.Transparent;
				isTakenLabel.Text = "تم أخذها";

			}else if (isTaken == 0){
				isTakenButton.Image = "X.png";
				isTakenButton.BackgroundColor = Color.Transparent;
				isTakenLabel.Text = "لم يتم أخذها";
			}
			base.OnAppearing ();
		}
	}
}


