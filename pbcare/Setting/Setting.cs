using System;
using System.Collections.Generic ;
using Xamarin.Forms;

namespace pbcare
{
	public class Setting : ContentPage
	{
		

		public Setting ()
		{
			this.Title = "الإعدادات";
			ListView setting = new ListView {
				RowHeight = 50  
			};
					
			setting.ItemsSource = getSettingList();
			setting.ItemTemplate = new DataTemplate (typeof(TextCell));
			setting.ItemTemplate.SetBinding (TextCell.TextProperty, "Name");


			setting.ItemSelected +=  (Sender, Event) => {
				var selceted = (everyCell)Event.SelectedItem;
				var settingView = new settingView(selceted);
				Navigation.PushAsync(settingView);
			};



			var logOutButton = new Button {
				Text = " تسجيل خــــروج ",
				TextColor = Color.White,
				FontSize = 15,
				BackgroundColor = Color.Red,
				VerticalOptions = LayoutOptions.End
			};

			Content = new StackLayout {
				VerticalOptions= LayoutOptions.FillAndExpand,
				Padding = 20 ,
				Children = {  
					setting ,
					logOutButton
				}
			};

		}

		public List<everyCell> getSettingList() {
			
	//================================================= 1
			var yourname = new Label {
				Text = "اسمك : ",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.End,
			};

			var nameEntry = new Entry {
				Placeholder = "أدخل اسمك هنا"	,

			};

	//================================================= 2
			var yourPass = new Label {
				Text = "كلمة المرور : ",
				FontSize = 20,
				HorizontalOptions = LayoutOptions.End,
			};

			var passwordEntry = new Entry {
				Placeholder = "أدخل كلمة المرور هنا"	,

			};

			var passConfirm = new Entry {
				Placeholder = " تأكيد كلمة المرور"	,

			};
	//================================================  3 

			var saveNameButton = new Button {
				Text = " حفظ البيانات ",

			};
			saveNameButton.Clicked += (sender, e) => {
				if(!nameEntry.Text.Equals(null)){
					pbcareApp.u.name = nameEntry.Text ;
					Navigation.PopAsync();
					DisplayAlert("  تم","  تغيير الاسم إلى"+nameEntry.Text,"موافق");

				}else{
					DisplayAlert("خطأ","لم يتم إدخال أي اسم","إلغاء");

				}
			};

			var savePassButton = new Button{
				Text = "حفظ البيانات"
			};

			savePassButton.Clicked += (sender, e) => {
				if(!passwordEntry.Text.Equals(null) && passConfirm.Text.Equals(passwordEntry.Text)){
					pbcareApp.u.Password = passwordEntry.Text ;
					Navigation.PopAsync();
					DisplayAlert(" تم"," تغيير كلمة المرور ","موافق");

				}else if(passwordEntry.Text != passConfirm.Text ){
					DisplayAlert("خطأ","كلمة المرور غير متطابقة","إلغاء");

				}else if(passConfirm.Text.Equals(null) && passwordEntry.Text.Equals(null)){
					DisplayAlert("خطأ","لم يتم إدخال كلمة مرور","إلغاء");
				}

			};

			var CancelNameButton = new Button {
				Text = "إلغاء",

			};

			CancelNameButton.Clicked += (sender, e) => {
				Navigation.PopAsync();
			};

			var CancelPassButton = new Button {
				Text = "إلغاء",

			};

			CancelPassButton.Clicked += (sender, e) => {
				Navigation.PopAsync();
			};
			return new List<everyCell> {
				// frist cell " change name " 
				new everyCell {
					Name = "تغيير الاسم",
					View = new StackLayout {
						VerticalOptions = LayoutOptions.FillAndExpand,
						Children = { yourname, nameEntry, saveNameButton, CancelNameButton}
					}
				},

				// second cell " change password "
				new everyCell {
					Name = "تغيير كلمة المرور" ,
					View = new StackLayout {
						VerticalOptions = LayoutOptions.FillAndExpand,
						Children = { yourPass, passwordEntry, passConfirm, savePassButton, CancelPassButton}
					}
				},


			};

	/*		var activityIndicator = new ActivityIndicator {
				IsEnabled = true,
				IsRunning = true
			};

			var boxView = new BoxView {
				Color = Color.Red
			};

			var button = new Button {
				Text = "Click Me"
			};
			var buttonLabel = new Label {
				Text = ""
			};
			button.Clicked += (sender, e) => {
				buttonLabel.Text = "I've been clicked!";
			};
			var buttonStack = new StackLayout {
				Children = { button, buttonLabel }
			};

			var datePicker = new DatePicker ();

			var editor = new Editor {
				Text = "You can edit multiple lines of text here!"
			};
			var entry1 = new Entry {
				Placeholder = "Enter a single line of text"
			};

			var image = new Image {
				Source = ImageSource.FromUri(new Uri("http://placehold.it/350x150"))
			};

			var label = new Label {
				Text = "Hello, I'm a label!"
			};

			var picker = new Picker ();
			picker.Items.Add ("Red");
			picker.Items.Add ("Green");
			picker.Items.Add ("Purple");
			picker.Items.Add ("Grey");
			picker.Items.Add ("Black");

			var progressBar = new ProgressBar {
				Progress = 0	
			};
			var progressButton = new Button {
				Text = "Start Progressing"
			};
			progressButton.Clicked += async (sender, e) => {
				await progressBar.ProgressTo(1.0, 500, Easing.Linear);
			};

			var progressStack = new StackLayout {
				Children = { progressBar, progressButton }
			};

			var searchBar = new SearchBar ();

			var slider = new Slider ();

			var stepper = new Stepper ();

			var @switch = new Switch ();

			var timePicker = new TimePicker ();

			var webView = new WebView {
				Source = new UrlWebViewSource {
					Url = "https://tutsplus.com/"
				},
				VerticalOptions = LayoutOptions.FillAndExpand
			};*/

			//			return new List<everyCell> {
			//				new everyCell {
			//					Name = "ActivityIndicator",
			//					View = activityIndicator
			//				},
			//				new everyCell {
			//					Name = "BoxView",
			//					View = boxView
			//				},
			//				new everyCell {
			//					Name = "Button",
			//					View = buttonStack
			//				},
			//				new everyCell {
			//					Name = "DatePicker",
			//					View = datePicker
			//				},
			//				new everyCell {
			//					Name = "Editor",
			//					View = editor
			//				},
			//				new everyCell {
			//					Name = "Entry",
			//					View = entry
			//				},
			//				new everyCell {
			//					Name = "Image",
			//					View = image
			//				},
			//				new everyCell {
			//					Name = "Label",
			//					View = label
			//				},
			//				new everyCell {
			//					Name = "Picker",
			//					View = picker
			//				},
			//				new everyCell {
			//					Name = "ProgressBar",
			//					View = progressStack
			//				},
			//				new everyCell {
			//					Name = "SearchBar",
			//					View = searchBar
			//				},
			//				new everyCell {
			//					Name = "Slider",
			//					View = slider
			//				},
			//				new everyCell {
			//					Name = "Stepper",
			//					View = stepper
			//				},
			//				new everyCell {
			//					Name = "Switch",
			//					View = @switch
			//				},
			//				new everyCell {
			//					Name = "TimePicker",
			//					View = timePicker
			//				},
			//				new everyCell {
			//					Name = "WebView",
			//					View = webView
			//				}
			//			};
		}
	}

	//--------------------------------------------------------------
	public class everyCell 
	{
		public string Name { get; set; }
		public View View { get; set; }

		//		public everyCell (string n , View v)
		//		{
		//			this.Name = n;
		//			this.View = v;
		//		}
	}

	//-------------------------------------------------------------

	public class settingView : ContentPage 
	{
		public settingView (everyCell sample)
		{
			Title = sample.Name;
			sample.View.HorizontalOptions = LayoutOptions.FillAndExpand;
			Content = new StackLayout {
				Padding = 20,
				Orientation = StackOrientation.Vertical,
				Children = { sample.View }
			};
		}
	}
}



