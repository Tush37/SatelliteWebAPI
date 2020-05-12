using SatelliteWebAPI.Models.DTOs;
using SatelliteWebAPI.Repository;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace SatelliteWebAPI.Repository
{
    public class SatelliteRepository
    {
        public List<SatelliteDetails> GetSatelliteDetails(string country = null)
        {
            DataTable dt;
            DataTable result;
            List<SatelliteDetails> satelliteDetails = new List<SatelliteDetails>();
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = @"Data Source = (localdb)\mssqllocaldb;Initial Catalog = IRC.SATELLITE.V1.0;Integrated Security=True";
                    //< add name = "satellite" connectionString = "Data Source = (localdb)\mssqllocaldb;Initial Catalog = IRC.SATELLITE.V1.0;Integrated Security = True; MultipleActiveResultSets=True;Application Name = EntityFramework" providerName = "System.Data.SqlClient" />

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = @"GetSatelliteDetails";
                        if (country != null)
                        {
                            cmd.Parameters.Add(new SqlParameter("@Country", country));
                        }
                        //dt = DataMgr.GetData(cmd);                       
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            result = new DataTable();
                            da.Fill(result);
                        }
                    }
                }
                foreach (DataRow data in result.Rows)
                {
                    SatelliteDetails satellite = new SatelliteDetails();
                    satellite.SatelliteName = data["SatelliteName"].ToString();
                    satellite.OrginOfUNRegistry = data["OrginOfUNRegistry"].ToString();
                    satellite.CountryOfOperator = data["CountryOfOperator"].ToString();
                    satellite.Users = data["Users"].ToString();
                    satellite.Purpose = data["Purpose"].ToString();
                    satellite.ClassofOrbit = data["ClassofOrbit"].ToString();
                    satellite.LongitudeofGEO = data["LongitudeofGEO"].ToString();
                    satellite.Perigee = data["Perigee"].ToString();
                    satellite.Apogee = data["Apogee"].ToString();
                    satellite.Inclination = data["Inclination"].ToString();
                    satellite.Period = data["Period"].ToString();
                    satellite.LaunchMass = data["LaunchMass"].ToString();
                    satellite.DryMass = data["DryMass"].ToString();
                    satellite.Power = data["Power"].ToString();
                    satellite.DateOfLaunch = data["DateOfLaunch"].ToString();
                    satellite.ExpectedLifetime = data["ExpectedLifetime"].ToString();
                    satellite.CountryofContractor = data["CountryofContractor"].ToString();
                    satellite.LaunchSite = data["LaunchSite"].ToString();
                    satellite.LaunchVehicle = data["LaunchVehicle"].ToString();
                    satellite.COSPARNumber = data["COSPARNumber"].ToString();
                    satellite.NORADNumber = data["NORADNumber"].ToString();
                    satelliteDetails.Add(satellite);
                }
                return satelliteDetails;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public SatelliteDetails GetSatelliteDetailsBySatelliteName(string Satellite = null)
        {
            DataTable dt;
            DataTable result;
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    conn.ConnectionString = @"Data Source = (localdb)\mssqllocaldb;Initial Catalog = IRC.SATELLITE.V1.0;Integrated Security=True";
                    //< add name = "satellite" connectionString = "Data Source = (localdb)\mssqllocaldb;Initial Catalog = IRC.SATELLITE.V1.0;Integrated Security = True; MultipleActiveResultSets=True;Application Name = EntityFramework" providerName = "System.Data.SqlClient" />

                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = @"GetSatelliteDetailsByName";
                        if (Satellite != null)
                        {
                            cmd.Parameters.Add(new SqlParameter("@Satellite", Satellite));
                        }
                        //dt = DataMgr.GetData(cmd);                       
                        using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        {
                            result = new DataTable();
                            da.Fill(result);
                        }
                    }
                }

                SatelliteDetails satellite = new SatelliteDetails();
                foreach (DataRow data in result.Rows)
                {
                    satellite.SatelliteName = data["SatelliteName"].ToString();
                    satellite.OrginOfUNRegistry = data["OrginOfUNRegistry"].ToString();
                    satellite.CountryOfOperator = data["CountryOfOperator"].ToString();
                    satellite.Users = data["Users"].ToString();
                    satellite.Purpose = data["Purpose"].ToString();
                    satellite.ClassofOrbit = data["ClassofOrbit"].ToString();
                    satellite.LongitudeofGEO = data["LongitudeofGEO"].ToString();
                    satellite.Perigee = data["Perigee"].ToString();
                    satellite.Apogee = data["Apogee"].ToString();
                    satellite.Inclination = data["Inclination"].ToString();
                    satellite.Period = data["Period"].ToString();
                    satellite.LaunchMass = data["LaunchMass"].ToString();
                    satellite.DryMass = data["DryMass"].ToString();
                    satellite.Power = data["Power"].ToString();
                    satellite.DateOfLaunch = data["DateOfLaunch"].ToString();
                    satellite.ExpectedLifetime = data["ExpectedLifetime"].ToString();
                    satellite.CountryofContractor = data["CountryofContractor"].ToString();
                    satellite.LaunchSite = data["LaunchSite"].ToString();
                    satellite.LaunchVehicle = data["LaunchVehicle"].ToString();
                    satellite.COSPARNumber = data["COSPARNumber"].ToString();
                    satellite.NORADNumber = data["NORADNumber"].ToString();
                }
                return satellite;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
