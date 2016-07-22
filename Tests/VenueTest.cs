using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class VenueTest : IDisposable
  {
    public VenueTest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=band_tracker_test;Integrated Security=SSPI;";
    }
    [Fact]
    public void Test_DatabaseEmptyAtFirst()
    {
      int result = Band.GetAll().Count;

      Assert.Equal(0, result);
    }

    [Fact]
    public void Test_Save_SavesToDatabase()
    {
      Venue testVenue = new Venue("Shatter Dome");

      testVenue.Save();
      List<Venue> result = Venue.GetAll();
      List<Venue> testList = new List<Venue>{testVenue};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindsVenueInDatabase()
    {
      Venue testVenue = new Venue("Shatter Dome");
      testVenue.Save();

      Venue foundVenue = Venue.Find(testVenue.GetId());

      Assert.Equal(testVenue, foundVenue);
    }

    [Fact]
    public void Test_AddBand_AddsBandToVenue()
    {
      Band testBand = new Band("Frets on Fire", 1);
      testBand.Save();
      Venue testVenue = new Venue("Shatter Dome");
      testVenue.Save();

      testVenue.AddBand(testBand);

      List<Band> testList = new List<Band>{testBand};
      List<Band> result = testVenue.GetBands();

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_GetBands_ReturnsAllBandBands()
    {
      Venue testVenue = new Venue("Shatter Dome");
      testVenue.Save();
      Band testBand1 = new Band("Frets on Fire", 1);
      testBand1.Save();
      Band testBand2 = new Band("Crimson Typhoon and the Knife Heads", 1);
      testBand2.Save();

      testVenue.AddBand(testBand1);
      testVenue.AddBand(testBand2);

      List<Band> testList = new List<Band> {testBand1, testBand2};
      List<Band> result = testVenue.GetBands();

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Update_UpdatesVenueWithNewValues()
    {
      Venue testVenue = new Venue("Shatter Dome", 1);
      testVenue.Save();

      testVenue.SetName("Belly of the Beast");
      testVenue.Update();

      Venue resultVenue = Venue.Find(testVenue.GetId());
      Venue test = new Venue("Belly of the Beast", testVenue.GetId());

      Assert.Equal(test, resultVenue);
    }

    [Fact]
    public void Test_Delete_DeletesVenueFromDatabase()
    {
      Venue testVenue1 = new Venue("Shatter Dome");
      testVenue1.Save();
      Venue testVenue2 = new Venue("Belly of the Beast");
      testVenue2.Save();

      Venue.Delete(testVenue1.GetId());

      List<Venue> testList = new List<Venue>{testVenue2};
      List<Venue> resultList = Venue.GetAll();

      Assert.Equal(testList, resultList);
    }

    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
