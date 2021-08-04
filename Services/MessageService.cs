using System;
using FitnessProject.Models;

namespace FitnessProject.Services
{
    public interface IMessageService
    {
        Message Create(Message message, string sId, string rId);
        
    }
    public class MessageService : IMessageService
    {
        private MyContext _db;

        public MessageService(MyContext db)
        {
            _db = db;
        }
        public Message Create(Message message, string sId, string rId)
        {
            message.MessageFromId = sId;
            message.UserMessagedId = rId;
            _db.Messages.Add(message);
            _db.SaveChanges();
            Console.WriteLine($"successfully sent message to {message.UserMessaged.FirstName}");
            return message;
        }
    }
}