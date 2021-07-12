using System.Data.Entity.Migrations;

namespace BackLayers.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<DAL.DatabaseContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DAL.DatabaseContext context)
        { }
    }
}
