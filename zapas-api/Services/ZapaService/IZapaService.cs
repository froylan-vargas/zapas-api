using Zapas.Data.Models;

namespace Zapas.Services.ZapaService
{
    public interface IZapaService
    {
        public Task<IEnumerable<Zapa>> GetByUserId(string userId);
    }
}
