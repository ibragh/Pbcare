using System;
using Xunit;
using pbcare;
using Xamarin.Forms;

namespace pbcare.Tests
{
public class ProjectTests
{
DateTime DueDate_Oct_20_2016 = DateTime.ParseExact ("20102016", "ddMMyyyy", null);
DateTime DueDate_Oct_20_2015 = DateTime.ParseExact ("20102015", "ddMMyyyy", null);
DateTime DueDate_Jul_15_2016 = DateTime.ParseExact ("20072016", "ddMMyyyy", null);
String Bd_Oct_20_2015 = "20102015";
DateTime Bd_Oct_20_2014 = DateTime.ParseExact ("20102014", "ddMMyyyy", null);

[Fact]
public void GetPregnancyCurrentWeek ()
{
	// Oct_20_2016
	Assert.Equal (PregnancyPage.CurrentWeek (DueDate_Oct_20_2016), 10); 
	// Depending on Today April_28_2016 Current week of DueDate Oct_20_2016
	// Should be week 15
}

[Fact]
public void ValidDueDate ()
{
	Assert.InRange (DueDate_Oct_20_2015, DateTime.Now.AddDays (-1), DateTime.Now.AddMonths (10));
	// Bcz Oct_20_2016 is a vild range The test will pass
	// he range is maximim 10 months and minim is current day
	// Otherwise Due Dateis not true
}

[Fact]
public void UserIsNotLoggenIn ()
{
	Assert.False (pbcareApp.IsUserLoggedIn);
}

[Fact]
public void GetBabyCurrentMonth ()
{
	Assert.Equal (BabyPage.CurrentMonth (Bd_Oct_20_2015), 10); 
	// Depending on Today April_28_2016 Current month of Birth date Oct_20_2015
	// the baby should be 7 month old
}

[Fact]
public void ValidBabyBirthDate ()
{
	Assert.InRange (Bd_Oct_20_2014, DateTime.Now.AddMonths (-11), DateTime.Now.AddMonths (12)); 
	// Bcz Oct_20_2016 is a vild range The test will pass
	// he range is maximim 12 months and minim is 11 months
	// Otherwise our aplication will not support child age
}

[Fact]
public void ValidEmailAddress ()
{
	// http://stackoverflow.com/a/16168117/563844
	string EmailRegex = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}" +
	                    @"\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\" +
	                    @".)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
	
	Assert.Matches (EmailRegex, "abc@mail@mail.com");
}
}
}

