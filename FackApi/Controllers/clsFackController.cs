using FackApi.Dto;
using FackBuisness;
using Microsoft.AspNetCore.Mvc;

namespace FackApi.Controllers
{
    [Route("Api/Fack")]
    [Controller]
    public class clsFackController : ControllerBase
    {


        [HttpGet]
        [ProducesResponseType(200)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<clsFackBuisness>> getFack()
        {
            try
            {
                return Ok(clsFackBuisness.getFacks());
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }

        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<clsFackBuisness> findFackByID(int id = 0)
        {

            try
            {
                clsFackBuisness clsFackBuisness = clsFackBuisness.findFackByID(id);
                if (clsFackBuisness == null)
                {
                    return NotFound("Fakc With ID Not Found");
                }

                return Ok(clsFackBuisness);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpPost()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<clsFackBuisness> saveFack([FromBody] clsFackDto fack)
        {
            clsFackBuisness _fackHolder;
            try
            {
                if (fack == null)
                    return BadRequest();

                if (fack.id != null && !clsFackBuisness.isExistByID(fack?.id ?? 0))
                    return NotFound();

                if (fack?.id == null && fack!.isHasNullValue)
                    return BadRequest();

                _fackHolder = fack?.id == null ? new clsFackBuisness() : clsFackBuisness.findFackByID(fack?.id ?? 0);
                _fackHolder.id = fack?.id == null ? null : fack.id;
                _fackHolder.name = string.IsNullOrEmpty(fack!.name) ? "" : fack.name;
                _fackHolder.job = string.IsNullOrEmpty(fack.job) ? "" : fack.job;
                _fackHolder.isDeleted = fack.isDeleted;
                return Ok(_fackHolder.save());

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


        [HttpDelete("{id:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<clsFackBuisness> saveFack(int id = 0)
        {
            try
            {

                if (!clsFackBuisness.isExistByID(id))
                    return NotFound();

                return Ok(clsFackBuisness.deleteFack(id));

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }


    }
}
