using Garage_3.Validations;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace Garage_3.Models
{
    public class Member
    {
        public int Id { get; set; }

        [DisplayName("Förnamn")]
        public string FirstName { get; set; }

        [DisplayName("Efternamn")]
        [FullName(ErrorMessage = "Förnamn och Efternamn kan inte vara samma!")]
        public string LastName { get; set; }

        [DisplayName("Personnummer")]
        [PersonNumber(ErrorMessage = "Personnummer måste ha 12 siffror")]
        [Remote(action: "IsInDataBase", controller: "Members")]
        public string PersNr { get; set; }

        public List<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
