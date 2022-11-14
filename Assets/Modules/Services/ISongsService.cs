using System.Collections.Generic;
using System.Threading.Tasks;

public interface ISongsService
{
    public  Task<List<BeatlesSong>> GetSongs();
}
