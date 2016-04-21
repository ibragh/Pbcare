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
using Xamarin.Forms;
using System.Diagnostics;

[assembly: Xamarin.Forms.Dependency (typeof(Bth))]
namespace pbcare.Droid
{
	public class Bth : IBth
	{

		private BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
		private BluetoothSocket BthSocket = null;
		private Stream inStream = null;
		BluetoothDevice device = null;

		private bool IsThreadOff { get; set; }

		const int RequestResolveError = 1000;

		public Bth ()
		{
		}

		public void Start (string name)
		{
			Task.Run (async() => {

				IsThreadOff = false;
				while (IsThreadOff == false) {

					try {
						//Thread.Sleep (200);

						adapter = BluetoothAdapter.DefaultAdapter;

						if (adapter == null) {
							Debug.WriteLine ("No Bluetooth adapter found.");
							MessagingCenter.Send<pbcareApp, string> ((pbcareApp)Application.Current, "6", "No Bluetooth adapter found.");
							break;

						} else {
						
							Debug.WriteLine ("Adapter found!!");
							if (!adapter.IsEnabled) {
								Debug.WriteLine ("Bluetooth adapter is not enabled.");
								MessagingCenter.Send<pbcareApp, string> ((pbcareApp)Application.Current, "5", "Bluetooth adapter is not enabled.");

							} else {
								Debug.WriteLine ("Adapter enabled!");

								// Scann paired Devices to connect with the Named Device
								foreach (var bd in adapter.BondedDevices) {
									Debug.WriteLine ("Paired devices found: " + bd.Name.ToUpper ());
									if (bd.Name.ToUpper ().IndexOf (name.ToUpper ()) >= 0) {
										device = bd;
										break;
									}
								}

								if (device == null) {
									MessagingCenter.Send<pbcareApp, string> ((pbcareApp)Application.Current, "4", "Named device not found");
									Debug.WriteLine ("Named device not found.");
								} else {
									BthSocket = device.CreateRfcommSocketToServiceRecord (UUID.FromString ("00001101-0000-1000-8000-00805f9b34fb"));

									if (BthSocket != null) {

										BthSocket.Connect ();

										if (BthSocket.IsConnected) {
											MessagingCenter.Send<pbcareApp, string> ((pbcareApp)Application.Current, "3", "Bleutooth Connected");
											Debug.WriteLine ("Connected!");
											// Check Whether Thread Is Canceled OR NOT
											while (IsThreadOff == false) {
												// Begin Listen To ---------------
												inStream = BthSocket.InputStream;
												byte[] buffer = new byte[1024];

												inStream.Read (buffer, 0, buffer.Length);
												string valor = System.Text.Encoding.ASCII.GetString (buffer);
												if (valor.Contains ("1")) {
													MessagingCenter.Send<pbcareApp, string> ((pbcareApp)Application.Current, "1", "There is Movement Detected");
													Debug.WriteLine ("value is 1");
												} 

												//                 ---------------
												// A little stop to the uneverending thread...
												//Thread.Sleep (200);
												if (!BthSocket.IsConnected) {

													Debug.WriteLine ("BthSocket.IsConnected = false, Throw exception");
													throw new Exception ();
												}
											}

											Debug.WriteLine ("Exit the inner loop");

										}
									} else
										Debug.WriteLine ("BthSocket = null");

								}
							}
						}
					} catch (Exception ex) {
						MessagingCenter.Send<pbcareApp, string> ((pbcareApp)Application.Current, "2", "Bluetooth Is NOT Connected.");
						Debug.WriteLine ("Line 120> ********" + ex.ToString ());

					} finally {
						IsThreadOff = true;
						if (BthSocket != null) {
							BthSocket.Close ();
						}
						device = null;
						adapter = null;
						//	break;
					}			
				}
				Debug.WriteLine ("Exit the external loop");
			});
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
		//					Debug.WriteLine ("types r");
		//					byte[] b;
		//					b = GetBytes ("b");
		//
		//					if (i < 40) {
		//						_os.Write (r, 0, r.Length);
		//					} else {
		//						_os.Write (b, 0, b.Length);
		//						Debug.WriteLine ("types b");
		//					}
		//
		//				}


		/// <summary>
		/// Cancel the Reading loop
		/// </summary>
		/// <returns><c>true</c> if this instance cancel ; otherwise, <c>false</c>.</returns>
		public void Cancel ()
		{
			
			// Send message to stop Warning Sound
			MessagingCenter.Send<pbcareApp, string> ((pbcareApp)Application.Current, "0", "bluetooth task is canceled");
			Debug.WriteLine ("Send a cancel to task!");
			IsThreadOff = true;
			try {
				BthSocket.Close ();
			} catch (Exception ex) {
				Debug.WriteLine ("BthSocket.Close () in Cancel Method Exception" + ex.Message);
			}
		}
	}

}

