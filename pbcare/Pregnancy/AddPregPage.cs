using System;

using Xamarin.Forms;
using Acr.Notifications;

namespace pbcare
{
	public class AddPregPage : ContentPage
	{
		bool Locked = false ;
		public AddPregPage ()
		{
			BackgroundColor = Color.FromRgb (94, 196, 225);
//=================================================================================
			Button CalMyDateButton = new Button {
				Text = "حساب تاريخ الولادة", 
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.Center,
				Font = Font.SystemFontOfSize (NamedSize.Micro),
				FontAttributes = FontAttributes.Bold,
				BorderWidth = 2,
				BorderColor = Color.FromHex("FFA4C1"),
				BackgroundColor =  Color.FromHex("FFA4C1"),
				WidthRequest = 110,
				HeightRequest = 40,
			};

			Button DueDateButton = new Button {
				Text =  "تحديد تاريخ الولادة ",
				TextColor =  Color.White,
				HorizontalOptions = LayoutOptions.Center,
				Font = Font.SystemFontOfSize (NamedSize.Micro),
				FontAttributes = FontAttributes.Bold,
				BorderWidth = 2,
				BorderColor =  Color.FromHex("FFA4C1"),
				BackgroundColor = Color.Transparent,
				WidthRequest = 110,
				HeightRequest = 40,
				StyleId = "MyDueDate"
			};

//=================================================================================
			// Difine DueDate !!!

			Label OptionText = new Label {
				Text = "أدخلي تاريخ الولادة",
				HorizontalOptions = LayoutOptions.CenterAndExpand,
				TextColor=Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label))
			};

			var dueDate = new DatePicker1 {
				Format = "D",
				VerticalOptions = LayoutOptions.CenterAndExpand,
				StyleId = "DueDate",
				MaximumDate = DateTime.Now.AddDays(280),
				MinimumDate = DateTime.Today
			};
			Button AddDueDate = new Button {
				Text = " اضافة تاريخ الولادة المتوقع", 
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
				HeightRequest = 50,
				StyleId = "AddMyDueDate"
			};

			String DueDateText;
			AddDueDate.Clicked += (sender, e) => {
				if(!Locked){
					Locked = true;
					pbcareApp.FinaldueDate = dueDate.Date; /* Save data for farther use */
					int CurrentWeek = PregnancyPage.CurrentWeek(pbcareApp.FinaldueDate.Date); // for testing
					//  convert date to formatted string for DB 
					string DueDateDisplay = pbcareApp.FinaldueDate.Date.ToString("ddMMyyyy") ;

					// the result from [AddPregnancyToDB] method will return numbers, each one has a meaning
					int result = pbcareApp.Database.AddPregnancy (pbcareApp.u.Email, DueDateDisplay);
					if (result == -1) {
						DisplayAlert ("خطأ", "خطأ غير معروف", "تم");

					} else if (result == 0) {
						DisplayAlert ("خطأ", "المستخدم غير مسجل مسبقاً", "تم");

					} else if (result == 1) {
						DisplayAlert ("خطأ", "يوجد لديكي حمل مسبق - لتغيير تاريخ الحمل من الإعدادات", "تم");

					}  else if (result == 99) { /* SUCCESSFUL */
						DisplayAlert ("", "موعدك الولادة المتوقع : " + pbcareApp.FinaldueDate.GetDateTimeFormats()[3]+" \nأنتي الآن في الأسبوع الـ "+CurrentWeek, "تم");
						TimeSpan difference = dueDate.Date - DateTime.Now.AddDays (-1);
						Notifications.Instance.Send("تنبيه","موعد ولادتك قد حان أو اقترب ",when: TimeSpan.FromDays ((int)difference.TotalDays -1));
						pbcareApp.Database.update_IsPregnant(1);
						pbcareApp.u.isPregnant = 1;

					} else {
						
						DisplayAlert ("خطأ", "خطأ غير معروف", "تم");
					}
					Locked = false ; 
					}
			};
//===============================================================================
			//Calculate DueDate !!!

