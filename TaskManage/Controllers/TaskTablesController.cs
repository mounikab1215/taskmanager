using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskManage.Data;
using TaskManage.Models;

namespace TaskManage.Controllers
{
    public class TaskTablesController : Controller
    {
        private readonly TaskDataContext _context;

        public TaskTablesController(TaskDataContext context)
        {
            _context = context;
        }

        // GET: TaskTables
        public async Task<IActionResult> Index()
        {
              return _context.Tasks != null ? 
                          View(await _context.Tasks.ToListAsync()) :
                          Problem("Entity set 'TaskDataContext.Tasks'  is null.");
        }

        // GET: TaskTables/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var taskTable = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Task_Id == id);
            if (taskTable == null)
            {
                return NotFound();
            }

            return View(taskTable);
        }

        // GET: TaskTables/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TaskTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Task_Id,Task_Name,Task_Description,IsComplete,Task_Dedline")] TaskTable taskTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskTable);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskTable);
        }

        // GET: TaskTables/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var taskTable = await _context.Tasks.FindAsync(id);
            if (taskTable == null)
            {
                return NotFound();
            }
            return View(taskTable);
        }

        // POST: TaskTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Task_Id,Task_Name,Task_Description,IsComplete,Task_Dedline")] TaskTable taskTable)
        {
            if (id != taskTable.Task_Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskTableExists(taskTable.Task_Id))
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
            return View(taskTable);
        }

        // GET: TaskTables/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tasks == null)
            {
                return NotFound();
            }

            var taskTable = await _context.Tasks
                .FirstOrDefaultAsync(m => m.Task_Id == id);
            if (taskTable == null)
            {
                return NotFound();
            }

            return View(taskTable);
        }

        // POST: TaskTables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tasks == null)
            {
                return Problem("Entity set 'TaskDataContext.Tasks'  is null.");
            }
            var taskTable = await _context.Tasks.FindAsync(id);
            if (taskTable != null)
            {
                _context.Tasks.Remove(taskTable);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskTableExists(int id)
        {
          return (_context.Tasks?.Any(e => e.Task_Id == id)).GetValueOrDefault();
        }
    }
}
