using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCAbit.Models;
using MVCAbit.Models;
using System;
using System.Diagnostics.Metrics;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVCAbit.Controllers
{
    public class AbiturientController : Controller
    {
        private readonly AbiturientsContext _abiturientsContext;
        public AbiturientController(AbiturientsContext abiturientContext)
        {
            _abiturientsContext = abiturientContext;
        }
        public class ChosenViewModel
        {
            public string AbitSurname { get; set; }
            public string AbitName { get; set; }
            public string AbitPapa { get; set; }
            public int TotalPoints { get; set; }
            public string ChosenSpecName { get; set; }
            public int ChosenAbId { get; set; }
            public int ChosenSpecId { get; set; }
        }
        public IActionResult IndexAdmin()
        {
            return View();
        }
        public IActionResult IndexOperator()
        {
            var aboba = _abiturientsContext.Chosens.OrderByDescending(c => c.ChosenId).Select(c => new ChosenViewModel
                {
                    AbitSurname = _abiturientsContext.Abiturients.Where(a => a.AbiturientId == c.ChosenAbId).Select(a => a.AbiturientSurname).FirstOrDefault(),
                    AbitName = _abiturientsContext.Abiturients.Where(a => a.AbiturientId == c.ChosenAbId).Select(a => a.AbiturientName).FirstOrDefault(),
                    AbitPapa = _abiturientsContext.Abiturients.Where(a => a.AbiturientId == c.ChosenAbId).Select(a => a.AbiturientPoBatyushke).FirstOrDefault(),
                    TotalPoints = c.ChosenFirstExam + c.ChosenSecondExam + c.ChosenThirdExam,
                    ChosenSpecName = _abiturientsContext.Specialities.Where(s => s.SpecId == c.ChosenSpecId).Select(s => s.SpecName).FirstOrDefault(),
                    ChosenAbId = c.ChosenAbId,
                    ChosenSpecId = c.ChosenSpecId
                }).ToList();
            return View(aboba);
        }
        public IActionResult IndexChecker()
        {
            var aboba = _abiturientsContext.Chosens.OrderByDescending(c => c.ChosenId).Select(c => new ChosenViewModel
                {
                    AbitSurname = _abiturientsContext.Abiturients.Where(a => a.AbiturientId == c.ChosenAbId).Select(a => a.AbiturientSurname).FirstOrDefault(),
                    AbitName = _abiturientsContext.Abiturients.Where(a => a.AbiturientId == c.ChosenAbId).Select(a => a.AbiturientName).FirstOrDefault(),
                    AbitPapa = _abiturientsContext.Abiturients.Where(a => a.AbiturientId == c.ChosenAbId).Select(a => a.AbiturientPoBatyushke).FirstOrDefault(),
                    TotalPoints = c.ChosenFirstExam + c.ChosenSecondExam + c.ChosenThirdExam,
                    ChosenSpecName = _abiturientsContext.Specialities.Where(s => s.SpecId == c.ChosenSpecId).Select(s => s.SpecName).FirstOrDefault(),
                    ChosenAbId = c.ChosenAbId,
                    ChosenSpecId = c.ChosenSpecId
                }).ToList();
            return View(aboba);
        }
        public IActionResult Index()
        {
            var aboba = _abiturientsContext.Chosens.OrderByDescending(c => c.ChosenId).Select(c => new ChosenViewModel
                {
                    AbitSurname = _abiturientsContext.Abiturients.Where(a => a.AbiturientId == c.ChosenAbId).Select(a => a.AbiturientSurname).FirstOrDefault(),
                    AbitName = _abiturientsContext.Abiturients.Where(a => a.AbiturientId == c.ChosenAbId).Select(a => a.AbiturientName).FirstOrDefault(),
                    AbitPapa = _abiturientsContext.Abiturients.Where(a => a.AbiturientId == c.ChosenAbId).Select(a => a.AbiturientPoBatyushke).FirstOrDefault(),
                    TotalPoints = c.ChosenFirstExam + c.ChosenSecondExam + c.ChosenThirdExam,
                    ChosenSpecName = _abiturientsContext.Specialities.Where(s => s.SpecId == c.ChosenSpecId).Select(s => s.SpecName).FirstOrDefault(),
                    ChosenAbId = c.ChosenAbId,
                    ChosenSpecId = c.ChosenSpecId
                }).ToList();
            return View(aboba);
        }
        public IActionResult Dig()
        {
            var abiturients = _abiturientsContext.Abiturients.Where(a => a.Chosens.Any(c => c.ChosenSpecId == 1 || c.ChosenSpecId == 2 || c.ChosenSpecId == 3)).OrderBy(s => s.AbiturientSurname).ToList();
            return View(abiturients);
        }
        public IActionResult DigOperator()
        {
            var abiturients = _abiturientsContext.Abiturients.Where(a => a.Chosens.Any(c => c.ChosenSpecId == 1 || c.ChosenSpecId == 2 || c.ChosenSpecId == 3)).OrderBy(s => s.AbiturientSurname).ToList();
            return View(abiturients);
        }
        public IActionResult DigChecker()
        {
            var abiturients = _abiturientsContext.Abiturients.Where(a => a.Chosens.Any(c => c.ChosenSpecId == 1 || c.ChosenSpecId == 2 || c.ChosenSpecId == 3)).OrderBy(s => s.AbiturientSurname).ToList();
            return View(abiturients);
        }
        public IActionResult Econom()
        {
            var abiturients = _abiturientsContext.Abiturients.Where(a => a.Chosens.Any(c => c.ChosenSpecId == 3 || c.ChosenSpecId == 5 || c.ChosenSpecId == 6)).OrderBy(s => s.AbiturientSurname).ToList();
            return View(abiturients);
        }
        public IActionResult EconomOperator()
        {
            var abiturients = _abiturientsContext.Abiturients.Where(a => a.Chosens.Any(c => c.ChosenSpecId == 3 || c.ChosenSpecId == 5 || c.ChosenSpecId == 6)).OrderBy(s => s.AbiturientSurname).ToList();
            return View(abiturients);
        }
        public IActionResult EconomChecker()
        {
            var abiturients = _abiturientsContext.Abiturients.Where(a => a.Chosens.Any(c => c.ChosenSpecId == 3 || c.ChosenSpecId == 5 || c.ChosenSpecId == 6)).OrderBy(s => s.AbiturientSurname).ToList();
            return View(abiturients);
        }
        public IActionResult Xim()
        {
            var abiturients = _abiturientsContext.Abiturients.Where(a => a.Chosens.Any(c => c.ChosenSpecId == 7 || c.ChosenSpecId == 8 || c.ChosenSpecId == 9)).OrderBy(s => s.AbiturientSurname).ToList();
            return View(abiturients);
        }
        public IActionResult XimOperator()
        {
            var abiturients = _abiturientsContext.Abiturients.Where(a => a.Chosens.Any(c => c.ChosenSpecId == 7 || c.ChosenSpecId == 8 || c.ChosenSpecId == 9)).OrderBy(s => s.AbiturientSurname).ToList();
            return View(abiturients);
        }
        public IActionResult XimChecker()
        {
            var abiturients = _abiturientsContext.Abiturients.Where(a => a.Chosens.Any(c => c.ChosenSpecId == 7 || c.ChosenSpecId == 8 || c.ChosenSpecId == 9)).OrderBy(s => s.AbiturientSurname).ToList();
            return View(abiturients);
        }
        public IActionResult Math()
        {
            var abiturients = _abiturientsContext.Abiturients.Where(a => a.Chosens.Any(c => c.ChosenSpecId == 10 || c.ChosenSpecId == 11 || c.ChosenSpecId == 12)).OrderBy(s => s.AbiturientSurname).ToList();
            return View(abiturients);
        }
        public IActionResult MathOperator()
        {
            var abiturients = _abiturientsContext.Abiturients.Where(a => a.Chosens.Any(c => c.ChosenSpecId == 10 || c.ChosenSpecId == 11 || c.ChosenSpecId == 12)).OrderBy(s => s.AbiturientSurname).ToList();
            return View(abiturients);
        }
        public IActionResult MathChecker()
        {
            var abiturients = _abiturientsContext.Abiturients.Where(a => a.Chosens.Any(c => c.ChosenSpecId == 10 || c.ChosenSpecId == 11 || c.ChosenSpecId == 12)).OrderBy(s => s.AbiturientSurname).ToList();
            return View(abiturients);
        }
        public IActionResult Add()
        {
            var faculties = _abiturientsContext.Faculties.ToList();
            ViewBag.Faculties = new SelectList(faculties, "FacultyId", "FacultyName");
            return View();
        }
        public IActionResult AddOperator()
        {
            var faculties = _abiturientsContext.Faculties.ToList();
            ViewBag.Faculties = new SelectList(faculties, "FacultyId", "FacultyName");
            return View();
        }
        public IActionResult AddDig()
        {
            var faculties = _abiturientsContext.Faculties.ToList();
            ViewBag.Faculties = new SelectList(faculties, "FacultyId", "FacultyName");
            return View();
        }
        public IActionResult AddEconom()
        {
            var faculties = _abiturientsContext.Faculties.ToList();
            ViewBag.Faculties = new SelectList(faculties, "FacultyId", "FacultyName");
            return View();
        }
        public IActionResult AddXim()
        {
            var faculties = _abiturientsContext.Faculties.ToList();
            ViewBag.Faculties = new SelectList(faculties, "FacultyId", "FacultyName");
            return View();
        }
        public IActionResult AddMath()
        {
            var faculties = _abiturientsContext.Faculties.ToList();
            ViewBag.Faculties = new SelectList(faculties, "FacultyId", "FacultyName");
            return View();
        }
        public IActionResult AddDigOperator()
        {
            var faculties = _abiturientsContext.Faculties.ToList();
            ViewBag.Faculties = new SelectList(faculties, "FacultyId", "FacultyName");
            return View();
        }
        public IActionResult AddEconomOperator()
        {
            var faculties = _abiturientsContext.Faculties.ToList();
            ViewBag.Faculties = new SelectList(faculties, "FacultyId", "FacultyName");
            return View();
        }
        public IActionResult AddXimOperator()
        {
            var faculties = _abiturientsContext.Faculties.ToList();
            ViewBag.Faculties = new SelectList(faculties, "FacultyId", "FacultyName");
            return View();
        }

        public IActionResult AddMathOperator()
        {
            var faculties = _abiturientsContext.Faculties.ToList();
            ViewBag.Faculties = new SelectList(faculties, "FacultyId", "FacultyName");
            return View();
        }
        public class AbiturientViewModel
        {
            public Abiturient Abiturient { get; set; }
            public Address Address { get; set; }
            public Secondary Secondary { get; set; }
            public Chosen Chosen { get; set; }
        }

        public IActionResult ChangeAdm(int id, int choseId)
        {
            var faculties = _abiturientsContext.Faculties.ToList();
            ViewBag.Faculties = new SelectList(faculties, "FacultyId", "FacultyName");
            int facultyId;
            if (choseId >= 1 && choseId <= 3)
            {
                facultyId = 1; // Институт Цифровых Систем
            }
            else if (choseId >= 4 && choseId <= 6)
            {
                facultyId = 2; // Институт экономики и менеджмента
            }
            else if (choseId >= 7 && choseId <= 9)
            {
                facultyId = 3; // Институт химии и химических технологий
            }
            else if (choseId >= 10 && choseId <= 12)
            {
                facultyId = 4; // Институт инженерии и машиностроения
            }
            else
            {
                facultyId = 1; 
            }
            int defaultFacultyId;
            if (choseId >= 1 && choseId <= 3)
            {
                defaultFacultyId = 1; 
            }
            else if (choseId >= 4 && choseId <= 6)
            {
                defaultFacultyId = 2; 
            }
            else if (choseId >= 7 && choseId <= 9)
            {
                defaultFacultyId = 3; 
            }
            else if (choseId >= 10 && choseId <= 12)
            {
                defaultFacultyId = 4; 
            }
            else
            {
                defaultFacultyId = 1;
            }
            ViewBag.DefaultFaculty = defaultFacultyId;
            Abiturient abiturient = _abiturientsContext.Abiturients.Find(id);
            Chosen chosen = _abiturientsContext.Chosens.SingleOrDefault(c => (c.ChosenAbId == id) && (c.ChosenSpecId == choseId));
            Address address = _abiturientsContext.Addresses.Find(id);
            Secondary secondary = _abiturientsContext.Secondaries.FirstOrDefault(s => s.Abiturients.Any(a => a.AbiturientId == id));
            if (abiturient == null || chosen == null || address == null || secondary == null)
            {
                return NotFound();
            }
            var tupleModel = new Tuple<Abiturient, Address, Secondary, Chosen>(abiturient, address, secondary, chosen);
            ViewBag.FacultyId = facultyId;
            ViewBag.ChosenSpecId = choseId; 
            return View(tupleModel);
        }
        public IActionResult ChangeAdmChecker(int id, int choseId)
        {
            var faculties = _abiturientsContext.Faculties.ToList();
            ViewBag.Faculties = new SelectList(faculties, "FacultyId", "FacultyName");
            int facultyId;
            if (choseId >= 1 && choseId <= 3)
            {
                facultyId = 1; // Институт Цифровых Систем
            }
            else if (choseId >= 4 && choseId <= 6)
            {
                facultyId = 2; // Институт экономики и менеджмента
            }
            else if (choseId >= 7 && choseId <= 9)
            {
                facultyId = 3; // Институт химии и химических технологий
            }
            else if (choseId >= 10 && choseId <= 12)
            {
                facultyId = 4; // Институт инженерии и машиностроения
            }
            else
            {
                facultyId = 1; 
            }
            int defaultFacultyId;
            if (choseId >= 1 && choseId <= 3)
            {
                defaultFacultyId = 1; 
            }
            else if (choseId >= 4 && choseId <= 6)
            {
                defaultFacultyId = 2;
            }
            else if (choseId >= 7 && choseId <= 9)
            {
                defaultFacultyId = 3; 
            }
            else if (choseId >= 10 && choseId <= 12)
            {
                defaultFacultyId = 4; 
            }
            else
            {
                defaultFacultyId = 1; 
            }
            ViewBag.DefaultFaculty = defaultFacultyId;
            Abiturient abiturient = _abiturientsContext.Abiturients.Find(id);
            Chosen chosen = _abiturientsContext.Chosens.SingleOrDefault(c => (c.ChosenAbId == id) && (c.ChosenSpecId == choseId));
            Address address = _abiturientsContext.Addresses.Find(id);
            Secondary secondary = _abiturientsContext.Secondaries.FirstOrDefault(s => s.Abiturients.Any(a => a.AbiturientId == id));
            if (abiturient == null || chosen == null || address == null || secondary == null)
            {
                return NotFound();
            }
            var tupleModel = new Tuple<Abiturient, Address, Secondary, Chosen>(abiturient, address, secondary, chosen);
            ViewBag.FacultyId = facultyId;
            ViewBag.ChosenSpecId = choseId;
            return View(tupleModel);
        }
        public IActionResult ChangeDig(int id, int choseId)
        {
            Abiturient abiturient = _abiturientsContext.Abiturients.Find(id);
            Chosen chosen = _abiturientsContext.Chosens.SingleOrDefault(c => (c.ChosenAbId == id) && (c.ChosenSpecId == choseId));
            Address address = _abiturientsContext.Addresses.Find(id);
            Secondary secondary = _abiturientsContext.Secondaries.FirstOrDefault(s => s.Abiturients.Any(a => a.AbiturientId == id));
            if (abiturient == null || chosen == null || address == null || secondary == null)
            {
                return NotFound();
            }

            var tupleModel = new Tuple<Abiturient, Address, Secondary, Chosen>(abiturient, address, secondary, chosen);
            ViewBag.ChosenSpecId = choseId; 
            return View(tupleModel);
        }

        public IActionResult ChangeDigChecker(int id, int choseId)
        {
            Abiturient abiturient = _abiturientsContext.Abiturients.Find(id);
            Chosen chosen = _abiturientsContext.Chosens.SingleOrDefault(c => (c.ChosenAbId == id) && (c.ChosenSpecId == choseId));
            Address address = _abiturientsContext.Addresses.Find(id);
            Secondary secondary = _abiturientsContext.Secondaries.FirstOrDefault(s => s.Abiturients.Any(a => a.AbiturientId == id));
            if (abiturient == null || chosen == null || address == null || secondary == null)
            {
                return NotFound();
            }
            var tupleModel = new Tuple<Abiturient, Address, Secondary, Chosen>(abiturient, address, secondary, chosen);
            ViewBag.ChosenSpecId = choseId; 
            return View(tupleModel);
        }

        public IActionResult ChangeEconom(int id, int choseId)
        {
            Abiturient abiturient = _abiturientsContext.Abiturients.Find(id);
            Chosen chosen = _abiturientsContext.Chosens.SingleOrDefault(c => (c.ChosenAbId == id) && (c.ChosenSpecId == choseId));
            Address address = _abiturientsContext.Addresses.Find(id);
            Secondary secondary = _abiturientsContext.Secondaries.FirstOrDefault(s => s.Abiturients.Any(a => a.AbiturientId == id));
            if (abiturient == null || chosen == null || address == null || secondary == null)
            {
                return NotFound();
            }
            var tupleModel = new Tuple<Abiturient, Address, Secondary, Chosen>(abiturient, address, secondary, chosen);
            ViewBag.ChosenSpecId = choseId; 
            return View(tupleModel);
        }
        public IActionResult ChangeEconomChecker(int id, int choseId)
        {
            Abiturient abiturient = _abiturientsContext.Abiturients.Find(id);
            Chosen chosen = _abiturientsContext.Chosens.SingleOrDefault(c => (c.ChosenAbId == id) && (c.ChosenSpecId == choseId));
            Address address = _abiturientsContext.Addresses.Find(id);
            Secondary secondary = _abiturientsContext.Secondaries.FirstOrDefault(s => s.Abiturients.Any(a => a.AbiturientId == id));
            if (abiturient == null || chosen == null || address == null || secondary == null)
            {
                return NotFound();
            }
            var tupleModel = new Tuple<Abiturient, Address, Secondary, Chosen>(abiturient, address, secondary, chosen);
            ViewBag.ChosenSpecId = choseId;
            return View(tupleModel);
        }
        public IActionResult ChangeXim(int id, int choseId)
        {
            Abiturient abiturient = _abiturientsContext.Abiturients.Find(id);
            Chosen chosen = _abiturientsContext.Chosens.SingleOrDefault(c => (c.ChosenAbId == id) && (c.ChosenSpecId == choseId));
            Address address = _abiturientsContext.Addresses.Find(id);
            Secondary secondary = _abiturientsContext.Secondaries.FirstOrDefault(s => s.Abiturients.Any(a => a.AbiturientId == id));
            if (abiturient == null || chosen == null || address == null || secondary == null)
            {
                return NotFound();
            }
            var tupleModel = new Tuple<Abiturient, Address, Secondary, Chosen>(abiturient, address, secondary, chosen);
            ViewBag.ChosenSpecId = choseId; 
            return View(tupleModel);
        }
        public IActionResult ChangeXimChecker(int id, int choseId)
        {
            Abiturient abiturient = _abiturientsContext.Abiturients.Find(id);
            Chosen chosen = _abiturientsContext.Chosens.SingleOrDefault(c => (c.ChosenAbId == id) && (c.ChosenSpecId == choseId));
            Address address = _abiturientsContext.Addresses.Find(id);
            Secondary secondary = _abiturientsContext.Secondaries.FirstOrDefault(s => s.Abiturients.Any(a => a.AbiturientId == id));
            if (abiturient == null || chosen == null || address == null || secondary == null)
            {
                return NotFound();
            }
            var tupleModel = new Tuple<Abiturient, Address, Secondary, Chosen>(abiturient, address, secondary, chosen);
            ViewBag.ChosenSpecId = choseId;
            return View(tupleModel);
        }
        public IActionResult ChangeMath(int id, int choseId)
        {
            Abiturient abiturient = _abiturientsContext.Abiturients.Find(id);
            Chosen chosen = _abiturientsContext.Chosens.SingleOrDefault(c => (c.ChosenAbId == id) && (c.ChosenSpecId == choseId));
            Address address = _abiturientsContext.Addresses.Find(id);
            Secondary secondary = _abiturientsContext.Secondaries.FirstOrDefault(s => s.Abiturients.Any(a => a.AbiturientId == id));
            if (abiturient == null || chosen == null || address == null || secondary == null)
            {
                return NotFound();
            }
            var tupleModel = new Tuple<Abiturient, Address, Secondary, Chosen>(abiturient, address, secondary, chosen);
            ViewBag.ChosenSpecId = choseId;
            return View(tupleModel);
        }
        public IActionResult ChangeMathChecker(int id, int choseId)
        {
            Abiturient abiturient = _abiturientsContext.Abiturients.Find(id);
            Chosen chosen = _abiturientsContext.Chosens.SingleOrDefault(c => (c.ChosenAbId == id) && (c.ChosenSpecId == choseId));
            Address address = _abiturientsContext.Addresses.Find(id);
            Secondary secondary = _abiturientsContext.Secondaries.FirstOrDefault(s => s.Abiturients.Any(a => a.AbiturientId == id));
            if (abiturient == null || chosen == null || address == null || secondary == null)
            {
                return NotFound();
            }
            var tupleModel = new Tuple<Abiturient, Address, Secondary, Chosen>(abiturient, address, secondary, chosen);
            ViewBag.ChosenSpecId = choseId;
            return View(tupleModel);
        }
        [HttpPost]
        public IActionResult Changes(int id, string redirect, int old_spec, int old_g_medal, int old_s_medal, int old_d_medal, string surname, string name, string papochka, string link, string city, string street, int num, string namesec, int numsec, string citysec, int dateOfEnd, string medalType, int specialtyId, int firstExam, int secondExam, int thirdExam)
        {
            int sec_id = _abiturientsContext.Abiturients.Where(a => a.AbiturientId == id).Select(a => a.AbiturientSecId).FirstOrDefault();
            Secondary secondary = _abiturientsContext.Secondaries.Find(sec_id);
            if (secondary != null)
            {
                secondary.SecondaryName = namesec;
                secondary.SecondaryNumber = numsec;
                secondary.SecondaryCity = citysec;
            }
            Abiturient abiturient = _abiturientsContext.Abiturients.Find(id);
            if (abiturient != null)
            {
                abiturient.AbiturientName = name;
                abiturient.AbiturientSurname = surname;
                abiturient.AbiturientPoBatyushke = papochka;
                abiturient.AbiturientPhoto = link;
                abiturient.AbiturientGoldMedal = false;
                abiturient.AbiturientSilverMedal = false;
                abiturient.AbiturientTechDiplom = false;
                if (medalType == "Gold")
                {
                    abiturient.AbiturientGoldMedal = true;
                }
                else
                {
                    if (medalType == "Silver")
                    {
                        abiturient.AbiturientSilverMedal = true;
                    }
                    if (medalType == "CollegeDiploma")
                    {
                        abiturient.AbiturientTechDiplom = true;
                    }
                }
                abiturient.AbiturientSecYear = dateOfEnd;
                Address address1 = _abiturientsContext.Addresses.Find(id);
                address1.AddressCity = city;
                address1.AddressStreet = street;
                address1.AddressHomeNum = num;
                int ch_id = _abiturientsContext.Chosens.Where(a => ((a.ChosenAbId == id) && (a.ChosenSpecId == old_spec))).Select(a => a.ChosenId).FirstOrDefault();
                Chosen chosen1 = _abiturientsContext.Chosens.Find(ch_id);
                chosen1.ChosenFirstExam = firstExam;
                chosen1.ChosenSecondExam = secondExam;
                chosen1.ChosenThirdExam = thirdExam;
                chosen1.ChosenSpecId = specialtyId;
                _abiturientsContext.Secondaries.Update(secondary);
                _abiturientsContext.Abiturients.Update(abiturient);
                _abiturientsContext.Addresses.Update(address1);
                _abiturientsContext.Chosens.Update(chosen1);
                _abiturientsContext.SaveChanges();
            }
            return RedirectToAction(redirect);
        }
        [HttpPost]
        public IActionResult IndexOperator(string surname, string name, string papochka, string link, string city, string street, int num, string namesec, int numsec, string citysec, int dateOfEnd, string medalType, string facultyId, int specialtyId, int firstExam, int secondExam, int thirdExam)
        {
            Secondary secondary = new Secondary { SecondaryName = namesec, SecondaryCity = citysec, SecondaryNumber = numsec };
            _abiturientsContext.Secondaries.Add(secondary);
            _abiturientsContext.SaveChanges();
            bool gold_medal = false, silver_medal = false, tech_diplom = false;
            if (medalType == "Gold")
            {
                gold_medal = true;
            }
            else
            {
                if (medalType == "Silver")
                {
                    silver_medal = true;
                }
                if (medalType == "CollegeDiploma")
                {
                    tech_diplom = true;
                }
            }
            int lastSecondaryId = _abiturientsContext.Secondaries.AsEnumerable().Select(s => s.SecondaryId).DefaultIfEmpty(0).Max();
            Abiturient abiturient = new Abiturient { AbiturientSurname = surname, AbiturientName = name, AbiturientPoBatyushke = papochka, AbiturientGoldMedal = gold_medal, AbiturientSilverMedal = silver_medal, AbiturientTechDiplom = tech_diplom, AbiturientSecYear = dateOfEnd, AbiturientPhoto = link, AbiturientSecId = lastSecondaryId };
            _abiturientsContext.Abiturients.Add(abiturient);
            _abiturientsContext.SaveChanges();
            int lastAbitId = _abiturientsContext.Abiturients.AsEnumerable().Select(s => s.AbiturientId).DefaultIfEmpty(0).Max();
            Address address = new Address { AddressId = lastAbitId, AddressCity = city, AddressStreet = street, AddressHomeNum = num };
            Chosen chosen = new Chosen { ChosenAbId = lastAbitId, ChosenSpecId = specialtyId, ChosenFirstExam = firstExam, ChosenSecondExam = secondExam, ChosenThirdExam = thirdExam };
            DateTime currentTime = DateTime.Now;
            Registration registration = new Registration { RegAbiturientId = lastAbitId, RegStaffId = 4, RegDate = currentTime };
            _abiturientsContext.Chosens.Add(chosen);
            _abiturientsContext.Addresses.Add(address);
            _abiturientsContext.Registrations.Add(registration);
            _abiturientsContext.SaveChanges();
            return RedirectToAction("IndexOperator");
        }
        [HttpPost]
        public IActionResult Index(string surname, string name, string papochka, string link, string city, string street, int num, string namesec, int numsec, string citysec, int dateOfEnd, string medalType, string facultyId, int specialtyId, int firstExam, int secondExam, int thirdExam)
        {
            Secondary secondary = new Secondary { SecondaryName = namesec, SecondaryCity = citysec, SecondaryNumber = numsec };
            _abiturientsContext.Secondaries.Add(secondary);
            _abiturientsContext.SaveChanges();
            bool gold_medal = false, silver_medal = false, tech_diplom = false;
            if (medalType == "Gold")
            {
                gold_medal = true;
            }
            else
            {
                if (medalType == "Silver")
                {
                    silver_medal = true;
                }
                if (medalType == "CollegeDiploma")
                {
                    tech_diplom = true;
                }
            }
            int lastSecondaryId = _abiturientsContext.Secondaries.AsEnumerable() .Select(s => s.SecondaryId).DefaultIfEmpty(0).Max();
            Abiturient abiturient = new Abiturient { AbiturientSurname = surname, AbiturientName = name, AbiturientPoBatyushke = papochka, AbiturientGoldMedal = gold_medal, AbiturientSilverMedal = silver_medal, AbiturientTechDiplom = tech_diplom, AbiturientSecYear = dateOfEnd, AbiturientPhoto = link, AbiturientSecId = lastSecondaryId };
            _abiturientsContext.Abiturients.Add(abiturient);
            _abiturientsContext.SaveChanges();
            int lastAbitId = _abiturientsContext.Abiturients.AsEnumerable() .Select(s => s.AbiturientId).DefaultIfEmpty(0).Max();
            Address address = new Address { AddressId = lastAbitId, AddressCity = city, AddressStreet = street, AddressHomeNum = num };
            Chosen chosen = new Chosen { ChosenAbId = lastAbitId, ChosenSpecId = specialtyId, ChosenFirstExam = firstExam, ChosenSecondExam = secondExam, ChosenThirdExam = thirdExam };
            DateTime currentTime = DateTime.Now;
            Registration registration = new Registration { RegAbiturientId = lastAbitId, RegStaffId = 4, RegDate = currentTime };
            _abiturientsContext.Chosens.Add(chosen);
            _abiturientsContext.Addresses.Add(address);
            _abiturientsContext.Registrations.Add(registration);
            _abiturientsContext.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult GetSpecialties(int facultyId)
        {
            var specialties = _abiturientsContext.Specialities.Where(s => s.SpecFacId == facultyId).Select(s => new { s.SpecId, s.SpecName }).ToList();
            if (specialties.Count == 1)
            {
                var specialtyId = specialties.First().SpecId;
                var specialtyDetails = _abiturientsContext.Specialities.FirstOrDefault(s => s.SpecId == specialtyId);
                return Json(specialtyDetails);
            }
            return Json(specialties);
        }
        [HttpGet]
        public IActionResult GetSpecialityById(int specId)
        {
            var speciality = _abiturientsContext.Specialities.FirstOrDefault(s => s.SpecId == specId);
            if (speciality == null)
            {
                return NotFound(); 
            }
            return Json(speciality); 
        }
        public IActionResult GetAbiturients(int SpecId)
        {
            var abiturients = _abiturientsContext.Abiturients.Where(a => a.Chosens.Any(c => c.ChosenSpecId == SpecId)).OrderBy(s => s.AbiturientSurname).ToList();
            return Json(abiturients);
        }
        [HttpGet]
        public IActionResult GetExamsByAbiturientId(int abiturientId)
        {
            var exams = _abiturientsContext.Chosens.FirstOrDefault(c => c.ChosenAbId == abiturientId);
            if (exams == null)
            {
                return NotFound();
            }
            return Json(exams); 
        }
        [HttpGet]
        public IActionResult GetSpecialtyDetails(int specialtyId)
        {
            var specialty = _abiturientsContext.Specialities.FirstOrDefault(s => s.SpecId == specialtyId);
            return Json(specialty);
        }
        public IActionResult Delete(int id)
        {
            Abiturient abiturient = _abiturientsContext.Abiturients.Find(id);
            if (abiturient != null)
            {
                var chosensToDelete = _abiturientsContext.Chosens.Where(c => c.ChosenAbId == id);
                _abiturientsContext.Chosens.RemoveRange(chosensToDelete);
                Registration registrationToDelete = _abiturientsContext.Registrations.FirstOrDefault(r => r.RegAbiturientId == id);
                if (registrationToDelete != null)
                {
                    _abiturientsContext.Registrations.Remove(registrationToDelete);
                }
                Address addressToDelete = _abiturientsContext.Addresses.FirstOrDefault(a => a.AddressId == id);
                if (addressToDelete != null)
                {
                    _abiturientsContext.Addresses.Remove(addressToDelete);
                }
                _abiturientsContext.Abiturients.Remove(abiturient);
                _abiturientsContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
