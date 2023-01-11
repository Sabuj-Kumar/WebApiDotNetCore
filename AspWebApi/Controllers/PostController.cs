using AspWebApi.DataContext;
using AspWebApi.Intefaces.Managers;
using AspWebApi.Manager;
using AspWebApi.Models;
using CoreApiResponse;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using System.Net;

namespace AspWebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PostController : BaseController
    {
        /*ApplicationDbContext _db;
        PostManager _postManager;*/
        Imanager _postManager;
        /*public PostController(ApplicationDbContext db)
        {
            _db = db;

            _postManager = new PostManager(db);
        }*/
        public PostController(Imanager postManager)// using Depandancy injection AddTransient<Imanager, PostManager>();
        {
           /* _db = db;*/

            /*_postManager = new PostManager(db);*/
            _postManager = postManager;
        }
        [HttpGet]
        public IActionResult GetAllPost()
        {
            try {
                /*var posts = _db.Post.ToList();*/
                var posts = _postManager.GetAll().ToList();

                if (posts == null)
                {

                    return NotFound();
                }
                return CustomResult("Data Get Succesfully",posts);
            }
            catch(Exception ex) {
                //return BadRequest(ex.Message);
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
            
        }
        [HttpGet]
        public IActionResult GetAllPostOrderBy() 
        {
            try
            {
                /*var posts = _db.Post.ToList();*/
                var posts = _postManager.GetAll().OrderBy(e=>e.CreatedTime).ThenByDescending(e=>e.Title).ToList();

                if (posts == null)
                {

                    return NotFound();
                }
                return CustomResult("Data Get Succesfully", posts);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }
        [HttpGet("title")]
        public IActionResult GetFilterData(string title)
        {
            try
            {
                /*var posts = _db.Post.ToList();*/
                var posts = _postManager.GetAllFilterData(title);

                if (posts == null)
                {
                    return NotFound();
                }
                return CustomResult("Data Get Succesfully", posts);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }
        [HttpGet("text")]
        public IActionResult GetContainsFilterData(string text)
        {
            try
            {
                /*var posts = _db.Post.ToList();*/
                var posts = _postManager.GetAllContainsFilterData(text);

                if (posts == null)
                {
                    return NotFound();
                }
                return CustomResult("Data Get Succesfully", posts);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }
        [HttpGet("{page}/{pageNumber}")]
        public IActionResult GetPagingData(int page,int pageNumber)
        {
            try
            {
                /*var posts = _db.Post.ToList();*/
                var posts = _postManager.GetPagingData(page, pageNumber);

                if (posts == null)
                {
                    return NotFound();
                }
                return CustomResult("Data Get Succesfully", posts);
            }
            catch (Exception ex)
            {
                //return BadRequest(ex.Message);
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }

        }
        [HttpGet("id")]
        public IActionResult GetById(int id) {

            try {
                var post = _postManager.GetById(id);

                if (post == null)
                {
                    return CustomResult("Data Not Found", HttpStatusCode.NotFound); 
                }
                return CustomResult("Data Get Succesfully",post,HttpStatusCode.OK);
            }
            catch (Exception ex) {
                return CustomResult("Data Not Found", HttpStatusCode.BadRequest);
            }
            
        }

        [HttpPost]
        public IActionResult AddPost(PostModel postModel)
        {
            try {
                postModel.CreatedTime = DateTime.Now;

                /*_db.Add(postModel);

                bool save = _db.SaveChanges() > 0;*/
                bool save = _postManager.Add(postModel);

                if (save)
                {
                    return CustomResult("Data Get Succesfully", postModel, HttpStatusCode.Created);
                }

                return CustomResult("Not Created", HttpStatusCode.BadRequest);
            }
            catch(Exception ex) {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
           
        }
        [HttpPut]
        public IActionResult UpdateData(PostModel postModel) {

            try
            {
                if (postModel.Id == 0)
                {

                    return BadRequest("Id not Found");
                }

                bool updated = _postManager.Update(postModel);

                if (updated)
                {
                    //return Ok(postModel);
                    return CustomResult("Data Update Succesfully", postModel, HttpStatusCode.OK);
                }
                return CustomResult("Not Updated", HttpStatusCode.BadRequest);
            }
            catch (Exception ex) {
                //return BadRequest(ex.Message);
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpDelete("id")]
        public IActionResult DeleteData(int id) {
            try
            {
                var data = _postManager.GetById(id);

                if (data == null)
                {
                    return CustomResult("Data Not Found", HttpStatusCode.NotFound);
                }

                bool isDelete = _postManager.Delete(data);

                if (isDelete)
                {
                    //return Ok("Data Delete Succesfully");
                    return CustomResult("Data Delete Succesfully", HttpStatusCode.OK);
                }

                //return BadRequest();
                return CustomResult("Data Not Deleted", HttpStatusCode.BadRequest);
            }
            catch (Exception ex) {
                //return BadRequest(ex.Message);
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
    }
}
