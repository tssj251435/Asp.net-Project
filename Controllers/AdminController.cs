using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using FindGavenCore.Models;
using Microsoft.AspNetCore.Authorization;
using FindGavenCore.Services;
using System;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System.Collections.Generic;
using System.Linq;
using FindGavenCore.Data;

namespace FindGavenCore.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ITagService _tagService;
        private readonly IProviderService _providerService;
        private readonly IGiftService _giftService;
        private readonly IHostingEnvironment _environment;
        private readonly IDataCollectorService _dataCollectorService;


        public AdminController(

            SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,
            ITagService tagService, IProviderService providerService, IGiftService giftService,
            IHostingEnvironment environment, IDataCollectorService dataCollectorService)
        {

            _signInManager = signInManager;
            _userManager = userManager;
            _tagService = tagService;
            _providerService = providerService;
            _giftService = giftService;
            _environment = environment;
            _dataCollectorService = dataCollectorService;
        }

        [HttpGet]
        [Authorize]
        public IActionResult Index()
        {
            return View("AdminFunctionalit");
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login()

        {
            if (User.Identity.IsAuthenticated)
                return Redirect("/admin");

            LoginViewModel vm = new LoginViewModel();
            return View(vm);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel viewModel)
        {
          
            var result =
                await _signInManager.PasswordSignInAsync(viewModel.Email, viewModel.Password, false, false);

            if (!result.Succeeded)
            {
                ViewData["message"] = "Invalid credentials";
                return View(viewModel);
            }

            return Redirect("/admin");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }
        [Route("admin/editprovider")]
        [HttpGet]
        public IActionResult EditProvider()
        {
            EditViewModel editViewModel = new EditViewModel();
            editViewModel.Providers = _providerService.GetAllProviders();
            return View(editViewModel);
        }
        [Route("admin/editprovider")]
        [HttpPost]
        public IActionResult EditProvider(EditViewModel model)
        {
            if (model.ProviderId != 0)
                _providerService.RemoveProvider(model.ProviderId);
            else
            {
                try
                {
                    _providerService.AddProvider(model.Name, model.Description, model.Image);
                }
                catch (Exception)
                {
                    ViewData["error"] = "Udbyderen kunne ikke tilføjes";
                }
            }
            model.Providers = _providerService.GetAllProviders();
            return View(model);
        }
        private void PrepPresView(EditViewModel editViewModel)
        {
            editViewModel.Presents = _giftService.GetAllPresents();
            editViewModel.Providers = _providerService.GetAllProviders();
        }
        [Route("admin/editPresent")]
        [HttpGet]
        public IActionResult EditPresent()
        {
            EditViewModel editViewModel = new EditViewModel();
            PrepPresView(editViewModel);
            return View(editViewModel);
        }
        [Route("admin/editPresent")]
        [HttpPost]
        public IActionResult EditPresent(EditViewModel model)
        {
            if (model.PresentId != 0)
            {
                _giftService.RemoveGift(model.PresentId);
            }
            else
            {
                try
                {
                    _giftService.AddGift(model.Name, model.Description, model.Price,
                        model.Image, model.Link, model.ProviderId);
                }
                catch (Exception)
                {
                    ViewData["error"] = "Gaven kunne ikke tilføjes";
                }
            }
            PrepPresView(model);
            return View(model);
        }

        [Route("admin/edittag/{id}")]
        [HttpGet]
        public IActionResult EditTag(int id)
        {
            EditViewModel editViewModel = new EditViewModel();
            if (id == 1)
                editViewModel.Headline = "anledning";
            else if (id == 2)
                editViewModel.Headline = "kategori";
            else
                editViewModel.Headline = "modtager";
            editViewModel.WhatType = id;
            PrepTagView(editViewModel);
            return View(editViewModel);
        }
        private void PrepTagView(EditViewModel model)
        {
            model.Presents = _giftService.GetAllPresents();
            model.ParamValues = _tagService.GetAllDistinctValues(model.WhatType);
        }
        [Route("admin/edittag/{id}")]
        [HttpPost]
        public IActionResult EditTag(string submitButton, EditViewModel model)
        {
            switch (submitButton)
            {
                case "add":
                    AddTag(model.PresentId, model.WhatType, model.Value);
                    PrepTagView(model);
                    return View(model);
                case "remove":
                    RemoveTag(model.PresentId, model.Value);
                    PrepTagView(model);
                    return View(model);
                default:
                    return View("editTag");
            }
        }

        private void AddTag(int presentId, int type, string value)
        {
            try
            {
                _tagService.AddTag(presentId, type, value);
            }
            catch (System.Exception)
            {
                ViewData["error"] = "Gaven har allerede det tag, der forsøges tilføjet";
            }
        }
        private void RemoveTag(int presentId, string value)
        {
            try
            {
                _tagService.RemoveTag(presentId, value);
            }
            catch (System.Exception)
            {
                ViewData["error"] = "Gaven har ikke det tag, der forsøges fjernet";
            }
        }
        private void PrepParamView(EditViewModel model)
        {
            if (model.WhatType == 1)
                model.Headline = "Anledning";
            else if (model.WhatType == 2)
                model.Headline = "Kategori";
            else
                model.Headline = "Modtager";

            model.ParamValues = _tagService.GetAllDistinctValues(model.WhatType);
        }
        [Route("admin/editParamValues/{id}")]
        [HttpGet]
        public IActionResult EditParamValue(int id)
        {
            EditViewModel editViewModel = new EditViewModel();
            editViewModel.WhatType = id;
            PrepParamView(editViewModel);
            return View(editViewModel);
        }
        [Route("admin/editParamValues/{id}")]
        [HttpPost]
        public IActionResult EditParamValue(EditViewModel model, int whatTypeTemp)
        {
            if (model.WhatType == 0)
                _tagService.RemoveParamValue(model.Value);
            else
            {
                try
                {
                    _tagService.AddParamValue(model.WhatType, model.Value);
                }
                catch (Exception)
                {
                    ViewData["error"] = "Parameterværdien kunne ikke tilføjes, da den allerede findes";
                }
            }
            if (whatTypeTemp != 0)
                model.WhatType = whatTypeTemp;
            PrepParamView(model);
            return View(model);
        }

        [Route("/admin/collect/{id}")]
        public IActionResult CollectData(int id)
        {
            EditViewModel viewModel = new EditViewModel();
            viewModel.WhatType = id;
            if (id == 1)
                viewModel.Headline = "Se gaver inden for specificeret prisklasse";
            else if (id == 2)
            {
                viewModel.Presents = _giftService.GetAllPresents();
                viewModel.Headline = "Se tags en udvalgt gave har";
            }
            else if (id == 3)
            {
                viewModel.Headline = "Se matchende gaver ud fra et tag";
                viewModel.ParamValues = _tagService.GetAllTagValues();
            }
            else if (id == 4)
                viewModel.Headline = "Se de mest popul�re gaver";
            else if (id == 5)
            {
                viewModel.Providers = _providerService.GetAllProviders();
                viewModel.Headline = "Se en specifik udbyders gaver";
            }
            else if (id == 6)
            {
                viewModel.Providers = _dataCollectorService.GetNumberOfGiftsFromProvider();
                viewModel.Headline = "Se hvilke gaver der h�rer til hvilken udbyder";
            }

            return View("CollectData", viewModel);
        }


        [HttpGet]
        [Route("/admin/callProc")]
        public IActionResult CollectData(int whatProc, int id, int minPrice, int maxPrice, string tagValue, int providerId)
        {
            EditViewModel editViewModel = new EditViewModel();
            editViewModel.WhatType = whatProc;
            if (whatProc == 1)
                editViewModel.Presents = _dataCollectorService.GetSpecificGiftsInPriceRange(minPrice, maxPrice);
            else if (whatProc == 2)
            {
                editViewModel.Presents = _giftService.GetAllPresents();
                editViewModel.ChosenPresent = _dataCollectorService.GetTagsOfChosenGift(id);
            }
            else if (whatProc == 3)
            {
                editViewModel.TagValue = tagValue;
                editViewModel.ParamValues = _tagService.GetAllTagValues();
                editViewModel.Presents = _dataCollectorService.GetGiftsMatchingSpecifiedTag(tagValue);
            }
            else if (whatProc == 4)
            {
                editViewModel.TopGifts = id;
                editViewModel.Presents = _dataCollectorService.GetMostPopularGifts(id);
            }
            else if (whatProc == 5)
            {
                editViewModel.Providers = _providerService.GetAllProviders();
                editViewModel.ChosenProvider = _providerService.GetProviderById(providerId);
                editViewModel.Presents = _dataCollectorService.GetMatchingGiftsByProvider(providerId);
            }
            else if (whatProc == 6)
            {
                editViewModel.Providers = _dataCollectorService.GetNumberOfGiftsFromProvider();
            }

            return View("CollectData", editViewModel);
        }

        [Route("tinymceimages")]
        public List<TinymceImages> TinyMCEImages()
        {
            var imagePath = @"images\PresentsPic";
            return Directory.GetFiles(Path.Combine(_environment.WebRootPath, imagePath)).Where(s =>
                s.EndsWith(".png", StringComparison.InvariantCultureIgnoreCase) ||
                s.EndsWith(".jpg", StringComparison.InvariantCultureIgnoreCase))
                .Select(x => new TinymceImages() { title = Path.GetFileName(x), value = $"images/PresentsPic/{Path.GetFileName(x)}" })
                .ToList();
        }
        [HttpGet]
        [Route("admin/images")]
        public ActionResult AddPictureToGallery()
        {
            var model = new AddPicturesToGalleryViewModel()
            {
                Images = TinyMCEImages()
            };
            return View(model);
        }
        [HttpPost]
        [Route("admin/images")]
        public async Task<ActionResult> AddPictureToGallery(IFormFile picture)
        {
            var path = Path.Combine(_environment.WebRootPath, @"images\PresentsPic");
           
            if (picture != null && picture.Length > 0)
            {
                if (picture.ContentType.ToLower() != "image/png")
                {
                    throw new Exception("Only png images are allowed as blog pictures");
                }

                using (var fileStream = new FileStream(Path.Combine(path, picture.FileName), FileMode.Create))
                {
                    await picture.CopyToAsync(fileStream);
                }
            }

            return RedirectToAction("AddPictureToGallery");
        }
        public ActionResult DeletePictureFromGallery(string filename)
        {
            var path = Path.Combine(_environment.WebRootPath, filename);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
            return RedirectToAction(nameof(AddPictureToGallery));
        }

    }
}