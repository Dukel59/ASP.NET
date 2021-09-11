using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HM.BLL.Interfaces;
using HM.BLL.ViewModels.Comment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace Homework_1.Controllres
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Route ("getbyid")]
        public List<InfoComment> GetCommentByFeedbackId(Guid id)
        {
            return _commentService.FindCommentsByFunc(m => m.FeedbackId == id);
        }

        [HttpGet]
        [Route("getall")]
        public List<InfoComment> GetAllComments()
        {
            return _commentService.FindCommentsByFunc(null);
        }

        [HttpPost]
        public Guid Create([FromForm] CreateComment comment)
        {
            return (_commentService.CreateCommentAsync(comment)).Result;
        }
    }
}
