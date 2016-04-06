using System;

namespace Blog.API.Models
{
	public class CommentModel
	{
		public string Url { get; set; }
		public int Id { get; set; }
		public string Body { get; set; }
		public DateTime DatePosted { get; set; }

		public CommentModel() { }

		public CommentModel(string url, int id, string body, DateTime datePosted)
		{
			Url = url;
			Id = id;
			Body = body;
			DatePosted = datePosted;
		}
	}
}