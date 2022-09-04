using Application.Features.Models;
using Application.Features.ProgrammingLanguages.Command.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Command.DeleteProgrammingLangue;
using Application.Features.ProgrammingLanguages.Command.UpdateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Application.Features.ProgrammingLanguages.Queries.GetIdProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Queries.GetListProgrammingLanguage;
using Core.Application.Requests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguageController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> AddProgrammingLanguage([FromBody] CreateProgrammingLanguageCommand createProgrammingLanguageCommand)
        {
            CreatedProgramminLanguageDto result = await Mediator.Send(createProgrammingLanguageCommand);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProgrammingLanguage([FromBody] UpdateProgrammingLanguageCommand updateProgrammingLanguageCommand)
        {
            UpdateProgrammingLanguageDto result = await Mediator.Send(updateProgrammingLanguageCommand);
            return Created("", result);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteProgrammingLanguage([FromBody] DeleteProgrammingLanguageCommand deleteProgrammingLanguageCommand)
        {
            DeleteProgrammingLangueageDto result = await Mediator.Send(deleteProgrammingLanguageCommand);
            return Created("", result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetIdProgrammingLanguage([FromRoute] GetIdProgrammingLanguageQuery getIdProgrammingLanguageQuery)
        {
            GetIdProgrammingLanguageDto result = await Mediator.Send(getIdProgrammingLanguageQuery);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetListProgrammingLanguage([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery result = new() { PageRequest = pageRequest };
            ProgrammingLanguageModel programmingLanguageModel = await Mediator.Send(result);
            return Ok(programmingLanguageModel);
        }
    }
}
