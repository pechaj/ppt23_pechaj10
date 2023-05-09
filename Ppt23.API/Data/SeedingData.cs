using Mapster;
using Ppt23.Shared;


namespace Ppt23.API.Data

{
    public class SeedingData
    {
        readonly PptDbContext db;
        public SeedingData(PptDbContext dbContext)
        {
            db = dbContext;
        }

        public async Task SeedData()
        {
            if (!db.Vybavenis.Any())//není žádné vybavení - nějaké přidáme
            {
                for (int i = 0; i < 2; i++)
                {
                    var en = new VybaveniVm();
                    en.Id = Guid.Empty;
                    db.Vybavenis.Add(en.Adapt<Vybaveni>());
                }
            }

            await db.SaveChangesAsync();
        }
    }
}
