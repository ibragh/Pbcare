using System;

using Xamarin.Forms;

namespace pbcare
{
	public class EveryVaccinationCell : ViewCell
	{
		public EveryVaccinationCell ()
		{
			var VaccinationName = new Label {
				Text = " . ",
				TextColor = Color.White ,
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold,
				HorizontalOptions = LayoutOptions.Start,
				VerticalOptions = LayoutOptions.Start,


			};
			VaccinationName.SetBinding(Label.TextProperty, "name");

			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				Padding = new Thickness (15, 5, 15, 15),

				Children = {
					new StackLayout {
						Padding = new Thickness (15, 5, 0, 15),
						Orientation = StackOrientation.Vertical,
						HorizontalOptions = LayoutOptions.EndAndExpand,
						Children = { VaccinationName 
						},


					}
				}
			};
		}
	}
}


