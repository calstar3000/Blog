using System;

namespace Blog.Data
{
	public class Comment
	{
		public int Id { get; set; }
		public string Body { get; set; }
		public DateTime DatePosted { get; set; }

		public Comment(int id, string body, DateTime datePosted)
		{
			Id = id;
			Body = body;
			DatePosted = datePosted;
		}
	}
}
