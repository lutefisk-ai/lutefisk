using HtmlAgilityPack;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace planner
{
    class Program
    {
        static void Main(string[] args)
        {
            //YelpAPIClient client = new YelpAPIClient();
            //JObject response = client.Search("Active life", "miami beach");

            //JArray businesses = (JArray)response.GetValue("businesses");

            //GetSFOData();       
            GetFargoData();
        }

        private static void GetFargoData()
        {
            HtmlDecoder wc = new HtmlDecoder();

            string city = "Fargo ND";
            HtmlDocument doc = null;
            //Console.WriteLine("Getting data for Culture Page 1");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g49785-Activities-c50-Fargo_North_Dakota.html");
            //GetTextByMultipleClassName(doc, 1, city);

            //Console.WriteLine("Getting data for Outdoors");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g49785-Activities-c45-Fargo_North_Dakota.html");

            //GetTextByMultipleClassName(doc, 2, city);

            //Console.WriteLine("Getting data for Landmarks");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g49785-Activities-c47-Fargo_North_Dakota.html");

            //GetTextByMultipleClassName(doc, 3, city);

            //Console.WriteLine("Getting data for Museums");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g49785-Activities-c49-Fargo_North_Dakota.html");

            //GetTextByMultipleClassName(doc, 4, city);

            //Console.WriteLine("Getting data for Performances");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g49785-Activities-c43-Fargo_North_Dakota.html");

            //GetTextByMultipleClassName(doc, 5, city);

            //Console.WriteLine("Getting data for Amusements");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g49785-Activities-c46-Fargo_North_Dakota.html");

            //GetTextByMultipleClassName(doc, 6, city);

            //Console.WriteLine("Getting data for Sports");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g49785-Activities-c44-Fargo_North_Dakota.html");

            //GetTextByMultipleClassName(doc, 7, city);

            //Console.WriteLine("Getting data for Zoos & Aquariums");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g49785-Activities-c48-Fargo_North_Dakota.html");

            //GetTextByMultipleClassName(doc, 8, city);

            //Console.WriteLine("Getting data for Ranch & Farm");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g49785-Activities-c25-Fargo_North_Dakota.html");

            //GetTextByMultipleClassName(doc, 15, city);

            //Console.WriteLine("Getting data for Bars");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g49785-Activities-c20-Fargo_North_Dakota.html");

            //GetTextByMultipleClassName(doc, 16, city);

            //Console.WriteLine("Getting data for Shopping");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g49785-Activities-c26-Fargo_North_Dakota.html");

            //GetTextByMultipleClassName(doc, 18, city);
        }

        private static void GetSFOData()
        {
            HtmlDecoder wc = new HtmlDecoder();

            string city = "San Fransisco";
            Console.WriteLine("Getting data for Culture Page 1");
            HtmlDocument doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g60713-Activities-c50-San_Francisco_California.html#TtD");
            GetTextByMultipleClassName(doc, 1, city);

            //Console.WriteLine("Getting data for Culture Page 2");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g60713-Activities-c50-oa30-San_Francisco_California.html#TtD");

            //GetTextByMultipleClassName(doc, 1, city);

            //Console.WriteLine("Getting data for Culture Page 3");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g60713-Activities-c50-oa60-San_Francisco_California.html#TtD");

            //GetTextByMultipleClassName(doc, 1, city);

            //Console.WriteLine("Getting data for Culture Page 4");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g60713-Activities-c50-oa90-San_Francisco_California.html#TtD");

            //GetTextByMultipleClassName(doc, 1, city);

            //Console.WriteLine("Getting data for Outdoors");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g60713-Activities-c45-San_Francisco_California.html#TtD");

            //GetTextByMultipleClassName(doc, 2, city);

            //Console.WriteLine("Getting data for Landmarks");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g60713-Activities-c47-San_Francisco_California.html#TtD");

            //GetTextByMultipleClassName(doc, 3, city);

            //Console.WriteLine("Getting data for Museums");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g60713-Activities-c49-San_Francisco_California.html#TtD");

            //GetTextByMultipleClassName(doc, 4, city);

            //Console.WriteLine("Getting data for Performances");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g60713-Activities-c43-San_Francisco_California.html#TtD");

            //GetTextByMultipleClassName(doc, 5, city);

            //Console.WriteLine("Getting data for Amusements");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g60713-Activities-c46-San_Francisco_California.html#TtD");

            //GetTextByMultipleClassName(doc, 6, city);

            //Console.WriteLine("Getting data for Sports");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g60713-Activities-c44-San_Francisco_California.html#TtD");

            //GetTextByMultipleClassName(doc, 7, city);

            //Console.WriteLine("Getting data for Zoos & Aquariums");
            //doc = wc.LoadHtml(@"http://www.tripadvisor.com/Attractions-g60713-Activities-c48-San_Francisco_California.html#TtD");

            //GetTextByMultipleClassName(doc, 8, city);
        }

        private static void GetTextByMultipleClassName(HtmlDocument htmlDocument, int category, string city)
        {
            var nodes = htmlDocument.DocumentNode.SelectNodes("//a[contains(@class, 'property_title')] | //img[contains(@class, 'sprite-ratings')] | //span[contains(@class, 'more')]");
            if (nodes != null)
            {
                for (int i = 0; i < 88 && i < nodes.Count; i++)
                {
                    if(nodes[i].Name != "a")
                    {
                        i++;
                    }

                    string title = nodes[i++].InnerText.Replace("\n" , "");
                    if (nodes[i].Name != "img" || nodes[i].Attributes["Content"] == null)
                    {
                        return;
                    }
                    double ratings = double.Parse(nodes[i++].Attributes["Content"].Value);
                    string rev = nodes[i].ChildNodes[1].InnerText.Replace("\n", "");
                    double reviews = double.Parse(rev.Substring(0, rev.IndexOf("review") -1));
                    Entity info = GetMoreInfo(title, city);
                    DataProvider.Instance.AddEntity(title, ratings, (int)reviews, category, info);
                }
            }
        }

        private static Entity GetMoreInfo(string name, string city)
        {
            WebClient client = new WebClient();
            Entity place = new Entity();
            GooglePlace gplace = null;
            using (Stream data = client.OpenRead(@"https://maps.googleapis.com/maps/api/place/textsearch/json?query=" + HttpUtility.UrlEncode(name) + HttpUtility.UrlEncode(city) + "&key=AIzaSyBd6pPfh0TkmyY4mgCi5ZB3DKr1vdMVvIo"))
            {
                using (StreamReader reader = new StreamReader(data))
                {
                    string s = reader.ReadToEnd();
                    GooglePlaces places = JsonConvert.DeserializeObject<GooglePlaces>(s);

                    //if (places.results.Count() == 0)
                    //{
                    //    places.results = new Row[1];
                    //    places.results[0] = new Row();
                    //    places.results[0].formatted_address = string.Empty;
                    //    places.results[0].geometry = new Geometry();
                    //    places.results[0].geometry.location = new Location();
                    //    places.results[0].geometry.location.lat = string.Empty;
                    //    places.results[0].geometry.location.lng = string.Empty;
                    //}

                    //place.result = places.results[0];
                    if (places.results.Count() == 0)
                    {
                        return place;
                    }

                    string placeid = places.results[0].place_id;

                    using (Stream data1 = client.OpenRead(@"https://maps.googleapis.com/maps/api/place/details/json?placeid=" + placeid + "&key=AIzaSyBd6pPfh0TkmyY4mgCi5ZB3DKr1vdMVvIo"))
                    {
                        using (StreamReader reader1 = new StreamReader(data1))
                        {
                            s = reader1.ReadToEnd();
                            gplace = JsonConvert.DeserializeObject<GooglePlace>(s);
                        }
                    }
                }
            }
            AddressComponent ac = gplace.result.address_components.FirstOrDefault(x => x.types.Contains("postal_code"));
            if (ac != null)
            {
                place.postal_code = ac.long_name;
            }
            place.address = gplace.result.formatted_address;
            place.lat = gplace.result.geometry.location.lat;
            place.lng = gplace.result.geometry.location.lng;
            place.place_id = gplace.result.place_id;
            if(gplace.result.price_level != null)
            {
                place.price_level = short.Parse(gplace.result.price_level);
            }
            if(gplace.result.opening_hours != null)
            {
                foreach(Period p in gplace.result.opening_hours.periods.ToList())
                {
                    EntityTiming timing = new EntityTiming();
                    timing.DayOfWeek = p.open.day;
                    timing.OpenTime = new TimeSpan(int.Parse(p.open.time.Substring(0, 2)), int.Parse(p.open.time.Substring(2, 2)), 0);

                    if (p.close != null)
                    {
                        timing.CloseTime = new TimeSpan(int.Parse(p.close.time.Substring(0, 2)), int.Parse(p.open.time.Substring(2, 2)), 0);
                    }
                    place.EntityTimings.Add(timing);
                }
            }
            return place;
        }
    }
}
