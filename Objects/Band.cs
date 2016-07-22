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
    public void SetVenueId(int VenueId)
    {
      _venueId = VenueId;
    }

    public override bool Equals(System.Object otherBand)
    {
      if (!(otherBand is Band))
      {
        return false;
      }
      else
      {
        Band newBand = (Band) otherBand;
        bool idEquality = this.GetId() == newBand.GetId();
        bool nameEquality = this.GetName() == newBand.GetName();
        bool venueIdEquality = this.GetVenueId() == newBand.GetVenueId();
        return (idEquality && nameEquality && venueIdEquality);
      }
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

      cmd.Parameters.Add(bandNameParameter);
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

    public static List<Band> GetAll()
    {
      List<Band> AllBands = new List<Band>{};

      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("SELECT * FROM bands;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int bandId = rdr.GetInt32(0);
        string bandName = rdr.GetString(1);
        int bandVenueId = rdr.GetInt32(2);
        Band newBand = new Band(bandName, bandVenueId, bandId);
        AllBands.Add(newBand);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllBands;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM bands;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
