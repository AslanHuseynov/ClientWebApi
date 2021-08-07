using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClientWebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class GeneralController : ControllerBase
    {
        
        [HttpPost]
        public Task InsertRecords()
        {
     
                var clientDbContext = new ClientDbContext();
                var array = Enumerable.Range(1980, 21);
                var random = new Random();
                var arrayForSurname = new[] {"შვილი", "იანი", "ძე", "ოვი", "ია", "ავა"};
            
                var nameArray = new[] { "ვალერი", "გოჩა", "ასლანი", "ანზორი", "მალხაზი", "ავთანდილი", "გიორგი", "მარი", "აშოტი", "გურამა", "ბერა", "ნათელა" };
                foreach (var VARIABLE in nameArray)
                {
                    var sixNumber = random.Next(100001, 999999);
                    var randomYear = random.Next(1980, 2000);
                    var randomMonth = random.Next(1, 12);
                    var randomDay = random.Next(1,31);
                    var randomForSurname = random.Next(0, arrayForSurname.Length);
                    var surnameSuffix = arrayForSurname[randomForSurname];
                    var client = new Client()
                    {
                        FirstName = VARIABLE,
                        LastName = VARIABLE + surnameSuffix,
                        PhoneNumber = $"555{sixNumber}",
                        BirthDate = new DateTime(randomYear, randomMonth, randomDay)
                    };
                    clientDbContext.Client.Add(client);
                    clientDbContext.SaveChanges();
                }
            
            
            
                return Task.CompletedTask;

        }
        
        [HttpGet]
        public ActionResult GetClient(int id)
        {
            
            var clientDbContext = new ClientDbContext();
            var desiredClients = clientDbContext.Client.Where(x => x.ID == id);
            var onlyClient = desiredClients.First();
            return Ok(onlyClient);
        }

        [HttpPut]
        public void UpdateClient(int id, string newPhoneNumber)
        {
            var clientDbContext = new ClientDbContext();
            var desiredClients = clientDbContext.Client.Where(x => x.ID == id);
            var onlyClient = desiredClients.First();
            onlyClient.PhoneNumber = newPhoneNumber;
            clientDbContext.SaveChanges();
        }
        

        [HttpPost]
        public Task InsertRecord(string firstName, string lastName, string phoneNumber, DateTime dateOfBirh)
        {
            var clientDbContext = new ClientDbContext();
            var client = new Client()
            {
                BirthDate = dateOfBirh,
                FirstName = firstName,
                LastName = lastName,
                PhoneNumber = phoneNumber
            };
            clientDbContext.Client.Add(client);
            clientDbContext.SaveChanges();
            return Task.CompletedTask;
        }

       

        [HttpDelete]
        public void DeleteClient(int id)
        {
            var clientDbContext = new ClientDbContext();
            var desiredClients = clientDbContext.Client.Where(x => x.ID == id);
            var onlyClient = desiredClients.First();
            clientDbContext.Remove(onlyClient);
            clientDbContext.SaveChanges();
        }
        
        //ლისტის წამოღება
        [HttpGet]
        public ActionResult GetAllClient()
        {
            var clientDbContext = new ClientDbContext();
            var desiredClients = clientDbContext.Client.ToList();
            return Ok(desiredClients);

        }

        [HttpGet]
        public ActionResult GetClientsByYear(int year)
        {
            var clientDbContext = new ClientDbContext();
            var desiredClients = clientDbContext.Client.Where(x => x.BirthDate.Year == year);
            return Ok(desiredClients);
            
        }
       
    }

}