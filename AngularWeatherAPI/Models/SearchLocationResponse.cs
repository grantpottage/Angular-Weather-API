using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace AngularWeatherAPI.Models
{
    [DataContract]
    public class SearchLocationResponse
    {
        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "location_type")]
        public string LocationType { get; set; }

        [DataMember(Name = "woeid")]
        public string WoeId { get; set; }

        [DataMember(Name = "latt_long")]
        public string LatitudeAndLongitude { get; set; }
    }
}
