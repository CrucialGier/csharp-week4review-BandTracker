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

    public Venue(string Name, int BandId, int Id = 0)
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
    public void SetBandId(int BandId)
    {
      _bandId = BandId;
    }

    public override bool Equals(System.Object otherVenue)
    {
      if (!(otherVenue is Venue))
      {
        return false;
      }
      else
      {
        Venue newVenue = (Venue) otherVenue;
        bool idEquality = this.GetId() == newVenue.GetId();
        bool nameEquality = this.GetName() == newVenue.GetName();
        bool bandIdEquality = this.GetBandId() == newVenue.GetBandId();
        return (idEquality && nameEquality && bandIdEquality);
      }
    }

    public void Save()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("INSERT INTO venues (name, band_id) OUTPUT INSERTED.id VALUES (@VenueName, @VenueBandId);", conn);

      SqlParameter venueNameParameter = new SqlParameter();
      venueNameParameter.ParameterName = "@VenueName";
      venueNameParameter.Value = this.GetName();

      SqlParameter venueBandIdParameter = new SqlParameter();
      venueBandIdParameter.ParameterName = "@VenueBandId";
      venueBandIdParameter.Value = this.GetBandId();

      cmd.Parameters.Add(venueNameParameter);
      cmd.Parameters.Add(venueBandIdParameter);

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

    public static List<Venue> GetAll()
    {
      List<Venue> AllVenues = new List<Venue>{};

      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlDataReader rdr;

      SqlCommand cmd = new SqlCommand("SELECT * FROM venues;", conn);
      rdr = cmd.ExecuteReader();

      while(rdr.Read())
      {
        int venueId = rdr.GetInt32(0);
        string venueName = rdr.GetString(1);
        int venueBandId = rdr.GetInt32(2);
        Venue newVenue = new Venue(venueName, venueBandId, venueId);
        AllVenues.Add(newVenue);
      }
      if (rdr != null)
      {
        rdr.Close();
      }
      if (conn != null)
      {
        conn.Close();
      }
      return AllVenues;
    }

    public static void DeleteAll()
    {
      SqlConnection conn = DB.Connection();
      conn.Open();
      SqlCommand cmd = new SqlCommand("DELETE FROM venues;", conn);
      cmd.ExecuteNonQuery();
    }
  }
}
