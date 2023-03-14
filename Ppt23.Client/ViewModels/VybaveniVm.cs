namespace Ppt23.Client.ViewModels;

public class VybaveniVm
{
    public string NAME { get; set; }
    public DateTime DATEBUY { get; set; }
    public DateTime LASTREV { get; set; }
    public bool IsRevNeeded { get => LASTREV + new TimeSpan(1095, 0, 0, 0) < DateTime.Now; }

    public VybaveniVm()
    {
        DateTime od = new DateTime(2010, 01, 01);
        this.NAME = randName();
        this.DATEBUY = GetRandomDate(od, DateTime.Now);
        this.LASTREV = GetRandomDate(DATEBUY, DateTime.Now);
    }
    public string randName()
    {
        Random rand = new Random();

        String str = "abcdefghijklmnopqrstuvwxyz";
        int size = 10;

        String ran = "";

        for (int i = 0; i < size; i++)
        {
            int x = rand.Next(26);
            ran = ran + str[x];
        }
        return ran;
    }

    public static DateTime GetRandomDate(DateTime from, DateTime to)
    {
        Random rand = new Random();
        var range = to - from;

        var randTimeSpan = new TimeSpan((long)(rand.NextDouble() * range.Ticks));

        return from + randTimeSpan;
    }
    
}
