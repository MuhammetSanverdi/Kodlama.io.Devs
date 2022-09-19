using Application.Features.LanguageTechnologies.Commands.CreateLanguageTechnoloy;
using Application.Features.LanguageTechnologies.Commands.DeleteLanguageTechnology;
using Application.Features.LanguageTechnologies.Commands.UpdateLanguageTechnology;
using Application.Features.LanguageTechnologies.Dtos;
using Application.Features.LanguageTechnologies.Models;
using Application.Features.LanguageTechnologies.Queries.GetListLanguageTechnology;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguageTechnologiesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
        {
            GetListLanguageTechnologyQuery getListLanguageTechnologyQuery = new GetListLanguageTechnologyQuery { PageRequest = pageRequest };
            LanguageTechnologyListModel languageTechnologyListModel = await Mediator.Send(getListLanguageTechnologyQuery);
            return Ok(languageTechnologyListModel);
        }
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] CreateLanguageTechnologyCommand command)
        {
            CreatedLanguageTechnologyDto technologyDto = await Mediator.Send(command);
            return Created("", technologyDto);
        }

        [HttpPost("update")]
        public async Task<IActionResult> Update([FromBody] UpdateLanguageTechnologyCommand command)
        {
            UpdatedLanguageTechnologyDto technologyDto = await Mediator.Send(command);
            return Ok(technologyDto);
        }

        [HttpPost("delete")]
        public async Task<IActionResult> Delete([FromBody] DeleteLanguageTechnologyCommand command)
        {
            DeletedLanguageTechnologyDto technologyDto = await Mediator.Send(command);
            return Ok(technologyDto);
        }
    }
}
