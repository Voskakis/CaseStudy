using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using BackLayers.DAL;
using BackLayers.Models;

namespace BackLayers.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class MyUsersController : ApiController
    {
        private DatabaseContext db = new DatabaseContext();

        // GET: api/MyUsers
        public IQueryable<MyUser> GetUsers()
        {
            return db.Users;
        }

        // GET: api/MyUsers/5
        [ResponseType(typeof(MyUser))]
        public IHttpActionResult GetMyUser(string id)
        {
            MyUser myUser = db.Users.Find(id);
            if (myUser == null)
            {
                return NotFound();
            }

            return Ok(myUser);
        }

        // PUT: api/MyUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMyUser(string id, MyUser myUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != myUser.MyUserId)
            {
                return BadRequest();
            }

            db.Entry(myUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MyUserExists(id))
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

        // POST: api/MyUsers
        [ResponseType(typeof(MyUser))]
        public IHttpActionResult PostMyUser(MyUser myUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Users.Add(myUser);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (MyUserExists(myUser.MyUserId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = myUser.MyUserId }, myUser);
        }

        // DELETE: api/MyUsers/5
        [ResponseType(typeof(MyUser))]
        public IHttpActionResult DeleteMyUser(string id)
        {
            MyUser myUser = db.Users.Find(id);
            if (myUser == null)
            {
                return NotFound();
            }

            db.Users.Remove(myUser);
            db.SaveChanges();

            return Ok(myUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MyUserExists(string id)
        {
            return db.Users.Count(e => e.MyUserId == id) > 0;
        }
    }
}