using System;

namespace Blog.Models
{
	public class Post
	{
		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime DatePublished { get; set; }

		public Post(string title, string body)
		{
			Title = title;
			Body = body;
		}
	}
}