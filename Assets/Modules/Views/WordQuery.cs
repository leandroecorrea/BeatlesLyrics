using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;
using System;

public class WordQuery : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text queryResult;  
    [SerializeField] private SongsProvider songsProvider;  
    [SerializeField] private TMP_InputField queryText;    
    [SerializeField] private Button searchButton;
    private IDisposable suscription;

    public void ShowWords()
    {
        int result = songsProvider.Songs.Where(x=> x.Lyrics.Contains(queryText.text, System.StringComparison.InvariantCultureIgnoreCase))
                                        .Select(x=> new{})
                                        .Count();
        queryResult.text = $"{queryText.text} appears {result} times";
    }
    
    void OnEnable()
    {
        searchButton.gameObject.SetActive(false);
        suscription = songsProvider.Songs.ObserveCountChanged(true)                  
                           .Subscribe(x=> 
                            {
                                HandleCountChange(x);                                
                            });
    }    
    private void HandleCountChange(int count)
    {
        if(count > 0)
        {
            searchButton.gameObject.SetActive(true);
            suscription.Dispose();
        }
    }
}
