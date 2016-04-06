using Blog.API.Data;
using Blog.API.Data.Repositories.Interfaces;
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
	public class CommentsController : BaseApiController
	{
		public CommentsController(IPostRepository postRepository, ICommentRepository commentRepository)
			: base(postRepository, commentRepository) { }

		// GET: api/blog/posts/5/comments
		[EnableCors(origins: "http://localhost:55180", headers: "*", methods: "*")]
		public IEnumerable<CommentModel> Get(int postId)
		{
			return CommentRepository.GetComments(postId).Select(c => ModelFactory.Create(c, postId));
		}

		// GET: api/blog/posts/5/comments/1
		[EnableCors(origins: "http://localhost:55180", headers: "*", methods: "*")]
		public HttpResponseMessage Get(int postId, int commentId)
		{
			CommentModel result = ModelFactory.Create(CommentRepository.GetComment(postId, commentId), postId);

			if (result == null)
				return Request.CreateResponse(HttpStatusCode.NotFound);

			return Request.CreateResponse(HttpStatusCode.OK, result);
		}

		// POST: api/blog/posts/5/comments
		[EnableCors(origins: "http://localhost:55180", headers: "*", methods: "*")]
		public HttpResponseMessage Post(int postId, [FromBody]CommentModel postRequest)
		{
			try
			{
				if (PostRepository.GetPost(postId) == null)
					return Request.CreateResponse(HttpStatusCode.NotFound);

				Comment comment = ModelFactory.Parse(postRequest);

				if (comment == null)
					Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read post in body");

				comment.Save(postId);

				return Request.CreateResponse(HttpStatusCode.Created, ModelFactory.Create(CommentRepository.GetComment(postId, comment.Id), postId));
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
		}

		// PUT: api/Comments/5
		[EnableCors(origins: "http://localhost:55180", headers: "*", methods: "*")]
		public HttpResponseMessage Put(int postId, int commentId, [FromBody]CommentModel putRequest)
		{
			try
			{
				if (PostRepository.GetPost(postId) == null)
					return Request.CreateResponse(HttpStatusCode.NotFound);

				Comment comment = CommentRepository.GetComment(postId, commentId);

				if (comment == null)
					return Request.CreateResponse(HttpStatusCode.NotFound);

				comment = ModelFactory.Parse(putRequest, commentId);

				if (comment == null)
					Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Could not read post in body");

				comment.Save(postId);

				return Request.CreateResponse(HttpStatusCode.Created, ModelFactory.Create(CommentRepository.GetComment(postId, comment.Id), postId));
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
		}

		// DELETE: api/blog/posts/5/comments/1
		[EnableCors(origins: "http://localhost:55180", headers: "*", methods: "*")]
		public HttpResponseMessage Delete(int postId, int commentId)
		{
			try
			{
				if (PostRepository.GetPost(postId) == null)
					return Request.CreateResponse(HttpStatusCode.NotFound);

				Comment comment = CommentRepository.GetComment(postId, commentId);

				if (comment == null)
					return Request.CreateResponse(HttpStatusCode.NotFound);

				comment.Delete(postId);

				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
			}
		}
	}
}
