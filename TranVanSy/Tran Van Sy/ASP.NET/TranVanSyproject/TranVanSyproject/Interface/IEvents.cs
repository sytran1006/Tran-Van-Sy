using JamesTranproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace JamesTranproject.Interface
{
    public interface IEvents
    {
        Task<IEnumerable<Events>> GetAll();
        Task<Events> GetItem(int id);
        Task<List<Events>> Add(Events aevent);
        Task<Events> Update(Events aevent);
        Task<Events> Delete(int Id);
        Task<string> Upload([FromForm] imgEventscs obj);
    }
}
