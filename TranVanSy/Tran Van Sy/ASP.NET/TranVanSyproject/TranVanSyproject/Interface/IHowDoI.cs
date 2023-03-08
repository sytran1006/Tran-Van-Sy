using JamesTranproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace JamesTranproject.Interface
{
    public interface IHowDoI
    {
        Task<IEnumerable<HowDoI>> GetAll();
        Task<HowDoI> GetItem(int id);
        Task<List<HowDoI>> Add(HowDoI howDoI);
        Task<HowDoI> Update(HowDoI howDoI);
        Task<HowDoI> Delete(int Id);
        Task<string> Upload([FromForm] imgHowDoI obj);
    }
}
