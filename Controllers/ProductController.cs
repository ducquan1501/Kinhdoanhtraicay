using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Kinhdoanhtraicay.Models;
using Microsoft.EntityFrameworkCore;
using System.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.IO.Pipes;

namespace Kinhdoanhtraicay.Controllers
{
    public class ProductController : Controller
    {       
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        private QLTCContext qltcContext = new QLTCContext();
        public IActionResult Index()
        {
            List<Product> products = qltcContext.Products.ToList();
            return View(products);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product, IFormFile uploadHinh)
        {
            qltcContext.Products.Add(product);

            qltcContext.SaveChanges();

            if(uploadHinh != null && uploadHinh.Length > 0)
            {
                int id = int.Parse(qltcContext.Products.ToList().Last().ProductId.ToString());
                string _FileName = "";
                int index = uploadHinh.FileName.IndexOf('.');
                _FileName = "sp" +id.ToString() + "." + uploadHinh.FileName.Substring(index + 1);
                string uploadFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Image/Product");
                string filePath = Path.Combine(uploadFolder, _FileName);
                using(var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    uploadHinh.CopyTo(fileStream);
                }

                Product uproduct = qltcContext.Products.FirstOrDefault(p => p.ProductId == id);
                uproduct.Image = _FileName;
                qltcContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var product = qltcContext.Products.Find(id);

            if (product != null)
            {
                qltcContext.Products.Remove(product);
                qltcContext.SaveChanges();               
            }
            else
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            var product = qltcContext.Products.Find(id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product, IFormFile imageFile)
        {
            if (ModelState.IsValid)
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    // Lưu hình ảnh vào thư mục và cập nhật đường dẫn trong cơ sở dữ liệu
                    var imagePath = SaveImage(imageFile);
                    product.Image = imagePath;
                }

                // Cập nhật thông tin sản phẩm trong cơ sở dữ liệu
                qltcContext.Entry(product).State = EntityState.Modified;
                qltcContext.SaveChanges();

                // Chuyển hướng về trang danh sách sản phẩm
                return RedirectToAction("Index");
            }
            return View(product);
        }

        private string SaveImage(IFormFile imageFile)
        {
            var fileName = DateTime.Now.Ticks.ToString() + Path.GetExtension(imageFile.FileName);
            var imagePath = Path.Combine("Image", "Product", fileName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                imageFile.CopyTo(fileStream);
            }
            return "/Image/Product/" + fileName;
        }
    }
}
