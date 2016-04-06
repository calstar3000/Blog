using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Blog.API.Data.Repositories
{
	public class PostRepository : Interfaces.IPostRepository
	{
		public Post GetPost(int id)
		{
			Post result = null;
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand(string.Format("SELECT id, title, body, date_posted FROM dbo.post WITH(NOLOCK) WHERE id = {0};", id), connection);

				connection.Open();

				SqlDataReader dr = command.ExecuteReader();

				if (dr.HasRows && dr.Read())
				{
					result = PopulatePost(dr);
				}

				dr.Close();
			}

			return result;
		}

		public List<Post> GetPosts()
		{
			List<Post> results = new List<Post>();
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand("SELECT id, title, body, date_posted FROM dbo.post WITH(NOLOCK) ORDER BY id DESC;", connection);

				connection.Open();

				SqlDataReader dr = command.ExecuteReader();

				if (dr.HasRows)
				{
					while (dr.Read())
					{
						results.Add(PopulatePost(dr));
					}
				}

				dr.Close();
			}

			return results;
		}

		private Post PopulatePost(SqlDataReader dr)
		{
			return new Post()
			{
				Id = dr.GetInt32(dr.GetOrdinal("id")),
				Title = dr.GetString(dr.GetOrdinal("title")),
				Body = dr.GetString(dr.GetOrdinal("body")),
				DatePosted = dr.GetDateTime(dr.GetOrdinal("date_posted")),
				Comments = new CommentRepository().GetComments(dr.GetInt32(dr.GetOrdinal("id")))
			};
		}
	}
}