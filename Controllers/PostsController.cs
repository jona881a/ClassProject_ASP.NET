using Microsoft.AspNetCore.Mvc;
using classProject.Models;
using classProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace classProject.Controllers;
[Authorize]
public class PostsController : Controller
{

    private readonly ClassProjectContext _context;

    public PostsController(ClassProjectContext context)
    {
        _context = context;
    }
    [AllowAnonymous]
    public IActionResult Index()
    {
        IEnumerable<Post> posts = _context.Posts.ToList();
        return View(posts);
    }

    public IActionResult Thanks()
    {
        ViewBag.greet = "Hello there from the ViewBag";
        // ViewBag.goodbyes = "Bye for now"; Kan ikke have to 

        return View();
    }

    public IActionResult Post()
    {
        return View("CreatePost");
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Post([Bind("Title,Body,Author,Status")] Post post)
    {

        if (ModelState.IsValid)
        {
            post.CreationDate = DateTime.Now;
            _context.Posts.Add(post);
            _context.SaveChanges();

            return RedirectToAction("Index"); //Kalder Actionmetoden Index istedet for at skulle return viewet med postlisten igen (DRY principle)
        }
        else
        {
            return RedirectToAction("Post");
        }
    }
    public IActionResult Edit(int? id)
    {

        if (id == null)
        {
            return NotFound();
        }

        var Post = _context.Posts.Find(id);
        if (Post == null)
        {
            return NotFound();
        }
        Console.Write(Post);
        return View(Post);
    }

    [HttpPost]
    public IActionResult Edit(int id, [Bind("Id,Title,Body,Author,Status")] Post post)
    {
        if (id != post.PostId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {

            _context.Update(post);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        return View(post);
    }
}

