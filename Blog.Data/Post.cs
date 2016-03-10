using System;
using System.Collections.Generic;

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
	}
}