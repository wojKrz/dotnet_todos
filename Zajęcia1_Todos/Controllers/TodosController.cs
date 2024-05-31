using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Zajęcia1_Todos.Data;
using Zajęcia1_Todos.Models;

namespace Zajęcia1_Todos.Controllers
{
    public class TodosController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public TodosController(
            ApplicationDbContext context,
            UserManager<IdentityUser> userManager,
            IAuthorizationService authorizationService)
        {
            _context = context;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        // GET: Todos
        public async Task<IActionResult> Index()
        {

            return View(await _context.TodoGroup
                .Where(g => g.OwnerId == _userManager.GetUserId(User))
                .Include(g => g.Todos)
                .ToListAsync());
        }

        // GET: Todos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var todo = await _context.Todo
                .FirstOrDefaultAsync(m => m.Id == id);
            var authResult = await _authorizationService.AuthorizeAsync(User, todo, OwnershipOperations.Read);
            if(!authResult.Succeeded)
            {
                return Forbid();
            }


            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // GET: Todos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,ForDay")] CreateTodoViewModel todoVM)
        {
            if (ModelState.IsValid)
            {
                var group = await _context.TodoGroup.Where(g => g.ForDay == todoVM.ForDay).FirstOrDefaultAsync();
                var userId = _userManager.GetUserId(User);
                if(group == null)
                {
                    group = new TodoGroup() { 
                        ForDay = todoVM.ForDay,
                        OwnerId = userId
                    };
                    _context.Add(group);
                }

                var todo = new Todo()
                {
                    Title = todoVM.Title,
                    OwnerId = userId
                };
                group.Todos.Add(todo);

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(todoVM);
        }

        [HttpPost, EnsureIdIsPresent]
        public async Task<IActionResult> SetDone(int? id)
        {
            var todo = await _context.Todo.FindAsync(id);
            if(todo == null)
            {
                return NotFound();
            }

            todo.IsDone = true;

            _context.Update(todo);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Todos/Edit/5
        [EnsureIdIsPresent]
        public async Task<IActionResult> Edit(int? id)
        {
            var todo = await _context.Todo.FindAsync(id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // POST: Todos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Title,IsDone")] Todo todo)
        {
            if (id != todo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(todo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TodoExists(todo.Id))
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
            return View(todo);
        }

        // GET: Todos/Delete/5
        [EnsureIdIsPresent]
        public async Task<IActionResult> Delete(int? id)
        {

            var todo = await _context.Todo
                .FirstOrDefaultAsync(m => m.Id == id);
            if (todo == null)
            {
                return NotFound();
            }

            return View(todo);
        }

        // POST: Todos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var todo = await _context.Todo.FindAsync(id);
            if (todo != null)
            {
                _context.Todo.Remove(todo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TodoExists(int id)
        {
            return _context.Todo.Any(e => e.Id == id);
        }
    }
}
