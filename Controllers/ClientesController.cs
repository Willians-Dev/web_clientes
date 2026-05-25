using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_clientes.Data;
using web_clientes.Models;

namespace web_clientes.Controllers
{
    public class ClientesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClientesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ClientesController
        public IActionResult Index()
        {
            var clientes = _context.Clientes.ToList();
            return View(clientes);
        }

        // GET: ClientesController/Details/5
        public IActionResult Details(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: ClientesController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(cliente);
        }

        // GET: ClientesController/Edit/5
        public IActionResult Edit(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ClienteModel cliente)
        {
            if (id != cliente.id)
            {
                return BadRequest("No se encontró el cliente");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Clientes.Update(cliente);
                    _context.SaveChanges();

                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    var existeCliente = _context.Clientes.Any(c => c.id == id);

                    if (!existeCliente)
                    {
                        return NotFound();
                    }

                    throw;
                }
            }

            return View(cliente);
        }

        // GET: ClientesController/Delete/5
        public IActionResult Delete(int id)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id, IFormCollection collection)
        {
            var cliente = _context.Clientes.FirstOrDefault(c => c.id == id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}