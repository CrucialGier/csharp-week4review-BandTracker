using Xunit;
using System.Collections.Generic;
using System;
using System.Data;
using System.Data.SqlClient;

namespace BandTracker
{
  public class BandTest : IDisposable
  {
    public BandTest()
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
      Band testBand = new Band("Frets on Fire", 0);
      testBand.Save();

      List<Band> testList = new List<Band>{testBand};
      List<Band> result = Band.GetAll();

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_Find_FindsBandInDatabase()
    {
      Band testBand = new Band("Frets on Fire", 0);
      testBand.Save();

      Band foundBand = Band.Find(testBand.GetId());

      Assert.Equal(testBand, foundBand);
    }

    [Fact]
    public void Test_AddVenue_AddsVenueToBand()
    {
      Band testBand = new Band("Frets on Fire", 1);
      testBand.Save();
      Venue testVenue = new Venue("Shatter Dome", 1);
      testVenue.Save();

      testBand.AddVenue(testVenue);

      List<Venue> testList = new List<Venue>{testVenue};
      List<Venue> result = testBand.GetVenues();

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_GetVenues_ReturnsAllBandVenues()
    {
      Band testBand = new Band("Frets on Fire", 1);
      testBand.Save();
      Venue testVenue1 = new Venue("Shatter Dome", 1);
      testVenue1.Save();
      Venue testVenue2 = new Venue("Belly of the Beast", 1);
      testVenue2.Save();

      testBand.AddVenue(testVenue1);
      testBand.AddVenue(testVenue2);

      List<Venue> testList = new List<Venue> {testVenue1, testVenue2};
      List<Venue> result = testBand.GetVenues();

      Assert.Equal(testList, result);
    }

    public void Dispose()
    {
      Band.DeleteAll();
      Venue.DeleteAll();
    }
  }
}
