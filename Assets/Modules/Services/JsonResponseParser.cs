using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class JsonResponseParser
{
    public static List<BeatlesSong> GetSongsFrom(string jsonString)
    {
        return JsonUtility.FromJson<BeatlesSongCollection>("{\"songs\":" + jsonString + "}").songs.ToList();
    }
}
