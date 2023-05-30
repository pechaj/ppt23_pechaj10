using Ppt23.Shared;

namespace Ppt23.API.Data
{
    public class Pracovnik
    {
        public Guid Id { get; set; }
        public string? Jmeno { get; set; }

        public string[] profese = {"doktorem", "radiologickým asistentem", "sestrou", "recepční"};
        public Pracovnik()
        {
            Random random = new Random();
            Id = Guid.Empty;
            Jmeno = profese[random.Next(profese.Length)];

        }
    }
}
