using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Products_Record_MAnagement_System.Models;
using Products_Record_MAnagement_System.Services;
using System;
using System.Linq;

namespace Products_Record_MAnagement_System.Controllers
{
    public class ProductController : Controller
    {
        private readonly ProductService _productService; //private readonly will Just Allow to read the data only to the user on the UI

        public ProductController(ProductService productService)
        {
            _productService = productService; //this is the Constructor dependency

        }
        // GET: ProductController
        public ActionResult Index()
        {
            var products = _productService.GetAll();
            try
            {
                var result = products.Select(ProductEntity => new Products
                {
                    ProductId = ProductEntity.ProductId,
                    Code = ProductEntity.Code,
                    Name = ProductEntity.Name,
                    Description = ProductEntity.Description,
                    ExpiryDate = ProductEntity.ExpiryDate,
                    Category = ProductEntity.Category,
                    Image = ProductEntity.Image,
                    Status = ProductEntity.Status,
                    CreationDate = ProductEntity.CreationDate
                });
                return View(result);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    // GET: ProductController/Details/5
    public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ProductController/Create
        public ActionResult AddUpdate()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddUpdate(Products products)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    _productService.AddUpdateProduct(products.Code,
                                                      products.Name,
                                                      products.Description,
                                                      products.ExpiryDate,
                                                      products.Category,
                                                      products.Image,
                                                      products.Status,
                                                      products.CreationDate);
                    return RedirectToAction("Index");
                }
                return View(products);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
