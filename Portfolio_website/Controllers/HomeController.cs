using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Portfolio_website.Data;
using Portfolio_website.Models;
using System.Diagnostics;
using System.Drawing;
using System.IO;

namespace Portfolio_website.Controllers
{
    public class HomeController : Controller
    {
        private readonly string demostr = "abc";

        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext applicationDbContext;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext applicationDbContext, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            this.applicationDbContext = applicationDbContext;
            _webHostEnvironment = webHostEnvironment;
        }

        /*Add Experience*/
        [Authorize]
        public IActionResult Add_Experience()
        {
            return View();
        }

        [Authorize]
        public IActionResult About_Me()
        {
            return View();
        }

        [Authorize]
		public IActionResult Add_Proj()
        {
            return View();
        }
        public IActionResult CV()
        {
            return View();
        }

        public IActionResult Exp_Details(Guid id)
        {
            var dish = applicationDbContext.Experience.FirstOrDefault(x => x.Experience_Id == id);
            if (dish != null)
            {
                var viewModel = new Experience()
                {
                    Experience_Id = dish.Experience_Id,
                    Domain_Name = dish.Domain_Name,
                    Description = dish.Description,
                    Level = dish.Level,
                    Image = dish.Image,
                    Company_Name = dish.Company_Name,
                    Experience_type = dish.Experience_type,
                    position = dish.position,
                };
                return View(viewModel);
            }
            return RedirectToAction("Index");
        }

        public IActionResult Contact()
        {
            List<UserDetails> user_det = applicationDbContext.UserDetails.ToList();

            return View(user_det);
        }
        public IActionResult Proj_details()
        {
            var p_data = applicationDbContext.Portfolio_Data.ToList();
            return View(p_data);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [Authorize]
        [HttpPost]
        public IActionResult Add_Proj(Portfolio_Data model)
        {
            var Portfolio_Data = new Portfolio_Data()
            {
                Id = Guid.NewGuid(),
                Proj_Name = model.Proj_Name,
                Proj_Description = model.Proj_Description,
                Proj_Type = model.Proj_Type,
                Proj_Language = model.Proj_Language,
                Pic_1 = model.Pic_1,
                Pic_2 = demostr /*model.Pic_2*/,
                Pic_3 = demostr /*model.Pic_3*/,
                video = model.video,
                proj_code = demostr/*model.proj_code*/,

            };
            applicationDbContext.Portfolio_Data.Add(Portfolio_Data);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Front_Page");
        }


		[HttpPost]
		public IActionResult Add_Details(UserDetails model)
		{
			var UserDetails = new UserDetails()
			{
				Id = Guid.NewGuid(),
				Name = model.Name,
				TagLine = model.TagLine,
				AboutMe = model.AboutMe,
				Address = model.Address,
				Phone = model.Phone,
				Email = model.Email,
				Website = model.Website,

			};
			applicationDbContext.UserDetails.Add(UserDetails);
			applicationDbContext.SaveChanges();
			return RedirectToAction("Front_Page");
		}

		/*Add Experience*/
		[Authorize]
		[HttpPost]
        public IActionResult Add_Experience(Experience model)
        {
            /*FOR IMAGE*/
            /*var fileName = Path.GetFileName(Image.FileName);
            var filePath = Path.Combine("wwwroot/Images", fileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                 model.Image.CopyTo(Stream);
            }*/

            /*var photo = new Image
            {
                FileName = fileName,
                FilePath = filePath
            };

            var expl = new Experience { Image = filePath };*/


            var Experience = new Experience()
            {
                Experience_Id = Guid.NewGuid(),
                Domain_Name = model.Domain_Name,
                Description = model.Description,
                Level = model.Level,
                Company_Name = model.Company_Name,
                Image = model.Image,
                Experience_type = model.Experience_type,
                position = model.position               
            };

            


            applicationDbContext.Experience.Add(Experience);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Front_Page");
        }

        [HttpPost]
        public IActionResult ContactUs(ContactUs model)
        {
            var ContactUs = new ContactUs()
            {
                ContactId = Guid.NewGuid(),
                Name = model.Name,
                Email = model.Email,
                Subject = model.Subject,
                Message = model.Message,

            };
            applicationDbContext.ContactUs.Add(ContactUs);
            applicationDbContext.SaveChanges();
            return RedirectToAction("Front_Page");
        }

        
        [HttpGet]
        public IActionResult Front_Page()
        {
            /*ist<var> data = new List<var>();*/
            List<Portfolio_Data> p_data = applicationDbContext.Portfolio_Data.ToList();
            List<Experience> exp_data = applicationDbContext.Experience.ToList();
			List<UserDetails> user_det = applicationDbContext.UserDetails.ToList();
			/*var exp_data = portfolioDbContext.Experience.ToList();*/

			dynamic model = new System.Dynamic.ExpandoObject();
            model.portf = p_data;
            model.Exp = exp_data;
			model.use = user_det;

			return View(model);
        }

		[HttpPost]  

        [Authorize]
		public IActionResult Delete(Experience model)
		{
			var dish = applicationDbContext.Experience.Find(model.Experience_Id);
			if (dish != null)
			{
                applicationDbContext.Experience.Remove(dish);
                applicationDbContext.SaveChanges();
				return RedirectToAction("Front_Page");
			}
			return RedirectToAction("Front_Page");
		}

		/* [HttpPost]
		 public IActionResult Delete(UpdateDishViewModel model)
		 {
			 var dish = mvcDemoDbContext.Dishes.Find(model.DishId);
			 if (dish != null)
			 {
				 mvcDemoDbContext.Remove(dish);
				 mvcDemoDbContext.SaveChanges();
				 return RedirectToAction("Index");
			 }
			 return RedirectToAction("Index");
		 }

		 [HttpPost]
		 public IActionResult SaveView(UpdateDishViewModel model)
		 {
			 var dish = mvcDemoDbContext.Dishes.Find(model.DishId);
			 if (dish != null)
			 {
				 dish.DishName = model.DishName;
				 dish.Description = model.Description;
				 dish.DishId = model.DishId;
				 dish.Price = model.Price;
				 dish.Quantity = model.Quantity;
				 dish.Image = model.Image;

				 mvcDemoDbContext.SaveChanges();
				 return RedirectToAction("Index");
			 }


			 return RedirectToAction("Index");
		 }*/
	}
}