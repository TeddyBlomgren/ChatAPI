﻿using ChatAPI.Data;
using ChatAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace ChatAPI.DAL
{
    public class PmManager
    {
        private readonly PmDbContext _context;

        public PmManager(PmDbContext context)
        {
            _context = context;
        }

        public async Task<List<PM>> GetInboxAsync(string userId)
        {
            return await _context.PrivateMessages
                .Where(m => m.ReceiverId == userId)
                .ToListAsync();
        }

        public async Task<List<PM>> GetSentAsync(string userId)
        {
            return await _context.PrivateMessages
                .Where(m => m.SenderId == userId)
                .ToListAsync();
        }

        public async Task<PM> SendAsync(PM message)
        {
            _context.PrivateMessages.Add(message);
            await _context.SaveChangesAsync();
            return message;
        }

        public async Task<List<PM>> GetConversationAsync(string userAId, string userBId)
        {
            return await _context.PrivateMessages
                .Where(m =>
                    (m.SenderId == userAId && m.ReceiverId == userBId) ||
                    (m.SenderId == userBId && m.ReceiverId == userAId))
                .OrderBy(m => m.SentAt)
                .ToListAsync();
        }

    }
}
