using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Q10.Application.Students.Commands;
using Q10.Application.SubjectRegistrations.Commands;
using Q10.Application.SubjectRegistrations.Queries;
using Q10.Application.Subjects.Commands;
using Q10.Application.Subjects.Queries;
using Q10.Domain.Dtos;
using Q10.Domain.Entities;
using Q10.Web.Models;

namespace Q10.Web.Controllers
{
    public class SubjectRegistrationsController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IStudentHandler _StudentHandler;

        public SubjectRegistrationsController(IMediator mediator, IStudentHandler studentHandler)
        {
            _mediator = mediator;
            _StudentHandler = studentHandler;
        }

        // Fix for CS0019: Replace the '??' operator with a null-coalescing assignment to ensure compatibility between IEnumerable<SubjectRegistration> and List<SubjectRegistration>.
        public async Task<IActionResult> Index(int? studentId, CancellationToken cancellationToken)
        {
            // Obtener estudiantes
            var studentsResult = await _StudentHandler.GetAll(cancellationToken);
            var students = studentsResult?.Select(student => new Q10.Web.Models.Student
            {
                Id = student.Id,
                Name = student.Name
            }).ToList();

            // Obtener inscripciones por estudiante (si hay uno seleccionado)
            IEnumerable<Domain.Dtos.SubjectRegistrationDto>? subjectRegistrations = null;
            if (studentId.HasValue)
            {
                subjectRegistrations = await _mediator.Send(new GetSubjectRegistrationsByStudentIdQuery() { StudentId = studentId.Value }, cancellationToken);
            }

            var viewModel = new SubjectRegistrationIndexViewModel
            {
                SubjectRegistrations = subjectRegistrations,
                Students = students
            };

            ViewBag.SelectedStudentId = studentId;
            return View(viewModel);
        }

        // GET: SubjectRegistrationController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SubjectRegistrationController/Create
        public ActionResult Create(int? studentId)
        {
            ViewBag.SelectedStudentId = studentId;
            return View();
        }

        // POST: SubjectRegistrationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,StudentId")] Domain.Entities.SubjectRegistration subject)
        {
            if (ModelState.IsValid)
            {
                // Ejecuta el comando y valida la lógica de negocio
                var result = await _mediator.Send(new CreateSubjectRegistrationCommand() { SubjectId = subject.SubjectId, StudentId = subject.StudentId });
                if (result is { Success: false, ErrorMessage: not null })
                {
                    // Mensaje personalizado
                    ModelState.AddModelError(string.Empty, result.ErrorMessage);
                    return View(subject);
                }
            }
            return View(subject);
        }

        // GET: SubjectRegistrationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SubjectRegistrationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, IFormCollection collection)
        {
            var subject = await _mediator.Send(new GetSubjectRegistrationByStudentIdQuery() { StudentId = id });
            if (subject != null)
            {
                await _mediator.Send(new DeleteSubjectRegistrationCommand() { Id = id });
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
