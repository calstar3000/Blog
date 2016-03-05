using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repositories
{
	public class PostRepository : Interfaces.IPostRepository
	{
		public Post GetPost(int id)
		{
			return GetPosts().Where(post => post.Id == id).FirstOrDefault();
		}

		public List<Post> GetPosts()
		{
			return new List<Post>()
			{
				new Post(3, "Third post", "My very third post", DateTime.Now.AddDays(-1)),
				new Post(2, "Second post", "My very second post", DateTime.Now.AddDays(-2)),
				new Post(1, "First post", "My very first post", DateTime.Now.AddDays(-3))
			};
		}
	}
}