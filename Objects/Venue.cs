using System.Collections.Generic;
using System.Data.SqlClient;
using System;

namespace BandTracker

{
  public class Venue
  {
    private int _id;
    private string _name;
    private int _bandId;

    public Band(string Name, int BandId, int Id = 0)
    {
      _id = Id;
      _name = Name;
      _bandId = BandId;
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

    public int GetBandId()
    {
      return _bandId;
    }
    public void SetBandId()
    {
      _bandId = BandId;
    }


  }
}
