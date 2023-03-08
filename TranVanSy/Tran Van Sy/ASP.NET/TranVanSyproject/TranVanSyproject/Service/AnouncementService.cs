using JamesTranproject.Interface;
using JamesTranproject.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Web;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Builder;
using Newtonsoft.Json.Serialization;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using System.Data.SqlClient;
using System.Data;


namespace JamesTranproject.Service
{
    public class AnouncementService : IAnouncementService
    {
        private readonly ReactContext _context;
        private static IWebHostEnvironment _webHostEnvironment;
        public AnouncementService(ReactContext reactContext ,IWebHostEnvironment webHostEnvironment)
        {
            this._context = reactContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<List<Anouncement>> Add(Anouncement anouncement)
        {
            _context.Anouncements.Add(anouncement);
            await _context.SaveChangesAsync();
            return (await _context.Anouncements.ToListAsync());

        }

        public async Task<Anouncement> Delete(int id)
        {
            var result = await _context.Anouncements.FindAsync(id);
            if (result == null)
                return null;

            _context.Anouncements.Remove(result);
            await _context.SaveChangesAsync();

            return (result);
        }

        public async Task<Anouncement> GetItem(int Id)
        {
            return await _context.Anouncements
                .FirstOrDefaultAsync(n => n.Id == Id);
        }

        public async Task<IEnumerable<Anouncement>> GetAll()
        {
            return await _context.Anouncements.ToListAsync();
        }

        public async Task<Anouncement> Update(Anouncement anouncement)
        {
            var result = await _context.Anouncements
                .FirstOrDefaultAsync(n => n.Id == anouncement.Id);

            if (result != null)
            {
                result.Title = anouncement.Title;
                result.Introduction = anouncement.Introduction;
                result.Img = anouncement.Img;
                result.DateTimeUse = anouncement.DateTimeUse;
                result.ResourceUse = anouncement.ResourceUse;


                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task<string> Upload([FromForm] imgAnouncement obj)
        {
            if (obj.imageAnouncement.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment.WebRootPath + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment.WebRootPath + "\\Images\\");
                    }
                    using FileStream fileStream = File.Create(_webHostEnvironment.WebRootPath + "\\Images\\" + obj.imageAnouncement.FileName);
                    obj.imageAnouncement.CopyTo(fileStream);
                    fileStream.Flush();
                    return "Images." + obj.imageAnouncement.FileName;
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
