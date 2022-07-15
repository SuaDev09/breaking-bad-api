using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using consumo_de_api.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace consumo_de_api.Controllers
{
    public class CharacterController : Controller
    {
        //Hosted web API REST Service base url
        string BaseUrl = "https://www.breakingbadapi.com/";

        public async Task<ActionResult> Index()
        {
            List<CharacterModel> Characters = new List<CharacterModel>();
            using (var client = new HttpClient())
            {
                //Passing service base url
                client.BaseAddress = new Uri(BaseUrl);
                client.DefaultRequestHeaders.Clear();

                //Define request data format
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //Sending request to find web api REST service resource GetAllCharacters using HttpClient
                HttpResponseMessage Res = await client.GetAsync("api/characters");

                //Checkinng the response is succesful or not which is sent using HttpClient
                if(Res.IsSuccessStatusCode)
                {
                    //Storing the response details recieved from web api
                    var ChaResponse = Res.Content.ReadAsStringAsync().Result;
                    //Deserializing the response recieved from web api and storing into the Character list
                    Characters = JsonConvert.DeserializeObject<List<CharacterModel>>(ChaResponse);
                }

                //Returning the Character list to view 
                return View(Characters);
            }

        }

        //// GET: Character
        //public ActionResult Index()
        //{
        //    return View();
        //}
    }
}