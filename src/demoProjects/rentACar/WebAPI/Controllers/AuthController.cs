using Application.Features.Users.Command.UserRegisterCommand;
using Application.Features.ProgrammingLanguages.Command.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.Users.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks.Sources;
using Application.Features.Users.Command.UserLoginCommand;

namespace WebAPI.Controllers
{
    public class AuthController : BaseController
    {
        [HttpPost("register")]
        public async Task<IActionResult> UserRegister([FromBody] UserRegisterCommand userRegisterCommand)
        {
            UserLoginAndRegisterDto result = await Mediator!.Send(userRegisterCommand);
            return Created("", result);
        }

        [HttpPost("login")]

        public async Task<IActionResult> UserLogin([FromQuery] UserLoginCommand userLoginCommand)
        {
            UserLoginAndRegisterDto result = await Mediator!.Send(userLoginCommand);
            return Created("", result);
        }
    }
}
