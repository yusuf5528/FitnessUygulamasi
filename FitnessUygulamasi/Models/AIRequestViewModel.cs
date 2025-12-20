namespace FitnessUygulamasi.Models
{
    public class AIRequestViewModel
    {
        public int Weight { get; set; } // Kilo
        public int Height { get; set; } // Boy (cm)
        public string Gender { get; set; } // Cinsiyet
        public string Goal { get; set; } // Hedef (Kilo verme, Kas yapma)
        public string? Result { get; set; } // AI'nin cevabı buraya gelecek
    }
}