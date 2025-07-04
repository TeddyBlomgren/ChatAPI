﻿using Microsoft.AspNetCore.Mvc;
using ChatAPI.DAL;
using ChatAPI.Models;

namespace ChatAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PmController : ControllerBase
    {

        private readonly PmManager _pmManager;

        public PmController(PmManager pmManager)
        {
            _pmManager = pmManager;
        }


        [HttpPost]
        public async Task<IActionResult> Send([FromBody] PM message)
        {
            var result = await _pmManager.SendAsync(message);
            return Ok(result);
        }

        [HttpGet("inbox/{userId}")]
        public async Task<IActionResult> GetInbox(string userId)
        {
            var messages = await _pmManager.GetInboxAsync(userId);
            return Ok(messages);

        }

        [HttpGet("sent/{userId}")]
        public async Task<IActionResult> GetSent(string userId)
        {
            var messages = await _pmManager.GetSentAsync(userId);
            return Ok(messages);
        }

        [HttpGet("conversation/{userAId}/{userBId}")]
        public async Task<IActionResult> GetConversation(string userAId, string userBId)
        {
            var messages = await _pmManager.GetConversationAsync(userAId, userBId);
            return Ok(messages);
        }

    }
}
