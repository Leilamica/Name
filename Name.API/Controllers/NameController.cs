using Microsoft.AspNetCore.Mvc;
using Name.model; // Assuming Info class is in this namespace
using Name.business; // Namespace containing InfoServices

namespace Name.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InfoController : ControllerBase
    {
        private readonly InfoServices _infoServices;

        public InfoController()
        {
            _infoServices = new InfoServices();
        }

        // GET: api/info
        [HttpGet]
        public ActionResult GetAllInfos()
        {
            var infos = _infoServices.GetAllInfos();
            return Ok(infos);
        }

        // POST: api/info
        [HttpPost]
        public ActionResult AddInfo([FromBody] Info info)
        {
            if (info == null)
            {
                return BadRequest("Info object is null");
            }

            if (_infoServices.AddInfo(info))
            {
                return CreatedAtAction(nameof(GetAllInfos), new { name = info.Name }, info);
            }
            else
            {
                return StatusCode(500, "Error adding info");
            }
        }

        // PATCH: api/info/{infoName}
        [HttpPatch("{infoName}")]
        public ActionResult UpdateInfo(string infoName, [FromBody] Info info)
        {
            if (info == null || info.Name != infoName)
            {
                return BadRequest("Info object or name mismatch");
            }

            if (_infoServices.UpdateInfo(info))
            {
                return Ok(info);
            }
            else
            {
                return StatusCode(500, $"Error updating info with name {infoName}");
            }
        }

        // DELETE: api/info/{infoName}
        [HttpDelete("{infoName}")]
        public ActionResult DeleteInfo(string infoName)
        {
            if (_infoServices.DeleteInfo(infoName))
            {
                return NoContent();
            }
            else
            {
                return StatusCode(500, $"Error deleting info with name {infoName}");
            }
        }
    }
}
