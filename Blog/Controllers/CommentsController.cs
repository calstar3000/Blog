using Blog.Data;
using Blog.Data.Repositories.Interfaces;
using Blog.Models;
using System.Collections.Generic;
using System.Linq;
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
			List<Comment> results = CommentRepository.GetComments(postId);

			return results.Select(c => ModelFactory.Create(c, postId));
		}

		// GET: api/blog/posts/5/comments/1
		public CommentModel Get(int postId, int commentId)
		{
			return ModelFactory.Create(CommentRepository.GetComment(postId, commentId), postId);
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
