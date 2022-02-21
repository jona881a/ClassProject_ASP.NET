using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace classProject.Models;

public class Post {

    public List<Post> Posts{get; set;} = new List<Post>();

    public int id {get; set;}
    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "The first letter must be uppercase and there must not be special characters")]
    [StringLength(20,MinimumLength = 3, ErrorMessage = "The Title mus be minimum 3 characters and maximum 20"),Display(Name = "Post Title")]
    public string? Title {get; set;}
    [Required]
    [StringLength(500,MinimumLength = 20, ErrorMessage = "The Post Body must be atleast 20 characters and maximum 500"),Display(Name = "Post Body")]
    public string? Body{get; set;}

    [Required]
    [RegularExpression(@"^[A-Z]+[a-zA-Z\s]*$", ErrorMessage = "The first letter must be uppercase and there must not be special characters")]
    [StringLength(20,MinimumLength = 3, ErrorMessage ="The Author should atleast have 3 characters and maximum 20"), Display(Name = "Author of Post")]
    public string? Author{get; set;}

    [DataType(DataType.Date)]
    public DateTime CreationDate {get;set;}

    public PostStatus PostStatus {get;set;}

    public override string ToString()
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