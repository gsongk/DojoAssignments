using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using TheWall.Models;

namespace TheWall.Controllers
{
    public class WallController : Controller
    {
        [HttpGet]
        [Route("dashboard")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("id") == null)
                return RedirectToAction("Index", "User");
            ViewBag.Messages = GetAllMessages();
            ViewBag.Comments = GetAllComments();
            ViewBag.User = DbConnector.Query($"SELECT first_name FROM users WHERE users.id = {(int)HttpContext.Session.GetInt32("id")}")[0];
            return View();
        }
        [HttpPost]
        [Route("messages/create")]
        public IActionResult CreateMessage(WallModels wallModel)
        {
            if (ModelState.IsValid)
            {
                // insert a message
                string query = $@"INSERT INTO messages (content, user_id, created_at, updated_at)
                                  VALUES ('{wallModel.MessagePost.MessageContent}', {(int)HttpContext.Session.GetInt32("id")}, NOW(), NOW())";
                DbConnector.Execute(query);
                return RedirectToAction("Index");
            }
            return View("Index");
        }
        [HttpPost]
        [Route("comments/create")]
        public IActionResult CreateComment(WallModels wallModel)
        {
            if (ModelState.IsValid)
            {
                // insert a message
                string query = $@"INSERT INTO comments (content, user_id, message_id, created_at, updated_at)
                                  VALUES ('{wallModel.CommentPost.CommentContent}', {(int)HttpContext.Session.GetInt32("id")}, '{wallModel.CommentPost.MessageId}', NOW(), NOW())";
                DbConnector.Execute(query);
                return RedirectToAction("Index");
            }
            return View("Index");
        }

        public List<Dictionary<string, object>> GetAllMessages()
        {
            string query = @"SELECT messages.id AS message_id, messages.content, messages.created_at, users.first_name, users.last_name 
                             FROM messages JOIN users ON messages.user_id = users.id";
            return DbConnector.Query(query);
        }

        public List<Dictionary<string, object>> GetAllComments()
        {
            string query = $@"SELECT comments.id AS comment_id, comments.content, comments.created_at, users.first_name, users.last_name, comments.message_id
                              FROM comments JOIN messages ON comments.message_id = messages.id
                              JOIN users ON comments.user_id = users.id";
            return DbConnector.Query(query);
        }

    }

}