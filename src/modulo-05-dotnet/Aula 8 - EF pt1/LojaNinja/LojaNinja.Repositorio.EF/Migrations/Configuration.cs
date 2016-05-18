namespace LojaNinja.Repositorio.EF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    /*
     * Esta classe é gerada automaticamente quando usamos o comando Enable-Migrations
     * Não há necessidade de nos preocuparmos com ela por enquanto.
     */
    internal sealed class Configuration : DbMigrationsConfiguration<LojaNinja.Repositorio.EF.ContextoDeDados>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(LojaNinja.Repositorio.EF.ContextoDeDados context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
