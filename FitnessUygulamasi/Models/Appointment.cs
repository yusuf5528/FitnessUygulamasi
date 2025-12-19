using System;

namespace FitnessUygulamasi.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        // Hangi Üye?
        public string UserId { get; set; }
        public AppUser User { get; set; }

        // Hangi Eğitmen?
        public int TrainerId { get; set; }
        public Trainer Trainer { get; set; }

        // Hangi Hizmet?
        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public DateTime Date { get; set; }
        public bool IsConfirmed { get; set; } = false;
    }
}