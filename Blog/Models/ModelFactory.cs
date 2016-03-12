using Blog.Data;
using System.Linq;
using System.Net.Http;
using System.Web.Http.Routing;
using System;

namespace Blog.Models
{
	public class ModelFactory
	{
		private UrlHelper _urlHelper;

		public ModelFactory(HttpRequestMessage request)
		{
			_urlHelper = new UrlHelper(request);
		}

		public PostModel Create(Post post)
		{
			if (post == null)
				return null;

			return new PostModel()
			{
				Url = _urlHelper.Link("Post", new { postId = post.Id }),
				Id = post.Id,
				Title = post.Title,
				Body = post.Body,
				DatePosted = post.DatePosted,
				Comments = post.Comments.Select(c => Create(c, post.Id)).ToList()
			};
		}

		public CommentModel Create(Comment comment, int postId)
		{
			if (comment == null)
				return null;

			return new CommentModel()
			{
				Url = _urlHelper.Link("Comment", new { postId = postId, commentId = comment.Id }),
				Id = comment.Id,
				Body = comment.Body,
				DatePosted = comment.DatePosted
			};
		}

		public Post Parse(PostModel post)
		{
			try
			{
				if (string.IsNullOrEmpty(post.Title))
					return null;
				if (string.IsNullOrEmpty(post.Body))
					return null;

				return new Post()
				{
					Title = post.Title,
					Body = post.Body
				};
			}
			catch
			{
				return null;
			}
		}
	}
}