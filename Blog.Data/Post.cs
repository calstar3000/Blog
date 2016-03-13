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

		public void Save()
		{
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

			using (connection)
			{
				connection.Open();

				if (Id <= 0)
					DoInsert(connection);
				else
					DoUpdate(connection);
			}
		}

		private void DoInsert(SqlConnection connection)
		{
			SqlCommand command = new SqlCommand(string.Format("INSERT INTO dbo.post WITH(ROWLOCK) (title, body) VALUES ('{0}', '{1}');", Title, Body), connection);
			
			command.ExecuteNonQuery();

			command = new SqlCommand("SELECT TOP 1 id FROM dbo.post WITH(NOLOCK) ORDER BY id DESC;", connection);

			SqlDataReader dr = command.ExecuteReader();

			if (dr.HasRows && dr.Read())
			{
				Id = dr.GetInt32(dr.GetOrdinal("id"));
			}

			dr.Close();
		}

		private void DoUpdate(SqlConnection connection)
		{
			SqlCommand command = new SqlCommand(string.Format("UPDATE dbo.post WITH(ROWLOCK) SET title = '{0}', body = '{1}' WHERE id = {2};", Title, Body, Id), connection);

			command.ExecuteNonQuery();
		}

		public void Delete()
		{
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand(string.Format("DELETE FROM dbo.post WITH(ROWLOCK) WHERE id = {0};", Id), connection);
				connection.Open();
				command.ExecuteNonQuery();
			}
		}
	}
}