using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using TestProj.Models;

namespace TestProj.Controllers
{

    public class HomeController : Controller
    {
        IConfiguration _configuration;

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        
        public IActionResult Index()

        {
            return View();
        }

        [Route("[action]")]
        [HttpPost]
        public async Task<IActionResult> PostCredential([FromBody]ViewModel viewModel)
        {
            HttpResponseMessage response;
            try
            {
                string url = "identity/connect/token";
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_configuration.GetValue<string>("Baseurl"));
                    client.DefaultRequestHeaders.Clear();
                    var requestBody = new List<KeyValuePair<string, string>>();
                    requestBody.Add(new KeyValuePair<string, string>("grant_type", viewModel.grant_type));
                    requestBody.Add(new KeyValuePair<string, string>("username", viewModel.username));
                    requestBody.Add(new KeyValuePair<string, string>("password", viewModel.password));
                    requestBody.Add(new KeyValuePair<string, string>("scope", viewModel.scope));
                    requestBody.Add(new KeyValuePair<string, string>("client_id", viewModel.client_id));
                    requestBody.Add(new KeyValuePair<string, string>("client_secret", viewModel.client_secret));
                    //  client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-form-urlencoded; charset=utf-8");                  
                    var request = new HttpRequestMessage(HttpMethod.Post, _configuration.GetValue<string>("Baseurl") + url)
                    {
                        Content = new System.Net.Http.FormUrlEncodedContent(requestBody)
                    };
                    response = await client.SendAsync(request);
                }
                return StatusCode((int)response.StatusCode, response.Content.ReadAsStringAsync().Result);
            }
            catch (Exception ex)
            {

                return new StatusCodeResult(500);
            }

        }

    }
}
