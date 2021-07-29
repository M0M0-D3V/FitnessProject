using System.Linq;
using System.Collections.Generic;
using FitnessProject.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FitnessProject.Services
{
    public interface IFitnessService
    {
        Class Create(Class fitclass, int tId);
        IEnumerable<Class> GetAll();
        Class GetById(int id);
        Class Update(Class fitclass, int id);
        void Delete(int cId, int tId);
        void UnRSVP(string uId, int cId);
        void RSVP(string uId, int cId);
        IEnumerable<RSVP> GetAllRSVPs(int cId);
    }
    public class FitnessService : IFitnessService
    {
        private MyContext _db;

        public FitnessService(MyContext db)
        {
            _db = db;
        }
        public Class Create(Class fitclass, int tId)
        {
            fitclass.InstructorId = tId;
            _db.Classes.Add(fitclass);
            _db.SaveChanges();
            Console.WriteLine($"successfully added {fitclass.ClassName} on {fitclass.ClassDate}");
            return fitclass;
        }
        public IEnumerable<Class> GetAll()
        {
            List<Class> allClasses = _db.Classes
            .Include(c => c.Instructor)
            .ThenInclude(i => i.User)
            .Include(c => c.Attending)
            .ThenInclude(a => a.Attendee)
            .OrderBy(o => o.ClassDate)
            .ThenBy(o => o.StartTime)
            .ToList();
            return allClasses;
        }
        public Class GetById(int id)
        {
            Class getClass = _db.Classes
            .Include(c => c.Instructor)
            .ThenInclude(i => i.User)
            .Include(c => c.Attending)
            .ThenInclude(a => a.Attendee)
            .FirstOrDefault(c => c.ClassId == id);
            return getClass;
        }
        public Class Update(Class fitclass, int id)
        {
            Class getClass = _db.Classes.FirstOrDefault(c => c.ClassId == id);
            getClass.ClassName = fitclass.ClassName;
            getClass.ClassDescription = fitclass.ClassDescription;
            getClass.ClassDate = fitclass.ClassDate;
            getClass.StartTime = fitclass.StartTime;
            getClass.EndTime = fitclass.EndTime;
            getClass.Location = fitclass.Location;
            getClass.ClassSize = fitclass.ClassSize;
            getClass.ClassPhoto = fitclass.ClassPhoto;
            getClass.ClassVideo = fitclass.ClassVideo;
            _db.SaveChanges();
            return getClass;
        }
        public void Delete(int cId, int tId)
        {
            Class delClass = _db.Classes.FirstOrDefault(c => c.ClassId == cId && c.InstructorId == tId);
            _db.Classes.Remove(delClass);
            _db.SaveChanges(); 
            Console.WriteLine($"Successfully Deleted class id {cId}");
            
        }
        public void UnRSVP(string uId, int cId)
        {
            RSVP delRSVP = _db.RSVPs.FirstOrDefault(r => r.ClassId == cId && r.UserId == uId);
            _db.RSVPs.Remove(delRSVP);
            _db.SaveChanges();
            Console.WriteLine($"Successfully Left class id {cId}");
        }
        public void RSVP(string uId, int cId)
        {
            RSVP addRSVP = new RSVP();
            addRSVP.UserId = uId;
            addRSVP.ClassId = cId;
            _db.RSVPs.Add(addRSVP);
            _db.SaveChanges();
            Console.WriteLine($"Successfully Joined class id {cId}");
        }
        public IEnumerable<RSVP> GetAllRSVPs(int cId)
        {
            List<RSVP> allRSVPs = new List<RSVP>();
            allRSVPs = _db.RSVPs
            .Where(r => r.ClassId == cId)
            .Include(r => r.Attendee)
            .Include(e => e.Attending)
            .ThenInclude(u => u.Instructor)
            .ToList();
            return allRSVPs;
        }
    }
}