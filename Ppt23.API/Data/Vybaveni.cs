using Ppt23.Shared;
using System.ComponentModel.DataAnnotations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace Ppt23.API.Data
{
    public class Vybaveni
    {
        public string NAME { get; set; } = "";
        public Guid Id { get; set; }
        public DateTime DATEBUY { get; set; }
        public DateTime LASTREV { get; set; }
        public bool IsRevNeeded { get => DateTime.Now.AddYears(-2) > LASTREV; }
        public int CENA { get; set; }
    }
}
