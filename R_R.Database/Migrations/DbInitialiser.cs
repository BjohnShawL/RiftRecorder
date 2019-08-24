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

        static void Initialise(R_RContext context)
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
                            McID = context.Mcs.First(mc=> mc.UserId.Equals(userId)).id,
                            Description = "This is a test game. It's got Steel-Beams Kev in it. Yes, that Steel-Beams Kev."
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
                }

                if (!context.Rifts.Any())
                {
                    var rifts = new List<Rift>
                    {
                       new Rift()
                       {
                           Name = "The Trickster",
                           Mystery = "If I'm tricking everyone, does that mean I have to be tricking myself?"
                           
                       },   
                       new Rift()
                       {
                           Name = "Action John",
                           Mystery = "If I always win, why does it never end?"
                       }
                    };
                    context.AddRange(rifts);
                    context.SaveChanges();
                }

                if (!context.Identities.Any())
                {
                    var identities = new List<Identity>
                    {
                        new Identity()
                        {
                            Name = "Conspiracy Freak",
                            Description = "Believes THEY are lying to us. THEY could be anyone, but it's probably aliens who run the government and want to turn frogs gay"

                        },
                        new Identity()
                        {
                            Name = "Blank Slate",
                            Description = "There's not much going on behind those eyes. Maybe there was, once..."
                        }
                    };
                    context.Identities.AddRange(identities);
                    context.SaveChanges();
                    
                }

                if (!context.Characters.Any())
                {
                    var characters = new List<Character>
                    {
                        new Character()
                        {
                            Name = "Steel-Beams Kev",
                            Description = "A raggedy, greasy haired man that smells of stale Guinness, sour sweat and the unhealthy reek of madness. Wears an 'I want to believe' T-shirt.",
                            BuildupPoints = 0,
                            GameId = context.Games.First(g => g.GameTitle.Equals("TestGame")).Id,
                            RiftId = context.Rifts.First(r=> r.Name.Equals("The Trickster")).Id,
                            IdentityId = context.Identities.First(i => i.Name.Equals("Conspiracy Freak")).Id,
                            CrewId = context.Crews.First().Id
                        },
                        new Character()
                        {
                            Name = "John",
                            Description = "The ultimate action hero. He's pretty impressive",
                            BuildupPoints = 0,
                            GameId = context.Games.First(g => g.GameTitle.Equals("TestGame")).Id,
                            RiftId = context.Rifts.First(r=> r.Name.Equals("Action John")).Id,
                            IdentityId = context.Identities.First(i => i.Name.Equals("Blank Slate")).Id,
                            CrewId = context.Crews.First().Id
                        }
                    };
                    context.Characters.AddRange(characters);
                    context.SaveChanges();
                    foreach (var character in characters)
                    {
                        context.Identities.First(i => i.Name.Equals(character.Identity.Name)).CharacterId =
                            character.ID;
                        context.Rifts.First(r => r.Name.Equals(character.Rift.Name)).CharacterId = character.ID;
                        context.SaveChanges();
                    }
                }

                if (!context.MythosThemes.Any())
                {
                    var mythosThemes = new List<MythosTheme>
                    {
                        new MythosTheme()
                        {

                        }
                    };
                }

            }
            
        }
    }
}
