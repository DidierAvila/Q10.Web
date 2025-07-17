using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Q10.Application.Subjects.Commands;
using Q10.Application.Subjects.Queries;
using Q10.Domain.Entities;

namespace Q10.Web.Controllers
{
    public class SubjectsController : Controller
    {
        private readonly IMediator _mediator;

        public SubjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // GET: Subjects
        public async Task<IActionResult> Index()
        {
            return View(await _mediator.Send(new GetSubjectsQuery()));
        }
        
        // GET: Subjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _mediator.Send(new GetSubjectQuery() { Id = id.Value });
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // GET: Subjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Subjects/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Code,Credit")] Subject subject)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new CreateSubjectCommand() { Code = subject.Code, Credit = subject.Credit, Name = subject.Name });
                return RedirectToAction(nameof(Index));
            }
            return View(subject);
        }

        // GET: Subjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _mediator.Send(new GetSubjectQuery() { Id = id.Value });
            if (subject == null)
            {
                return NotFound();
            }
            return View(subject);
        }

        // POST: Subjects/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Code,Credit")] Subject subject)
        {
            if (id != subject.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _mediator.Send(new UpdateSubjectCommand() { Id = subject.Id, Code = subject.Code, Credit = subject.Credit, Name = subject.Name });
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubjectExists(subject.Id))
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
            return View(subject);
        }

        // GET: Subjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subject = await _mediator.Send(new GetSubjectQuery() { Id = id.Value });
            if (subject == null)
            {
                return NotFound();
            }

            return View(subject);
        }

        // POST: Subjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subject = await _mediator.Send(new GetSubjectQuery() { Id = id });
            if (subject != null)
            {
                await _mediator.Send(new DeleteSubjectCommand() { Id = id });
            }
            return RedirectToAction(nameof(Index));
        }

        private bool SubjectExists(int id)
        {
            var result = _mediator.Send(new GetSubjectQuery() { Id = id });
            return result != null;
        }
    }
}
