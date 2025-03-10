using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    internal class Ad
    {
        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeFromCharge { get; set; }
        public int Id { get; set; }
        public string imageUrl { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }

         public static List<Ad> LoadFromCsv()
        {
            List<Ad> ads = new();

            using StreamReader sr = new(
                path: @"../../../src/realestates.csv",
                encoding: Encoding.UTF8);
            _ = sr.ReadLine();
            while (!sr.EndOfStream) ads.Add(new(sr.ReadLine()));

            return ads;
        }
        public Ad(string sor)
        {
            var temp = sor.Split(';');
            Id = int.Parse(temp[0]) ;
            imageUrl = temp[7];
            Description = temp[5];
            Area = int.Parse(temp[4]);
            Rooms = int.Parse(temp[1]);
            Floors = int.Parse(temp[3]) ;
            LatLong = temp[2];
            FreeFromCharge = temp[6] == "1" ? true : false;
            CreatedAt = DateTime.Parse(temp[8]);
            Category = new Category(int.Parse(temp[12]), temp[13]);
            Seller = new Seller(int.Parse(temp[9]), temp[10], temp[11]);
        }
    }
}
