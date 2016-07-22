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

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("INSERT INTO bands (name, venue_id) OUTPUT INSERTED.id VALUES (@BandName, @BandVenueId);", conn);

      SqlParameter bandNameParameter = new SqlParameter();
      bandNameParameter.ParameterName = "@BandName";
      bandNameParameter.Value = this.GetName();

      SqlParameter bandVenueIdParameter = new SqlParameter();
      bandVenueIdParameter.ParameterName = "@BandVenueId";
      bandVenueIdParameter.Value = this.GetVenueId();

      cmd.Parameters.AddbandNameParameter);
      cmd.Parameters.Add(bandVenueIdParameter);

      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        this._id = rdr.GetInt32(0);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
    }

  }
}
