using System.Linq;
using System.Collections.Generic;
using FitnessProject.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace FitnessProject.Services
{
    public interface ICommunityService
    {
        ReviewClass CreateClassReview(ReviewClass review, string uId);
        IEnumerable<ReviewClass> GetAllClassReviews();
        IEnumerable<ReviewClass> GetAllReviewsOneClass(int cId);
        ReviewInstructor CreateInstructorReview(ReviewInstructor review, string uId);
        IEnumerable<ReviewInstructor> GetAllInstructorReviews();
        IEnumerable<ReviewInstructor> GetAllReviewsOneInstructor(int tId);
        void LikeReview(string uId, int rcId);
        void UnlikeReview(string uId, int rcId);
        void LikeClass(string uId, int cId);
        void UnlikeClass(string uId, int cId);
        IEnumerable<LikeClass> GetAllClassLikes(int cId);
        IEnumerable<LikeReview> GetAllReviewLikes(int rId);
    }
    public class CommunityService : ICommunityService
    {
        private MyContext _db;
        public CommunityService(MyContext db)
        {
            _db = db;
        }
        public ReviewClass CreateClassReview(ReviewClass review, string uId)
        {
            return review;
        }
        public IEnumerable<ReviewClass> GetAllClassReviews()
        {
            IEnumerable<ReviewClass> allReviews = _db.ReviewClasses;
            return allReviews;
        }
        public IEnumerable<ReviewClass> GetAllReviewsOneClass(int cId)
        {
            IEnumerable<ReviewClass> allReviews = _db.ReviewClasses.Where(c => c.ClassId == cId);
            return allReviews;
        }
        public ReviewInstructor CreateInstructorReview(ReviewInstructor review, string uId)
        {
            return review;
        }
        public IEnumerable<ReviewInstructor> GetAllInstructorReviews()
        {
            IEnumerable<ReviewInstructor> allReviews = _db.ReviewInstructors;
            return allReviews;
        }
        public IEnumerable<ReviewInstructor> GetAllReviewsOneInstructor(int tId)
        {
            IEnumerable<ReviewInstructor> allReviews = _db.ReviewInstructors.Where(t => t.InstructorId == tId);
            return allReviews;
        }
        public void LikeReview(string uId, int rcId)
        {
            LikeReview addLikeReview = new LikeReview();
            addLikeReview.UserId = uId;
            addLikeReview.ReviewClassId = rcId;
            _db.LikeReviews.Add(addLikeReview);
            _db.SaveChanges();
            Console.WriteLine($"Successfully liked review id {rcId}");
        }
        public void UnlikeReview(string uId, int rcId)
        {
            LikeReview delLikeReview = _db.LikeReviews.FirstOrDefault(rc => rc.ReviewClassId == rcId && rc.UserId == uId);
            _db.LikeReviews.Remove(delLikeReview);
            _db.SaveChanges();
            Console.WriteLine($"Successfully unliked review id {rcId}");
        }
        public void LikeClass(string uId, int cId)
        {
        LikeClass addLikeClass = new LikeClass();
            addLikeClass.UserId = uId;
            addLikeClass.ClassId = cId;
            _db.LikeClasses.Add(addLikeClass);
            _db.SaveChanges();
            Console.WriteLine($"Successfully liked class id {cId}");
        }
        public void UnlikeClass(string uId, int cId)
        {
            LikeClass delLikeClass = _db.LikeClasses.FirstOrDefault(c => c.ClassId == cId && c.UserId == uId);
            _db.LikeClasses.Remove(delLikeClass);
            _db.SaveChanges();
            Console.WriteLine($"Successfully unliked class id {cId}");
        }
        public IEnumerable<LikeClass> GetAllClassLikes(int cId)
        {
            IEnumerable<LikeClass> allLikes = _db.LikeClasses
            .Where(c => c.ClassId == cId)
            .Include(l => l.LikedBy)
            .Include(c => c.LikedClass)
            .ThenInclude(t => t.Instructor);
            return allLikes;
        }
        public IEnumerable<LikeReview> GetAllReviewLikes(int rId)
        {
            IEnumerable<LikeReview> allLikes = _db.LikeReviews
            .Where(r => r.ReviewClassId == rId)
            .Include(u => u.LikedBy)
            .Include(r => r.LikedClassReview)
            .ThenInclude(rc => rc.Reviewer);
            return allLikes;    
        }
    }
}