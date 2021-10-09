using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TicketOffice.BLL.Interfaces;
using TicketOffice.BLL.VMs.Train;

namespace TicketOffice.Controllers
{
    [Route("train")]
    public class TrainController : Controller
    {
        private readonly ITrainService _trainService;

        public TrainController(ITrainService trainService)
        {
            _trainService = trainService;
        }

        [HttpGet]
        [Route("Schedule")]
        public IActionResult Schedule(TrainSearch train)
        {
            var trains = _trainService.FindTrain(train);
            return View(trains);
        }

        [HttpGet]
        [Route("Edit")]
        [Authorize(Roles = "admin")]
        public IActionResult Edit(TrainSearch t)
        {
            var train = _trainService.FindTrain(t).FirstOrDefault();
            return View(train);
        }

        [HttpPost]
        [Route("Edit")]
        public IActionResult Edit(InfoTrain t)
        {
            _trainService.Update(t);
            return RedirectToAction("Schedule", "Train");
        }


        [Authorize(Roles = "admin")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateTrain train)
        {
            await _trainService.CreateTrainAsync(train);
            return RedirectToAction("Schedule");
        }

        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("delete")]
        public IActionResult Delete(TrainSearch search)
        {
            var train = _trainService.FindTrain(search).FirstOrDefault();
            return View(train);
        }

        [HttpPost]
        [Route("delete")]
        public IActionResult Delete(InfoTrain train)
        {
            _trainService.Delete(train);
            return RedirectToAction("Schedule", "Train");
        }
    }
}
