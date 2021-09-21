using System;
using System.Security.AccessControl;
using System.Collections.Generic;
using System.Linq;
using dotnet_rpg.Models;
using System.Threading.Tasks;
using dotnet_rpg.Dtos.Character;
using AutoMapper;
using dotnet_rpg.Models;
using dotnet_rpg.Services;
using Microsoft.EntityFrameworkCore;
using dotnet_rpg.Data;


namespace dotnet_rpg.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {
        private readonly IMapper _mapper;
        
        private readonly DataContext _context;

        public CharacterService(IMapper mapper, DataContext context){
            _context = context;
            _mapper = mapper;
        }

    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        Character character = _mapper.Map<Character>(newCharacter);

        _context.Characters.Add(character);
        await _context.SaveChangesAsync();
        serviceResponse.Data = await _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToListAsync();//adding srvcerespns data to character
        return serviceResponse; //returns ServiceResponse object  as response
    }

    public async Task <ServiceResponse<List<GetCharacterDto>>> DeleteCharacter(int id)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        try
        {
            Character character = await _context.Characters.FirstAsync(c => c.Id == id);
            _context.Characters.Remove(character);
            await _context.SaveChangesAsync();
            
            serviceResponse.Data = _context.Characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();

        }
        catch (Exception ex) 
        {
            serviceResponse.Success = false;
            serviceResponse.Message = ex.Message;
        }
        return serviceResponse; 
    }


    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters(int userId)
    {
        var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
        var dbCharacters = await _context.Characters.Where(c => c.User.Id == userId).ToListAsync();//to get all characters from database by user id
        serviceResponse.Data = dbCharacters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
        return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();
        var dbCharacter = await _context.Characters.FirstOrDefaultAsync(c => c.Id == id);
        serviceResponse.Data = _mapper.Map<GetCharacterDto>(dbCharacter); //serviceResponse.Data is actual result
        return serviceResponse;

    }
    
    public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
    {
        var serviceResponse = new ServiceResponse<GetCharacterDto>();
        
        try
        {
        Character character= await _context.Characters.FirstOrDefaultAsync(c => c.Id == updatedCharacter.Id);

        character.Name = updatedCharacter.Name;
        character.Hitpoints = updatedCharacter.Hitpoints;
        character.Strenght = updatedCharacter.Strenght;
        character.Defence = updatedCharacter.Defence;
        character.Inteligence = updatedCharacter.Inteligence;
        character.Class = updatedCharacter.Class;
        
        await _context.SaveChangesAsync();

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