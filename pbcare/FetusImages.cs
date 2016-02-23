using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace pbcare
{
	public class FetusImages : ContentPage
	{
		public FetusImages ()
		{

			var im = new Grid {
				RowDefinitions = new RowDefinitionCollection  {
					new RowDefinition {Height = new GridLength(1 , GridUnitType.Star)},
					new RowDefinition {Height = new GridLength(1 , GridUnitType.Star)},
					new RowDefinition {Height = new GridLength(1 , GridUnitType.Star)},
					new RowDefinition {Height = new GridLength(1 , GridUnitType.Star)}
				},
				ColumnDefinitions = new ColumnDefinitionCollection{
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
					new ColumnDefinition {Width = new GridLength(1, GridUnitType.Star)},
				}
					
			};
			var l = new Label{
				BackgroundColor = Color.Black
			};
			var l2 = new Label{
				BackgroundColor = Color.Pink
			};
			var l23 = new Label{
				BackgroundColor = Color.Green
			};

			im.Children.Add(l , 0 , 1);
			im.Children.Add(l2 , 2 , 1);
			im.Children.Add(l23 , 6 , 1);

			Content = new StackLayout{
				Padding = 20,
				Children = {
					im 
				}
			};
		}		
	}
}


