using CallbacksTester.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;


namespace CallbacksTester.Controllers
{
    [Route("api/[controller]")]        
    [ApiController]
    public class CallbackController : ControllerBase
    {
        private readonly ILogger<CallbackController> _logger;

        public CallbackController(ILogger<CallbackController> logger)
        {
            _logger = logger;
        }

        [Route("200OK")]        
        public async Task<ActionResult> TwoHundredOK()
        {
            await LogHelper.LogRequest(Request,_logger);
            return Ok();
        }

        [Route("VariableStatusCode")]
        public async Task<ActionResult> VaribleStatusCode(int _code)
        {
            await LogHelper.LogRequest(Request, _logger);
            return StatusCode(_code);
        }

        [Route("Redirect302")]
        public async Task<ActionResult> Redirect302(string location)
        {
            await LogHelper.LogRequest(Request, _logger);
            return Redirect(location);
        }

        [Route("Redirect301")]
        public async Task<ActionResult> Redirect301(string location)
        {
            await LogHelper.LogRequest(Request, _logger);
            return RedirectPermanent(location);
        }

        [Route("Redirect308")]
        public async Task<ActionResult> Redirect308(string location)
        {
            await LogHelper.LogRequest(Request, _logger);
            return RedirectPermanentPreserveMethod(location);
        }

        [Route("Redirect307")]
        public async Task<ActionResult> Redirect307(string location)
        {
            await LogHelper.LogRequest(Request, _logger);
            return RedirectPreserveMethod(location);
        }

        [Route("Unauthorized401")]
        public async Task<ActionResult> Unauthorized401()
        {
            await LogHelper.LogRequest(Request, _logger);
            return Unauthorized();
        }

        [Route("UnauthorizedBasicAuth")]    
        public async Task<ActionResult> UnauthorizedBasicAuth()
        {
            await LogHelper.LogRequest(Request, _logger);            
            Response.Headers.Add("WWW-Authenticate", "Basic realm=\"MyRealm\"");            
            return Unauthorized();
            
        }

        [Route("UnauthorizedNTLMAuth")]
        public async Task<ActionResult> UnauthorizedNTLMAuth()
        {
            await LogHelper.LogRequest(Request, _logger);
            Response.Headers.Add("WWW-Authenticate", "NTLM");            
            return Unauthorized();

        }

        [Route("UnauthorizedNegotiateNTLMAuth")]
        public async Task<ActionResult> UnauthorizedNegotiateNTLMAuth()
        {
            await LogHelper.LogRequest(Request, _logger);
            Response.Headers.Add("WWW-Authenticate", "Negotiate, NTLM");            
            return Unauthorized();

        }

        [Route("Unauthorized403")]
        public async Task<ActionResult> Unauthorized403()
        {
            await LogHelper.LogRequest(Request, _logger);
            return StatusCode(403);
        }

        [Route("CustomResponse")]
        public async Task<ActionResult> CustomResponse(string? contenttype="text/plain")
        {
            await LogHelper.LogRequest(Request, _logger);
            string customresponse = System.IO.File.ReadAllText("CustomResponse.txt");
            Response.ContentType = contenttype;
            return Content(customresponse);
        }

        [Route("CustomResponseJson")]
        public async Task<ActionResult> CustomResponseJson()
        {
            await LogHelper.LogRequest(Request, _logger);
            string customresponse = System.IO.File.ReadAllText("CustomResponse.json");            
            //ControllerContext.HttpContext.Response.StatusCode = _code.GetValueOrDefault();
            Response.ContentType = "application/json";
            return Content(customresponse);
        }

        [Route("CustomResponseXML")]
        public async Task<ActionResult> CustomResponseXML()
        {
            await LogHelper.LogRequest(Request, _logger);
            string customresponse = System.IO.File.ReadAllText("CustomResponse.xml");
//            ControllerContext.HttpContext.Response.StatusCode = _code.GetValueOrDefault();
            Response.ContentType = "text/xml";
            return Content(customresponse);
        }

        [Route("CustomResponseHTML")]
        public async Task<ActionResult> CustomResponseHTML()
        {
            await LogHelper.LogRequest(Request, _logger);
            string customresponse = System.IO.File.ReadAllText("CustomResponse.html");
            //ControllerContext.HttpContext.Response.StatusCode = _code.GetValueOrDefault();
            Response.ContentType = "text/html";
            return Content(customresponse);
        }
    }
}
