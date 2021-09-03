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


namespace dotnet_rpg.Controllers
{
    
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
        
        public async Task<ActionResult<List<Character>>> Get() //IActionResult returning type because it enables us to send specific http status quotes back to the client together with requested data
        {
            return Ok(await _characterService.GetAllCharacters());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<Character>> GetSingle(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }
        
        [HttpPost]
        public async Task<ActionResult<List<Character>>> AddCharacter(Character newCharacter)
        {
            
            return Ok(await _characterService.AddCharacter(newCharacter));
        }
    }
}