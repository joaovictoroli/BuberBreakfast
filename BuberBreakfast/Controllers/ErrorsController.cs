using Microsoft.AspNetCore.Mvc;

namespace BuberBreakfast.Controllers;

public class ErrorsController : ControllerBase
{
    [Route("/error")]
    public IActionResult Error() => Problem();

    // [Route("/error")]
    // public IActionResult Error() {
    //     return Problem();
    // }
}