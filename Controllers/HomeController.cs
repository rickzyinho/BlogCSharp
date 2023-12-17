using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using blogCSharp.Models;
using blogCSharp.Repository.Interfaces;

namespace CursoDesenvolvimentoWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRepositoryBase<Post> _postRepository;

        public HomeController(ILogger<HomeController> logger, IRepositoryBase<Post> postRepository)
        {
            _logger = logger;
            _postRepository = postRepository;
        }

        public async Task<IActionResult> Index()
        {
            var allPosts = await _postRepository.All();
            ViewBag.AllPosts = allPosts;
            return View(allPosts);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string title)
        {
            var allPost = await _postRepository.All();
            var postsSelected = allPost
                .Where(p => p.Title.ToUpper().Contains(title.ToUpper()))
                .ToList();

            ViewBag.AllPosts = postsSelected;

            return View(allPost);
        }

        public async Task<IActionResult> Post(string postId)
        {
            var idFormated = Guid.Parse(postId);
            var getPost = await _postRepository.GetPerId(idFormated);

            var allPosts = await _postRepository.All();
            ViewBag.AllPosts = allPosts;

            return View(getPost);
        }

        public async Task<IActionResult> SearchPost(string title)
        {
            var allPost = await _postRepository.All();
            var postSelected = allPost
                .Where(p => p.Title.ToUpper().Contains(title.ToUpper()))
                .ToList();

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(
                new ErrorViewModel
                {
                    RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
                }
            );
        }
    }
}