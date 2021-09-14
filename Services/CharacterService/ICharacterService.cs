using System.Security.AccessControl;
using System.Collections.Generic;
using dotnet_rpg.Models;
using System.Threading.Tasks;

namespace dotnet_rpg.Services
{
    public interface ICharacterService
    {
         Task<ServiceResponse<List<Character>>> GetAllCharacters();

         Task<ServiceResponse<Character>> GetCharacterById(int id);

         Task<ServiceResponse<List<Character>>> AddCharacter(Character newCharacter);
    }
}  