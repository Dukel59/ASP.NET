using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HM.BLL.Interfaces;
using HM.BLL.ViewModels.Feedback;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework_1.Controllres
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet]
        [Route ("getbyid")]
        public List<InfoFeedback> GetFeedbackById(Guid id)
        {
            return _feedbackService.FindFeedbacksByFunc(m => m.Id == id);
        }

        [HttpGet]
        [Route("getall")]
        public List<InfoFeedback> GetAllFeedback()
        {
            return _feedbackService.FindFeedbacksByFunc(null);
        }

        [HttpPost]
        public Guid Create([FromForm] CreateFeedback feedback)
        {
            return (_feedbackService.CreateFeedbackAsync(feedback)).Result;
        }
    }
}
