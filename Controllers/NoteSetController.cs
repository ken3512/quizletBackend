using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using quizletBackend.Dtos.NoteSet;
using quizletBackend.Services.NoteSetService;

namespace quizletBackend.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class NoteSetController : ControllerBase
    {
        private readonly INoteSetService _noteSetService;
        public NoteSetController(INoteSetService noteSetService)
        {
            _noteSetService = noteSetService;
        }

        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<GetNoteSetNameDto>>>> Search(string? search = "")
        {
            var response = await _noteSetService.Search(search);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<GetNoteSetDto>>> GetNoteSet(int id)
        {
            var response = await _noteSetService.GetNoteSet(id);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<ActionResult<ServiceResponse<GetNoteSetNameDto>>> CreateNoteSet(CreateNoteSetDto newNoteSet)
        {
            var response = await _noteSetService.CreateNoteSet(newNoteSet);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<int>>> DeleteNoteSet(int id)
        {
            var response = await _noteSetService.DeleteNoteSet(id);
            if(response.Success == false)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

    }
}