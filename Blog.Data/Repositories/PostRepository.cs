using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;

namespace Blog.Data.Repositories
{
	public class PostRepository : Interfaces.IPostRepository
	{
		public Post GetPost(int id)
		{
			return GetPosts().Where(post => post.Id == id).FirstOrDefault();
		}

		public List<Post> GetPosts()
		{
			List<Post> results = new List<Post>();
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand("SELECT id, title, body, date_posted FROM dbo.post WITH(NOLOCK) ORDER BY id DESC;", connection);

				connection.Open();

				SqlDataReader reader = command.ExecuteReader();

				if (reader.HasRows)
				{
					while (reader.Read())
					{
						Post item = new Post();

						item.Id = reader.GetInt32(reader.GetOrdinal("id"));
						item.Title = reader.GetString(reader.GetOrdinal("title"));
						item.Body = reader.GetString(reader.GetOrdinal("body"));
						item.DatePosted = reader.GetDateTime(reader.GetOrdinal("date_posted"));
						item.Comments = new CommentRepository().GetComments(item.Id);

						results.Add(item);
					}
				}

				reader.Close();

				return results;
			}
		}
	}
}