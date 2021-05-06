using ExpeditionGo.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ExpeditionGo.InterfaceImplementation.IFace;
using ExpeditionGo.DataModel;
using Microsoft.AspNetCore.Identity;

namespace ExpeditionGo.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBlog _blogImplementation;
        private readonly IPlace _placeImplementation;
        private readonly IContactUs _contactUsImplementation;
        private static UserManager<IdentityUser> _userManager;

        public HomeController(IBlog blogImplementation, IPlace placeImplementation, IContactUs contactUsImplementation, UserManager<IdentityUser> userManager)
        {
            _blogImplementation = blogImplementation;
            _placeImplementation = placeImplementation;
            _contactUsImplementation = contactUsImplementation;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult HomeIndex()
        {

            var tmp = new List<BlogLeft>();
            tmp = _blogImplementation.GetAllBlogLeft().ToList();
            var BlogsLeft = tmp.Select(model => new BlogModel
            {
                BlogLeftHeading = model.BlogLeftHeading,
                BlogLeftId = model.BlogLeftId,
                BlogLeftCity = model.BlogLeftCity,
                BlogLeftCountry = model.BlogLeftCountry,
                BlogLeftDescription = model.BlogLeftDescription,
                BlogLeftCreated = model.BlogLeftCreated,
                BlogLeftContent = model.BlogLeftContent,
                BlogLeftSubContent = model.BlogLeftSubContent,
                BlogSide = model.BlogSide,
                ImageURLOne = model.ImageURLOne,
                ImageURLTwo = model.ImageURLTwo,
                ImageURLThree = model.ImageURLThree,
            });

            var tmp2 = new List<Place>();
            tmp2 = _placeImplementation.GetAllPlace().ToList();
            var Place = tmp2.Select(model => new PlaceModel
            {
                PlaceHeading = model.PlaceHeading,
                City = model.City,
                PlaceId = model.PlaceId,
                Country = model.Country,
                PlaceDescription = model.PlaceDescription,
                PlaceCreated = DateTime.Now,
                PlaceContent = model.PlaceContent,
                PlaceSubContent = model.PlaceSubContent,
                PlaceContinent = model.PlaceContinent,
                ImageURL = model.ImageURL,
            }) ;

            var model = new HomeIndexModel
            {
                blogsLeft = BlogsLeft,
                place = Place,
            };
            return View(model);
        }

        public IActionResult BlogCreate()
        {
            return View();
        }
        public IActionResult OpenBlog(int id)
        {
            var model = _blogImplementation.GetById(id);
            var BlogsLeft = new BlogModel
            {
                BlogLeftHeading = model.BlogLeftHeading,
                BlogLeftCity = model.BlogLeftCity,
                BlogLeftCountry = model.BlogLeftCountry,
                BlogLeftDescription = model.BlogLeftDescription,
                BlogLeftCreated = model.BlogLeftCreated,
                BlogLeftContent = model.BlogLeftContent,
                BlogLeftSubContent = model.BlogLeftSubContent,
                BlogSide = model.BlogSide,
                ImageURLOne = model.ImageURLOne,
                ImageURLTwo = model.ImageURLTwo,
                ImageURLThree = model.ImageURLThree,
            };

            return View(BlogsLeft);
        }
        public async Task<IActionResult> AddBlogLeft(BlogModel model)
        {
            var PostModel = new BlogLeft()
            {
                BlogLeftHeading = model.BlogLeftHeading,
                BlogLeftCity = model.BlogLeftCity,
                BlogLeftCountry = model.BlogLeftCountry,
                BlogLeftDescription = model.BlogLeftDescription,
                BlogLeftCreated = DateTime.Now,
                BlogLeftContent = model.BlogLeftContent,
                BlogLeftSubContent = model.BlogLeftSubContent,
                BlogSide = model.BlogSide,
                ImageURLOne = model.ImageURLOne,
                ImageURLTwo = model.ImageURLTwo,
                ImageURLThree = model.ImageURLThree,
            };
            await _blogImplementation.AddBlogLeft(PostModel);
            return RedirectToAction("HomeIndex", "Home");
        }

        public IActionResult PlaceCreate()
        {
            return View();
        }
        public IActionResult OpenPlace(int id)
        {
            var model = _placeImplementation.GetByPlaceId(id);
            var PlaceLeft = new PlaceModel
            {
                PlaceHeading = model.PlaceHeading,
                City = model.City,
                Country = model.Country,
                PlaceDescription = model.PlaceDescription,
                PlaceCreated = DateTime.Now,
                PlaceContent = model.PlaceContent,
                PlaceSubContent = model.PlaceSubContent,
                PlaceContinent = model.PlaceContinent,
                ImageURL = model.ImageURL,
            };

            return View(PlaceLeft);
        }
        public async Task<IActionResult> AddPlace(PlaceModel model)
        {
            var PostModel = new Place()
            {
                PlaceHeading = model.PlaceHeading,
                City = model.City,
                Country = model.Country,
                PlaceDescription = model.PlaceDescription,
                PlaceCreated = DateTime.Now,
                PlaceContent = model.PlaceContent,
                PlaceSubContent = model.PlaceSubContent,
                PlaceContinent = model.PlaceContinent,
                ImageURL = model.ImageURL,
            };
            await _placeImplementation.AddPlace(PostModel);
            return RedirectToAction("HomeIndex", "Home");
        }

        public async Task<IActionResult> AddContactUs(ContactUsModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var PostModel = new ContactUs()
            {
                Id = model.ContactUsId,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Subject = model.Subject,
                ContactCreated = DateTime.Now,
                User = user,
            };
            await _contactUsImplementation.AddContactUs(PostModel);
            return RedirectToAction("HomeIndex", "Home");
        }
        public IActionResult ContactUs()
        {
            var tmp = new List<ContactUs>();
            tmp = _contactUsImplementation.GetAllContactUs().ToList();
            var Contact = tmp.Select(model => new ContactUsModel
            {
                ContactUsId = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                Subject = model.Subject,
                ContactCreated = model.ContactCreated,
                UserEmail = model.User.Email,
            });

            return View(Contact);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
