using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace Blog.Data
{
	public class Post
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime DatePosted { get; set; }
		public List<Comment> Comments { get; set; }

		public Post() { }

		public Post(int id, string title, string body, DateTime datePosted)
		{
			Id = id;
			Title = title;
			Body = body;
			DatePosted = datePosted;
			Comments = new Repositories.CommentRepository().GetComments(id);
		}

		public int Save()
		{
			int result = 0;
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand(string.Format("INSERT INTO dbo.post WITH(ROWLOCK) (title, body) VALUES ('{0}', '{1}');", Title, Body), connection);
				connection.Open();
				command.ExecuteNonQuery();

				command = new SqlCommand("SELECT TOP 1 id FROM dbo.post WITH(NOLOCK) ORDER BY id DESC;", connection);

				SqlDataReader dr = command.ExecuteReader();

				if (dr.HasRows && dr.Read())
				{
					result = dr.GetInt32(dr.GetOrdinal("id"));
				}

				dr.Close();
			}

			return result;
		}
	}
}