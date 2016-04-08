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
				FontSize = Device.GetNamedSize (NamedSize.Medium, typeof(Label)),
				FontAttributes = FontAttributes.Bold
			};
			VaccinationName.SetBinding(Label.TextProperty, "name");

			View = new StackLayout {
				Orientation = StackOrientation.Horizontal,
				HorizontalOptions = LayoutOptions.StartAndExpand,
				Padding = new Thickness (15, 5, 5, 15),

				Children = {

					new StackLayout {
						Padding = new Thickness (15, 5, 5, 15),
						Orientation = StackOrientation.Vertical,
						Children = { VaccinationName }
					}
				}
			};
		}
	}
}


