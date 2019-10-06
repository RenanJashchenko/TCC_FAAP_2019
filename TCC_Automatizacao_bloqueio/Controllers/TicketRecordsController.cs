using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TCC_Automatizacao_bloqueio.Models;
using TCC_Automatizacao_bloqueio.Services;
namespace TCC_Automatizacao_bloqueio.Controllers
{
    public class TicketRecordsController : Controller
    {

        private readonly TicketRecordService _ticketRecordService;

        public TicketRecordsController(TicketRecordService ticketRecordService)
        {
            _ticketRecordService = ticketRecordService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _ticketRecordService.FindByDateAsync(minDate, maxDate);

            return View(result);
        }

        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await _ticketRecordService.FindByDateGroupingAsync(minDate, maxDate);

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(TicketRecord ticketRecord)
        {
            _ticketRecordService.Insert(ticketRecord);
            return RedirectToAction("Index");
        }



    }
}