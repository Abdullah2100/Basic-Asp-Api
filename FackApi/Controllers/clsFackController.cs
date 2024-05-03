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
        public async Task<ActionResult<IEnumerable<clsFackBuisness>>> getFack()
        {
            try
            {

                return Ok(await clsFackBuisness.getFacks());

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);


            }

        }
    }
}
