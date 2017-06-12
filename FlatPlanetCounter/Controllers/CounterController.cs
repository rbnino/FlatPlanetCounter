using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FlatPlanetCounter.Models;

namespace FlatPlanetCounter.Controllers
{
    public class CounterController : Controller
    {
        private CounterModels CounterModels;

        public CounterController()
        {
            CounterModels = new CounterModels();
        }

        //
        // GET: /Counter/
        public ActionResult Index(int prmCounter = 0, bool prmButtonClicked = false)
        {
            try
            {
                if (prmButtonClicked) prmCounter++;

                CounterModels.Counter = prmCounter;
                this.CounterModels.CounterInsert(CounterModels);

                return View(CounterModels);
            }
            catch (Exception e)
            {
                var viewModelError = new CounterModels
                {
                    Counter = CounterModels.CounterLimit,
                    Message = e.Message
                };
                return View(viewModelError);
            }
        }
	}
}