using Mapster;
using Ppt23.Shared;
using System;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Ppt23.API.Data
{
    public class Vybaveni
    {
        public string Name { get; set; } = "";
        public Guid Id { get; set; }
        public DateTime DATEBUY { get; set; }
        public int Cena { get; set; }
        public List<Revize> Revizes { get; set; } = new();
        public List<Ukon> Ukons { get; set; } = new();

        public void pridatRevizes(PptDbContext _db)
        {

            Random r = new Random();

            for (int j = 0; j < r.Next(0, 3); j++)
            {
                Revize rev = new Revize
                {
                    Name = $"Revize {Name} #{j + 1}",
                    Id = Guid.Empty,
                    Vybaveni = this,
                    VybaveniId = Id

                };

                rev.SetRandomDate(this.Adapt<VybaveniVm>(), this.DATEBUY, DateTime.Now);

                Revizes.Add(rev);
                _db.Revizes.Add(rev);
            }
        }

        public void pridatUkons(PptDbContext _db)
        {
            string[] ukony = { "CT sken", "Ultrazvukové vyšetření", "MRI sken", "Rentgen" };

            Random random = new Random();

            for (int i = 0; i < random.Next(1, 4); i++) {
                if (random.Next(2) == 1)
                {
                    Pracovnik pracovnik = new Pracovnik();

                    Ukon ukon = new Ukon
                    {
                        NazevAkce = ukony[random.Next(ukony.Length)],
                        Id = Guid.Empty,
                        Vybaveni = this,
                        VybaveniId = Id,
                        pracovnik = pracovnik,
                        PracovnikId = pracovnik.Id
                    };

                    ukon.SetRandomDate(this.Adapt<VybaveniVm>(), DATEBUY, DateTime.Now);

                    Ukons.Add(ukon);
                    _db.Ukons.Add(ukon);
                }
                else
                {
                    Ukon ukon = new Ukon
                    {
                        NazevAkce = ukony[random.Next(ukony.Length)],
                        Id = Guid.Empty,
                        Vybaveni = this,
                        VybaveniId = Id
                    };

                    ukon.SetRandomDate(this.Adapt<VybaveniVm>(), DATEBUY, DateTime.Now);

                    Ukons.Add(ukon);
                    _db.Ukons.Add(ukon);
                }
            }

            
            
        }
    }
}
