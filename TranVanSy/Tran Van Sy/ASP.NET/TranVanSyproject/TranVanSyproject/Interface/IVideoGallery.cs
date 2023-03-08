using JamesTranproject.Models;
using Microsoft.AspNetCore.Mvc;

namespace JamesTranproject.Interface
{
    public interface IVideoGallery
    {
        Task<IEnumerable<VideoGallery>> GetAll();
        Task<VideoGallery> GetItem(int id);
        Task<List<VideoGallery>> Add(VideoGallery videoGallery);
        Task<VideoGallery> Update(VideoGallery videoGallery);
        Task<VideoGallery> Delete(int Id);
        Task<string> Upload([FromForm] imgVideo obj);
    }
}
