using System;
using System.Collections.Generic;
using System.Text;

namespace Satellite.ADODataRepository.Models
{
    public class SatelliteDetails
    {
        public string SatelliteName { get; set; }
        public string OrginOfUNRegistry { get; set; }
        public string CountryOfOperator { get; set; }
        public string Users { get; set; }
        public string Purpose { get; set; }
        public string ClassofOrbit { get; set; }
        public string LongitudeofGEO { get; set; }
        public string Perigee { get; set; }
        public string Apogee { get; set; }
        public string Inclination { get; set; }
        public string Period { get; set; }
        public string LaunchMass { get; set; }
        public string DryMass { get; set; }
        public string Power { get; set; }
        public string DateOfLaunch { get; set; }
        public string ExpectedLifetime { get; set; }
        public string CountryofContractor { get; set; }
        public string LaunchSite { get; set; }
        public string LaunchVehicle { get; set; }
        public string COSPARNumber { get; set; }
        public string NORADNumber { get; set; }
    }
}
