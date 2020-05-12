//using SatelliteWebAPI.Models.DTOs;
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

namespace SatelliteWebAPI.Controllers
{
    public class SatelliteController : Controller
    {
        public DbProviderFactory DbFactory = null;
        public DbConnection Oconnection { get; set; }
        string Command;
        // GET: Satellite
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public List<SatelliteDetails> GetAllSatelliteDetails()
        {
            SatelliteRepository sRepo = new SatelliteRepository();
            List<SatelliteDetails> satelliteDetails = new List<SatelliteDetails>();
            satelliteDetails = sRepo.GetSatelliteDetails();
            return satelliteDetails;
        }

        [HttpGet]
        public List<SatelliteDetails> GetAllSatelliteDetailsByCountry(string Country)
        {
            SatelliteRepository sRepo = new SatelliteRepository();
            List<SatelliteDetails> satelliteDetails = new List<SatelliteDetails>();
            satelliteDetails = sRepo.GetSatelliteDetails(Country);
            return satelliteDetails;
        }

        [HttpGet]
        public SatelliteDetails GetSatelliteDetailsBySatelliteName(string Satellite = null)
        {
            SatelliteRepository sRepo = new SatelliteRepository();
            SatelliteDetails satelliteDetails = new SatelliteDetails();
            satelliteDetails = sRepo.GetSatelliteDetailsBySatelliteName(Satellite);
            return satelliteDetails;
        }
    }
}