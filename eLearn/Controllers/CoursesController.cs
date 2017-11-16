using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using eLearn.Data;
using eLearn.Models;
using Microsoft.AspNetCore.Authorization;
using eLearn.Models.ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace eLearn.Controllers
{
    public class CoursesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CoursesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Courses
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Courses.Include(c => c.Category).Include(c => c.Professor);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Courses/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Category)
                .Include(c => c.Professor)
                .SingleOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // GET: Courses/Create
        [Authorize(Roles ="Professor, Administrator")]
        public IActionResult Create()
        {
            // ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID");
            // ViewData["ProfessorID"] = new SelectList(_context.Professors, "Id", "Id");
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Summary,Password,StartDate,FinishDate,Category")] CursoViewModel course)
        {
            if (ModelState.IsValid)
            {
                Course c = new Course
                {
                    Name = course.Name,
                    Summary = course.Summary,
                    // Category = 
                    CreationDate = DateTime.Now,
                    FinishDate = course.FinishDate,
                    StartDate = course.StartDate,
                    Password = course.Password,
                    ProfessorID = this.User.FindFirstValue(ClaimTypes.NameIdentifier),
                    CourseID = Guid.NewGuid(),
                };
                //var idC = _context.Categories.First(u => u.Name == course.Category).CategoryID;
                var idC = _context.Categories.First().CategoryID;
                c.CategoryID = idC;
                _context.Add(c);
                await _context.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
                //course.CourseID = Guid.NewGuid();
                //_context.Add(course);
                //await _context.SaveChangesAsync();
                //return RedirectToAction(nameof(Index));
            }
            //ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", course.CategoryID);
            //ViewData["ProfessorID"] = new SelectList(_context.Professors, "Id", "Id", course.ProfessorID);
            return View(course);
        }

        // GET: Courses/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses.SingleOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", course.CategoryID);
            ViewData["ProfessorID"] = new SelectList(_context.Professors, "Id", "Id", course.ProfessorID);
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("CourseID,Name,Summary,Password,CreationDate,StartDate,FinishDate,CategoryID,ProfessorID")] Course course)
        {
            if (id != course.CourseID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(course);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CourseExists(course.CourseID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryID"] = new SelectList(_context.Categories, "CategoryID", "CategoryID", course.CategoryID);
            ViewData["ProfessorID"] = new SelectList(_context.Professors, "Id", "Id", course.ProfessorID);
            return View(course);
        }

        // GET: Courses/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var course = await _context.Courses
                .Include(c => c.Category)
                .Include(c => c.Professor)
                .SingleOrDefaultAsync(m => m.CourseID == id);
            if (course == null)
            {
                return NotFound();
            }

            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var course = await _context.Courses.SingleOrDefaultAsync(m => m.CourseID == id);
            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CourseExists(Guid id)
        {
            return _context.Courses.Any(e => e.CourseID == id);
        }
        
    }
}
