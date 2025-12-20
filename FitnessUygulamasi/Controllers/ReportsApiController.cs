using Microsoft.AspNetCore.Mvc;
using FitnessUygulamasi.Data;
using FitnessUygulamasi.Models;
using System.Linq; // LINQ için gerekli

namespace FitnessUygulamasi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportsApiController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ReportsApiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // 1. Rapor: Tüm antrenörleri ve uzmanlıklarını getir (LINQ Select)
        // Adres: /api/reportsapi/trainers
        [HttpGet("trainers")]
        public IActionResult GetTrainers()
        {
            var data = _context.Trainers
                .Select(x => new {
                    AdSoyad = x.Name,
                    Uzmanlik = x.Specialty
                })
                .ToList();

            return Ok(data);
        }

        // 2. Rapor: Belirli bir tarihteki dolu randevuları getir (LINQ Where)
        // Adres: /api/reportsapi/appointments/2025-12-20
        [HttpGet("appointments/{date}")]
        public IActionResult GetAppointmentsByDate(string date)
        {
            DateTime filterDate;
            // Tarih formatı geçerli mi kontrolü
            if (!DateTime.TryParse(date, out filterDate))
            {
                return BadRequest("Geçersiz tarih formatı! (Yıl-Ay-Gün kullanın)");
            }

            var data = _context.Appointments
                .Where(x => x.Date.Date == filterDate.Date) // LINQ Filtreleme
                .Select(x => new {
                    Uye = x.User.UserName,
                    Egitmen = x.Trainer.Name,
                    Hizmet = x.Service.Name,
                    Saat = x.Date.ToShortTimeString()
                })
                .ToList();

            return Ok(data);
        }
    }
}