using Blog.API.Data;
using Blog.API.Data.Repositories.Interfaces;
using Blog.API.Filters;
using Blog.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Blog.API.Controllers
{
	[AllowAnonymous]
	//[BlogAuthorize]
	public class PostsController : BaseApiController
	{
		public PostsController(IPostRepository postRepository) 
			: base(postRepository) { }

		// GET: api/blog/posts
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		public IEnumerable<PostModel> Get()
		{
			return PostRepository.GetPosts().Select(p => ModelFactory.Create(p));
		}

		// GET: api/blog/posts/latest
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		public HttpResponseMessage GetLatest()
		{
			PostModel result = ModelFactory.Create(PostRepository.GetLatestPost());

			if (result == null)
				return Request.CreateResponse(HttpStatusCode.NotFound);

			return Request.CreateResponse(HttpStatusCode.OK, result);
		}

		// GET: api/blog/posts/5
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		public HttpResponseMessage Get(int postId)
		{
			PostModel result = ModelFactory.Create(PostRepository.GetPost(postId));

			if (result == null)
				return Request.CreateResponse(HttpStatusCode.NotFound);

			return Request.CreateResponse(HttpStatusCode.OK, result);
		}

		// POST: api/blog/posts
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		public HttpResponseMessage Post([FromBody]PostModel postRequest)
		{
			try
			{
				Post post = ModelFactory.Parse(postRequest);

				if (post == null)
					Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read post in body");

				post.Save();

				return Request.CreateResponse(HttpStatusCode.Created, ModelFactory.Create(PostRepository.GetPost(post.Id)));
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
		}

		// PUT: api/blog/posts/5
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		public HttpResponseMessage Put(int postId, [FromBody]PostModel putRequest)
		{
			try
			{
				Post post = PostRepository.GetPost(postId);

				if (post == null)
					return Request.CreateResponse(HttpStatusCode.NotFound);

				post = ModelFactory.Parse(putRequest, postId);
				
				if (post == null)
					Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read post in body");

				post.Save();

				return Request.CreateResponse(HttpStatusCode.Created, ModelFactory.Create(PostRepository.GetPost(post.Id)));
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
		}

		// DELETE: api/blog/posts/5
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		public HttpResponseMessage Delete(int postId)
		{
			try
			{
				Post post = PostRepository.GetPost(postId);

				if (post == null)
					return Request.CreateResponse(HttpStatusCode.NotFound);

				post.Delete();

				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
		}
	}
}
