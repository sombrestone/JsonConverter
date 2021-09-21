using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CustomJsonConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            UniversalJsonConverter converter = new UniversalJsonConverter();

            string result = converter.Serialize(new Product
            {
                Id = 1,
                Name = "Плинтус",
                Price = 12.3M,
                UnitId = 1,
                Units = 
                new Unit[]
                {
                    new Unit
                    {
                        Id = 1,
                        Name = "сантиметр",
                        ShortName = "см."
                    },
                    new Unit
                    {
                        Id = 2,
                        Name = "килограмм",
                        ShortName = "кг."
                    },
                    new Unit
                    {
                        Id = 3,
                        Name = "штука",
                        ShortName = "шт."
                    },
                },
                Numbers= new int[]
                {
                    1,2,3,4
                }
            });

            Console.WriteLine(result);
        }
    }
}
