using System;
using Android.Bluetooth;
using System.Threading.Tasks;
using pbcare.Droid;
using System.Threading;
using Android.Views;
using Android.Widget;
using System.IO;
using Java.Util;
using System.Text;
using pbcare;

[assembly: Xamarin.Forms.Dependency (typeof(Bth))]
namespace pbcare.Droid
{
	public class Bth : IBth
	{

		private BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
		private BluetoothSocket BthSocket = null;
		private Stream inStream = null;
		BluetoothDevice device = null;
		private CancellationTokenSource _ct { get; set; }

		const int RequestResolveError = 1000;

		public Bth ()
		{
		}

		public void Start (string name)
		{
			Task.Run (async() => loop (name));
		}
		private async Task loop (string name)
		{

			_ct = new CancellationTokenSource ();
			while (_ct.IsCancellationRequested == false) {

				try {
					System.Threading.Thread.Sleep (200);

					adapter = BluetoothAdapter.DefaultAdapter;

					if (adapter == null) {
						System.Diagnostics.Debug.WriteLine ("No Bluetooth adapter found.");
						Xamarin.Forms.MessagingCenter.Send<pbcareApp, string> ((pbcareApp) Xamarin.Forms.Application.Current, "6", "No Bluetooth adapter found.");

					} else {
						System.Diagnostics.Debug.WriteLine ("Adapter found!!");

					}
					if (!adapter.IsEnabled) {
						System.Diagnostics.Debug.WriteLine ("Bluetooth adapter is not enabled.");
						Xamarin.Forms.MessagingCenter.Send<pbcareApp, string> ((pbcareApp) Xamarin.Forms.Application.Current, "5", "Bluetooth adapter is not enabled.");

					} else {

						System.Diagnostics.Debug.WriteLine ("Adapter enabled!");

					}

					foreach (var bd in adapter.BondedDevices) {
						System.Diagnostics.Debug.WriteLine ("Paired devices found: " + bd.Name.ToUpper ());
						if (bd.Name.ToUpper ().IndexOf (name.ToUpper ()) >= 0) {
							device = bd;
							break;
						}
					}

					if (device == null){
						Xamarin.Forms.MessagingCenter.Send<pbcareApp, string> ((pbcareApp) Xamarin.Forms.Application.Current, "4", "Named device not found");
						System.Diagnostics.Debug.WriteLine ("Named device not found.");
					}
					else {
						BthSocket = device.CreateRfcommSocketToServiceRecord (UUID.FromString ("00001101-0000-1000-8000-00805f9b34fb"));

						if (BthSocket != null) {

							BthSocket.Connect ();

							if (BthSocket.IsConnected) {
								Xamarin.Forms.MessagingCenter.Send<pbcareApp, string> ((pbcareApp) Xamarin.Forms.Application.Current, "3", "Bleutooth Connected");
								System.Diagnostics.Debug.WriteLine ("Connected!");
								while (_ct.IsCancellationRequested == false) {
									// Begin Listen To ---------------
									inStream = BthSocket.InputStream;
									byte[] buffer = new byte[1024];

									inStream.Read (buffer, 0, buffer.Length);
									string valor = System.Text.Encoding.ASCII.GetString (buffer);
									if (valor.Contains ("1")) {
										Xamarin.Forms.MessagingCenter.Send<pbcareApp, string> ((pbcareApp) Xamarin.Forms.Application.Current, "1", "There is Movement Detected");
										System.Diagnostics.Debug.WriteLine ("value is 1");
									} 

									//                 ---------------
									// A little stop to the uneverending thread...
									System.Threading.Thread.Sleep (200);
									if (!BthSocket.IsConnected) {

										System.Diagnostics.Debug.WriteLine ("BthSocket.IsConnected = false, Throw exception");
										throw new Exception ();
									}
								}

								System.Diagnostics.Debug.WriteLine ("Exit the inner loop");

							}
						} else
							System.Diagnostics.Debug.WriteLine ("BthSocket = null");

					}


				} catch (Exception ex) {
					Xamarin.Forms.MessagingCenter.Send<pbcareApp, string> ((pbcareApp) Xamarin.Forms.Application.Current, "2", "Bluetooth Is NOT Connected.");
					System.Diagnostics.Debug.WriteLine ("Line 120> ********" + ex.ToString ());
				
				} finally {
					if (BthSocket != null) {
						BthSocket.Close ();
					}
					device = null;
					adapter = null;
					//	break;
				}			
			}


			System.Diagnostics.Debug.WriteLine ("Exit the external loop");
		}



//		public void beginListenForData ()
//		{
//
//		}

//				public void beginWriteForData ()
//				{
//					int i = 0;
//					var _os = BthSocket.OutputStream;
//					var _ints = BthSocket.InputStream;
//					byte[] inpuData = new byte[3];
//					byte[] r;
//					r = GetBytes ("r");
//					System.Diagnostics.Debug.WriteLine ("types r");
//					byte[] b;
//					b = GetBytes ("b");
//		
//					if (i < 40) {
//						_os.Write (r, 0, r.Length);
//					} else {
//						_os.Write (b, 0, b.Length);
//						System.Diagnostics.Debug.WriteLine ("types b");
//					}
//		
//				}


		/// <summary>
		/// Cancel the Reading loop
		/// </summary>
		/// <returns><c>true</c> if this instance cancel ; otherwise, <c>false</c>.</returns>
		public void Cancel ()
		{
			if (_ct != null) {
				// Send message to stop Warning Sound
				Xamarin.Forms.MessagingCenter.Send<pbcareApp, string> ((pbcareApp) Xamarin.Forms.Application.Current, "0", "bluetooth task is canceled");
				System.Diagnostics.Debug.WriteLine ("Send a cancel to task!");
				_ct.Cancel ();
				BthSocket.Close ();

			}
		}
	}

}

