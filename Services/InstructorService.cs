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
            List<Instructor> allInstructors = new List<Instructor>();
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
        public Instructor Update(Instructor fitclass, int id)
        {
            Instructor getIns = GetById(id);
            // stuff missing
            _db.SaveChanges();
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