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
                rev.VybaveniId = this.Id;

                Revizes.Add(rev);
                _db.Revizes.Add(rev);
            }
        }
    }
}
