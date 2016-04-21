using System;
using Xamarin.Forms;
using pbcare.Droid;
using Android.Media;

[assembly: Xamarin.Forms.Dependency (typeof(AudioService))]

namespace pbcare.Droid
{
	public class AudioService : IAudio
	{
		public AudioService() {}

		private MediaPlayer _mediaPlayer;

		public bool PlayAlarm()
		{

			_mediaPlayer = MediaPlayer.Create (global::Android.App.Application.Context, Resource.Raw.Alarm_Clock);
			_mediaPlayer.Looping = true;
			_mediaPlayer.Start ();

			return true;
		}

		public bool StopAlarm()
		{
			_mediaPlayer.Stop ();
			return true;
		}
	}
}