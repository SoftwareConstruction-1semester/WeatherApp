using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using Windows.Data.Xml.Dom;
using Windows.Storage;
using WeatherApp.Annotations;

namespace WeatherApp.model
{
    public class weathermodel
    {
    
        public String City { get; set; }

        public String Temperature { get; set; }
        public String Wind { get; set; }
        public String Sunrise { get; set; }
        public String Sunset { get; set; }
        public String Humidity { get; set; }
        public String Cloudiness { get; set; }
    }
}
