using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Globalization;
using System.Xml;
using System.Reflection.PortableExecutable;
using System.IO.Enumeration;
using System.IO;
using System.Security.AccessControl;
using System;
using dotnet_rpg.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using dotnet_rpg.Services;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace dotnet_rpg.Controllers
{
    [Authorize] // So every silngle method of controller is secured
    [ApiController]
    [Route("[controller]")] //we can find our controller by this name
    
    public class CharacterController : ControllerBase
    {
        
        //injecting characterService into the controller
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet("GetAll")]
        
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Get() //IActionResult returning type because it enables us to send specific http status quotes back to the client together with requested data
        {
            
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }
        
        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto newCharacter)
        {
            
            return Ok(await _characterService.AddCharacter(newCharacter));
        }

        [HttpPut]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> Delete(int id)
        {
            var response = await _characterService.DeleteCharacter(id);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }
    }
}