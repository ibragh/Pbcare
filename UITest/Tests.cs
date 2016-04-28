using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Queries;
using Xamarin.UITest.iOS;
using Xamarin.UITest.Android;

namespace pbcare
{
	[TestFixture (Platform.Android)]
	[TestFixture (Platform.iOS)]
	public class Tests
	{
		IApp app;
		Platform platform;

		public Tests (Platform platform)
		{
			this.platform = platform;
		}

		[SetUp]
		public void BeforeEachTest ()
		{
			app = AppInitializer.StartApp (platform);
		}

[Test]
public void AddDueDateTest ()
{;
	app.EnterText ("emailEntry", "A@a");
	app.EnterText ("passwordEntry", "A");
	app.DismissKeyboard();
	app.Tap ("LoginButton");
	app.Tap ("AddDuDate");
	app.Tap ("MyDueDate");
	app.Tap ("AddMyDueDate");
	app.Tap("button2");
	app.Back();
	app.Tap("FollowPregnancy");
}
[Test]
public void SwipeBetweenPages ()
{
	app.Tap("FollowPregnancy");
	app.SwipeRightToLeft();
	app.SwipeRightToLeft();
	app.SwipeRightToLeft();
	app.SwipeRightToLeft (0.9, 800, true);
	app.SwipeRightToLeft (0.999, 900, false);
	app.SwipeLeftToRight (0.999, 2000, false);
	app.SwipeLeftToRight (0.999, 4000, false);
	app.SwipeRightToLeft (0.999, 2000, false);
	app.Back();
	app.Tap(v => v.Text("حملي"));
	app.Tap(v => v.Text("أطفالي"));
	app.Tap(v => v.Text("المنتدى"));
}
[Test]
public void LogoutTest ()
{
	app.Tap(v => v.Text("حملي"));
	app.Tap(v => v.Text("أطفالي"));
	app.Tap(v => v.Text("المنتدى"));
	app.Tap(v => v.Text("الإعدادات"));
	app.Tap("LogoutButton");
	app.Tap("button1");
}
	}
}

