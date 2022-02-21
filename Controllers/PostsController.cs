using Microsoft.AspNetCore.Mvc;
using classProject.Models;
using classProject.Data;

namespace classProject.Controllers;

public class PostsController : Controller {

    private readonly ClassProjectContext _context;

    public PostsController(ClassProjectContext context) {
        _context = context;
    }

    public IActionResult Thanks() {
        ViewBag.greet = "Hello there from the ViewBag";
       // ViewBag.goodbyes = "Bye for now"; Kan ikke have to 

        return View();
    }

    [HttpGet]
    public IActionResult Post() {
        return View("CreatePost");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Post([Bind("Title,Body,Author")] Post post) {

        if(ModelState.IsValid) {
            
            post.CreationDate = DateTime.Now;
            _context.Posts.Add(post);
            _context.SaveChanges();

            return View("Thanks");
        } else {
            return RedirectToAction("Post");
        }      
    }
}