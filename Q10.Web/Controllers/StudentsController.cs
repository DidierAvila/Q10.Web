using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q10.Application.Students.Commands;
using Q10.Domain.Entities;

namespace Q10.Web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly IStudentHandler _StudentHandler;

        public StudentsController(IStudentHandler studentHandler)
        {
            _StudentHandler = studentHandler;
        }

        // GET: Students
        public async Task<IActionResult> Index(CancellationToken cancellationToken)
        {
            return View(await _StudentHandler.GetAll(cancellationToken));
        }

        // GET: Students/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _StudentHandler.GetByID(id.Value, CancellationToken.None);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: Students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Document,Email")] Student student)
        {
            if (ModelState.IsValid)
            {
                await _StudentHandler.CreateStudent(student, CancellationToken.None);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: Students/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _StudentHandler.GetByID(id.Value, CancellationToken.None);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Document,Email")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _StudentHandler.Update(student, CancellationToken.None);
                }
                catch (DbUpdateConcurrencyException)
                {
                    var result = await StudentExists(student.Id);
                    if (!result)
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
            return View(student);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _StudentHandler.GetByID(id.Value, CancellationToken.None);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _StudentHandler.Delete(id, CancellationToken.None);
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> StudentExists(int id)
        {
            var result = await _StudentHandler.GetByID(id, CancellationToken.None);
            return result != null;
        }
    }
}
