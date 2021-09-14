using System;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Linq;
using dotnet_rpg.Models;
using System.Threading.Tasks;




namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        private static List<Character> characters = new List<Character> {
            new Character(), 
            new Character {Id = 1, Name = "Sam"}
        };

    public async Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter)
    {
        var serviceResponse = new ServiceResponse<List<Character>>();
        characters.Add(newCharacter);
        serviceResponse.Data = characters;//adding srvcerespns data to character
        return serviceResponse; //returns ServiceResponse as response
    }

    public async Task<ServiceResponse<List<Character>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<Character>>();
        serviceResponse.Data = characters;
        return serviceResponse;
    }

    public async Task<ServiceResponse<Character>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<Character>();
        serviceResponse.Data = characters.FirstOrDefault(c =>c.Id == id); //serviceResponse.Data is actual result
        return serviceResponse;

    }

    }
}