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

  }
}
