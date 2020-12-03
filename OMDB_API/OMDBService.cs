using System;
using RestSharp;
using System.Configuration;

namespace OMDB_API
{
    public class OMDBService
    {
        public string GetFromOMDB(
            string movieTitle,
            int movieYear,
            MoviePlot moviePlot, 
            string dataType)
        {
            try
            {
                string apiKey = ConfigurationManager.AppSettings["apiKey"];

                string url = String.Format("http://www.omdbapi.com/?" +
                    "apikey={0}&" +
                    "t={1}&" +
                    "y={2}&" +
                    "plot={3}&" +
                    "r={4}",
                    apiKey, 
                    movieTitle, 
                    movieYear,
                    moviePlot.ToString(),
                    dataType);

                RestClient client = new RestClient(url);

                RestRequest request = new RestRequest(Method.GET);

                IRestResponse response = client.Execute(request);
                return response.Content;
            }
            catch (Exception ex)
            {
                return ex.InnerException.ToString();
            }

        }
    }
}
