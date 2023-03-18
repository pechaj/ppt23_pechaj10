using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Ppt23.Client.ViewModels;

public class VybaveniVm
{
    [Required(ErrorMessage = "Pole nesmí být prázdné")]
    [MinLength(5, ErrorMessage = "Délka u pole \"{0}\" musí být alespoň {1} znaků")]
    [Display(Name = "Název")]
    public string NAME { get; set; }
    public DateTime DATEBUY { get; set; }

    [CustomValidation(typeof(VybaveniVm),nameof(validation))]
    public DateTime LASTREV { get; set; }
    public bool IsRevNeeded { get => DateTime.Now.AddYears(-2) > LASTREV; }
    public bool IsInEditMode { get; set; }

    [Required(ErrorMessage = "Pole Cena nesmí být prázdné")]
    [Range(0, 10000000, ErrorMessage = "Cena musí být mezi 0 až 10,000,000")]
    public int CENA { get; set; }

    
    public VybaveniVm()
    {
        DateTime od = new DateTime(2010, 01, 01);
        this.NAME = randName(10);
        this.DATEBUY = GetRandomDate(od, DateTime.Now);
        this.LASTREV = GetRandomDate(DATEBUY, DateTime.Now);
        this.IsInEditMode = false;
        this.CENA = Random.Shared.Next(10000000);
    }
    public VybaveniVm Copy()
    {
        VybaveniVm to = new();
        to.DATEBUY = DATEBUY;
        to.LASTREV = LASTREV;
        to.IsInEditMode = IsInEditMode;
        to.NAME = NAME;
        to.CENA = CENA;
        return to;
    }
    public void MapTo(VybaveniVm? to)
    {
        if (to == null) return;
        to.DATEBUY = DATEBUY;
        to.LASTREV = LASTREV;
        to.NAME = NAME;
        to.CENA = CENA;
    }
    public string randName(int length) => new(Enumerable.Range(0, length).Select(_ => (char)Random.Shared.Next('a', 'z')).ToArray());

    public static DateTime GetRandomDate(DateTime from, DateTime to)
    {
        Random rand = new Random();
        var range = to - from;

        var randTimeSpan = new TimeSpan((long)(rand.NextDouble() * range.Ticks));

        return from + randTimeSpan;
    }

    public static ValidationResult? validation(DateTime lastRev, ValidationContext validationContext)
    {
        var vm = (VybaveniVm)validationContext.ObjectInstance;

        if (lastRev < vm.DATEBUY)
        {
            return new ValidationResult("Poslední revize nesmí být dříve než koupě");
        }

        return ValidationResult.Success;
    }
}
