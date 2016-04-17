using System;

using Xamarin.Forms;

namespace pbcare
{
	public class AddPregPage : ContentPage
	{
		public AddPregPage ()
		{
			BackgroundColor = Color.FromRgb (94, 196, 225);
//=================================================================================
			Button CalMyDateButton = new Button {
				Text = "حساب تاريخ الولادة", 
				TextColor = Color.White,
				HorizontalOptions = LayoutOptions.Center,
				Font = Font.SystemFontOfSize (NamedSize.Small),
				FontAttributes = FontAttributes.Bold,
				BorderWidth = 2,
				BorderColor = Color.FromHex("FFA4C1"),
				BackgroundColor =  Color.FromHex("FFA4C1"),
				WidthRequest = 100,
				HeightRequest = 30,
			};

			Button DueDateButton = new Button {
				Text =  "تحديد تاريخ الولادة ",
				TextColor =  Color.White,
				HorizontalOptions = LayoutOptions.Center,
				Font = Font.SystemFontOfSize (NamedSize.Small),
				FontAttributes = FontAttributes.Bold,
				BorderWidth = 2,
				BorderColor =  Color.FromHex("FFA4C1"),
				BackgroundColor = Color.Transparent,
				WidthRequest = 100,
				HeightRequest = 30,

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
				VerticalOptions = LayoutOptions.CenterAndExpand
			};
			Button AddDueDate = new Button {
				Text = " اضافة تاريخ الولادة المتوقع", 
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
				HeightRequest = 40 ,
			};

			String DueDateText;
			AddDueDate.Clicked += (sender, e) => {
				/* check if data is within a valid pregnancy date 
				 * not before a ten mothns from the current date ,
				 * AND not after ten months from the current date 
				 */
				if (dueDate.Date < DateTime.Now.AddDays (-1) || dueDate.Date > DateTime.Now.AddMonths (11)) {
					DisplayAlert ("خطأ", "يجب أن يكون موعد الولادة المتوقع صحيحاً", "تم");
				} else {
					pbcareApp.FinaldueDate = dueDate.Date; /* Save data for farther use */
					int CurrentWeek = pbcareApp.CurrentWeek(dueDate.Date); // for testing
					//  convert date to formatted string for DB 
					DueDateText = dueDate.Date.ToString("ddMMyyyy"); 
					// convert date to string for display 
					int y = dueDate.Date.Year, m = dueDate.Date.Month, d = dueDate.Date.Day;
					string DueDateDisplay = d + "/" + m + "/" + y; 

					// the result from [AddPregnancyToDB] method will return numbers, each one has a meaning
					int result = pbcareApp.Database.AddPregnancyToDB (pbcareApp.u.Email,DueDateText );
					if (result == -1) {
						DisplayAlert ("خطأ", "خطأ غير معروف", "تم");
					} else if (result == 0) {
						Navigation.PopAsync ();
						DisplayAlert ("خطأ", "المستخدم غير مسجل مسبقاً", "تم");

					} else if (result == 1) {
						Navigation.PopAsync ();
						DisplayAlert ("خطأ", "يوجد لديكي حمل مسبق - لتغيير تاريخ الحمل من الإعدادات", "تم");

					}  else if (result == 99) { /* SUCCESSFUL */
						DisplayAlert ("", "موعدك الولادة المتوقع : " + DueDateDisplay+" \nأنتي الآن في الأسبوع الـ "+CurrentWeek, "تم");
						Navigation.PopAsync ();


					} else {
						Navigation.PopAsync ();
						DisplayAlert ("خطأ", "خطأ غير معروف", "تم");

					}
				}
			};
//===============================================================================
			//Calculate DueDate !!!

			var dueDatePicker = new DatePicker1 {
				Format= "D",
				VerticalOptions = LayoutOptions.Center
			};
			Button CalculateButton = new Button {
				Text = "احسب تاريخ الولادة المتوقع",
				TextColor = Color.FromHex("#FFFFFF"),
				FontSize = Device.GetNamedSize(NamedSize.Medium, typeof(Button)),
				BackgroundColor = Color.FromHex("#FFA4C1"),
				BorderColor = Color.FromHex("#FFA4C1"),
				HeightRequest = 40 ,
			};
			Label MyDueDate = new Label {
				Text = "ادخلي تاريخ أول يوم في فترة حملك ",
				HorizontalOptions = LayoutOptions.Center,
				TextColor=Color.White,
				FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label))
			};
			CalculateButton.Clicked += delegate {
				int y=dueDate.Date.Year, m=dueDate.Date.Month, d=dueDate.Date.Day;
				MyDueDate.Text = d+"/"+m+"/"+y;
				DisplayAlert ("Success", "Your Due date is " + MyDueDate.Text, "Done");
				Navigation.PopToRootAsync();

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
							Spacing = -7,
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
							Spacing = -7,
							Children = {
								CalMyDateButton , DueDateButton

							}
						},
						new StackLayout {
							Spacing = 20 ,
							Padding = 20,
							Children = {
								MyDueDate,
								dueDatePicker,
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
						Spacing = -7,
						Children = {
							CalMyDateButton , DueDateButton

						}
					},
					new StackLayout {
						Spacing = 20 ,
						Padding = 20,
						Children = {
							MyDueDate,
							dueDatePicker,
							CalculateButton
						}
					}
				}
			};
		}
	}
}


