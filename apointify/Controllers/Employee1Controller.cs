using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using apointify.Models;

namespace apointify.Controllers
{
    public class Employee1Controller : Controller
    {

       
        OmParmarContext _context = new OmParmarContext();



        // GET: Employee1
        public  IActionResult Index()
        {
            var user = _context.Employees.ToList();

            return View(user);  
        }

        // GET: Employee1/Details/5
        //public  Task<IActionResult> Details(long? id)
        //{

        //    var user = _context.Employees.ToList();
        //    return View(user);
        //}

        // GET: Employee1/Create
        //public IActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Employee1/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("EmployeeId,FirstName,LastName,MobileNo,BirthDate,UserName,UserEmailAddress,Password,HomeAddress,City,State,Zipcode,InsertedDate")] Employee1 employee1)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(employee1);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(employee1);
        //}

        //// GET: Employee1/Edit/5
        //public async Task<IActionResult> Edit(long? id)
        //{
        //    if (id == null || _context.Employees1 == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee1 = await _context.Employees1.FindAsync(id);
        //    if (employee1 == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(employee1);
        //}

        //// POST: Employee1/Edit/5
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(long id, [Bind("EmployeeId,FirstName,LastName,MobileNo,BirthDate,UserName,UserEmailAddress,Password,HomeAddress,City,State,Zipcode,InsertedDate")] Employee1 employee1)
        //{
        //    if (id != employee1.EmployeeId)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(employee1);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!Employee1Exists(employee1.EmployeeId))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(employee1);
        //}

        //// GET: Employee1/Delete/5
        //public async Task<IActionResult> Delete(long? id)
        //{
        //    if (id == null || _context.Employees1 == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee1 = await _context.Employees1
        //        .FirstOrDefaultAsync(m => m.EmployeeId == id);
        //    if (employee1 == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(employee1);
        //}

        //// POST: Employee1/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(long id)
        //{
        //    if (_context.Employees1 == null)
        //    {
        //        return Problem("Entity set 'OmParmarContext.Employees1'  is null.");
        //    }
        //    var employee1 = await _context.Employees1.FindAsync(id);
        //    if (employee1 != null)
        //    {
        //        _context.Employees1.Remove(employee1);
        //    }
            
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool Employee1Exists(long id)
        //{
        //  return (_context.Employees1?.Any(e => e.EmployeeId == id)).GetValueOrDefault();
        //}
    }
}
