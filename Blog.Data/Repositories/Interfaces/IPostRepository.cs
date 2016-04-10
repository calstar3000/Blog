using System.Collections.Generic;

namespace Blog.API.Data.Repositories.Interfaces
{
	public interface IPostRepository
	{
		Post GetPost(int id);
		List<Post> GetPosts();
	}
}
