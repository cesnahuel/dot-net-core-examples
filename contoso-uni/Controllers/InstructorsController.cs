using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContosoUniversity.Data;
using ContosoUniversity.Models;
using ContosoUniversity.Models.SchoolViewModels;


namespace contoso_uni.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly SchoolContext _context;

        public InstructorsController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Instructors
        public async Task<IActionResult> Index(int? id, int? courseId)
        {
            InstructorIndexData viewModel = new InstructorIndexData();
            viewModel.Instructors = await _context.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments)
                    .ThenInclude(c => c.Course)
                        .ThenInclude(c => c.Enrollments)
                            .ThenInclude(e => e.Student)
                .Include(i => i.CourseAssignments)
                    .ThenInclude(c => c.Course)
                        .ThenInclude(c => c.Department)
                .OrderBy(i => i.LastName)
                .AsNoTracking()
                .ToListAsync();

            if (id != null)
            {
                ViewData["InstructorId"] = id.Value;
                Instructor instructor = viewModel.Instructors
                    .Single(i => i.InstructorId == id.Value);
                viewModel.Courses = instructor.CourseAssignments
                    .Select(ca => ca.Course);
            }

            if (courseId != null)
            {
                ViewData["CourseId"] = courseId.Value;
                viewModel.Enrollments = viewModel.Courses
                    .Single(c => c.CourseId == courseId.Value)
                    .Enrollments;
            }

            return View(viewModel);
        }

        // GET: Instructors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                .Include(m => m.OfficeAssignment)
                .Include(m => m.CourseAssignments)
                    .ThenInclude(ca => ca.Course)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.InstructorId == id);
            if (instructor == null)
            {
                return NotFound();
            }
            return View(instructor);
        }

        // GET: Instructors/Create
        public IActionResult Create()
        {
            Instructor instructor = new Instructor();
            instructor.CourseAssignments = new List<CourseAssignment>();
            PopulateAssignedCourseData(instructor);
            return View();
        }

        // POST: Instructors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InstructorId,LastName,FirstMidName,HireDate")] Instructor instructor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(instructor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(instructor);
        }

        // GET: Instructors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments)
                    .ThenInclude(ca => ca.Course)
                .AsNoTracking()
                .SingleOrDefaultAsync(m => m.InstructorId == id);
            if (instructor == null)
            {
                return NotFound();
            }
            PopulateAssignedCourseData(instructor);
            return View(instructor);
        }

        // POST: Instructors/Edit/5
        // To protect from overposting attacks, please enable the specific properties
        // you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Instructor instructor = await _context.Instructors
                .Include(i => i.OfficeAssignment)
                .Include(i => i.CourseAssignments)
                    .ThenInclude(ca => ca.Course)
                .SingleOrDefaultAsync(m => m.InstructorId == id);
            if (instructor == null)
            {
                return NotFound();
            }
            bool valid = await TryUpdateModelAsync<Instructor>(
                instructor,
                "",
                i => i.InstructorId,
                i => i.LastName,
                i => i.FirstMidName,
                i => i.HireDate,
                i => i.OfficeAssignment
            );
            if (ModelState.IsValid && valid)
            {
                if (String.IsNullOrWhiteSpace(instructor.OfficeAssignment?.Location))
                {
                    instructor.OfficeAssignment = null;
                }
                try
                {
                    _context.Update(instructor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!await InstructorExists(instructor.InstructorId))
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
            return View(instructor);
        }

        private void PopulateAssignedCourseData(Instructor instructor)
        {
            var allCourses = _context.Courses;
            var instructorCourses = new HashSet<int>(
                instructor.CourseAssignments.Select(c => c.CourseId)
            );
            var viewModel = new List<AssignedCourseData>();
            foreach (var course in allCourses)
            {
                viewModel.Add(new AssignedCourseData
                {
                    CourseId = course.CourseId,
                    Title = course.Title,
                    Assigned = instructorCourses.Contains(course.CourseId)
                });
            }
            ViewData["Courses"] = viewModel;
        }

        // GET: Instructors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var instructor = await _context.Instructors
                .SingleOrDefaultAsync(m => m.InstructorId == id);
            if (instructor == null)
            {
                return NotFound();
            }

            return View(instructor);
        }

        // POST: Instructors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var instructor = await _context.Instructors.SingleOrDefaultAsync(m => m.InstructorId == id);
            _context.Instructors.Remove(instructor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> InstructorExists(int id)
        {
            return await _context.Instructors.AnyAsync(e => e.InstructorId == id);
        }
    }
}
