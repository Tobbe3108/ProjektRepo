using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using GMap.NET;
using GMap.NET.CacheProviders;
using GMap.NET.MapProviders;

namespace BusinessLayer
{
    public static class CalculateDistanceMethod
    {
        //Denne kode er taget fra et spørgsmål på StackOverflow, og den oprindelige skaber af metoden er 
        //https://stackoverflow.com/questions/13999187/distance-between-addresses
        public static int GetDistanceByAddresses(string address1, string address2)
        {
            //var request = WebRequest.Create("http://maps.googleapis.com/maps/api/geocode/json?address=" + address1 + " +View,+CA&sensor=true_or_false");
            //var response = (HttpWebResponse)request.GetResponse();
            //request.ContentType = "application/json; charset=utf-8";

            //ac.long_name = address1;
            //GoogleMapProvider
            //Location
            //StartLocation
            //EndLocation

            ////            GMap.NET.GMaps
            //AddressComponent ac = new AddressComponent();


            GoogleMapProvider googleMapProvider = GoogleMapProvider.Instance;

            GeoCoderStatusCode test = new GMap.NET.GeoCoderStatusCode();

            PointLatLng? point1 = /*(PointLatLng)*/googleMapProvider.GetPoint(address1, out test);
            PointLatLng? point2 = /*(PointLatLng)*/googleMapProvider.GetPoint(address2, out test);

            MapRoute mapRoute = new MapRoute("test"); // = googleMapProvider.GetRoute(point1, point2, false, true, 0);

            return (int)mapRoute.Distance;
        }

    }
}
