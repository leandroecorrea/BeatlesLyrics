using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using UnityEngine;
using System.Linq;

public class LoadSongsUseCase 
{
    private ISongsService _songsService;

    public LoadSongsUseCase()
    {
        _songsService = new SongsService(new HttpClient());
    }

    public async Task<List<BeatlesSong>> GetSongsAsync()
    {
        return await _songsService.GetSongs();                                                    
    }
}
