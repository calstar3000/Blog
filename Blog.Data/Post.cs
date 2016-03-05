using System;
using System.Collections.Generic;

namespace Blog.Data
{
	public class Post
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public string Body { get; set; }
		public DateTime DatePublished { get; set; }
		public List<Comment> Comments { get; set; }

		public Post(int id, string title, string body, DateTime datePublished)
		{
			Id = id;
			Title = title;
			Body = body;
			DatePublished = datePublished;
			Comments = new Repositories.CommentRepository().GetComments(id);
		}
	}
}