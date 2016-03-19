using System;

using Xamarin.Forms;
using System.Diagnostics;

namespace pbcare
{
	public class FollowPregnancy : CarouselPage
	{
		public FollowPregnancy ()
		{
			this.Title = "PregnancyWeekly";
			string[] info = new string[44];

			try {
				for (int i = 1; i < info.Length; i++) {
					info [i] = pbcareApp.Database.InsertIntoPregnancyWeekly (i);
				}
				
				this.ItemsSource = new PregnancyWeekly[] {
					new PregnancyWeekly ("week1", info [1]),
					new PregnancyWeekly ("week2", info [2]),
					new PregnancyWeekly ("week3", info [3]),
					new PregnancyWeekly ("week4", info [4]),
					new PregnancyWeekly ("week5", info [5]),
					new PregnancyWeekly ("week6", info [6]),
					new PregnancyWeekly ("week6", info [7]),
					new PregnancyWeekly ("week7", info [8]),
					new PregnancyWeekly ("week8", info [9]),
					new PregnancyWeekly ("week9", info [10]),
					new PregnancyWeekly ("week4", info [11]),
					new PregnancyWeekly ("week5", info [12]),
					new PregnancyWeekly ("week6", info [13]),
					new PregnancyWeekly ("week6", info [14]),
					new PregnancyWeekly ("week1", info [15]),
					new PregnancyWeekly ("week2", info [16]),
					new PregnancyWeekly ("week3", info [17]),
					new PregnancyWeekly ("week4", info [18]),
					new PregnancyWeekly ("week5", info [19]),
					new PregnancyWeekly ("week6", info [20]),
					new PregnancyWeekly ("week6", info [21]),
					new PregnancyWeekly ("week3", info [22]),
					new PregnancyWeekly ("week4", info [23]),
					new PregnancyWeekly ("week5", info [24]),
					new PregnancyWeekly ("week6", info [25]),
					new PregnancyWeekly ("week6", info [26]),
					new PregnancyWeekly ("week1", info [27]),
					new PregnancyWeekly ("week2", info [28]),
					new PregnancyWeekly ("week3", info [29]),
					new PregnancyWeekly ("week4", info [30]),
					new PregnancyWeekly ("week5", info [31]),
					new PregnancyWeekly ("week6", info [32]),
					new PregnancyWeekly ("week6", info [33]),
					new PregnancyWeekly ("week6", info [34]),
					new PregnancyWeekly ("week6", info [35]),
					new PregnancyWeekly ("week6", info [36]),
					new PregnancyWeekly ("week5", info [37]),
					new PregnancyWeekly ("week6", info [38]),
					new PregnancyWeekly ("week6", info [39]),
					new PregnancyWeekly ("week6", info [40]),
					new PregnancyWeekly ("week6", info [41]),
					new PregnancyWeekly ("week6", info [42]),
				};
			
				this.ItemTemplate = new DataTemplate (() => {
					return new PregnancyWeeklyPage (true);
				});
				this.SelectedItem = ((PregnancyWeekly[])ItemsSource) [2];

			} catch (Exception ex) {
				Debug.WriteLine (ex.ToString ());
			}
		}
	}
}

