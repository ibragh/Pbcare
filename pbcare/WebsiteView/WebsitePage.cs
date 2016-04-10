using System;

using Xamarin.Forms;

namespace pbcare
{
	public class WebsitePage : ContentPage
	{
		public WebsitePage ()
		{
			this.Title = "المنتدى";


		}

		protected override void OnAppearing()
		{
			NavigationPage.SetHasNavigationBar (this, false);
		}
			
		}
	}



