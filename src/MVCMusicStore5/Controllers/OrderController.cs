using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApp.BusinessLogic;
using Microsoft.AspNet.Http;
using Microsoft.AspNet.Mvc;
using MVCMusicStore5.BusinessLogic;
using Microsoft.AspNet.Session;
using MVCMusicStore5.Models.GenreModels;
using MVCMusicStore5.Models.OrderModels;
using MVCMusicStore5.Repositories;
using Newtonsoft.Json;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace MVCMusicStore5.Controllers
{
    public class OrderController : Controller
    {
        // GET: /<controller>/
        public IActionResult ViewOrder()
        {
            var model = new OrderModel();
            var repository = new AlbumRepository();
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("CartItems")))
            {
                var cartItems = GetCartItemsFromSession();
                var orderTotal = Convert.ToDecimal(0);
                foreach (var cartItem in cartItems)
                {
                    repository = new AlbumRepository();
                    var album = repository.GetAlbum(cartItem.Id);
                    cartItem.Title = album.Title;
                    cartItem.Price = album.Price;
                    cartItem.ItemSubtotal = album.Price*cartItem.Quantity;
                    orderTotal += album.Price*cartItem.Quantity;
                }

                model.CartItems = cartItems;
                model.OrderTotal = orderTotal;
            }
            ViewBag.QuantityDictionary = BusinessMethods.GetQuantityDictionary();
            return View(model);
        }

        public JsonResult AddToCart(Guid id, int quantity)
        {
            var cartItem = new CartItemModel {Id = id, Quantity = quantity};
            var cartItems = AddCartItem(cartItem);
            PutCartItemsInSession(cartItems);
            var numberItems = 0;
            foreach (var c in cartItems)
            {
                numberItems += c.Quantity;
            }
            return Json(new {cartItemNumber = numberItems});
        }

        private List<CartItemModel> AddCartItem(CartItemModel cartItem)
        {
            List<CartItemModel> cartItems = null;
            if (!String.IsNullOrEmpty(HttpContext.Session.GetString("CartItems")))
            {
                cartItems = GetCartItemsFromSession();
            }
            else
            {
                cartItems = new List<CartItemModel>();
            }
            cartItems.Add(cartItem);
            return cartItems;
        }

        private void PutCartItemsInSession(List<CartItemModel> cartItems)
        {
            var json = SerializationLogic<List<CartItemModel>>.Serialize(cartItems);
            HttpContext.Session.SetString("CartItems", json);
        }

        private List<CartItemModel> GetCartItemsFromSession()
        {
            var json = HttpContext.Session.GetString("CartItems");
            return SerializationLogic<List<CartItemModel>>.Deserialize(json);

        }

        [HttpGet]
        public ActionResult EditCartItem(Guid id)
        {
            var cartItems = GetCartItemsFromSession();
            var editCartItem = cartItems.FirstOrDefault(c => c.Id == id);
            var repository = new AlbumRepository();
            var album = repository.GetAlbum(id);
            editCartItem.Title = album.Title;
            editCartItem.Price = album.Price;
            cartItems.Remove(editCartItem);
            PutCartItemsInSession(cartItems);
            ViewBag.QuantityDictionary = BusinessMethods.GetQuantityDictionary();
            return View(editCartItem);
        }

        [HttpPost]
        public ActionResult EditCartItem(CartItemModel cartItem)
        {
            var cartItems = AddCartItem(cartItem);
            PutCartItemsInSession(cartItems);
            return RedirectToAction("ViewOrder");
        }

        public ActionResult DeleteCartItem(Guid id)
        {
            var cartItems = GetCartItemsFromSession();
            var deleteCartItem = cartItems.FirstOrDefault(c => c.Id == id);
            cartItems.Remove(deleteCartItem);
            PutCartItemsInSession(cartItems);
            return RedirectToAction("ViewOrder");

        }
    }
}
