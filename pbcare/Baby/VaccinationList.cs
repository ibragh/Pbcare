using System;

using Xamarin.Forms;
using System.Collections.Generic;

namespace pbcare
{
	public class VaccinationList : ContentPage
	{
		public static List<vaccinationTable> Vaccinations = new List<vaccinationTable>(); 
		ListView vaccinationList = new ListView {
			RowHeight = 40
		};
		public VaccinationList (Child c)
		{
			this.Title = c.name + "  تطعيمات ";
			BackgroundColor = Color.White;


			Vaccinations =  pbcareApp.Database.getVaccinationsFromDB();

			vaccinationList.ItemsSource = Vaccinations;
			vaccinationList.ItemTemplate = new DataTemplate (typeof(EveryVaccinationCell));

			vaccinationList.ItemSelected +=  (Sender, Event) => {
				var V = (vaccinationTable)Event.SelectedItem;
				Navigation.PushAsync(new VaccinationInfoView(V));
			};

			Content = new StackLayout {
				VerticalOptions= LayoutOptions.FillAndExpand,
				Padding = new Thickness(0, 10, 0, 10 ),
				Children = {  
					vaccinationList
				}
			};
		}

		protected override void OnAppearing ()
		{
			Content = new StackLayout {
				VerticalOptions= LayoutOptions.FillAndExpand,
				Padding = new Thickness(0, 10, 0, 10),
				Children = {  
					vaccinationList
				}
			};
			//vaccinationList.SelectedItem = null;
			base.OnAppearing ();
		}
	}

	//-------------------------------------------------------
	public class VaccinationInfoView : ContentPage
	{
		public VaccinationInfoView (vaccinationTable V)
		{
			BackgroundColor = Color.White;
			var VName = new Label{ 
				Text = V.name,
				FontSize = Device.GetNamedSize(NamedSize.Large , typeof(Label)),
				HorizontalOptions = LayoutOptions.Center
			};
			var VInfo = new Label{ 
				Text = "تعتبر اللّغة العربيّة إحدى أكثر اللّغات انتشاراً في العالم، وهي لغة القرآن وسنّة النبيّ محمد صلّى الله عليه وسلّم، بالإضافة على أنّها لغةٍ مقدّسةٍ يتحدثّها يوميّاً ما يقارب خمسمئة مليون شخص، وتسمّى بلغة الضّاد، وذلك لعدم وجود حرف الضّاد في لغة أخرى، وتتّسم اللّغة العربيّة بالروعة والجمال وقوتها التي لم تستطع لغات العالم مجاراتها بسبب ترنيمتها الدقيقة، وتتوزع فيها مخارج الحروف من الشفتين إلى أعلى الحلق لتشكل ترنيمة صوتيّة قوية وواسعة، ويبلغ عدد حروف اللّغة العربيّة ثمانية وعشرون حرفاً لتكون من أقلّ لغات العالم حروفاً، وتُقام الاحتفالات للّغة العربيّة في كلّ سنة وذلك في اليوم الثامن عشر من كانون الثاني في يوم يسمّى باليوم العالميّ للغة العربيّة، فقد تمّ اعتمادها من قبل منظّمة الأمم المتّحدة لتكون واحدة من اللّغات الستّ الرسميّة في العالم، وأهمّ ما يميّز اللّغة الّعربية والفارسيّة بأنّها تكتب من اليمين إلى اليسار على عكس كلّتعتبر اللّغة العربيّة إحدى أكثر اللّغات انتشاراً في العالم، وهي لغة القرآن وسنّة النبيّ محمد صلّى الله عليه وسلّم، بالإضافة على أنّها لغةٍ مقدّسةٍ يتحدثّها يوميّاً ما يقارب خمسمئة مليون شخص، وتسمّى بلغة الضّاد، وذلك لعدم وجود حرف الضّاد في لغة أخرى، وتتّسم اللّغة العربيّة بالروعة والجمال وقوتها التي لم تستطع لغات العالم مجاراتها بسبب ترنيمتها الدقيقة، وتتوزع فيها مخارج الحروف من الشفتين إلى أعلى الحلق لتشكل ترنيمة صوتيّة قوية وواسعة، ويبلغ عدد حروف اللّغة العربيّة ثمانية وعشرون حرفاً لتكون من أقلّ لغات العالم حروفاً، وتُقام الاحتفالات للّغة العربيّة في كلّ سنة وذلك في اليوم الثامن عشر من كانون الثاني في يوم يسمّى باليوم العالميّ للغة العربيّة، فقد تمّ اعتمادها من قبل منظّمة الأمم المتّحدة لتكون واحدة من اللّغات الستّ الرسميّة في الدقيقة، وتتوزع فيها مخارج الحروف من الشفتين إلى أعلى الحلق لتشكل ترنيمة صوتيّة قوية وواسعة، ويبلغ عدد حروف اللّغة العربيّة ثمانية وعشرون حرفاً لتكون من أقلّ لغات العالم حروفاً، وتُقام الاحتفالات للّغة العربيّة في كلّ سنة وذلك في اليوم الثامن عشر من كانون الثاني في يوم يسمّى باليوم العالميّ للغة العربيّة، فقد تمّ اعتمادها من قبل منظّمة الأمم المتّحدة لتكون واحدة من اللّغات الستّ الرسميّة في العالم، وأهمّ ما يميّز اللّغة الّعربية والفارسيّة بأنّها تكتب من اليمين إلى اليسار على عكس كلّ لغات العال\n\nإقرأ المزيد على موضوع.كوم: http://mawdoo3.com/%D9%85%D9%82%D8%A7%D9%84_%D8%B9%D9%86_%D8%A3%D9%87%D9%85%D9%8A%D8%A9_%D8%A7%D9%84%D9%84%D8%BA%D8%A9_%D8%A7%D9%84%D8%B9%D8%B1%D8%A8%D9%8A%D8%A9، وأهمّ ما يميّز اللّغة الّعربية والفارسيّة بأنّها تكتب من اليمين إلى اليسار على عكس كلّ لغات العالم.\n\nإقرأ المزيد على موضوع.كوم: http://mawdoo3.com/%D9%85%D9%82%D8%A7%D9%84_%D8%B9%D9%86_%D8%A3%D9%87%D9%85%D9%8A%D8%A9_%D8%A7%D9%84%D9%84%D8%BA%D8%A9_%D8%A7%D9%84%D8%B9%D8%B1%D8%A8%D9%8A%D8%A9 لغات العالم.\n\nإقرأ المزيد على موضوع.كوم: http://mawdoo3.com/%D9%85%D9%82%D8%A7%D9%84_%D8%B9%D9%86_%D8%A3%D9%87%D9%85%D9%8A%D8%A9_%D8%A7%D9%84%D9%84%D8%BA%D8%A9_%D8%A7%D9%84%D8%B9%D8%B1%D8%A8%D9%8A%D8%A9",//V.info,
				FontSize = Device.GetNamedSize(NamedSize.Medium , typeof(Label)),
				HorizontalOptions = LayoutOptions.End
			};

			Content = new StackLayout {
				Padding = new Thickness(0,20,0,0),
				Orientation = StackOrientation.Vertical,
				HorizontalOptions = LayoutOptions.FillAndExpand,
				Children = { 
					new StackLayout{
						Padding = new Thickness(20,0,0,0),
						Children={
							VName
						}
					},
					new ScrollView{
						Content = new StackLayout{
							Padding = new Thickness(10, 5, 10, 10),
							Children = {
								VInfo 
							}
						}
					}
				}
			};
		}
	}
}


