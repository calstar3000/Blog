using Blog.Data.Repositories.Interfaces;
using System.Collections.Generic;
using System.Web.Http;

namespace Blog.Controllers
{
	public class CommentsController : ApiController
	{
		private ICommentRepository _repo;

		public CommentsController(ICommentRepository repo)
		{
			_repo = repo;
		}

		// GET: api/blog/posts/5/comments/
		public IEnumerable<Data.Comment> Get(int postId)
		{
			return _repo.GetComments(postId);
		}

		// GET: api/blog/posts/5/comments/1
		public Data.Comment Get(int postId, int id)
		{
			return _repo.GetComment(postId, id);
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
