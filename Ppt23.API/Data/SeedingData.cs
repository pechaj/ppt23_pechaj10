using Mapster;
using Ppt23.Shared;
using System;
using System.Xml.Linq;


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
                string[] profese = { "doktorem", "radiologickým asistentem", "sestrou", "recepční" };
                string[] ukony = { "CT sken", "Ultrazvukové vyšetření", "MRI sken", "Rentgen" };

                for (int x = 0; x < Random.Shared.Next(1, 10); x++)
                {
                    _db.Pracovniks.Add(new Pracovnik { Id = Guid.Empty, Jmeno = profese[Random.Shared.Next(profese.Length)] });
                }
                await _db.SaveChangesAsync();

                for (int i = 0; i < 3; i++)
                {
                    VybaveniVm vyb = new VybaveniVm();
                    var en = vyb.Adapt<Vybaveni>();

                    for (int j = 0; j < Random.Shared.Next(1, 4); j++)
                    {
                        Revize rev = new Revize
                        {
                            Name = $"Revize {en.Name} #{j + 1}",
                            Id = Guid.Empty,
                            Vybaveni = en,
                            VybaveniId = en.Id

                        };

                        for (int l = 0; l < Random.Shared.Next(0, 3); l++)
                        {

                            Ukon ukon = new Ukon
                            {
                                NazevAkce = ukony[Random.Shared.Next(ukony.Length)],
                                Id = Guid.Empty,
                                Vybaveni = en,
                                VybaveniId = en.Id
                            };

                            if (Random.Shared.Next(0, 3) == 0)
                            {
                                int toSkip = Random.Shared.Next(0, _db.Pracovniks.Count());
                                var pracovnik = _db.Pracovniks.Skip(toSkip).Take(1).First();

                                ukon.pracovnik = pracovnik;
                                ukon.PracovnikId = pracovnik.Id;

                            }

                            ukon.SetRandomDate(this.Adapt<VybaveniVm>(), en.DATEBUY, DateTime.Now);

                            en.Ukons.Add(ukon);
                            _db.Ukons.Add(ukon);
                        }



                        rev.SetRandomDate(this.Adapt<VybaveniVm>(), en.DATEBUY, DateTime.Now);

                        en.Revizes.Add(rev);
                        _db.Revizes.Add(rev);


                    }
                    _db.Vybavenis.Add(en);
                }
                //en.pridatRevizes(_db);
                //en.pridatUkons(_db);


                


            }
            await _db.SaveChangesAsync();
        }

        
    }
}
