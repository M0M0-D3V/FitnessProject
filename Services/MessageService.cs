using System;
using System.Collections.Generic;
using System.Linq;
using FitnessProject.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessProject.Services
{
    public interface IMessageService
    {
        Message SendMessage(Message message, string sId, string rId);
        IEnumerable<Message> GetAllSent(string uId);
        IEnumerable<Message> GetAllReceived(string uId);
        
    }
    public class MessageService : IMessageService
    {
        private MyContext _db;

        public MessageService(MyContext db)
        {
            _db = db;
        }
        public Message SendMessage(Message message, string sId, string rId)
        {
            message.MessageFromId = sId;
            message.UserMessagedId = rId;
            _db.Messages.Add(message);
            _db.SaveChanges();
            Console.WriteLine($"successfully sent message to {message.UserMessaged.FirstName}");
            return message;
        }
        public IEnumerable<Message> GetAllSent(string uId)
        {
            IEnumerable<Message> sentMessages = _db.Messages
            .Where(u => u.MessageFromId == uId)
            // .Include(i => i.Title)
            // .Include(i => i.Content)
            .Include(u => u.UserMessaged)
            .Include(u => u.MessageFrom);
            return sentMessages;
        }
        public IEnumerable<Message> GetAllReceived(string uId)
        {
            IEnumerable<Message> receivedMessages = _db.Messages
            .Where(u => u.UserMessagedId == uId)
            // .Include(i => i.Title)
            // .Include(i => i.Content)
            .Include(u => u.MessageFrom)
            .Include(u => u.UserMessaged);
            return receivedMessages;
        }
    }
}