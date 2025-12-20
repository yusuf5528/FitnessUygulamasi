namespace FitnessUygulamasi.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; }

        // Soru işareti (?) ekledik: Resim olmasa da olur.
        public string? ImageUrl { get; set; }

        // Soru işareti (?) ekledik: Henüz randevusu olmasa da olur.
        public ICollection<Appointment>? Appointments { get; set; }
    }
}