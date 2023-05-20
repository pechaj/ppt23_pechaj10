using Mapster;
using Ppt23.Shared;


namespace Ppt23.API.Data

{
    public class SeedingData
    {
        readonly PptDbContext _db;
        public SeedingData(PptDbContext dbContext)
        {
            _db = dbContext;
        }

        public async Task SeedData()
        {
            if (!_db.Vybavenis.Any())
            {
                for (int i = 0; i < 2; i++)
                {
                    VybaveniVm vyb = new VybaveniVm();
                    var en = vyb.Adapt<Vybaveni>();

                    en.pridatRevizes(_db);
                    en.pridatUkons(_db);
                    _db.Vybavenis.Add(en);


                }
            }

            await _db.SaveChangesAsync();
        }
    }
}
