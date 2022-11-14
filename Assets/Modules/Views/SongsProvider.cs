using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;

public class SongsProvider : MonoBehaviour
{
    public ReactiveCollection<BeatlesSong> Songs {get; private set;} = new ReactiveCollection<BeatlesSong>();
    
    async void OnEnable()
    {
        var result = await new LoadSongsUseCase().GetSongsAsync();
        Songs = result.ToReactiveCollection();
    }
}
