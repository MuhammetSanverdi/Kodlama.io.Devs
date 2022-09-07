using Application.Features.ProgramingLanguages.Commands.UpdateProgrammingLanguage;
using Application.Features.ProgramingLanguages.Dtos;
using Application.Features.ProgramingLanguages.Models;
using Application.Features.ProgramingLanguages.Queries.GetByIdProgrammingLanguage;
using Application.Features.ProgramingLanguages.Queries.GetListProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Commands.CreateProgrammingLanguage;
using Application.Features.ProgrammingLanguages.Dtos;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProgrammingLanguagesController : BaseController
    {

        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateProgrammingLanguageCommand command)
        {
            CreatedProgrammingLanguageDto result = await Mediator.Send(command);
            return Created("", result);
        }


        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateProgrammingLanguageCommand command)
        {
            UpdatedProgrammingLanguageDto result = await Mediator.Send(command);
            return Ok(result);
        }


        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteProgrammingLanguageCommand command)
        {
            DeletedProgrammingLanguageDto result = await Mediator.Send(command);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListProgrammingLanguageQuery getListProgrammingLanguageQuery = new() { PageRequest=pageRequest};
            ProgrammingLanguageListModel result = await Mediator.Send(getListProgrammingLanguageQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdProgrammingLanguageQuery getByIdProgrammingLanguageQuery)
        {
            ProgrammingLanguageGetByIdDto result = await Mediator.Send(getByIdProgrammingLanguageQuery);
            return Ok(result);
        }
    }
}
