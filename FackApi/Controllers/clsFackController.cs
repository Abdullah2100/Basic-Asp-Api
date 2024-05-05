using FackApi.Dto;
using FackApi.Global;
using FackBuisness;
using Microsoft.AspNetCore.Mvc;

namespace FackApi.Controllers
{
    [Route("Api/Fack")]
    [Controller]
    public class clsFackController : ControllerBase
    {

        [HttpGet()]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<clsFackBuisness>> getFacks()
        {

            try
            {
                var facks = clsFackBuisness.getFacks();

                if (facks.Count == 0)
                {
                    return (new List<clsFackBuisness> { });
                }
                facks.ForEach(f =>
                {
                    f.image = getImage(f.image);
                });

                return Ok(facks);
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
                clsFackBuisness.image = getImage(clsFackBuisness.image);
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

        [NonAction]
        public string getImage(string image)
        {

            try
            {
                if (Util.isExistFile(image))
                    return Util.hostUrl + image.Replace("\\", "/").ToString();
                return "";
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error is : " + ex.Message);
                return "";
            }
        }


        [HttpPost()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(500)]
        public ActionResult<clsFackBuisness> createFack([FromForm] clsFackDto fack)
        {
            clsFackBuisness _fackHolder;
            try
            {
                if (fack == null)
                    return BadRequest();

                if (fack!.isHasNullValue())
                    return BadRequest();


                _fackHolder = new clsFackBuisness();
                _fackHolder.name = string.IsNullOrEmpty(fack!.name) ? "" : fack.name;
                _fackHolder.job = string.IsNullOrEmpty(fack.job) ? "" : fack.job;
                _fackHolder.isDeleted = fack.isDeleted;

                if (fack.image != null)
                {
                    string image = Util.saveFile(fack.image);
                    if (string.IsNullOrEmpty(image))
                        return StatusCode(500, "Could not Save Image");
                    _fackHolder.image = image;
                }
                _fackHolder.save();
                _fackHolder.image = getImage(_fackHolder.image);

                return Ok(_fackHolder);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



        [HttpPut()]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        [ProducesResponseType(500)]
        public ActionResult<clsFackBuisness> updateFack([FromForm] clsUpdateFackDto fack)
        {
            clsFackBuisness _fackHolder;
            try
            {
                if (fack == null)
                    return BadRequest();

                if (fack.id != null && !clsFackBuisness.isExistByID(fack?.id ?? 0))
                    return NotFound();


                _fackHolder = fack?.id == null ? new clsFackBuisness() : clsFackBuisness.findFackByID(fack?.id ?? 0);
                _fackHolder.id = fack?.id == null ? null : fack.id;
                _fackHolder.name = string.IsNullOrEmpty(fack!.name) ? "" : fack.name;
                _fackHolder.job = string.IsNullOrEmpty(fack.job) ? "" : fack.job;
                _fackHolder.isDeleted = fack.isDeleted;

                if (fack.image != null)
                {
                    if (_fackHolder.image != null)
                    {
                        Util.deletedFile(_fackHolder.image);
                    }
                    string image = Util.saveFile(fack.image);
                    if (string.IsNullOrEmpty(image))
                        return StatusCode(500, "Could not Save Image");
                    _fackHolder.image = image;

                }
                _fackHolder.save();
                _fackHolder.image = getImage(_fackHolder.image);
                return Ok(_fackHolder);

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
        public ActionResult<clsFackBuisness> deleteFack(int id = 0)
        {
            try
            {

                clsFackBuisness fack = clsFackBuisness.findFackByID(id);
                if (fack != null)
                    return NotFound();

                if (clsFackBuisness.deleteFack(id))
                {
                    Util.deletedFile(fack.image);

                    return Ok("Okay");
                }
                return StatusCode(500, "Server Error");
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }



    }
}
