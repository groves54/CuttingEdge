using CuttingEdge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CuttingEdge.Controllers
{
    public class AppointmentController : Controller
    {
        private ApplicationDbContext _dbContext;

        public AppointmentController()
        {
            _dbContext = new ApplicationDbContext();
        }
        // GET: Appointment
        [Authorize]
        public ActionResult Index()
        {
            var appointments = _dbContext.Appointments.ToList();

            return View(appointments);
        }
        public ActionResult New()
        {
            return View();
        }
        public ActionResult Add(Appointments appointment)
        {
            _dbContext.Appointments.Add(appointment);
            _dbContext.SaveChanges();
            return RedirectToAction("ThankYou");
        }
        public ActionResult Edit(int id)
        {
            var appointment = _dbContext.Appointments.SingleOrDefault(p => p.Id == id);

            if (appointment == null)
                return HttpNotFound();

            return View(appointment);
        }
        [HttpPost]
        public ActionResult Update(Appointments appointments)
        {
            var appointmentsInDb = _dbContext.Appointments.SingleOrDefault(p => p.Id == appointments.Id);

            if (appointmentsInDb == null)
                return HttpNotFound();

            appointmentsInDb.FirstName = appointments.FirstName;
            appointmentsInDb.LastName = appointments.LastName;
            appointmentsInDb.Phone = appointments.Phone;
            appointmentsInDb.Date = appointments.Date;
            appointmentsInDb.Description = appointments.Description;
            _dbContext.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var appointment = _dbContext.Appointments.SingleOrDefault(p => p.Id == id);

            if (appointment == null)
                return HttpNotFound();

            return View(appointment);
        }
        [HttpPost]
        public ActionResult DoDelete(int id)
        {
            var appointment = _dbContext.Appointments.SingleOrDefault(p => p.Id == id);
            if (appointment == null)
                return HttpNotFound();
            _dbContext.Appointments.Remove(appointment);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult ThankYou()
        {
            return View();
        }
    }
}