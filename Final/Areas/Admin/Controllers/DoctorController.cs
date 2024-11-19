using Final.Core.Models;
using Final.Business.Services.Abstarct;
using Final.Business.Exceptions;
using Microsoft.AspNetCore.Mvc;
using FileNotFoundException = Final.Business.Exceptions.FileNotFoundException;

namespace Final.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DoctorController : Controller
    {
        private readonly IDoctorService _doctorService;
        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }
        public IActionResult Index()
        {
            var doctors = _doctorService.GetAllDoctors();
            return View(doctors);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Doctor doctor)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                await _doctorService.AddDoctor(doctor);
            }
            catch (ImageContentException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (ImageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (FileNullReferenceException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            var existDoctor = _doctorService.GetDoctor(x => x.Id == id);
            if (existDoctor == null) return NotFound();
            return View(existDoctor);
        }
        [HttpPost]
        public IActionResult Update(Doctor doctor)
        {
            if (!ModelState.IsValid)
                return View();

            try
            {
                _doctorService.UpdateDoctor(doctor.Id, doctor);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (ImageContentException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (ImageSizeException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (FileNotFoundException ex)
            {
                ModelState.AddModelError("ImageFile", ex.Message);
                return View();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            var existDoctor = _doctorService.GetDoctor(x => x.Id == id);
            if (existDoctor == null) return NotFound();
            return View(existDoctor);
        }

        [HttpPost]
        public IActionResult DeletePost(int id)
        {

            try
            {
                _doctorService.DeleteDoctor(id);
            }
            catch (EntityNotFoundException ex)
            {
                return NotFound();
            }
            catch (FileNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return RedirectToAction("Index");
        }
    }
}
