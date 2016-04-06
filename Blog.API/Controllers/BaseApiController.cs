using Blog.API.Data.Repositories.Interfaces;
using Blog.API.Models;
using System.Web.Http;

namespace Blog.API.Controllers
{
	public abstract class BaseApiController : ApiController
	{
		private IPostRepository _postRepository;
		private ICommentRepository _commentRepository;
		private ModelFactory _modelFactory;

		public BaseApiController(IPostRepository postRepository)
		{
			_postRepository = postRepository;
		}

		public BaseApiController(ICommentRepository commentRepository)
		{
			_commentRepository = commentRepository;
		}

		public BaseApiController(IPostRepository postRepository, ICommentRepository commentRepository)
		{
			_postRepository = postRepository;
			_commentRepository = commentRepository;
		}

		public IPostRepository PostRepository
		{
			get
			{
				return _postRepository;
			}
		}

		public ICommentRepository CommentRepository
		{
			get
			{
				return _commentRepository;
			}
		}

		protected ModelFactory ModelFactory
		{
			get
			{
				if (_modelFactory == null)
					_modelFactory = new ModelFactory(Request);

				return _modelFactory;
			}
		}
	}
}
