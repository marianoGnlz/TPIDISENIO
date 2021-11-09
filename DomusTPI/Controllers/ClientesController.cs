using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DomusTPI.Models;
using DomusTPITPI.Models;
using DomusTPI.IServices;

namespace DomusTPI.Controllers
{
    public class ClientesController : Controller
    {
        private readonly TPIContext _context;
        private readonly IClientesService _clientesService;

        public ClientesController(TPIContext context, IClientesService clientesService)
        {
            _context = context;
            _clientesService = clientesService;
        }

        public ActionResult<Request<IList<Cliente>>> GetClientes()
        {
            Request<IList<Cliente>> req = _clientesService.GetClientes();
            if (req.Success)
            {
                return Ok(req);
            }
            else
            {
                return BadRequest(req);
            }
        }
        public ActionResult<Request<Cliente>> GetCliente(int id)
        {
            Request<Cliente> req = _clientesService.GetCliente(id);
            if (req.Success)
            {
                return Ok(req);
            }
            else
            {
                return BadRequest(req);
            }
        }

        // GET: Clientes
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clientes.ToListAsync());
        }


        // GET: Clientes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes
                .FirstOrDefaultAsync(m => m.IdCliente == id);
            if (cliente == null)
            {
                return NotFound();
            }

            return View(cliente);
        }

        // GET: Clientes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Clientes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCliente,Tipo,NroCuenta,CUIT,RazonSocial,Nacionalidad,Domicilio,Nombre,Apellido,DNI,CUIL,FechaDeNacimiento,Telefono,Email")] Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);
        }

        // GET: Clientes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }
            return View(cliente);
        }

        // POST: Clientes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCliente,Tipo,NroCuenta,CUIT,RazonSocial,Nacionalidad,Domicilio,Nombre,Apellido,DNI,CUIL,FechaDeNacimiento,Telefono,Email")] Cliente cliente)
        {
            if (id != cliente.IdCliente)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cliente);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClienteExists(cliente.IdCliente))
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
            return View(cliente);
        }

        // GET: Clientes/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Request<Cliente> req = _clientesService.GetCliente((int) id);

            if (!req.Success)
            {
                return NotFound();
            }

            return View(req.Data);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            Request<Cliente> req = _clientesService.GetCliente((int)id);
            _context.Clientes.Remove(req.Data);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.IdCliente == id);
        }
    }
}
