
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BeatlesSong 
{
    public string _id;
    public string Name;
    public string Song; 
    public string Lyrics;
    public string __v;
}

[System.Serializable]
public class BeatlesSongCollection
{
    public BeatlesSong[] songs;
}