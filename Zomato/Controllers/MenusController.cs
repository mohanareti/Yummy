using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Zomato.DataLayer;
using Zomato.DataModels;
using System.Data.Entity;
using Zomato.ViewModels;
using System.ComponentModel.DataAnnotations;
using Zomato.Models;
using Microsoft.AspNet.Identity;
using Zomato.Global;

namespace Zomato.Controllers
{
    public class MenusController : Controller
    {
        // GET: Menus

        ApplicatioDbContext dbc = null;
        ApplicationDbContext abc = null;
        public MenusController()
        {
            dbc = new ApplicatioDbContext();
            abc = new ApplicationDbContext();
        }
       
       // public MenuItemsViewModel MenuItemsView { get; set; }


        public ActionResult Index()
        {

            if (User.Identity.IsAuthenticated)
            {
                Globalvariable.CartCount = 0;
                Globalvariable.CartCount = dbc.ShoppingCarts.Where(m => m.ApplicationUserId == User.Identity.Name).ToList().Count;
            }
            var Menitm = dbc.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).ToList();
            var viewModel = new MenuItemsViewModel
            {
                MenuItem=Menitm
            };
            return View(viewModel);
        }
        public ActionResult IndexAt(int id)
        {

            var Menitm = dbc.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).Where(m => m.CategoryId.Equals(id)).ToList();
            var viewModel = new MenuItemsViewModel
            {
                MenuItem = Menitm
            };
            return View(viewModel);
        }
        public ActionResult Create()
        {
            ViewBag.cat = dbc.Categories.ToList();
            ViewBag.subcat = dbc.SubCategories.ToList();
            return View();
        }

        [HttpPost]
        public ActionResult Create(MenuItem menu )
        {
            //if(!ModelState.IsValid)
            //{
            //    return RedirectToAction("Create");
            //}
            
            
                if (Request.Files.Count >= 1)
                {
                    var photo = Request.Files[0];
                    var imgByte = new byte[photo.ContentLength - 1];
                    photo.InputStream.Read(imgByte, 0, photo.ContentLength - 1);
                    var base64st = Convert.ToBase64String(imgByte, 0, imgByte.Length);
                    menu.Image = base64st;
                }
                dbc.MenuItems.Add(menu);
                dbc.SaveChanges();
                return RedirectToAction("AIndex");
            
        }

        [Authorize]
        public ActionResult Details(int id)
        {
            ViewBag.shop = dbc.ShoppingCarts;
            ViewBag.user = User.Identity.GetUserId();
            var menit = dbc.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).Where(m => m.Id == id).SingleOrDefault();
            return View(menit);
        }
        public ActionResult Edit(int id)
        {
            //var cat = dbc.Categories.ToList();
            //var subc = dbc.SubCategories.ToList();
            //var emit = dbc.MenuItems.SingleOrDefault(m => m.Id == id);
            //var vmid = new MenuItemsViewModel
            //{
            //    MenuItem = emit,
            //    Categories=cat,
            //    SubCategories=subc
            //};
            ViewBag.cat = dbc.Categories.ToList();
            ViewBag.subcat = dbc.SubCategories.ToList();
            var eem = dbc.MenuItems.Where(m => m.Id == id).SingleOrDefault();
            return View(eem);
           // return View(vmid);
        }

        [HttpPost]
        public ActionResult Edit(MenuItem menu)
        {
            var exmen = dbc.MenuItems.Where(m => m.Id == menu.Id).FirstOrDefault();
            if (Request.Files.Count >= 1)
            {
                var photo = Request.Files[0];
                var imgByte = new byte[photo.ContentLength - 1];
                photo.InputStream.Read(imgByte, 0, photo.ContentLength - 1);
                var base64st = Convert.ToBase64String(imgByte, 0, imgByte.Length);
                menu.Image = base64st;
            }
            exmen.Name = menu.Name;
            exmen.Description = menu.Description;
            exmen.Spicyness = menu.Spicyness;
            exmen.Image = menu.Image;
            exmen.CategoryId = menu.CategoryId;
            exmen.SubCategoryId = menu.SubCategoryId;
            exmen.Price = menu.Price;
            dbc.SaveChanges();
            return RedirectToAction("AIndex");
        }

        public ActionResult Delete(int id)
        {
            ViewBag.cat = dbc.Categories.ToList();
            ViewBag.subcat = dbc.SubCategories.ToList();
            var eem = dbc.MenuItems.Where(m => m.Id == id).SingleOrDefault();
            return View(eem);
        }
        [HttpPost]
        public ActionResult Delete(int id,MenuItem menu)
        {
            var depmen = dbc.MenuItems.Where(m => m.Id==id).FirstOrDefault();
            dbc.MenuItems.Remove(depmen);
            dbc.SaveChanges();
            return RedirectToAction("AIndex");
        }

        [HttpPost]
        public ActionResult AddToCart(ShoppingCart cart)
        {
            bool Exis = false;

            if (User.Identity.IsAuthenticated)
            {
               
                var scart = dbc.ShoppingCarts.ToList();
                foreach (var item in scart)
                {
                    if ((cart.ApplicationUserId == item.ApplicationUserId) && (cart.MenuItemId == item.MenuItemId))
                    {
                        Exis = true;
                        item.Quantity=item.Quantity+1;
                    }
                }
                if(Exis==false)
                {
                    cart.Quantity = 1;
                    dbc.ShoppingCarts.Add(cart);
                }

                Globalvariable.CartCount = Globalvariable.CartCount + 1;
                dbc.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        [Authorize]
        public ActionResult UrCart()
        {
            ViewBag.uId = User.Identity.GetUserId();
            string auId = ViewBag.uId;
            var shoppingcart = dbc.ShoppingCarts.Where(e=>e.ApplicationUserId==auId).ToList();
            // var cartItems = GetCartItems(auId);
            var viewModel = new MenuItemsViewModel
            {
                ShoppingCarts = shoppingcart
            };
            return View(viewModel);
        }

        public ActionResult PlusItems(int cartId)
        {
            var cart = dbc.ShoppingCarts.FirstOrDefault(e => e.Id == cartId);
            cart.Quantity += 1;
            Globalvariable.CartCount = Globalvariable.CartCount + 1;
            dbc.SaveChanges();
            return RedirectToAction("UrCart");

        }
        public ActionResult MinusItems(int cartId)
        {
            var cart = dbc.ShoppingCarts.FirstOrDefault(e => e.Id == cartId);

            if (cart.Quantity == 0)
            {
                dbc.ShoppingCarts.Remove(cart);
               
                dbc.SaveChanges();
            }
            else
            {
                cart.Quantity -= 1;
                Globalvariable.CartCount = Globalvariable.CartCount - 1;
                dbc.SaveChanges();
            }
            return RedirectToAction("UrCart");

        }
        public ActionResult Remove(int cartId)
        {
            var cart = dbc.ShoppingCarts.FirstOrDefault(e => e.Id == cartId);
            dbc.ShoppingCarts.Remove(cart);
            Globalvariable.CartCount = Globalvariable.CartCount - 1;
            dbc.SaveChanges();
            return RedirectToAction("UrCart");
        }

        public ActionResult OderSumary()
        {
            ViewBag.uId = User.Identity.GetUserId();
            string auId = ViewBag.uId;
            var shoppingcart = dbc.ShoppingCarts.Where(e=>e.ApplicationUserId==auId).ToList();
            // var cartItems = GetCartItems(auId);
            var viewModel = new MenuItemsViewModel
            {
                ShoppingCarts = shoppingcart
            };
            return View(viewModel);
        }

        public ActionResult CRemove(string UName)
        {
            var cart = dbc.ShoppingCarts.Where(e => e.ApplicationUserId == UName);
            dbc.ShoppingCarts.RemoveRange(cart);
            dbc.SaveChanges();
            return RedirectToAction("OrderHistory");
        }

        public ActionResult OrderHistory()
        {


            return View();
        }
        public ActionResult AIndex()
        {

            var Menitm = dbc.MenuItems.Include(m => m.Category).Include(m => m.SubCategory).ToList();
            var viewModel = new MenuItemsViewModel
            {
                MenuItem = Menitm
            };
            return View(viewModel);
        }
    }

}