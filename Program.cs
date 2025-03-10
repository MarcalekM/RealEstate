using RealEstate;

List<Ad> ingatlanok = Ad.LoadFromCsv();

var f6 = ingatlanok.Where(x => x.Floors.Equals(1)).Average(x => x.Area);
Console.WriteLine($"A földszinti lakások átlagos alapterülete: {f6:0.00} négyzetméter");