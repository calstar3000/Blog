using System;
using System.Configuration;
using System.Data.SqlClient;

namespace Blog.API.Data
{
	public class Comment
	{
		public int Id { get; set; }
		public string Body { get; set; }
		public DateTime DatePosted { get; set; }

		public Comment() { }

		public Comment(int id, string body, DateTime datePosted)
		{
			Id = id;
			Body = body;
			DatePosted = datePosted;
		}

		public void Save(int postId)
		{
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

			using (connection)
			{
				connection.Open();

				if (Id <= 0)
					DoInsert(postId, connection);
				else
					DoUpdate(postId, connection);
			}
		}

		private void DoInsert(int postId, SqlConnection connection)
		{
			SqlCommand command = new SqlCommand(string.Format("INSERT INTO dbo.comment WITH(ROWLOCK) (post_id, body) VALUES ({0}, '{1}');", postId, Body), connection);

			command.ExecuteNonQuery();

			command = new SqlCommand("SELECT TOP 1 id FROM dbo.comment WITH(NOLOCK) ORDER BY id DESC;", connection);

			SqlDataReader dr = command.ExecuteReader();

			if (dr.HasRows && dr.Read())
			{
				Id = dr.GetInt32(dr.GetOrdinal("id"));
			}

			dr.Close();
		}

		private void DoUpdate(int postId, SqlConnection connection)
		{
			SqlCommand command = new SqlCommand(string.Format("UPDATE dbo.comment WITH(ROWLOCK) SET body = '{0}' WHERE post_id = {1} AND id = {2};", Body, postId, Id), connection);

			command.ExecuteNonQuery();
		}

		public void Delete(int postId)
		{
			SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

			using (connection)
			{
				SqlCommand command = new SqlCommand(string.Format("DELETE FROM dbo.comment WITH(ROWLOCK) WHERE post_id = {0} AND id = {1};", postId, Id), connection);
				connection.Open();
				command.ExecuteNonQuery();
			}
		}
	}
}
