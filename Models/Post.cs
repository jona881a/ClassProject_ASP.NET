using System.ComponentModel.DataAnnotations;
namespace classProject.Models;

public class Post {

    public List<Post> Posts{get; set;} = new List<Post>();

    public int id {get; set;}
    public string? title {get; set;}
    [Display(Name = "body")]
    public string? body{get; set;}
    public string? author{get; set;}

    public override string? ToString()
    {
        return "Post title: " + title + "Post body: " + body + "Post author: " + author;
    }

    public Post(){}

    public Post(string? title, string? body, string? author) {
        this.title = title;
        this.body = body;
        this.author = author;
    }

}