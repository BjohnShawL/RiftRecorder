using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R_R.Common.Entities;
using R_R.Common.EntitiyInterfaces;

namespace R_R.Database.Services
{
    
    public class UIReadService :IUIReadService  
    {
        private readonly IDbReadService _dbRead;

        public UIReadService(IDbReadService dbRead)
        {
            _dbRead = dbRead;
        }

        #region Get Character Methods
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

            var userCharacter = await _dbRead.SingleAsync<UserCharacter>(uc => uc.UserId.Equals(userId) && uc.CharacterId.Equals(characterID));
            if (userCharacter == null)
            {
                return default;
            }
            return userCharacter.Character;
        }
        #endregion

        #region Get Game Methods
        public async Task<IEnumerable<Game>> GetGames(string userId)
        {
            _dbRead.Include<UserGame>();
            _dbRead.Include<Game>();

            var userGames = await _dbRead.GetAsync<UserGame>(ug => ug.UserId.Equals(userId));
            return userGames.Select(g => g.Game);
        }

        public async Task<Game> GetGame(string userId, int gameId)
        {
            _dbRead.Include<UserGame>();
            _dbRead.Include<Game>();

            var userGame = await _dbRead.SingleAsync<UserGame>(ug=> ug.UserId.Equals(userId) && ug.GameId.Equals(gameId));
            if (userGame == null)
            {
                return default;
            }
            return userGame.Game;
        }
        #endregion

        #region Get Note Methods

        public async Task<IEnumerable<Note>> GetNotes(string userId)
        {
            _dbRead.Include<Note>();
            _dbRead.Include<Game>();

            var notes = await _dbRead.GetAsync<Note>(n=>n.UserId.Equals(userId));
            return notes;
            
        }

        public async Task<IEnumerable<Note>> GetNotes(int gameId, string userId)
        {
            _dbRead.Include<Note>();
            _dbRead.Include<Game>();
            _dbRead.Include<MC>();

            var visibleNotes = new List<Note>();

            var notes = await _dbRead.GetAsync<Note>(n => n.GameId.Equals(gameId));

            foreach (Note note in notes)
            {
                var NoteisVisible = note.Game.MC.UserId.Equals(userId) && note.IsPrivate.Equals(false);
                if (NoteisVisible)
                {
                    visibleNotes.Add(note);
                }
            }
            
            return visibleNotes;

        }
        
        #endregion
        
        #region Get StoryTag Methods
        //Shows all the story tags associated with a game, but only shows it to the MC
        public async Task<IEnumerable<StoryTag>> GetStoryTags(int gameId, string userId)
        {
            _dbRead.Include<UserGame>();
            _dbRead.Include<Game>();
            _dbRead.Include<StoryTag>();

            var visibleStoryTags = new List<StoryTag>();

            var storyTags = await _dbRead.GetAsync<StoryTag>(st => st.GameId.Equals(gameId));

            foreach (StoryTag storyTag in storyTags)
            {
                if (GetGame(userId, storyTag.GameId).Result.MC.UserId.Equals(userId))
                {
                    visibleStoryTags.Add(storyTag);
                }
            }

            return visibleStoryTags;

        }
        //Shows all the story tags associated with a particular person in a game to the MC of that game
        public async Task<IEnumerable<StoryTag>> GetStoryTags(int gameId, string userId, int characterId)
        {
            _dbRead.Include<UserGame>();
            _dbRead.Include<Game>();
            _dbRead.Include<StoryTag>();

            var visibleStoryTags = new List<StoryTag>();

            var storyTags = await _dbRead.GetAsync<StoryTag>(st =>
                st.GameId.Equals(gameId));
            foreach (StoryTag storyTag in storyTags)
            {
                if (GetGame(userId, storyTag.GameId).Result.MC.UserId.Equals(userId) && storyTag.CharacterId.Equals(characterId))
                {
                    visibleStoryTags.Add(storyTag);
                }
            }
            return visibleStoryTags;
        }
        //Shows the user any tags associated with their active characters across all games
        public async Task<IEnumerable<StoryTag>> GetStoryTag(string userId)
        {
            _dbRead.Include<UserCharacter>();
            _dbRead.Include<UserGame>();
            _dbRead.Include<Game>();
            _dbRead.Include<StoryTag>();

            var storyTags = await _dbRead.GetAsync<StoryTag>(st =>
                st.CharacterId.Equals(GetCharacters(userId).Result.First(c=> c.GameId.Equals(st.GameId)&& c.IsActive).ID));
            return storyTags;
        }



        #endregion

        #region Get Concept Methods

        public async Task<IEnumerable<Iconcept>> GetConcepts(int characterId)
        {
            _dbRead.Include<CharacterMythos,CharacterLogos>();
            //_dbRead.Include<CharacterLogos>();
            _dbRead.Include<MythosConcept,LogosConcept>();
            //_dbRead.Include<LogosConcept>();
            _dbRead.Include<MythosTheme,LogosTheme>();
            var concepts = new List<Iconcept>();

            var mythosConcept = await _dbRead.SingleAsync<CharacterMythos>(cm => cm.CharacterId.Equals(characterId));
            concepts.Add(mythosConcept.MythosConcept);
            var logosConcept = await _dbRead.SingleAsync<CharacterLogos>(cl => cl.CharacterId.Equals(characterId));
            concepts.Add(logosConcept.LogosConcept);

            return concepts;
        }

        #endregion
    }
}
