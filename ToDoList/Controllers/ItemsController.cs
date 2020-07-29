using Microsoft.AspNetCore.Mvc;
using ToDoList.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ToDoList.Controllers
{
  public class ItemsController : Controller
  {
    private readonly ToDoListContext _db;

    public ItemsController(ToDoListContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Item> model = _db.Items.Include(items => items.Category).ToList();
      return View(model);
      // for each Item in the database include the category it belongs to and then put into list
    }

    public ActionResult Create()
    {
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View();
    }

    [HttpPost]
    public ActionResult Create(Item item)
    {
      _db.Items.Add(item);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult Details(int id)
    {
      Item thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
      return View(thisItem);
    }
    public ActionResult Edit (int id)  // Get method that routes to page with form to update item
    {
      var thisItem = _db.Items.FirstOrDefault(items => items.ItemId == id);
      ViewBag.CategoryId = new SelectList(_db.Categories, "CategoryId", "Name");
      return View(thisItem); // finds spectific item and passes it to the view
    }
    [HttpPost]
    public ActionResult Edit (Item item) // updates the item after being routed to there by Get method
    {
      _db.Entry(item).State = EntityState.Modified;  // (item) = routing parameter // Entry () = method, State = property // state updated to EntityState.Modified = tells Entity the entry has been updated 
      _db.SaveChanges();// once state has been modified, we call SaveChanges
      return RedirectToAction("Index");
    }

    public ActionResult Delete (int id) // initializes delete process by grabbing the item?
    {
      var thisItem = _db.Items.FirstOrDefault(item => item.ItemId == id);
      return View (thisItem);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed (int id) // confirms the delete of selected Id
    {
      var thisItem = _db.Items.FirstOrDefault(items => items.ItemId ==id);
      _db.Items.Remove(thisItem); // destroys entry
      _db.SaveChanges(); // commits to database
      return RedirectToAction("Index"); // returns to top
    }
  }
}