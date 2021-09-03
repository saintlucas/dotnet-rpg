using System.Collections.Generic;
namespace dotnet_rpg.Services
{
    public interface ICharacterService
    {
         List<Character> GetAllCharacters();

         Character GetCharacterById(int id);

         List<Character> AddCharacter(Character newCharacter);
    }
}