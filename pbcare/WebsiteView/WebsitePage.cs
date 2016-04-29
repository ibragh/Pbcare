using System;

using Xamarin.Forms;

namespace pbcare
{
	public class WebsitePage : ContentPage
	{
		WebView browser;
		WebView webView;

		public WebsitePage ()
		{
			StyleId = "WebsitePage";
			Title = "المنتدى";
			//BackgroundColor = Color.FromRgb (94, 196, 225);
			browser = new WebView {
				Source = "www.google.com"
			};


			webView = new WebView
			{
				Source = new UrlWebViewSource
				{
					Url = "https://pbcare.azurewebsites.net/",
				},
				VerticalOptions = LayoutOptions.FillAndExpand
			};

			Content = new ScrollView {
				Content = new StackLayout {
					Children = {
						webView 
					}
				}
			};
					
		}

		protected override void OnAppearing()
		{
				
	   }
	}
}



