using Microsoft.AspNetCore.Mvc;
using FitnessUygulamasi.Models;

namespace FitnessUygulamasi.Controllers
{
    public class AIController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View(new AIRequestViewModel());
        }

        [HttpPost]
        public IActionResult GeneratePlan(AIRequestViewModel model)
        {
            // 1. Vücut Kitle İndeksi (BMI) Hesapla
            // Formül: Kilo / (Boy(m) * Boy(m))
            double heightInMeters = model.Height / 100.0;
            double bmi = model.Weight / (heightInMeters * heightInMeters);

            string aiResponse = "";

            // 2. Yapay Zeka Mantığı (Simülasyon)
            // Bu kısım, OpenAI'dan gelmiş gibi akıllı metinler üretir.

            if (model.Goal == "kilo_verme")
            {
                if (bmi > 25)
                    aiResponse = $"Vücut Kitle İndeksiniz: {bmi:F2} (Fazla Kilolu). \n\n" +
                                 "Size özel AI Önerisi: Kalori açığı oluşturmaya odaklanmalıyız. " +
                                 "Haftada 4 gün 'Low Intensity Steady State' (LISS) kardiyo yapmalısınız. " +
                                 "Beslenme olarak 'Intermittent Fasting' (Aralıklı Oruç) 16:8 metodunu deneyebilirsiniz. " +
                                 "Şeker ve basit karbonhidratları tamamen kesin.";
                else
                    aiResponse = $"Vücut Kitle İndeksiniz: {bmi:F2} (Normal/İdeal). \n\n" +
                                 "Size özel AI Önerisi: Kilonuz ideal, ancak yağ yakıp sıkılaşmak istiyorsunuz. " +
                                 "HIIT (Yüksek Yoğunluklu Aralıklı Antrenman) programı uygulayın. " +
                                 "Protein alımını artırarak (kilo başına 1.5g) kas kaybını önleyin.";
            }
            else // Kas Yapma (Hacim)
            {
                if (bmi < 20)
                    aiResponse = $"Vücut Kitle İndeksiniz: {bmi:F2} (Zayıf). \n\n" +
                                 "Size özel AI Önerisi: 'Dirty Bulk' yapmadan temiz bir şekilde kilo almalıyız. " +
                                 "Günlük kalori ihtiyacınızın 500 kalori üzerine çıkın. " +
                                 "Antrenman programınız 'Hypertrophy' (Büyüme) odaklı olmalı (8-12 tekrar aralığı). " +
                                 "Karbonhidrat tüketmekten korkmayın, antrenman öncesi pirinç/yulaf tüketin.";
                else
                    aiResponse = $"Vücut Kitle İndeksiniz: {bmi:F2} (Güçlü/Yapılı). \n\n" +
                                 "Size özel AI Önerisi: Zaten iyi bir altyapınız var. 'Progressive Overload' (Aşamalı Yükleme) tekniğini kullanın. " +
                                 "Her antrenmanda ağırlığı %2.5 artırmayı hedefleyin. " +
                                 "Kreatin takviyesi (günde 5g) performansınızı artıracaktır.";
            }

            model.Result = aiResponse;
            return View("Index", model);
        }
    }
}