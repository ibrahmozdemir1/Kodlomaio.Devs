using Application.Features.Models;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Application.Features.ProgrammingTechnologies.Command.CreateProgrammingTehcnologies;
using Application.Features.ProgrammingTechnologies.Command.DeleteProgrammingTechnologies;
using Application.Features.ProgrammingTechnologies.Command.UpdateProgrammingTechnologies;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.UserSocialMedias.Command.CreateSocialMediaCommand;
using Application.Features.UserSocialMedias.Command.DeleteSocialMediaCommand;
using Application.Features.UserSocialMedias.Command.UpdateSocialMediaCommand;
using Application.Features.UserSocialMedias.Dtos;
using Application.Features.UserSocialMedias.Models;
using Application.Features.UserSocialMedias.Queries.GetListUserSocialMedia;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSocialMediaController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> CreateUserSocialMedia([FromBody] CreateUserSocialMediaCommand createUserSocialMediaCommand)
        {
            CreateUserSocialMediaCommandDto result = await Mediator.Send(createUserSocialMediaCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUserSocialMedia([FromBody] UpdateUserSocialMediaCommand updateUserSocialMediaCommand)
        {
            UpdateUserSocialMediaCommandDto result = await Mediator.Send(updateUserSocialMediaCommand);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteUserSocialMedia([FromBody] DeleteUserSocialMediaCommand deleteUserSocialMediaCommand)
        {
            DeleteUserSocialMediaCommandDto result = await Mediator.Send(deleteUserSocialMediaCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListUserSocialMedia([FromQuery] PageRequest pageRequest)
        {
            GetListUserSocialMediaQuery result = new() { PageRequest = pageRequest };
            GetListUserSocialMediaModel getListUserSocialMediaModel = await Mediator.Send(result);
            return Ok(getListUserSocialMediaModel);
        }
    }
}
