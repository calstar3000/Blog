using System.Collections.Generic;

namespace Blog.Data.Repositories.Interfaces
{
	public interface IPostsRepository
	{
		List<Post> GetPosts();
	}
}