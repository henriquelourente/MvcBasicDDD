using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MySample.Application.ViewModels;
using MySample.Presentation.Models;
using MySample.Application;

namespace MySample.Presentation.Controllers
{
    [Authorize]
    public class ClienteApiController : ApiController
    {
        private IClienteAppService _service;

        public ClienteApiController(IClienteAppService service)
        {
            _service = service;
        }

        // GET: api/ClienteApi
        public IEnumerable<ClienteViewModel> GetCliente()
        {
            return _service.GetAll();
        }

        // GET: api/ClienteApi/5
        [ResponseType(typeof(ClienteViewModel))]
        public IHttpActionResult GetCliente(Guid id)
        {
            ClienteViewModel cliente = _service.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            return Ok(cliente);
        }

        // PUT: api/ClienteApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCliente(Guid id, ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cliente.ClienteId)
            {
                return BadRequest();
            }

            try
            {
                _service.Update(cliente);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Exists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/ClienteApi
        [ResponseType(typeof(ClienteViewModel))]
        public IHttpActionResult PostCliente(ClienteViewModel cliente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                _service.Add(cliente);
            }
            catch (DbUpdateException)
            {
                if (Exists(cliente.ClienteId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = cliente.ClienteId }, cliente);
        }

        // DELETE: api/ClienteApi/5
        [ResponseType(typeof(ClienteViewModel))]
        public IHttpActionResult DeleteCliente(Guid id)
        {
            ClienteViewModel cliente = _service.GetById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _service.Remove(cliente);
     
            return Ok(cliente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _service.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Exists(Guid id)
        {
            return _service.GetById(id) != null;
        }
    }
}