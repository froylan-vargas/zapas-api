using Zapas.Data.DTO.Race.RaceOptions;
using Zapas.Data.Models;

namespace Zapas.Services.ZapaService
{
    public interface IZapaService
    {
        Task<IEnumerable<ZapaSelection>> GetSelection(string userId);
    }
}
