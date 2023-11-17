using Bovinos.Models;

namespace Bovinos.Services
{
    public interface IRaceService
    {
        Race GetRaceById(int id);
        List<Race> GetRaces(int page, int pageSize);
        void CreateRace(Race race);
        void UpdateRace(int id, Race race);
        void DeleteRace(int id);
    }
}
