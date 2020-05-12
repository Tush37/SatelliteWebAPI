using System;
using System.Collections.Generic;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SatelliteWebAPI.Models.DTOs;
using SatelliteWebAPI.Repository;

namespace Satellite.Test
{
    [TestClass]
    public class TestSatelliteDetailsController
    {
        [TestMethod]
        public void GetAllSatellitesCount_ShouldReturnTotalCountOfSatellites()
        {
            int count = 992;
            Assert.AreEqual(count, GetAllSatellites());
        }

        [TestMethod]
        public void GetUSASatellitesCount_ShouldReturnUSATotalCountOfSatellites()
        {
            int count = 703;
            Assert.AreEqual(count, GetAllSatellites("USA"));
        }

        [TestMethod]
        public void GetIndiaSatellitesCount_ShouldReturnIndiaTotalCountOfSatellites()
        {
            int count = 47;
            Assert.AreEqual(count, GetAllSatellites("India"));
        }

        [TestMethod]
        public void GetIsraelSatellitesCount_ShouldReturnIsraelTotalCountOfSatellites()
        {
            int count = 1;
            Assert.AreEqual(count, GetAllSatellites("Israel"));
        }

        [TestMethod]
        public void GetChinaSatellitesCount_ShouldReturnChinaTotalCountOfSatellites()
        {
            int count = 238;
            Assert.AreEqual(count, GetAllSatellites("China"));
        }

        [TestMethod]
        public void GetPakistanSatellitesCount_ShouldReturnPakistanTotalCountOfSatellites()
        {
            int count = 3;
            Assert.AreEqual(count, GetAllSatellites("Pakistan"));
        }

        //Negative Test Cases
        //1. Compare count of particular Country       
        //2. Compare count of All countries

        //Positive
        //1. Compare the Name or details of specific Country Satellite
        [TestMethod]
        public void GetSatelliteName_ShouldReturnCorrectName()
        {
            List<SatelliteDetails> result = new List<SatelliteDetails>();
            result = GetSatelliteDetailsByCountry("USA");
            Assert.AreEqual(result[2].COSPARNumber, "2009-001A");
        }

        //2. Compare the details of a specific Satellite
        [TestMethod]
        public void GetSatelliteDetailsByName_ShouldThrowNotFoundException()
        {
            SatelliteDetails satellite= GetSatelliteDetailsByName("ISRO2345AD"); 
            Assert.IsNull(satellite);
        }

        [TestMethod]
        public void GetSatelliteDetailsByName_ShouldMatchtheDetailsOfaSpecificSatellite()
        {
            SatelliteDetails satellite = new SatelliteDetails();
            satellite = GetSatelliteDetailsByName("AsiaSat-3S");
            Assert.AreEqual(satellite.OrginOfUNRegistry, "China");
            Assert.AreEqual(satellite.NORADNumber, "25657");
            Assert.AreNotEqual(satellite.CountryOfOperator, "India");
        }

        [TestMethod]
        public void GetSatelliteDetailsByName_ShouldNotMatchtheSatelliteDetails()
        {
            SatelliteDetails actual = new SatelliteDetails();
            actual = GetSatelliteDetailsByName("AsiaSat-3S");
            SatelliteDetails expected = new SatelliteDetails() { Apogee="",ClassofOrbit="",COSPARNumber="",DryMass=""};
            Assert.AreNotEqual(actual, expected);
        }

        private int GetAllSatellites(string country = null)
        {
            SatelliteRepository repo = new SatelliteRepository();
            List<SatelliteDetails> result = new List<SatelliteDetails>();
            result = repo.GetSatelliteDetails(country);
            return result.Count;
        }

        public List<SatelliteDetails> GetSatelliteDetailsByCountry(string country = null)
        {
            SatelliteRepository srepo = new SatelliteRepository();
            List<SatelliteDetails> result = new List<SatelliteDetails>();
            result = srepo.GetSatelliteDetails(country);
            return result;
        }

        public SatelliteDetails GetSatelliteDetailsByName(string satelliteName = null)
        {
            SatelliteRepository srepo = new SatelliteRepository();
            SatelliteDetails result = new SatelliteDetails();
            result = srepo.GetSatelliteDetailsBySatelliteName(satelliteName);
            return result;
        }

    }
}
