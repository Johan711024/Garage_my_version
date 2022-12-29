using Garage_my_version.Models;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace Garage_my_version.Data
{
    public class DbInitializer
    {
        public static void Seeder(string jsonData, IApplicationBuilder applicationBuilder)
        {
            GarageContext garageContext = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<GarageContext>();

            garageContext.Database.EnsureCreated();

            //add time
            List<Vehicle>? vehicles = JsonConvert.DeserializeObject<List<Vehicle>>(jsonData, new IsoDateTimeConverter { DateTimeFormat = "yyyy-MM-dd" });

            if (!garageContext.Vehicle.Any())
            {
                //how to check if this works? safety...
                garageContext.AddRange(vehicles);
            }

            garageContext.SaveChanges();
        }
    }
}
