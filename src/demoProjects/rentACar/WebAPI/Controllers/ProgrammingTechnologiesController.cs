using Application.Features.ProgrammingLanguages.Command.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Command.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingTechnologies.Command.CreateProgrammingTehcnologies;
using Application.Features.ProgrammingTechnologies.Command.DeleteProgrammingTechnologies;
using Application.Features.ProgrammingTechnologies.Command.UpdateProgrammingTechnologies;
using Application.Features.ProgrammingTechnologies.Dtos;
using Application.Features.ProgrammingTechnologies.Models;
using Application.Features.ProgrammingTechnologies.Queries;
using Application.Features.UserSocialMedias.Models;
using Application.Features.UserSocialMedias.Queries.GetListUserSocialMedia;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingTechnologiesController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddProgrammingTechnologies([FromBody] CreateProgrammingTechnologiesCommand createProgrammingTechnologiesCommand)
        {
            CreatedProgrammingTechnologiesDto result = await Mediator.Send(createProgrammingTechnologiesCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProgrammingTechnologies([FromBody] UpdateProgrammingTechnologiesCommand updateProgrammingTechnologiesCommand)
        {
            UpdateProgrammingTechnologiesDto result = await Mediator.Send(updateProgrammingTechnologiesCommand);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProgrammingTechnologies([FromBody] DeleteProgrammingTechnologiesCommand deleteProgrammingTechnologiesCommand)
        {
            DeleteProgrammingTechnologiesDto result = await Mediator.Send(deleteProgrammingTechnologiesCommand);
            return Created("", result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListProgrammingTechnologies([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingTechnologiesQuery result = new() { PageRequest = pageRequest };
            GetListProgrammingTechnologiesModel getListProgrammingTechnologiesModel = await Mediator.Send(result);
            return Ok(getListProgrammingTechnologiesModel);
        }
    }
}
