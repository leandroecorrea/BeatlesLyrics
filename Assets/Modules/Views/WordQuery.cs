using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UniRx;

public class WordQuery : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Text queryResult;  
    [SerializeField] private SongsProvider songsProvider;  
    [SerializeField] private TMP_InputField queryText;    
    [SerializeField] private Button searchButton; 
    
    public void ShowWords()
    {
        int result = songsProvider.Songs.Where(x=> x.Lyrics.Contains(queryText.text, System.StringComparison.InvariantCultureIgnoreCase))
                                        .Select(x=> new{})
                                        .Count();
        queryResult.text = $"{queryText.text} aparece {result} veces";
    }
    
    void OnEnable()
    {
        searchButton.gameObject.SetActive(false);
        songsProvider.Songs.ObserveEveryValueChanged(x=> x)
                           .Subscribe(_=> 
                            {
                                searchButton.gameObject.SetActive(true);
                            });
    }    
}
