using System.Collections.Generic;

namespace Blog.Data.Repositories.Interfaces
{
	public interface ICommentRepository
	{
		Comment GetComment(int postId, int id);
		List<Comment> GetComments(int postId);
	}
}
