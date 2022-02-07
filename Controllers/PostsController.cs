using Microsoft.AspNetCore.Mvc;
using classProject.Models;

namespace classProject.Controllers;

public class PostsController : Controller {

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

            Post newPost = new Post(post.Title, post.Body, post.Author);
            return View("Thanks");
        }
    
        return RedirectToAction("Post");
    }

}