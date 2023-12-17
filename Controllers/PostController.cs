using blogCSharp.Models;
using blogCSharp.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CursoDesenvolvimentoWeb.Controllers
{
    public class PostController : Controller
    {
        private readonly ILogger<PostController> _logger;
        private readonly IRepositoryBase<Post> _postRepository;

        public PostController(ILogger<PostController> logger, IRepositoryBase<Post> postRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
        }

        public async Task<IActionResult> GetPost(string postId, string title = "")
        {
            var allPost = await _postRepository.All();
            var idFormated = Guid.Parse(postId);
            var getPost = allPost.Where(p => p.Id == idFormated).FirstOrDefault();

            if (title == null)
            {
                ViewBag.AllPosts = allPost;
            }
            else
            {
                var postsSelected = allPost
                    .Where(p => p.Title.ToUpper().Contains(title.ToUpper()))
                    .ToList();

                ViewBag.AllPosts = postsSelected;
            }

            return View(getPost);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}