			var firstPregnancyDate = new DatePicker1 {
				Format= "D",
				VerticalOptions = LayoutOptions.Center,
				MaximumDate = DateTime.Today,
				MinimumDate = DateTime.Now.AddDays(-280)
			};
			Button CalculateButton = new Button {
				Text = "احسب تاريخ الولادة المتوقع",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
				HeightRequest = 50 ,
			};
			Label MyDueDate = new Label {
				Text = "ادخلي تاريخ أول يوم في فترة حملك ",
				HorizontalOptions = LayoutOptions.Center,
				TextColor=Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label))
			};

			CalculateButton.Clicked += (sender, e) =>  {
				if(!Locked){
					Locked = true;
					DateTime expectedDueDate = firstPregnancyDate.Date.AddDays(280);
					pbcareApp.FinaldueDate = expectedDueDate.Date; 
					int currentWeek = PregnancyPage.CurrentWeek(pbcareApp.FinaldueDate.Date);
					string DueDateDisplay = pbcareApp.FinaldueDate.Date.ToString("ddMMyyyy") ;

					// the result from [AddPregnancyToDB] method will return numbers, each one has a meaning
					int result = pbcareApp.Database.AddPregnancy (pbcareApp.u.Email, DueDateDisplay );
					if (result == -1) {
						DisplayAlert ("خطأ", "خطأ غير معروف", "تم");
					} else if (result == 0) {
						DisplayAlert ("خطأ", "المستخدم غير مسجل مسبقاً", "تم");

					} else if (result == 1) {
						DisplayAlert ("خطأ", "يوجد لديكي حمل مسبق - لتغيير تاريخ الحمل من الإعدادات", "تم");

					}  else if (result == 99) { /* SUCCESSFUL */
						DisplayAlert ("", "موعدك الولادة المتوقع : " + pbcareApp.FinaldueDate.GetDateTimeFormats()[3]+" \nأنتي الآن في الأسبوع الـ "+currentWeek, "تم");
						TimeSpan difference = expectedDueDate.Date - DateTime.Now.AddDays (-1);
						Notifications.Instance.Send("تنبيه","موعد ولادتك قد حان أو اقترب ",when: TimeSpan.FromDays ((int)difference.TotalDays -1));
						pbcareApp.Database.update_IsPregnant(1);
						pbcareApp.u.isPregnant = 1;

					} else {
						Navigation.PopAsync ();
						DisplayAlert ("خطأ", "خطأ غير معروف", "تم");
					}
					Locked = false ; 
					}
			};
				
//===============================================================================================

			DueDateButton.Clicked += (sender, e) => {
				
				DueDateButton.BackgroundColor = Color.FromHex("FFA4C1");
				DueDateButton.TextColor = Color.White;
				DueDateButton.BorderColor = Color.FromHex("FFA4C1");

				CalMyDateButton.BackgroundColor = Color.Transparent;
				CalMyDateButton.TextColor = Color.White;
				CalMyDateButton.BorderColor  = Color.FromHex("FFA4C1");

				Content = new StackLayout {
					Spacing = 15 ,
					Children = {
						new StackLayout { 
							Orientation = StackOrientation.Horizontal,
							HorizontalOptions = LayoutOptions.Center,
							VerticalOptions = LayoutOptions.Start,
							Padding = new Thickness (10, 20),
							Spacing = -5,
							Children = {
								CalMyDateButton , DueDateButton
						
							}
						},
							new StackLayout {
							Spacing = 20 ,
							Padding = 20,
								Children = {
									OptionText,
									dueDate,
									AddDueDate
								}
							}
						}
				};
			};

			CalMyDateButton.Clicked += (sender, e) => {

				CalMyDateButton.BackgroundColor = Color.FromHex("FFA4C1");
				CalMyDateButton.TextColor = Color.White;
				CalMyDateButton.BorderColor = Color.FromHex("FFA4C1");

				DueDateButton.BackgroundColor = Color.Transparent;
				DueDateButton.TextColor = Color.White;
				DueDateButton.BorderColor  = Color.FromHex("FFA4C1");

				Content = new StackLayout {
					Spacing = 15 ,
					Children = {
						new StackLayout { 
							Orientation = StackOrientation.Horizontal,
							HorizontalOptions = LayoutOptions.Center,
							VerticalOptions = LayoutOptions.Start,
							Padding = new Thickness (10, 20),
							Spacing = -5,
							Children = {
								CalMyDateButton , DueDateButton

							}
						},
						new StackLayout {
							Spacing = 20 ,
							Padding = 20,
							Children = {
								MyDueDate,
								firstPregnancyDate,
								CalculateButton
							}
						}
					}
				};
			};

			Content = new StackLayout {
				Spacing = 15 ,
				Children = {
					new StackLayout { 
						Orientation = StackOrientation.Horizontal,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Start,
						Padding = new Thickness (10, 20),
						Spacing = -5,
						Children = {
							CalMyDateButton , DueDateButton

						}
					},
					new StackLayout {
						Spacing = 20 ,
						Padding = 20,
						Children = {
							MyDueDate,
							firstPregnancyDate,
							CalculateButton
						}
					}
				}
			};
		}
	}
}


