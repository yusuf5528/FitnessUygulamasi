namespace FitnessUygulamasi.Models
{
    public class Trainer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Specialty { get; set; } // Uzmanlık: Yoga, Fitness vb.
        public string ImageUrl { get; set; } = ""; // Resim yolu

        // İlişkiler
        public ICollection<Appointment> Appointments { get; set; }
    }
}