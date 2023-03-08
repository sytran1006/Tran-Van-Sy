using JamesTranproject.Interface;
using JamesTranproject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace JamesTranproject.Service
{
    public class EventsService : IEvents
    {
        private readonly ReactContext _context;
        private static IWebHostEnvironment _webHostEnvironment;
        public EventsService(ReactContext reactContext ,IWebHostEnvironment webHostEnvironment)
        {
            this._context = reactContext;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<List<Events>> Add(Events aevent)
        {
            _context.Events.Add(aevent);
            await _context.SaveChangesAsync();
            return (await _context.Events.ToListAsync());

        }

        public async Task<Events> Delete(int id)
        {
            var result = await _context.Events.FindAsync(id);
            if (result == null)
                return null;

            _context.Events.Remove(result);
            await _context.SaveChangesAsync();

            return (result);
        }

        public async Task<Events> GetItem(int Id)
        {
            return await _context.Events
                .FirstOrDefaultAsync(n => n.Id == Id);
        }

        public async Task<IEnumerable<Events>> GetAll()
        {
            return await _context.Events.ToListAsync();
        }

        public async Task<Events> Update(Events aevent)
        {
            var result = await _context.Events
                .FirstOrDefaultAsync(n => n.Id == aevent.Id);

            if (result != null)
            {
                result.Number = aevent.Number;
                result.Day = aevent.Day;
                result.Title = aevent.Title;
                result.Img = aevent.Img;
                result.Time = aevent.Time;

                await _context.SaveChangesAsync();

                return result;
            }
            return null;
        }
        public async Task<string> Upload([FromForm] imgEventscs obj)
        {
            if (obj.imageEvents.Length > 0)
            {
                try
                {
                    if (!Directory.Exists(_webHostEnvironment + "\\Images\\"))
                    {
                        Directory.CreateDirectory(_webHostEnvironment + "\\Images\\");
                    }
                    using (FileStream fileStream = System.IO.File.Create(_webHostEnvironment + "\\Images\\" + obj.imageEvents.FileName))
                    {
                        obj.imageEvents.CopyTo(fileStream);
                        fileStream.Flush();
                        return "Images." + obj.imageEvents.FileName;
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
