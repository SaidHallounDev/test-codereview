using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using test_codereview.Models;
using test_codereview.Services;

namespace test_codereview.Controllers;

[ApiController]
[Route("api/[Controller]")]
public class CurrencyController : ControllerBase
{
    private readonly IRateService rateService;

    public CurrencyController(IRateService rateService)
    {
        this.rateService = rateService;
    }

    [HttpGet("GetRate/{currency}")]
    public async Task<IResult> GetRate([FromRoute] CurrencyTypes currency)
    {
        var rateResult = await this.rateService.GetCurrencyRate(currency);

        if (rateResult.IsFailure)
        {
            return Results.BadRequest();
        }

        return Results.Ok(rateResult);
    }
}


// TODO 
/*
 
ME QUEDE EN:
   - SUBIRLO A GITHUB
   
y luego:
- Un par de todos que deje
 

- ver video de milan de como manejar errores (ver en orden de fechas desde el mas viejo al mas nuevo):
    - https://www.youtube.com/watch?v=YBK93gkGRj8&t=611s
    - https://www.youtube.com/watch?v=uOEDM0c9BNI&t=7s
    - https://www.youtube.com/watch?v=WCCkEe_Hy2Y
    - luego rematar con la lectura para ver si falto algo mas: https://www.milanjovanovic.tech/blog/functional-error-handling-in-dotnet-with-the-result-pattern

POR VER:

 - Sistema de Logging + seq
    - ver videos
		- https://www.youtube.com/watch?v=nVAkSBpsuTk
		- https://www.youtube.com/watch?v=mT8ZkXafuZk
		- https://www.youtube.com/watch?v=w7yDuoCLVvQ&t=193s
        - https://www.youtube.com/watch?v=TCiL3y2P4rA
        - ver Solve Logging as a Cross-Cutting Concern with MediatR
            https://www.youtube.com/watch?v=JVX9MMpO6pE&list=PLYpjLpq5ZDGu8RXq5HoLqTll3YLBr3PNY&index=9 
            para ver de que trata esto, no lo aplico, porque decidi no hacer esta api con Clean Architecture

 - Authorizacion y Permisos
 - BD con EF (Entity Framework)

 - handling globar error in apis: un ojazo a https://www.rfc-editor.org/rfc/rfc7807.html
   y videos de milan https://www.youtube.com/watch?v=WCCkEe_Hy2Y
   y https://www.youtube.com/watch?v=H3EbflpXVmo
   y https://www.youtube.com/watch?v=a1ye9eGTB98


-  healt checks: https://www.youtube.com/watch?v=4abSfjdzqms

 - CancelationToken: https://www.youtube.com/watch?v=bH8TfxVBzTg
*/