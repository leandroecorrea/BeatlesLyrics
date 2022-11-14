using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
public class SongsService : ISongsService
{
    private readonly HttpClient _client;
    private readonly string _requestUri = "https://beatles-api.herokuapp.com/";

    public SongsService(HttpClient client)
    {
        _client = client;
    }

    public async Task<List<BeatlesSong>> GetSongs()
    {
        var response = await _client.GetAsync(_requestUri);
        if(response.StatusCode == HttpStatusCode.OK)
        {
            var responseString = await response.Content.ReadAsStringAsync();
            var songs = JsonResponseParser.GetSongsFrom(responseString);
            Debug.Log("First item: " +songs[0].Name);
            return songs;
        }
        return Enumerable.Empty<BeatlesSong>().ToList();
    }
}
