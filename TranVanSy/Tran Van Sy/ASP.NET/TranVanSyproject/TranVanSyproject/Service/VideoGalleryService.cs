using JamesTranproject.Interface;
using JamesTranproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;


namespace JamesTranproject.Service
{
    public class VideoGalleryService : IVideoGallery
    {
        private readonly ReactContext _context;
        private static IWebHostEnvironment _webHostEnvironment;
        public VideoGalleryService(ReactContext reactContext, IWebHostEnvironment webHostEnvironment)
        {
            this._context = reactContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<List<VideoGallery>> Add(VideoGallery videoGallery)
        {
            _context.VideoGallerys.Add(videoGallery);
            await _context.SaveChangesAsync();
            return (await _context.VideoGallerys.ToListAsync());

        }

        public async Task<VideoGallery> Delete(int id)
        {
            var result = await _context.VideoGallerys.FindAsync(id);
            if (result == null)
                return null;

            _context.VideoGallerys.Remove(result);
            await _context.SaveChangesAsync();

            return (result);
        }

        public async Task<VideoGallery> GetItem(int Id)
        {
            return await _context.VideoGallerys
                .FirstOrDefaultAsync(n => n.Id == Id);
        }

        public async Task<IEnumerable<VideoGallery>> GetAll()
        {
            return await _context.VideoGallerys.ToListAsync();
        }

        public async Task<VideoGallery> Update(VideoGallery videoGallery)
        {
            var result = await _context.VideoGallerys
                .FirstOrDefaultAsync(n => n.Id == videoGallery.Id);

            if (result != null)
            {
                result.Video = videoGallery.Video;

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task<string> Upload([FromForm] imgVideo obj)
        {
            if (obj.imageVideo.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment + "\\Images\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment + "\\Images\\" + obj.imageVideo.FileName))
                    {
                        obj.imageVideo.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Images." + obj.imageVideo.FileName;
                    }
                }
                catch (Exception e)
                {
                    return e.ToString();
                }
            }
            else
            {
                return "false";
            }
        }
    }
}
