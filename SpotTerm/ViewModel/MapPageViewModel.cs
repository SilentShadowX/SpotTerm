using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml;
using SpotTerm.Utils;

namespace SpotTerm.ViewModel
{
    class MapPageViewModel : BindableBase
    {
        private string _coordinate;
        private string _labelname;
        private const string KEY = "AtT2UrTEwP_WhkLH_7-iBw1OcAjQLjSZt0T0MxnzjKyCI75Fv5cDbJr5zqc1n3x4";

        public ICommand BackToMenuCommand { get; set; }

        public String Coordinate
        {
            get { return _coordinate; }
            set
            {
                SetProperty(ref _coordinate, value);
                OnPropertyChanged("Coordinate");
            }
        }

        private string LabelName
        {
            get { return _labelname; }
            set
            {
                SetProperty(ref _labelname, value); 
                OnPropertyChanged("LabelName");
            }
        }

        public MapPageViewModel(string address)
        {
            // request
            XmlDocument doc = Geocode(address);
            _coordinate = GetLocationCoordinate(doc);
            _labelname = address;
            BackToMenuCommand = new RelayCommand((action) => BackToMenuPage());
        }

        private void BackToMenuPage()
        {
            Navigation.Back();
        }

        public XmlDocument Geocode(string addressQuery)
        {
            //Create REST Services geocode request using Locations API
            string geocodeRequest = "http://dev.virtualearth.net/REST/v1/Locations/" + addressQuery + "?o=xml&key=" + KEY;


            //Make the request and get the response
            XmlDocument geocodeResponse = GetXmlResponse(geocodeRequest);

            return (geocodeResponse);
        }

        private XmlDocument GetXmlResponse(string requestUrl)
        {
            System.Diagnostics.Trace.WriteLine("Request URL (XML): " + requestUrl);
            HttpWebRequest request = WebRequest.Create(requestUrl) as HttpWebRequest;
            using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
            {
                if (response.StatusCode != HttpStatusCode.OK)
                    throw new Exception(String.Format("Server error (HTTP {0}: {1}).",
                        response.StatusCode,
                        response.StatusDescription));
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(response.GetResponseStream());
                return xmlDoc;
            }
        }

        private string GetLocationCoordinate(XmlDocument doc)
        {
            XmlNamespaceManager nsmgr = new XmlNamespaceManager(doc.NameTable);
            nsmgr.AddNamespace("rest", "http://schemas.microsoft.com/search/local/ws/rest/v1");
            XmlNodeList locationElements = doc.SelectNodes("//rest:Location", nsmgr);
            XmlNodeList displayGeocodePoints =
                locationElements[0].SelectNodes(".//rest:GeocodePoint/rest:UsageType[.='Display']/parent::node()", nsmgr);
            string latitude = displayGeocodePoints[0].SelectSingleNode(".//rest:Latitude", nsmgr).InnerText;
            string longitude = displayGeocodePoints[0].SelectSingleNode(".//rest:Longitude", nsmgr).InnerText;
            return latitude + ", " + longitude;
        }
    }
}
