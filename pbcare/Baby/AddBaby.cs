using System;

using Xamarin.Forms;
using Acr.Notifications;

namespace pbcare
{
	public class AddBaby : ContentPage
	{
		bool Locked = false ;
		public AddBaby ()
		{
			Title = "إضــافة طــفل ";
			BackgroundColor = Color.FromRgb (94, 196, 225);


			var childName = new Label {
				Text = "إسم الطفل",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.End
			};

			var nameEntry = new Entry1 {
				Placeholder = " اسم الطفل هنا",
				PlaceholderColor = Color.White,
				TextColor = Color.FromHex("#5069A1"),
			
			};

			var childGender = new Label {
				Text = "الجنس",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.End,
			};

			var gender = new Picker1 ();
			gender.Title = "اختر الجنس";
			gender.Items.Add ("ذكر");
			gender.Items.Add ("أنثى");


			var childBirthdate = new Label {
				Text = "تاريخ الميلاد",
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.End,
			};

			var birthdate = new DatePicker1 {
				MaximumDate = DateTime.Today,
				MinimumDate = DateTime.Now.AddDays(-365)
			};

			var saveButton = new Button {
				Text = "حفظ البيانات",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
				HeightRequest = 40 ,
				WidthRequest = 110
			};

			saveButton.Clicked += (sender, e) => {
				if(!Locked){
					Locked = true;
				if (!string.IsNullOrWhiteSpace (nameEntry.Text) && gender.SelectedIndex != -1) {
					Baby baby = new Baby{
						mother = pbcareApp.u.Email,
						ChildName = nameEntry.Text,
						birthDate = birthdate.Date.ToString("ddMMyyyy") ,
						gender = gender.Items [gender.SelectedIndex]
					};
					bool check = pbcareApp.Database.AddChild(baby);

					if (check) {
						pbcareApp.Database.set_CV_Sechduale(baby.ChildName);
						var Vaccinations =  pbcareApp.Database.getVaccinationsList();
						Navigation.PopAsync ();

						for(int i = 0 ; i < Vaccinations.Count ; i++){
							var periodInDays = (Vaccinations[i].time *30) - ((int)(DateTime.Now.Date - birthdate.Date).TotalDays) ;
							Notifications.Instance.Send ("تنبيه", Vaccinations[i].name + "  for  " + baby.ChildName ,when: TimeSpan.FromDays (periodInDays));
						}
					} else {
						DisplayAlert ("خطأ", "لديك طفل مسجل مسبقا بنفس الاسم ", "إلغاء");
					}
				} else {
					DisplayAlert ("خطأ", "معلومات الطفل غير كاملة", "إلغاء");
				}
				}
			};

			var cancelButton = new Button {
				Text = "إلغاء",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
				HeightRequest = 40 ,
				WidthRequest = 110
			};

			cancelButton.Clicked += (sender, e) => {
				Navigation.PopAsync ();
			};

			Content = new ScrollView {
					Content = new StackLayout {
						Padding = 20, 
						Spacing = 15,
						Children = {
							childName,
							nameEntry,
							childGender,
							gender,
							childBirthdate,
							birthdate,
							new StackLayout{
								Padding = new Thickness (0 , 20 , 0 , 10),
								Orientation = StackOrientation.Horizontal,
								HorizontalOptions = LayoutOptions.Center,
								Children = {
									cancelButton,
									saveButton
								}
							}
						}
					}
			};
	}
}
}

