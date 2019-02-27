using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models.Entities;
using TH13Chieu.Models.Functions;


namespace TH13Chieu.Controllers
{
    public class SanPhamController : Controller
    {
        //
        // GET: /SanPham/

        public ActionResult ViewDS()
        {
            var model = new SanPhamF().DSSanPham.ToList();
            return View(model);
        }

        public ActionResult ChiTietSP(string id)
        {
            var model = new SanPhamF().FindEntity(id);
            return View(model);
        }

        public ActionResult TimKiem(string TuKhoa)
        {
            var model = new SanPhamF().DSSanPham.Where(x => x.TenSp.Contains(TuKhoa)).ToList();
            return View("ViewDS", model);
        }

        public ActionResult Index()
        {
            var model = new SanPhamF().DSSanPham.Where(x => x.TenSp != null).ToList();
            return View(model);
        }

        

        public ActionResult Details(int id)
        {
            return View();
        }


        //
        // GET: /SanPham/Create

   

        //
        // POST: /SanPham/Create

        [HttpPost]
        public ActionResult Create(SanPham model, HttpPostedFileBase UrlAnh)
        {
            try
            {
                // TODO: Add update logic here

                if (UrlAnh == null)
                {
                    ModelState.AddModelError("File", "Chưa upload file ảnh");
                }
                else if (UrlAnh.ContentLength > 0)
                {                 //TO:DO
                    var fileName = Path.GetFileName(UrlAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/Content/Images"), fileName);
                    UrlAnh.SaveAs(path);                    //   

                    SanPhamF spF = new SanPhamF();
                    model.MoTa = fileName;
                    if (spF.Insert(model))
                    {
                        return RedirectToAction("Index");
                    }
                }
            }
            catch
            {
                return View();
            }
            return View();
        }

        //
        // GET: /SanPham/Edit/5

        public ActionResult Edit(string id)
        {
            var model = new SanPhamF().FindEntity(id);
            return View(model);
        }

        //
        // POST: /SanPham/Edit/5

        [HttpPost]
        public ActionResult Edit(SanPham model)
        {
            try
            {
                // TODO: Add update logic here
                if (new SanPhamF().Update(model))
                {

                    return RedirectToAction("ViewDS");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /SanPham/Delete/5

        public ActionResult Delete(string id)
        {
            var model = new SanPhamF().FindEntity(id);
            return View("Edit", model);
        }

        //
        // POST: /SanPham/Delete/5

        [HttpPost]
        public ActionResult Delete(SanPham model)
        {
            try
            {
                if (new SanPhamF().Delete(model.GiaSp))
                {

                    return RedirectToAction("ViewDS");
                }
                else
                {
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }
    }
}
