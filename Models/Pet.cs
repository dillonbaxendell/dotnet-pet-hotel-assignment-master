using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace pet_hotel
{
    public enum PetBreedType {
        Shepherd,
        Poodle,
        Beagle,
        Bulldog,
        Terrier,
        Boxer,
        Labrador,
        Retriever

    }
    public enum PetColorType {
        White,
        Black,
        Golden,
        Tricolor,
        Spotted
    }
    public class Pet {

        public int id {get; set;}

        public DateTime checkedInAt {get; set;}

        [Required]
        public string name {get; set;}

        [ForeignKey("PetOwner")]
        [Required]
        public int petOwnerid {get; set;}   

        [Required]
        public string breed {get; set;}

        public int petCount {get; set;}

        public void checkIn() {
            petCount += 1;
        }

        public void checkOut() {
            petCount -= 1;
        }

    }
}
