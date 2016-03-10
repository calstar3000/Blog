using Blog.Data;
using Blog.Data.Repositories.Interfaces;
using Blog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Blog.Controllers
{
	[AllowAnonymous]
	public class PostsController : BaseApiController
	{
		public PostsController(IPostRepository postRepository) 
			: base(postRepository) { }

		// GET: api/blog/posts/
		public IEnumerable<PostModel> Get()
		{
			List<Post> results = PostRepository.GetPosts();

			return results.Select(p => ModelFactory.Create(p));
		}

		// GET: api/blog/posts/5
		public PostModel Get(int postId)
		{
			return ModelFactory.Create(PostRepository.GetPost(postId));
		}

		// POST: api/Posts
		public void Post([FromBody]string value)
		{
		}

		// PUT: api/Posts/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE: api/Posts/5
		public void Delete(int id)
		{
		}
	}
}
