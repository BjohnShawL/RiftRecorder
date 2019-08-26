using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using R_R.Common.Entities;

namespace R_R.Database.Contexts
{
    public class R_RContext : IdentityDbContext<R_RUser>
    {
        public DbSet<Game> Games { get; set; }
        public DbSet<MC> Mcs { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<MythosConcept> MythosConcepts { get; set; }
        public DbSet<LogosConcept> LogosConcepts { get; set; }
        public DbSet<Crew> Crews { get; set; }
        public DbSet<HelpHurt> HelpHurts { get; set; }
        public DbSet<MythosTheme> MythosThemes { get; set; }
        public DbSet<LogosTheme> LogosThemes { get; set; }
        public DbSet<PowerTag> PowerTags { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<StoryTag> StoryTags { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<UserCharacter> UserCharacters { get; set; }
        public DbSet<UserGame> UserGames { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<CharacterMythos> CharacterMythoses { get; set; }
        public DbSet<CharacterLogos> CharacterLogoses { get; set; }


        public R_RContext(DbContextOptions<R_RContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserGame>().HasKey(ug => new {ug.GameId, ug.UserId});
            builder.Entity<UserCharacter>().HasKey(uc => new {uc.CharacterId, uc.UserId});
            builder.Entity<HelpHurt>().HasKey(hh => new {hh.CharacterId, hh.OtherCharacterId});
            builder.Entity<CharacterMythos>().HasKey(cm => new {cm.CharacterId, cm.MythosConceptId});
            builder.Entity<CharacterLogos>().HasKey(cm => new { cm.CharacterId, cm.LogosConceptId });

            builder.Entity<MythosTheme>().Property(mt => mt.Type).HasConversion<int>();
            builder.Entity<LogosTheme>().Property(lt => lt.Type).HasConversion<int>();

            

            foreach (var relationship in builder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

        }
    }
}
