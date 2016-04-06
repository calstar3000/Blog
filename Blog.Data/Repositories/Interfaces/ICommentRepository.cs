using System.Collections.Generic;

namespace Blog.API.Data.Repositories.Interfaces
{
	public interface ICommentRepository
	{
		Comment GetComment(int postId, int id);
		List<Comment> GetComments(int postId);
	}
}
