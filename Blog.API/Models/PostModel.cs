using System;
using System.Collections.Generic;

namespace Blog.API.Models
{
	public class PostModel
	{
		public string Url { get; set; }
		public int Id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime DatePosted { get; set; }
		public List<CommentModel> Comments { get; set; }

		public PostModel() { }

		public PostModel(string url, int id, string title, string body, List<CommentModel> comments)
		{
			Url = url;
			Id = id;
			Title = title;
			Body = body;
			Comments = comments;
		}
	}
}