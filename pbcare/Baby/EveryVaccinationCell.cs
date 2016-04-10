using System;

using Xamarin.Forms;

namespace pbcare
{
	public class EveryVaccinationCell : ViewCell
	{
		public EveryVaccinationCell ()
		{
			var ss = new Label{ 
				BackgroundColor = Color.Transparent,
				TextColor = Color.Transparent,
				Text = "000",
			};
			var VaccinationName = new Label {
				Text = " . ",
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold
			};
			VaccinationName.SetBinding(Label.TextProperty, "name");

			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.EndAndExpand,
				Padding = new Thickness (15, 5, 0, 15),

				Children = {
					new StackLayout {
						Padding = new Thickness (15, 5, 0, 15),
						Orientation = StackOrientation.Vertical,
						HorizontalOptions = LayoutOptions.EndAndExpand,
						Children = { VaccinationName}
					},
					ss

				}
			};
		}
	}
}


