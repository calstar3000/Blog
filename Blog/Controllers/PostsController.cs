using Blog.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace Blog.Controllers
{
	[AllowAnonymous]
	public class PostsController : ApiController
	{
		private IPostRepository _repo;

		public PostsController(IPostRepository repo)
		{
			_repo = repo;
		}

		// GET: api/blog/posts/
		public IEnumerable<Data.Post> Get()
		{
			return _repo.GetPosts();
		}

		// GET: api/blog/posts/5
		public Data.Post Get(int id)
		{
			return _repo.GetPost(id);
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
