using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace pbcare
{
	public class AddPregnancy : ContentPage
	{
		static string FinaldueDate;
		public AddPregnancy ()
		{

			Label OptionText = new Label{
				Text="أدخلي تاريخ الولادة",
				HorizontalOptions = LayoutOptions.CenterAndExpand
				};

			var dueDate = new DatePicker {
				Format= "D",
				VerticalOptions = LayoutOptions.CenterAndExpand
			};

			Button CalMyDate = new Button{
				Text="Calculate my Due date", 
				TextColor=Color.Red,HorizontalOptions=LayoutOptions.Center,
				Font = Font.SystemFontOfSize(NamedSize.Large),
				BorderWidth = 2,
			};
				
			CalMyDate.Clicked += (object sender, EventArgs e) => {

				Navigation.PushAsync(new CalMyDueDate());
			};
		
				Content = new StackLayout{ 
				VerticalOptions = LayoutOptions.CenterAndExpand, Padding=20,
				Children = {
					
					OptionText,
					dueDate,
					CalMyDate
				}
			};

		}
	}
}


