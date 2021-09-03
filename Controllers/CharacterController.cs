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


namespace dotnet_rpg.Controllers
{
    
    [ApiController]
    [Route("[controller]")] //we can find our controller by this name
    
    public class CharacterController : ControllerBase
    {
        private static List<Character> characters = new List<Character> {
            new Character(), 
            new Character {Id = 1, Name = "Sam"}
        }; 

        
        [HttpGet("GetAll")]
        
        public ActionResult<List<Character>> Get() //IActionResult returning type because it enables us to send specific http status quotes back to the client together with requested data
        {
            return Ok(characters);
        }

        [HttpGet("{id}")]

        public ActionResult<Character> GetSingle(int id)
        {
            return Ok(characters.FirstOrDefault(c =>c.Id == id));
        }
        
        [HttpPost]
        public ActionResult<List<Character>> AddCharacter(Character newCharacter)
        {
            characters.Add(newCharacter);
            return Ok(characters);
        }
    }
}