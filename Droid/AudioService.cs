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

		public bool PlayMp3File(string fileName)
		{

				_mediaPlayer = MediaPlayer.Create (global::Android.App.Application.Context, Resource.Raw.test);
				_mediaPlayer.Looping = true;

				_mediaPlayer.Start ();

			return true;
		}

		public bool StopMP3File()
		{

			_mediaPlayer.Stop ();

			return true;
		}
	}
}