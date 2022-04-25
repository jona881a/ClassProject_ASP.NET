using Microsoft.AspNetCore.Mvc;
using classProject.Models;
using classProject.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using classProject.Models.Entites;

namespace classProject.Controllers;
[Authorize]
public class PostsController : Controller
{

    private readonly ClassProjectContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public PostsController(ClassProjectContext context, UserManager<IdentityUser> userManager)
    {
        this._userManager = userManager;
        this._context = context;
    }
    [AllowAnonymous]
    public IActionResult Index(string SearchString)
    {
        var posts = from p in _context.Posts select p;

        posts = posts.Where(x => x.Title.Contains(SearchString)).Include(y => y.User);

        var vm = new PostIndexVm {Posts= posts.ToList(), SearchString = SearchString};

        return View(vm);
    }

    public IActionResult Post()
    {
        return View("CreatePost");
    }

    [HttpPost]
    [ValidateAntiForgeryToken] 
    public async Task<IActionResult> Post([Bind("Title,Body,Author,Status")] Post post)
    {

        if (ModelState.IsValid)
        {
            IdentityUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            post.CreationDate = DateTime.Now;
            post.User = user;
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

        var Post = _context.Posts.Include(x => x.Comments).ThenInclude(x => x.User).First(x => x.PostId == id);
        if (Post == null)
        {
            return NotFound();
        }
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

