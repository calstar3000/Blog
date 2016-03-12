using Blog.Data;
using Blog.Data.Repositories.Interfaces;
using Blog.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
			return PostRepository.GetPosts().Select(p => ModelFactory.Create(p));
		}

		// GET: api/blog/posts/5
		public HttpResponseMessage Get(int postId)
		{
			PostModel result = ModelFactory.Create(PostRepository.GetPost(postId));

			if (result == null)
				return Request.CreateResponse(HttpStatusCode.NotFound);

			return Request.CreateResponse(HttpStatusCode.OK, result);
		}

		// POST: api/Posts
		public void Post([FromBody]PostModel post)
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
