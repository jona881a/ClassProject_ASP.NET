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
    public IActionResult CreatePost() {
        return View();
    }

    [HttpPost]
    public IActionResult CreatePost(Post post) {
        Post newPost = new Post(post.title, post.body, post.author);

        return Content($"Post title: {post.title}, Post body: {post.body}, Post author: {post.author}");
        //return newPost.ToString;
    }

}