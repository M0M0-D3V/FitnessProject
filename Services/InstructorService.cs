using System.Linq;
using System.Collections.Generic;
using FitnessProject.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FitnessProject.Services
{
    public interface IInstructorService
    {
        Instructor Create(Instructor fitclass, int tId);
        IEnumerable<Instructor> GetAll();
        Instructor GetById(int id);
        Instructor GetLoggedInsById(string uId);
        Instructor Update(Instructor fitclass, int id);
        void Delete(int tId);
    }
    public class InstructorService : IInstructorService
    {
        private MyContext _db;

        public InstructorService(MyContext db)
        {
            _db = db;
        }
        public Instructor Create(Instructor fitclass, int tId)
        {
            return fitclass;
        }
        public IEnumerable<Instructor> GetAll()
        {
            List<Instructor> allInstructors = _db.Instructors
            .Include(i => i.User)
            .Include(i => i.Classes)
            .ThenInclude(i => i.Attending)
            .OrderBy(n => n.User.FirstName)
            .ToList();
            return allInstructors;
        }
        public Instructor GetById(int id)
        {
            Instructor getIns = _db.Instructors
            .Include(c => c.User)
            .Include(c => c.Classes)
            .ThenInclude(a => a.Attending)
            .FirstOrDefault(c => c.InstructorId == id);
            return getIns;
        }
        public Instructor GetLoggedInsById(string uId)
        {
            Instructor loggedIns = _db.Instructors
            .Include(t => t.User)
            .Include(t => t.Classes)
            .FirstOrDefault(t => t.UserId == uId);
            return loggedIns;
        }
        public Instructor Update(Instructor ins, int id)
        {
            Instructor getIns = GetById(id);
            getIns.InstructorPhoto = ins.InstructorPhoto;
            getIns.Expertise = ins.Expertise;
            getIns.Biography = ins.Biography;
            _db.SaveChanges();
            Console.WriteLine("successfully updated");
            return getIns;
        }
        public void Delete(int tId)
        {
            Instructor delIns = GetById(tId);
            _db.Instructors.Remove(delIns);
            _db.SaveChanges(); 
            Console.WriteLine($"Successfully Deleted Instructor id {tId}");
        }
    }
}