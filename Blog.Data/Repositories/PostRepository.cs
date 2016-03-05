using System.Collections.Generic;

namespace Blog.Data.Repositories
{
	public class PostRepository : Interfaces.IPostsRepository
	{
		public List<Post> GetPosts()
		{
			return new List<Post>()
			{
				new Post("Third post", "My very third post"),
				new Post("Second post", "My very second post"),
				new Post("First post", "My very first post")
			};
		}
	}
}