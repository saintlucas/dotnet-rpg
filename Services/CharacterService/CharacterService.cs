using System;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Linq;
using dotnet_rpg.Models;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using AutoMapper;
using dotnet_rpg.Models;



namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        private static List<Character> characters = new List<Character> {
            new Character(), 
            new Character {Id = 1, Name = "Sam"}
        };
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper){
            _mapper = mapper;
        }

    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        Character character = _mapper.Map<Character>(newCharacter);
        character.Id = characters.Max(c => c.Id) + 1;
        characters.Add(character);
        serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();//adding srvcerespns data to character
        return serviceResponse; //returns ServiceResponse object  as response
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();
        serviceResponse.Data = _mapper.Map<GetCharacterDto>(characters.FirstOrDefault(c =>c.Id == id)); //serviceResponse.Data is actual result
        return serviceResponse;

    }
    
    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();
        
        try
        {
        Character character= characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);

        character.Name = updatedCharacter.Name;
        character.Hitpoints = updatedCharacter.Hitpoints;
        character.Strenght = updatedCharacter.Strenght;
        character.Defence = updatedCharacter.Defence;
        character.Inteligence = updatedCharacter.Inteligence;
        character.Class = character.Class;
        
        serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);

        }
        catch (Exception ex) 
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse;
    }
    }
}