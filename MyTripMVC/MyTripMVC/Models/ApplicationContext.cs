using System.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyTripMVC.Models
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser, IdentityRole, string>
    {
        // Denna konstruktor krävs för att konfigurationen ska fungera
        public ApplicationContext(DbContextOptions<ApplicationContext> options) :
        base(options)
        {
        }
        // Exponerar våra databas-modeller via properties av typen DbSet<T>
        public DbSet<City> Cities { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<Activity> Activities { get; set; }
		public DbSet<UserActivity> UserActivities { get; set; }
		public DbSet<UserRestaurant> UserRestaurants { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Specificerar data som en specific tabellska för-populeras med
            modelBuilder.Entity<City>().HasData(
            new City { Id = 1, Name = "Stockholm" },
            new City { Id = 2, Name = "Göteborg" },
            new City { Id = 3, Name = "Uppsala" },
            new City { Id = 4, Name = "Malmö" },
            new City { Id = 5, Name = "Kiruna" });

            modelBuilder.Entity<Restaurant>().HasData(
            new Restaurant { Id = 1000, CityId = 1, Name = "Mahalo", AltTag="Laid tables at Mahalo", Description = "A serene dining spot offering a diverse culinary experience, Mahalo entices with its elegant ambiance and delectable menu, inviting patrons to savor a mix of flavors.", ImageUrl = "/Image/Mahalo.jpeg" },
            new Restaurant { Id = 2000, CityId = 1, Name = "Linglong", AltTag = "Laid tables at Linglong", Description = "An enchanting eatery, Linglong promises a gastronomic journey through its array of dishes, serving up a fusion of traditional and contemporary tastes that captivate the senses.", ImageUrl = "/Image/linglong.jpg" },
            new Restaurant { Id = 3000, CityId = 1, Name = "Tranan", AltTag = "Laid tables at Tranan", Description = "Nestled in the heart of the city, Tranan beckons diners with its cozy atmosphere and an array of dishes that reflect the essence of the local culinary scene.", ImageUrl = "/Image/Tranan.jpg" },

            new Restaurant { Id = 4000, CityId = 2, Name = "Daawat", AltTag = "Tabel with different cusines", Description = "A culinary haven, Daawat tempts with its aromatic creations inspired by authentic flavors, offering a taste of the rich culinary heritage of the region.", ImageUrl = "/Image/daawat.jpg" },
            new Restaurant { Id = 5000, CityId = 2, Name = "Panos Panos Tavern", AltTag = "Laid tables at Panos Panos Tavern", Description = " With a warm and welcoming ambiance, Panos Panos Tavern celebrates the art of Mediterranean cuisine, inviting guests to indulge in dishes that evoke the sun-soaked shores.", ImageUrl = "/Image/panos.jpg" },
            new Restaurant { Id = 6000, CityId = 2, Name = "Bord 27", AltTag = "Laid tables at Bord 27", Description = "A culinary destination, Bord 27 invites patrons to relish an array of delightful dishes curated with passion, representing a symphony of tastes and textures.", ImageUrl = "/Image/bord27.jpg" },

            new Restaurant { Id = 7000, CityId = 3, Name = "Aaltos Italian Grill", AltTag = "Laid tables at Aaltos Italian Grill", Description = " A charming spot, Aaltos Italian Grill & Garden delights with its blend of traditional and innovative Italian fare, providing an inviting setting for a memorable dining experience.", ImageUrl = "/Image/Aaltos.jpg" },
            new Restaurant { Id = 8000, CityId = 3, Name = "Hambergs Fisk", AltTag = "Laid tables at Hambergs Fisk", Description = "Nestled by the waterfront, Hambergs Fisk celebrates the bounties of the sea, offering a seafood-centric menu that showcases the freshness and flavors of the ocean.", ImageUrl = "/Image/Hamberg.jpg" },
            new Restaurant { Id = 9000, CityId = 3, Name = "Miss Voon", AltTag = "Laid tables at Miss Voon", Description = "A modern and sophisticated eatery, Miss Voon presents a fusion of Asian flavors with a contemporary twist, promising a culinary journey that excites the palate.", ImageUrl = "/Image/Miss.jpg" },

            new Restaurant { Id = 1100, CityId = 4, Name = "Vollmers", AltTag = "Laid tables at Vollmers", Description = "A culinary masterpiece, Vollmers offers an exceptional dining experience, crafting dishes that epitomize artistry and innovation, inviting guests to embark on a culinary exploration.", ImageUrl = "/Image/Vollmers.jpg" },
            new Restaurant { Id = 1200, CityId = 4, Name = "Aster", AltTag = "Laid tables at Aster", Description = "With an atmosphere of elegance, Aster redefines modern dining with its creative menu that marries traditional elements with avant-garde culinary techniques.", ImageUrl = "/Image/aster.jpeg" },
            new Restaurant { Id = 1300, CityId = 4, Name = "Lyran Matbar", AltTag = "Overlooking the bar at Lyran Matbar", Description = "A hidden gem, Lyran Matbar captures the essence of its surroundings, serving dishes that reflect the region's bounty and cultural heritage in every bite.", ImageUrl = "/Image/Lyran.jpg" },

            new Restaurant { Id = 1400, CityId = 5, Name = "Annis Grill", AltTag = "Cheeseburger without bacon", Description = "Known for its flavorsome offerings, Annis Grill beckons with its rich and succulent dishes, providing a culinary journey that celebrates the art of grilling.", ImageUrl = "/Image/Annis.jpg" },
            new Restaurant { Id = 1500, CityId = 5, Name = "Enoks i Láddjujávri", AltTag = "Entrance of Enoks", Description = "Set against a stunning backdrop, Enoks i Láddjujávri combines breathtaking views with delectable fare, giving guests an opportunity to relish nature's beauty alongside their meal.", ImageUrl = "/Image/Enok.jpg" },
            new Restaurant { Id = 1600, CityId = 5, Name = "Nikkaluokta Sarri", AltTag = "Dining hall", Description = "Embracing its rustic charm, Nikkaluokta Sarri immerses diners in traditional flavors, offering a taste of authentic cuisine that pays homage to local heritage.", ImageUrl = "/Image/Nik.jpg" });

            modelBuilder.Entity<Activity>().HasData(
            new Activity { Id = 1, CityId = 1, Name = "Vasamuseet", AltTag = "A buildning with a ship on top", Description = "Vasamuseet houses a historic vessel, the Vasa warship, offering an immersive experience into maritime history and Swedish naval heritage.", ImageUrl = "/Image/Vasamuseet.jpg" },
            new Activity { Id = 2, CityId = 1, Name = "Skansen", AltTag = "Entrance of Skansen", Description = "A cultural oasis, Skansen introduces visitors to the charm of Sweden's past with its open-air museum and zoo, allowing guests to explore history and wildlife.", ImageUrl = "/Image/Skansen.jpg" },
            new Activity { Id = 3, CityId = 1, Name = "Bonniers konsthall", AltTag = "The building of Bonniers konsthall", Description = "An artistic haven, Bonniers konsthall showcases contemporary art exhibitions, providing a space for art enthusiasts to immerse themselves in diverse creative expressions.", ImageUrl = "/Image/Bonnier.jpeg" },

            new Activity { Id = 4, CityId = 2, Name = "Liseberg", AltTag = "Animated image of the amusement park during the evening", Description = " Liseberg is a thrilling amusement park offering a blend of exhilarating rides, captivating performances, and family-friendly entertainment for all ages.", ImageUrl = "/Image/Liseberg.jpg" },
            new Activity { Id = 5, CityId = 2, Name = "Slottsskogen", AltTag = "Park with a fountain", Description = "Nature enthusiasts find solace at Slottsskogen, a vast urban park where tranquility meets wildlife, offering serene walks and an opportunity to connect with nature.", ImageUrl = "/Image/Slottsskogen.jpg" },
            new Activity { Id = 6, CityId = 2, Name = "Maritiman", AltTag = "War ship", Description = "Maritiman beckons maritime enthusiasts with its collection of ships and boats, offering an interactive journey through seafaring history and maritime traditions.", ImageUrl = "/Image/Maritiman.jpg" },

            new Activity { Id = 7, CityId = 3, Name = "Linnéträdgården", AltTag = "Two ladies walking in a the garden.", Description = "Linnéträdgården is a botanical oasis celebrating the legacy of Carl Linnaeus, featuring a variety of plants and settings that transport visitors to a bygone era.", ImageUrl = "/Image/Linnetradgarden.jpg" },
            new Activity { Id = 8, CityId = 3, Name = "Botaniska Trädgården", AltTag = "Overlooking the garden infront of a building", Description = "Botaniska Trädgården is a botanical paradise, offering an immersive experience through diverse plant species, greenhouses, and serene landscapes.", ImageUrl = "/Image/Botaniska_Tradgarden.jpg" },
            new Activity { Id = 9, CityId = 3, Name = "Uppsala Domkyrka", AltTag = "Old church in middle of Uppsala", Description = "Uppsala Domkyrka, the Uppsala Cathedral, stands as a majestic religious site, inviting visitors to explore its stunning architecture and historical significance.\r\n", ImageUrl = "/Image/Uppsala_domkyrka.jpg" },

            new Activity { Id = 10, CityId = 4, Name = "Kungsparken", AltTag = "Image of a pond with a willow tree next to it.", Description = "Kungsparken offers a tranquil urban escape, combining scenic beauty with historic sculptures and a serene lake, making it a perfect spot for relaxation.", ImageUrl = "/Image/Kungsparken-Malmo.jpg" },
            new Activity { Id = 11, CityId = 4, Name = "Malmö Private Bike Tour", AltTag = "People riding bikes on the street.", Description = "A cycling adventure through Malmö, the Private Bike Tour offers an exploration of the city's landmarks and hidden gems, guided by local expertise.", ImageUrl = "/Image/MalmoBikeTour.jpg" },
            new Activity { Id = 12, CityId = 4, Name = "Malmöhus slott", AltTag = "Overhead view of a castle in Malmö", Description = "Malmöhus slott, Malmö Castle, encapsulates history within its walls, inviting visitors to delve into centuries of culture and heritage through exhibitions and architecture.", ImageUrl = "/Image/MalmoHusSlott.jpg" },

            new Activity { Id = 13, CityId = 5, Name = "Aurora Sky Station", AltTag = "Aurora borialis on the night sky", Description = " Located in Kiruna, Aurora Sky Station offers a chance to witness the mesmerizing Northern Lights, providing a celestial experience amidst the Arctic wilderness.", ImageUrl = "/Image/AuroraSkyStation-Kiruna.jpg" },
            new Activity { Id = 14, CityId = 5, Name = "Silverfallet", AltTag = "Waterfall", Description = "Silverfallet is a captivating waterfall in Kiruna, offering a picturesque natural setting where guests can revel in the serene beauty of cascading waters.", ImageUrl = "/Image/Silverfallet-Kiruna.jpg" },
            new Activity { Id = 15, CityId = 5, Name = "LKAB:s Visitor Centre", AltTag = "The inside of a mine with blue lights along the walls.", Description = "LKAB's Visitor Centre provides insights into Kiruna's mining heritage, offering a glimpse into the region's mining history and its impact on the community.", ImageUrl = "/Image/LKABVisitorCenter-Kiruna.jpg" });


        }
    }
}

