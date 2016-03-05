using System;
using System.Collections.Generic;
using System.Linq;

namespace Blog.Data.Repositories
{
	public class CommentRepository : Interfaces.ICommentRepository
	{
		public Comment GetComment(int postId, int commentId)
		{
			return GetComments(postId).Where(comment => comment.Id == commentId).FirstOrDefault();
		}

		public List<Comment> GetComments(int postId)
		{
			return new List<Comment>()
			{
				new Comment(3, string.Format("Third comment for post {0}", postId), DateTime.Now.AddDays(-1)),
				new Comment(2, string.Format("Second comment for post {0}", postId), DateTime.Now.AddDays(-2)),
				new Comment(1, string.Format("First comment for post {0}", postId), DateTime.Now.AddDays(-3))
			};
		}
	}
}
