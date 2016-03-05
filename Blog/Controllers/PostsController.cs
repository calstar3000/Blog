using Blog.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace Blog.Controllers
{
	[AllowAnonymous]
	public class PostsController : ApiController
	{
		private IPostsRepository _repo;

		public PostsController(IPostsRepository repo)
		{
			_repo = repo;
		}

		// GET: api/Posts
		public IEnumerable<Data.Post> Get()
		{
			return _repo.GetPosts();
		}

		// GET: api/Posts/5
		public string Get(int id)
		{
			return "value";
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
