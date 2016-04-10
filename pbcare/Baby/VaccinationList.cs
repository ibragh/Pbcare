using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace pbcare
{
	public class VaccinationList : ContentPage
	{
		public static List<vaccinationTable> Vaccinations = new List<vaccinationTable>(); 

		public VaccinationList (Child c)
		{
			this.Title = c.name + "  تطعيمات ";
			BackgroundImage = null;

			ListView vaccinationList = new ListView {
				RowHeight = 50
			};
			Vaccinations =  pbcareApp.Database.getVaccinationsFromDB();

			vaccinationList.ItemsSource = Vaccinations;
			vaccinationList.ItemTemplate = new DataTemplate (typeof(EveryVaccinationCell));


			Content = new StackLayout {
				VerticalOptions= LayoutOptions.FillAndExpand,
				Padding = 15,
				Children = {  
					vaccinationList
				}
			};
		}
	}
}


