using JamesTranproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace JamesTranproject.Interface
{
    public interface IAnouncementService
    {
        Task<IEnumerable<Anouncement>> GetAll();
        Task<Anouncement> GetItem(int id);
        Task<List<Anouncement>> Add(Anouncement anouncement);
        Task<Anouncement> Update(Anouncement anouncement);
        Task<Anouncement> Delete(int Id);
        Task<string> Upload([FromForm] imgAnouncement obj);
    }
}
