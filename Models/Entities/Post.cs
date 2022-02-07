using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace classProject.Models;

public class Post {

    public List<Post> Posts{get; set;} = new List<Post>();

    public int id {get; set;}
    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [StringLength(20,MinimumLength = 3),Display(Name = "Post Title")]
    public string? Title {get; set;}
    [Required]
    [StringLength(500,MinimumLength = 20),Display(Name = "Post Body")]
    public string? Body{get; set;}

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$")]
    [StringLength(20,MinimumLength = 5), Display(Name = "Author of Post")]
    public string? Author{get; set;}

    [DataType(DataType.Date)]
    public DateTime CreationDate {get;set;}

    public PostStatus PostStatus {get;set;}

    public override string? ToString()
    {
        return "Post title: " + Title + "Post body: " + Body + "Post author: " + Author;
    }

    public Post(){}
    public Post(string? Title, string? Body, string? Author) {
        this.Title = Title;
        this.Body = Body;
        this.Author = Author;
    }

}