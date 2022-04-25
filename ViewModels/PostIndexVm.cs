namespace classProject.Models.Entites;

public class PostIndexVm
{
  public IEnumerable<Post> Posts {get; set;}

  public string SearchString {get; set;}

}