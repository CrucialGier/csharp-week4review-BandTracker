using System.Collections.Generic;
using System;
using Nancy;

namespace BandTracker
{
  public class HomeModule : NancyModule
  {
    public HomeModule()
    {
      Get["/"] =_=> {
        List<Venue> AllVenues = Venue.GetAll();
        return View["index.cshtml", AllVenues];
      };
      Post["/venue/new"] =_=> {
        Venue NewVenue = new Venue(Request.Form["newVenue"]);
        NewVenue.Save();
        List<Venue> AllVenues = Venue.GetAll();
        return View["index.cshtml", AllVenues];
      };
      Patch["/venue/edit/{id}"] =parameters=> {
        Venue changeVenue = Venue.Find(parameters.id);
        changeVenue.SetName(Request.Form["newVenueName"]);
        changeVenue.Update();
        List<Venue> AllVenues = Venue.GetAll();
        return View["index.cshtml", AllVenues];
      };
      Delete["/venue/delete/{id}"] =parameters=> {
        Venue.Delete(parameters.id);
        List<Venue> AllVenues = Venue.GetAll();
        return View["index.cshtml", AllVenues];
      };
      Get["/band/all"] =_=> {
        List<Band> AllBands = Band.GetAll();
        return View["all_bands.cshtml", AllBands];
      };
      Post["/band/new"] =_=> {
        Band NewBand = new Band(Request.Form["newBand"]);
        NewBand.Save();
        List<Band> AllBands = Band.GetAll();
        return View["all_bands.cshtml", AllBands];
      };
    }
  }
}
