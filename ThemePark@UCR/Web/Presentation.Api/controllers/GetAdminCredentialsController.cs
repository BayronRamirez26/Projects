//using Microsoft.AspNetCore.Authorization;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.Identity.Web.Resource;
//using UCR.ECCI.PI.ThemePark_UCR.Application.Person.Services;
//using UCR.ECCI.PI.ThemePark_UCR.Infrastructure.ApiClient.Client.Models;

//namespace UCR.ECCI.PI.ThemePark_UCR.Presentation.Api.controllers
//{
//    [Authorize]
//    [ApiController]
//    [Route("[controller]")]
//    [RequiredScope(RequiredScopesConfigurationKey = "AzureAd:Scopes")]

//    public class UserController : ControllerBase
//        {
//            private readonly IUserService _userService;

//            public UserController(IUserService UserService)
//            {
//                _UserService = UserService;
//            }

//            [HttpGet("create-User-login")]
//            public async Task<IActionResult> CreateUserLogin()
//            {
//                var UserCredentials = await _UserService.GetUserCredentialsAsync();
//                return Ok(UserCredentials);
//            }
//        }
//}
