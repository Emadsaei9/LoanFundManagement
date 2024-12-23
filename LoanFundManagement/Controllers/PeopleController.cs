﻿using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LoanFundManagement.Models;

namespace LoanFundManagement.Controllers
{
    public class PeopleController : Controller
    {
        private readonly LoanFundDbContext _context;

        public PeopleController(LoanFundDbContext context)
        {
            _context = context;
        }

        // GET: People
        public async Task<IActionResult> Index()
        {
            var people = await _context.Persons.ToListAsync();
            return View(people);
        }

        // GET: People/Create
        public IActionResult Create()
        {
            return PartialView();
        }

        // POST: People/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PersonId,FirstName,LastName,NationalCode,Mobile,Tel,Address,FatherName,BirthDate,BirthCertificateNo,BirthPlace,AccountNumber,Status,Note,IsGuarantor")] Person person)
        {
            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return Json(new { success = false, errors = validationErrors });
            }

            _context.Add(person);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        // GET: People/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            return PartialView(person);
        }

        // POST: People/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PersonId,FirstName,LastName,NationalCode,Mobile,Tel,Address,FatherName,BirthDate,BirthCertificateNo,BirthPlace,AccountNumber,Status,Note,IsGuarantor")] Person person)
        {
            if (id != person.PersonId)
            {
                return NotFound();
            }

            if (!ModelState.IsValid)
            {
                var validationErrors = ModelState.Values
                    .SelectMany(v => v.Errors)
                    .Select(e => e.ErrorMessage)
                    .ToList();

                return Json(new { success = false, errors = validationErrors });
            }

            _context.Update(person);
            await _context.SaveChangesAsync();

            return Json(new { success = true });
        }

        private bool PersonExists(int id)
        {
            return _context.Persons.Any(e => e.PersonId == id);
        }
    }
}
