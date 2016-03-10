using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
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
			List<Comment> results = new List<Comment>();
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand(string.Format("SELECT id, body, date_posted FROM dbo.comment WITH(NOLOCK) WHERE post_id = {0} ORDER BY id DESC;", postId), connection);

				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						Comment item = new Comment();

						item.Id = reader.GetInt32(reader.GetOrdinal("id"));
						item.Body = reader.GetString(reader.GetOrdinal("body"));
						item.DatePosted = reader.GetDateTime(reader.GetOrdinal("date_posted"));

						results.Add(item);
					}
				}

				reader.Close();

				return results;
			}
		}
	}
}
