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
			Comment result = new Comment();
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand(string.Format("SELECT id, body, date_posted FROM dbo.comment WITH(NOLOCK) WHERE post_id = {0} AND id = {1};", postId, commentId), connection);

				connection.Open();

				SqlDataReader dr = command.ExecuteReader();

				if (dr.HasRows && dr.Read())
				{
					result = PopulateComment(dr);
				}

				dr.Close();
			}

			return result;
		}

		public List<Comment> GetComments(int postId)
		{
			List<Comment> results = new List<Comment>();
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand(string.Format("SELECT id, body, date_posted FROM dbo.comment WITH(NOLOCK) WHERE post_id = {0} ORDER BY id DESC;", postId), connection);

				connection.Open();

				SqlDataReader dr = command.ExecuteReader();

				if (dr.HasRows)
				{
					while (dr.Read())
					{
						results.Add(PopulateComment(dr));
					}
				}

				dr.Close();
			}

			return results;
		}

		private Comment PopulateComment(SqlDataReader dr)
		{
			return new Comment()
			{
				Id = dr.GetInt32(dr.GetOrdinal("id")),
				Body = dr.GetString(dr.GetOrdinal("body")),
				DatePosted = dr.GetDateTime(dr.GetOrdinal("date_posted"))
			};
		}
	}
}
