using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using R_R.Common.Entities;
using R_R.Database.Contexts;

namespace R_R.Database.Migrations
{
    public class DbInitialiser
    {
        public static void RecreateDatabase(R_RContext context)
        {
            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }

        public static void Initialise(R_RContext context)
        {
            var email = "a@bc.com";
            var userId = string.Empty;
            var adminRole = string.Empty;

            if (context.Users.Any(r => r.Email.Equals(email)))
                userId = context.Users.First(r => r.Email.Equals(email)).Id;

            if (!userId.Equals(string.Empty))
            {
                if (!context.Mcs.Any())
                {
                    var mcs = new List<MC>
                    {
                        new MC()
                        {
                            UserId = userId
                        }
                    };
                    context.Mcs.AddRange(mcs);
                    context.SaveChanges();
                }

                if (!context.Games.Any())
                {
                    var games = new List<Game>
                    {
                        new Game()
                        {
                            GameTitle = "TestGame",
                            McID = context.Mcs.First(mc => mc.UserId.Equals(userId)).id,
                            Description =
                                "This is a test game. It's got Steel-Beams Kev in it. Yes, that Steel-Beams Kev."
                        }
                    };
                    context.Games.AddRange(games);
                    context.SaveChanges();
                }

                if (!context.Crews.Any())
                {
                    var crews = new List<Crew>
                    {
                        new Crew()
                        {
                            Name = "Test_Crew",
                            Weakness = "Not existing",
                            GameId = context.Games.First().Id
                        }
                    };
                    context.Crews.AddRange(crews);
                    context.SaveChanges();
                }

                if (!context.MythosConcepts.Any())
                {
                    var rifts = new List<MythosConcept>
                    {
                        new MythosConcept()
                        {
                            Name = "The Trickster",
                            Description = "The classic archetype of the trickster. Usually a bit of a prick",
                        },
                        new MythosConcept()
                        {
                            Name = "Action John",
                            Description = "McLane, Wick, Wayne, Rambo - He's all of them and more",
                        }
                    };
                    context.AddRange(rifts);
                    context.SaveChanges();
                }

                if (!context.LogosConcepts.Any())
                {
                    var identities = new List<LogosConcept>
                    {
                        new LogosConcept()
                        {
                            Name = "Conspiracy Freak",
                            Description =
                                "Believes THEY are lying to us. THEY could be anyone, but it's probably aliens who run the government and want to turn frogs gay",
                        },
                        new LogosConcept()
                        {
                            Name = "Blank Slate",
                            Description = "There's not much going on behind those eyes. Maybe there was, once...",
                        }
                    };
                    context.LogosConcepts.AddRange(identities);
                    context.SaveChanges();
                }

                if (!context.Characters.Any())
                {
                    var characters = new List<Character>
                    {
                        new Character()
                        {
                            Name = "Steel-Beams Kev",
                            Description =
                                "A raggedy, greasy haired man that smells of stale Guinness, sour sweat and the unhealthy reek of madness. Wears an 'I want to believe' T-shirt.",
                            BuildupPoints = 0,
                            GameId = context.Games.First(g => g.GameTitle.Equals("TestGame")).Id,
                            CrewId = context.Crews.First().Id
                        },
                        new Character()
                        {
                            Name = "John",
                            Description = "The ultimate action hero. He's pretty impressive",
                            BuildupPoints = 0,
                            GameId = context.Games.First(g => g.GameTitle.Equals("TestGame")).Id,

                            CrewId = context.Crews.First().Id
                        }
                    };
                    context.Characters.AddRange(characters);
                    context.SaveChanges();
                }

                if (!context.CharacterMythoses.Any())
                {
                    var characterMythoi = new List<CharacterMythos>
                    {
                        new CharacterMythos()
                        {
                            CharacterId = context.Characters.First(cm => cm.Name.Equals("Steel-Beams Kev")).ID,
                            MythosConceptId = context.MythosConcepts.First(r => r.Name.Equals("The Trickster")).Id
                        },
                        new CharacterMythos()
                        {
                            CharacterId = context.Characters.First(cm => cm.Name.Equals("John")).ID,
                            MythosConceptId = context.MythosConcepts.First(r => r.Name.Equals("Action John")).Id
                        }
                    };
                    context.CharacterMythoses.AddRange(characterMythoi);
                    context.SaveChanges();
                }

                if (!context.CharacterLogoses.Any())
                {
                    var characterLogoi = new List<CharacterLogos>
                    {
                        new CharacterLogos()
                        {
                            CharacterId = context.Characters.First(cl => cl.Name.Equals("Steel-Beams Kev")).ID,
                            LogosConceptId = context.LogosConcepts.First(i => i.Name.Equals("Conspiracy Freak")).Id
                        },
                        new CharacterLogos()
                        {
                            CharacterId = context.Characters.First(cl => cl.Name.Equals("John")).ID,
                            LogosConceptId = context.LogosConcepts.First(i => i.Name.Equals("Blank Slate")).Id
                        }
                    };
                    context.CharacterLogoses.AddRange(characterLogoi);
                    context.SaveChanges();
                }

                if (!context.MythosThemes.Any())
                {
                    var mythosThemes = new List<MythosTheme>
                    {
                        new MythosTheme()
                        {
                            Name = "Hello boys, I'm Baaaaack!",
                            Description = "Tricksters have a way of showing up where you least expect them",
                            Type = MythosType.Mobility,
                            IsBurned = false,
                            Attention = 0,
                            Fade = 0,
                            MythosConceptId = context.MythosConcepts.First(r => r.Name.Equals("The Trickster")).Id,
                            Mystery = "Why am I always in temptations way?"
                        },
                        new MythosTheme()
                        {
                            Name = "Fooled ya!",
                            Description =
                                "A power that allows the trickster to take actions as if he had planned this all along.",
                            Type = MythosType.Adaptation,
                            IsBurned = false,
                            Attention = 0,
                            Fade = 0,
                            MythosConceptId = context.MythosConcepts.First(r => r.Name.Equals("The Trickster")).Id,
                            Mystery = "Who am I really fooling?"
                        },
                        new MythosTheme()
                        {
                            Name = "Stone-cold Badass",
                            Description = "Everything's a weapon, every move deadly. His fists do the talking",
                            Type = MythosType.Expression,
                            IsBurned = false,
                            Attention = 0,
                            Fade = 0,
                            MythosConceptId = context.MythosConcepts.First(r => r.Name.Equals("Action John")).Id,
                            Mystery = "Is there anything I can't punch into submission?"
                        },
                        new MythosTheme()
                        {
                            Name = "Men want to be him...",
                            Description = "No one knows what he looks like, because he just looks...perfect.",
                            Type = MythosType.Subversion,
                            IsBurned = false,
                            Attention = 0,
                            Fade = 0,
                            MythosConceptId = context.MythosConcepts.First(r => r.Name.Equals("Action John")).Id,
                            Mystery = "What does the ultimate hero look like?"
                        },
                        new MythosTheme()
                        {
                            Name = "My murder senses are tingling",
                            Description =
                                "Superhuman hyper-awareness in combat situations due to some kind of scientifically dubious McGuffin",
                            Type = MythosType.Divination,
                            IsBurned = false,
                            Attention = 0,
                            Fade = 0,
                            MythosConceptId = context.MythosConcepts.First(r => r.Name.Equals("Action John")).Id,
                            Mystery = "How much more about the world can I learn in combat?"
                        }
                    };
                    context.MythosThemes.AddRange(mythosThemes);
                    context.SaveChanges();
                }

                if (!context.LogosThemes.Any())
                {
                    var logosThemes = new List<LogosTheme>
                    {
                        new LogosTheme()
                        {
                            Name = "The Truth Shall Set Them Free",
                            Description = "Wake up sheeple, they're lying to you!",
                            Type = LogosType.Mission,
                            IsBurned = false,
                            Crack = 0,
                            Attention = 0,
                            LogosConceptId = context.LogosConcepts.First(l => l.Name.Equals("Conspiracy Freak")).Id,
                            Identity = "Believe nothing that The Man tells you without verifying it first."
                        },
                        new LogosTheme()
                        {
                            Name = "Where everybody knows your name...",
                            Description = "The beer's good, and the people are real",
                            Type = LogosType.DefiningRelationship,
                            IsBurned = false,
                            Crack = 0,
                            Attention = 0,
                            LogosConceptId = context.LogosConcepts.First(l => l.Name.Equals("Conspiracy Freak")).Id,
                            Identity = "I'm not about to let my buddies get hurt"
                        },
                        new LogosTheme()
                        {
                            Name = "Tabula Rasa",
                            Description = "Pretty easy going, cos there's nothing going on",
                            Type = LogosType.Personality,
                            IsBurned = false,
                            Crack = 0,
                            Attention = 0,
                            LogosConceptId = context.LogosConcepts.First(l => l.Name.Equals("Blank Slate")).Id,
                            Identity = "I can't have been all that interesting, if I can't remember myself..."
                        }
                    };
                    context.LogosThemes.AddRange(logosThemes);
                    context.SaveChanges();
                }

                if (!context.GameSessions.Any())
                {
                    var sessions = new List<GameSession>
                    {
                        new GameSession()
                        {
                            GameId = context.Games.First().Id,
                            SessionDate = DateTime.Now
                        }
                    };
                    context.GameSessions.AddRange(sessions);
                    context.SaveChanges();
                }

                if (!context.PowerTags.Any())
                {
                    var powerTags = new List<PowerTag>
                    {
                        new PowerTag()
                        {
                            Name = "TestPowerTag1",
                            Description = "A generic description...1",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"a",
                            MythosThemeId = context.MythosThemes
                                .First(mt => mt.Name.Equals("Hello boys, I'm Baaaaack!")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTag2",
                            Description = "A generic description...2",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"e",
                            MythosThemeId = context.MythosThemes
                                .First(mt => mt.Name.Equals("Hello boys, I'm Baaaaack!")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTag3",
                            Description = "A generic description...3",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"g",
                            MythosThemeId = context.MythosThemes
                                .First(mt => mt.Name.Equals("Hello boys, I'm Baaaaack!")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTag4",
                            Description = "A generic description...4",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"a",
                            MythosThemeId = context.MythosThemes.First(mt => mt.Name.Equals("Fooled ya!")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTag5",
                            Description = "A generic description...5",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"c",
                            MythosThemeId = context.MythosThemes.First(mt => mt.Name.Equals("Fooled ya!")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTag6",
                            Description = "A generic description...6",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"e",
                            MythosThemeId = context.MythosThemes.First(mt => mt.Name.Equals("Fooled ya!")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTag7",
                            Description = "A generic description...7",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"a",
                            MythosThemeId = context.MythosThemes.First(mt => mt.Name.Equals("Stone-cold Badass")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTag8",
                            Description = "A generic description...8",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"b",
                            MythosThemeId = context.MythosThemes.First(mt => mt.Name.Equals("Stone-cold Badass")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTag9",
                            Description = "A generic description...9",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"h",
                            MythosThemeId = context.MythosThemes.First(mt => mt.Name.Equals("Stone-cold Badass")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTag10",
                            Description = "A generic description...10",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"a",
                            MythosThemeId = context.MythosThemes.First(mt => mt.Name.Equals("Men want to be him...")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTag11",
                            Description = "A generic description...11",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"c",
                            MythosThemeId = context.MythosThemes.First(mt => mt.Name.Equals("Men want to be him...")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTag12",
                            Description = "A generic description...12",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"j",
                            MythosThemeId = context.MythosThemes.First(mt => mt.Name.Equals("Men want to be him...")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTag10",
                            Description = "A generic description...10",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"a",
                            MythosThemeId = context.MythosThemes
                                .First(mt => mt.Name.Equals("My murder senses are tingling")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTag11",
                            Description = "A generic description...11",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"c",
                            MythosThemeId = context.MythosThemes
                                .First(mt => mt.Name.Equals("My murder senses are tingling")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTag12",
                            Description = "A generic description...12",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"j",
                            MythosThemeId = context.MythosThemes
                                .First(mt => mt.Name.Equals("My murder senses are tingling")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTagL1",
                            Description = "A generic description...L1",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"a",
                            LogosThemeId = context.LogosThemes
                                .First(mt => mt.Name.Equals("The Truth Shall Set Them Free")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTagL2",
                            Description = "A generic description...L2",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"c",
                            LogosThemeId = context.LogosThemes
                                .First(mt => mt.Name.Equals("The Truth Shall Set Them Free")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTagL3",
                            Description = "A generic description...L3",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"g",
                            LogosThemeId = context.LogosThemes
                                .First(mt => mt.Name.Equals("The Truth Shall Set Them Free")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTagL4",
                            Description = "A generic description...L4",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"a",
                            LogosThemeId = context.LogosThemes
                                .First(mt => mt.Name.Equals("Where everybody knows your name...")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTagL5",
                            Description = "A generic description...L5",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"c",
                            LogosThemeId = context.LogosThemes
                                .First(mt => mt.Name.Equals("Where everybody knows your name...")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTagL6",
                            Description = "A generic description...L6",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"g",
                            LogosThemeId = context.LogosThemes
                                .First(mt => mt.Name.Equals("Where everybody knows your name...")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTagL7",
                            Description = "A generic description...L7",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"a",
                            LogosThemeId = context.LogosThemes.First(mt => mt.Name.Equals("Tabula Rasa")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTagL8",
                            Description = "A generic description...L8",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"c",
                            LogosThemeId = context.LogosThemes.First(mt => mt.Name.Equals("Tabula Rasa")).Id
                        },
                        new PowerTag()
                        {
                            Name = "TestPowerTagL9",
                            Description = "A generic description...L9",
                            IsBurned = false,
                            IsBroad = false,
                            QuestionAnswered = $"g",
                            LogosThemeId = context.LogosThemes.First(mt => mt.Name.Equals("Tabula Rasa")).Id
                        }
                    };
                    context.PowerTags.AddRange(powerTags);
                    context.SaveChanges();
                }

                if (!context.HelpHurts.Any())
                {
                    var helphurts = new List<HelpHurt>
                    {
                        new HelpHurt()
                        {
                            CharacterId = context.Characters.First(c1 => c1.Name.Equals("Steel-Beams Kev")).ID,
                            OtherCharacterId = context.Characters.First(c1 => c1.Name.Equals("John")).ID,
                            Help = 2,
                            Hurt = 0
                        },
                        new HelpHurt()
                        {
                            CharacterId = context.Characters.First(c1 => c1.Name.Equals("John")).ID,
                            OtherCharacterId = context.Characters.First(c1 => c1.Name.Equals("Steel-Beams Kev")).ID,
                            Help = 0,
                            Hurt = 0
                        }
                    };
                    context.HelpHurts.AddRange(helphurts);
                    context.SaveChanges();
                }

                if (!context.Statuses.Any())
                {
                    var statuses = new List<Status>
                    {
                        new Status()
                        {
                            CharacterId = context.Characters.First(c1 => c1.Name.Equals("Steel-Beams Kev")).ID,
                            Description = "Falling down drunk",
                            Effect = 3,
                            IsPositive = false
                        }
                    };
                    context.Statuses.AddRange(statuses);
                    context.SaveChanges();
                }

                if (!context.StoryTags.Any())
                {
                    var storyTags = new List<StoryTag>
                    {
                        new StoryTag()
                        {
                            CreatedOn = DateTime.Now,
                            GameId = context.Games.First().Id,
                            JuiceCost = 4,
                            Name = "Fake Id"
                        }
                    };
                    context.StoryTags.AddRange(storyTags);
                    context.SaveChanges();
                }

                if (!context.Notes.Any())
                {
                    var notes = new List<Note>
                    {
                        new Note()
                        {
                            Title = "Test Note 1",
                            Content = "Yadah yadah lorem ipsum",
                            CreatedOn = DateTime.Now,
                            GameId = context.Games.First().Id,
                            IsPrivate = false,
                            UserId = userId
                        }
                    };
                    context.Notes.AddRange(notes);
                    context.SaveChanges();
                }

                if (!context.UserCharacters.Any())
                {
                    var userCharacters = new List<UserCharacter>
                    {
                        new UserCharacter()
                        {
                            CharacterId = context.Characters.First(c => c.Name.Equals("Steel-Beams Kev")).ID,
                            UserId = userId
                        },
                        new UserCharacter()
                        {
                            CharacterId = context.Characters.First(c => c.Name.Equals("John")).ID,
                            UserId = userId
                        }
                    };
                    context.UserCharacters.AddRange(userCharacters);
                    context.SaveChanges();
                }

                if (!context.UserGames.Any())
                {
                    var userGames = new List<UserGame>
                    {
                        new UserGame()
                        {
                            GameId = context.Games.First().Id,
                            UserId = userId
                        }
                    };
                    context.UserGames.AddRange(userGames);
                    context.SaveChanges();
                }
            }
        }
    }
}