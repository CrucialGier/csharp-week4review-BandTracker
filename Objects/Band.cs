using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker

{
  public class Band
  {
    private int _id;
    private string _name;
    private int _venueId;

    public Band(string Name, int VenueId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _venueId = VenueId;
    }

    public int GetId()
    {
      return _id;
    }

    public string GetName()
    {
      return _name;
    }
    public void SetName(string Name)
    {
      _name = Name;
    }

    public int GetVenueId()
    {
      return _venueId;
    }
    public void SetVenueId()
    {
      _venueId = VenueId;
    }

    
  }
}
