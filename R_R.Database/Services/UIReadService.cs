using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R_R.Common.Entities;

namespace R_R.Database.Services
{
    public class UIReadService :IUIReadService  
    {
        private readonly IDbReadService _dbRead;

        public UIReadService(IDbReadService dbRead)
        {
            _dbRead = dbRead;
        }
        public async Task<IEnumerable<Character>> GetCharacters(string userId)
        {
            _dbRead.Include<UserCharacter>();
            _dbRead.Include<Character>();
            
            var userCharacters = await _dbRead.GetAsync<UserCharacter>(uc => uc.UserId.Equals(userId));
            return userCharacters.Select(c => c.Character);
        }

        public async Task<Character> GetCharacter(string userId, int characterID)
        {
            _dbRead.Include<UserCharacter>();
            _dbRead.Include<Character>();

            var userCharacter = await _dbRead.SingleAsync<UserCharacter>(uc => uc.UserId.Equals(userId)&& uc.CharacterId.Equals(characterID));
            if (userCharacter==null)
            {
                return default;
            }
            return userCharacter.Character;
        }

        public async Task<IEnumerable<Game>> GetGames(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<Game> GetGame(string userId, int gameId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Note>> GetNotes(string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Note>> GetNotes(int gameId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StoryTag>> GetStoryTags(int gameId, string userId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<StoryTag>> GetStoryTags(int gameId, string userId, int characterId)
        {
            throw new NotImplementedException();
        }

        public async Task<StoryTag> GetStoryTag(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
