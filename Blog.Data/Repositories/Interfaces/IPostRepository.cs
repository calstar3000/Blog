using System.Collections.Generic;

namespace Blog.Data.Repositories.Interfaces
{
	public interface IPostRepository
	{
		Post GetPost(int id);
		List<Post> GetPosts();
	}
}