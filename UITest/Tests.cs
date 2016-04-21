﻿using System;
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
		public void AppLaunches ()
		{
			app.Repl ();
//			app.EnterText ("emailEntry", "A@a");
//			app.EnterText ("passwordEntry", "A");
//			app.Tap (c => c.Button ("تســـجيل الدخــول"));
//			app.Tap (c => c.Button ("إضافة حمل"));

		}
	}
}

