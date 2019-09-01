using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using R_R.Common.Entities;
using R_R.Common.EntitiyInterfaces;

namespace R_R.Database.Services
{
    public interface IUIReadService
    {
        //Retrieve characters, as a list and as a unique instance
        Task<IEnumerable<Character>> GetCharacters(string userId);
        Task<Character> GetCharacter(string userId, int characterID);
        
        //Retrieve games, as a list and as a unique instance
        Task<IEnumerable<Game>> GetGames(string userId);
        Task<Game> GetGame(string userId, int gameId);

        //gets notes for each user
        Task<IEnumerable<Note>> GetNotes(string userId);
        //gets notes by game
        Task<IEnumerable<Note>> GetNotes( int gameId, string userId);

        //Retrieve story tags, as a list and as a unique instance
        Task<IEnumerable<StoryTag>> GetStoryTags(int gameId, string userId);
        Task<IEnumerable<StoryTag>> GetStoryTags(int gameId, string userId, int characterId);
        Task<IEnumerable<StoryTag>> GetStoryTag(string userId);
        
        //Retreive Mythos and Logos concepts as a list
        Task<IEnumerable<Iconcept>> GetConcepts(int characterId);

    }
}
