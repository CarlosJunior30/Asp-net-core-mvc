using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using WebApplication1.Services;
using WebApplication1.Data;
using WebApplication1.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

		public SalesRecordsController(SalesRecordService salesRecordService)
		{
			_salesRecordService = salesRecordService;
		}
		public IActionResult Index()
        {
            return View();
        }

        //Simple Search
        public async Task<IActionResult> SimpleSearch(DateTime? mindate, DateTime? maxdate)
        {
            var result = await _salesRecordService.FindByDateAsync (mindate, maxdate);
            return View(result);
        }

        //Group Search
        public IActionResult GroupingSearch()
        {
            return View();
        }
    }
}
