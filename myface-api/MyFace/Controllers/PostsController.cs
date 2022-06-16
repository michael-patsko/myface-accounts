using Microsoft.AspNetCore.Mvc;
using MyFace.Models.Request;
using MyFace.Models.Response;
using MyFace.Repositories;
using MyFace.Utilities;
using System;

namespace MyFace.Controllers
{
    [ApiController]
    [Route("/posts")]
    public class PostsController : ControllerBase
    {
        private readonly IPostsRepo _posts;
        private readonly IUsersRepo _users;
        private readonly IAuthorizeUser _authorizeUser;

        public PostsController(IPostsRepo posts, IUsersRepo users, IAuthorizeUser authorizeUser)
        {
            _posts = posts;
            _users = users;
            _authorizeUser = authorizeUser;
        }

        [HttpGet("")]
        public ActionResult<PostListResponse> Search([FromQuery] PostSearchRequest searchRequest)
        {
            var posts = _posts.Search(searchRequest);
            var postCount = _posts.Count(searchRequest);
            return PostListResponse.Create(searchRequest, posts, postCount);
        }

        [HttpGet("{id}")]
        public ActionResult<PostResponse> GetById([FromRoute] int id)
        {
            var post = _posts.GetById(id);
            return new PostResponse(post);
        }

        [HttpPost("create")]
        public IActionResult Create(
            [FromHeader] string authorization,
            [FromBody] CreatePostRequest newPost
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                string[] splitHeader = authorization.Split(" ");
                string encodedUsernameAndPassword = splitHeader[1];
                byte[] usernameAndPasswordBytes = Convert.FromBase64String(
                    encodedUsernameAndPassword
                );
                string usernameAndPassword = System.Text.Encoding.UTF8.GetString(
                    usernameAndPasswordBytes
                );
                string[] usernameAndPasswordSplit = usernameAndPassword.Split(":");
                string username = usernameAndPasswordSplit[0];
                string password = usernameAndPasswordSplit[1];

                if (!_authorizeUser.CheckUsernameAndPassword(username, password))
                {
                    return Unauthorized("Username and password are not valid.");
                }

                var authenticatedUser = _users.GetByUsername(username);

                if (authenticatedUser.Id != newPost.UserId)
                {
                    return Unauthorized("Cannot create a post for another user.");
                }
            }
            catch (Exception err)
            {
                return Unauthorized("Must pass a valid authorization header.");
            }

            var post = _posts.Create(newPost);

            var url = Url.Action("GetById", new { id = post.Id });
            var postResponse = new PostResponse(post);
            return Created(url, postResponse);
        }

        [HttpPatch("{id}/update")]
        public ActionResult<PostResponse> Update(
            [FromRoute] int id,
            [FromBody] UpdatePostRequest update
        )
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var post = _posts.Update(id, update);
            return new PostResponse(post);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            _posts.Delete(id);
            return Ok();
        }
    }
}
