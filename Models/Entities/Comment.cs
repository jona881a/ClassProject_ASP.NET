using System.ComponentModel.DataAnnotations;
namespace classProject.Models;
using Microsoft.AspNetCore.Identity;

public class Comment {
  public int CommentId {get; set;}
  [Display(Name = "Comment")]
  public string CommentBody {get; set;}
  [Display(Name = "Author")]
  public string CommentAuthor {get; set;}
  public int likes {get; set;}
  public DateTime CommentDate {get; set;}

  public int PostId {get; set;}
  public Post Post {get; set;}

  public string UserId {get; set;}
  public IdentityUser User {get; set;}
}