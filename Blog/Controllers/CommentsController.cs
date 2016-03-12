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
	public class CommentsController : BaseApiController
	{
		public CommentsController(ICommentRepository commentRepository)
			: base(commentRepository) { }

		// GET: api/blog/posts/5/comments/
		public IEnumerable<CommentModel> Get(int postId)
		{
			return CommentRepository.GetComments(postId).Select(c => ModelFactory.Create(c, postId));
		}

		// GET: api/blog/posts/5/comments/1
		public HttpResponseMessage Get(int postId, int commentId)
		{
			CommentModel result = ModelFactory.Create(CommentRepository.GetComment(postId, commentId), postId);

			if (result == null)
				return Request.CreateResponse(HttpStatusCode.NotFound);

			return Request.CreateResponse(HttpStatusCode.OK, result);
		}

		// POST: api/Comments
		public void Post([FromBody]string value)
		{
		}

		// PUT: api/Comments/5
		public void Put(int id, [FromBody]string value)
		{
		}

		// DELETE: api/Comments/5
		public void Delete(int id)
		{
		}
	}
}
