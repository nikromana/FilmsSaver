using Model;
using System.Net;
using System.Text;
using System.Text.Json;

namespace Services
{
    public class OmdbApi
    {
        private const string BASE_URL = "https://www.omdbapi.com/?t=";
        private const string API_KEY = "2d10eac1";
        private Film _findedFilm;

        public Film GetFilm
        {
            get => _findedFilm;
        }

        public void RequestSearch(string title)
        {
            WebRequest request = WebRequest.Create(BASE_URL + title + "&apikey=" + API_KEY);
            request.Method = "GET";
            request.Timeout = 10000;
            request.ContentType = "application/json";
            string result = string.Empty;

            try
            {
                using (var reader = new StreamReader(request.GetResponse().GetResponseStream(), Encoding.UTF8))
                {
                    result = reader.ReadToEnd();
                }
            }
            catch (Exception e)
            {
                throw new Exception();
            }

            _findedFilm = null;

            if (result == "{\"Response\":\"False\",\"Error\":\"Movie not found!\"}")
            {
                throw new Exception(); return;
            }

            ParseJson(result);
        }

        private void ParseJson(string req)
        {
            _findedFilm = JsonSerializer.Deserialize<Film>(req);
        }
    }
}
