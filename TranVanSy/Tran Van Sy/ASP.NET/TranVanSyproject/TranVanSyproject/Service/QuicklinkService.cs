using JamesTranproject.Interface;
using JamesTranproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace JamesTranproject.Service
{
    public class QuicklinkService : IQuickLink
    {
        private readonly ReactContext _context;
        private static IWebHostEnvironment _webHostEnvironment;
        public QuicklinkService(ReactContext reactContext, IWebHostEnvironment webHostEnvironment)
        {
            this._context = reactContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<List<QuickLink>> Add(QuickLink quickLink)
        {
            _context.QuickLinks.Add(quickLink);
            await _context.SaveChangesAsync();
            return (await _context.QuickLinks.ToListAsync());

        }

        public async Task<QuickLink> Delete(int id)
        {
            var result = await _context.QuickLinks.FindAsync(id);
            if (result == null)
                return null;

            _context.QuickLinks.Remove(result);
            await _context.SaveChangesAsync();

            return (result);
        }

        public async Task<QuickLink> GetItem(int Id)
        {
            return await _context.QuickLinks
                .FirstOrDefaultAsync(n => n.Id == Id);
        }

        public async Task<IEnumerable<QuickLink>> GetAll()
        {
            return await _context.QuickLinks.ToListAsync();
        }

        public async Task<QuickLink> Update(QuickLink quickLink)
        {
            var result = await _context.QuickLinks
                .FirstOrDefaultAsync(n => n.Id == quickLink.Id);

            if (result != null)
            {
                result.Img = quickLink.Img;
                result.Title = quickLink.Title;
             
                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task<string> Upload([FromForm] imgQuickLink obj)
        {
            if (obj.imageQuickLink.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment + "\\Images\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment + "\\Images\\" + obj.imageQuickLink.FileName))
                    {
                        obj.imageQuickLink.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Images." + obj.imageQuickLink.FileName;
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
