using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FindGavenCore.Models;
using FindGavenCore.Data;
using FindGavenCore.Services;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Identity;


namespace FindGavenCore.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGiftService _giftService;
        private readonly IProviderService _providerService;
        private readonly ITagService _tagService;
        private readonly ApplicationDbContext _db;

       
        public HomeController(IGiftService giftService, IProviderService providerService, ITagService tagService, ApplicationDbContext db)
        {
            _giftService = giftService;
            _providerService = providerService;
            _tagService = tagService;
            _db = db;
        }


        private int SetPageViewData(int? page, ViewDataDictionary viewData, string suffix)
        {
            int pageNo = page == null ? 1 : (int)page;
            ViewData["nextPage" + suffix] = (pageNo + 1);
            ViewData["prevPage" + suffix] = (pageNo - 1);

            return pageNo;
        }
     
        private bool HasNextPage(int pageNo, int count, double det)
        {
            return ((pageNo + 1) > Math.Ceiling(count / det)) ? false : true;
        }
       
        private bool HasPrevPage(int pageNo)
        {
            return (pageNo - 1) > 0;
        }
     
        [HttpGet]
        public IActionResult Index(int? page, int? popPage, string occasion, string who, string category, string sliderPrice)
        {
            IndexViewModel viewModel = new IndexViewModel();
            viewModel.DistinctOccasion = _tagService.GetAllDistinctValues(1); 
            viewModel.DistinctCategory = _tagService.GetAllDistinctValues(2);
            viewModel.DistinctWho = _tagService.GetAllDistinctValues(3);
            int pageNo = SetPageViewData(page, ViewData, null);
            int popPageNo = SetPageViewData(popPage, ViewData, "Popular");

            ViewData["url"] = Request.Path;

            if (sliderPrice != null)
            {
                viewModel.PresentsResults = _giftService.FindGifts(pageNo, sliderPrice, category, who, occasion);
                viewModel.HeadLine = "Gaver som matcher din søgning";
                if (viewModel.PresentsResults == null)
                {
                    viewModel.HeadLine = "Den valgte parameterkombination er ugyldig";
                    viewModel.PresentsResults = new List<Present>();
                }
                else if (viewModel.PresentsResults.Count == 0)
                    viewModel.HeadLine = "Ingen gaver matcher søgningen";
            }
            else
            {
                viewModel.PresentsResults = _giftService.ListRandomGifts(pageNo);
            }
            viewModel.PresentResultsLimit = viewModel.PresentsResults.Skip((pageNo - 1) * 9).Take(9).ToList();
            viewModel.HasNextPage = HasNextPage(pageNo, viewModel.PresentsResults.Count, 9d);
            viewModel.HasPrevPage = HasPrevPage(pageNo);
            
            viewModel.PopularPresents = _giftService.ListPopularGifts(popPageNo);
            viewModel.PopHasNextPage = HasNextPage(popPageNo, _db.Present.Count(), 3d);
            viewModel.PopHasPrevPage = HasPrevPage(popPageNo);

            return View(viewModel);
        }
        [HttpPut]
        [Route("presents/{id}/rating")]
        public IActionResult UpdateRating(int id)
        {
            try
            {
                if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
                    return NotFound();

                _giftService.IncreaseRating(id);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Route("Providers/{id}")]
        public IActionResult Provider(int id)
        {
            IndexViewModel viewModel = new IndexViewModel(); 
            viewModel.Provider = _providerService.GetProviderById(id);

            return View("Provider", viewModel);
        }
    }
}
