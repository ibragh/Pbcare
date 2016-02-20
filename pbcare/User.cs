using System;
using Xamarin.Forms; 
using System.Collections.Generic;

namespace pbcare
{
	public class User
	{
		public string Email { get; set; }
		public string Password { get; set; }
		public string Username { get; set;}
		public List<Child> MyChilren  = new List<Child>(); 


	public User(){
			
		}
		
	}

}