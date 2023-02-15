using System;
using System.Net;
using Newtonsoft.Json;

namespace Open_Movie_Database_API_Lab.Models
{
	public class MovieDAL
	{
        public static MovieModel GetMovie(string title)
        {
            //Setup
            string key = "2b9440bd";
            string url = $"https://www.omdbapi.com/?apikey={key}&t={title}";

            //Request
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            //Convert it to JSON
            StreamReader reader = new StreamReader(response.GetResponseStream());
            string JSON = reader.ReadToEnd();

            //Convert to C#
            MovieModel result = JsonConvert.DeserializeObject<MovieModel>(JSON);
            return result;
        }
    }
}

