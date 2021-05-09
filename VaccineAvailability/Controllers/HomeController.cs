using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VaccineAvailability.Models;
using VaccineAvailability.Models.Data;
using AvailableCenter = VaccineAvailability.Models.AvailableCenter;

namespace VaccineAvailability.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private VaccineAvailabilityDBContext _dbContext = new VaccineAvailabilityDBContext();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //_dbContext = dbContext;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LoadData()
        {
            try
            {
                //var client = new RestClient("https://cdn-api.co-vin.in/api/v2/appointment/sessions/public/calendarByDistrict?district_id=165&date=08-05-2021");
                //client.Timeout = -1;
                //var request = new RestRequest(Method.GET);
                //IRestResponse response = client.Execute(request);
                //var data = JsonConvert.DeserializeObject<Root>(response.Content);

                var client1 = new RestClient("https://cdn-api.co-vin.in/api/v2/appointment/sessions/public/calendarByDistrict?district_id=776&date=08-05-2021");
                client1.Timeout = -1;
                var request1 = new RestRequest(Method.GET);
                IRestResponse response1 = client1.Execute(request1);
                var data1 = JsonConvert.DeserializeObject<Root>(response1.Content);

                //data1.centers.AddRange(data.centers);

                return PartialView("_GridPartial", data1);
            }
            catch(Exception ex)
            {
                return StatusCode(400, ex.Message);
            }
        }
        public IActionResult InsertAvailaibityTime()
        {
            var client = new RestClient("https://cdn-api.co-vin.in/api/v2/appointment/sessions/public/calendarByDistrict?district_id=776&date=08-05-2021");
            client.Timeout = -1;
            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);
            var data = JsonConvert.DeserializeObject<Root>(response.Content);

            string fileData = "";
            var listData = data.centers.Where(x => x.sessions.Count >1 &&  x.sessions[1].min_age_limit >= 45 && x.sessions[1].available_capacity > 0)
                .Select(x => new AvailableCenter
                {
                    Address = x.address,
                    PinCode = x.pincode,                    
                    AvailableVaccines = x.sessions[0].available_capacity,
                    CurrentDateTime = DateTime.Now,
                    Date = x.sessions[0].date,
                    District = x.district_name,
                    Id = x.center_id,
                    MinimumAge = x.sessions[0].min_age_limit,
                    Name = x.name,
                    State = x.state_name

                });
            foreach (var item in listData)
            {
                VaccineAvailability.Models.Data.AvailableCenter availableCenter = new Models.Data.AvailableCenter();
                availableCenter.Address = item.Address;
                availableCenter.Pincode = item.PinCode;
                availableCenter.AvailableVaccines = item.AvailableVaccines;
                availableCenter.CurrentDateTime = DateTime.Now;
                availableCenter.Date = Convert.ToDateTime(item.Date);
                availableCenter.District = item.District;
                availableCenter.Id = item.Id;
                availableCenter.MinimumAge = item.MinimumAge;
                availableCenter.Name = item.Name;
                availableCenter.State = item.State;
                _dbContext.AvailableCenter.Add(availableCenter);
            }
            //var result = _dbContext.AvailableCenter.Add(listData);

            //using (var mem = new MemoryStream())
            //using (var writer = new StreamWriter("E:\\VaccineAvailability\\VaccineAvailability\\vaccine_availability.csv"))
            //using (var csvWriter = new CsvWriter(writer))
            //{
            //    //csvWriter.Configuration.Delimiter = ";";
            //    csvWriter.Configuration.HasHeaderRecord = true;
            //    csvWriter.Configuration.AutoMap<AvailableCenter>();

            //    csvWriter.WriteHeader<AvailableCenter>();
            //    csvWriter.WriteRecords(listData);

                
            //    writer.Flush();
            //    //return File(mem.ToArray(), "text/csv", "E:\\PROJECT\\VaccineAvailability\\vaccine_availability.csv");
            //}

            //foreach (var center in data.centers)
            //{

            //    foreach (var session in center.sessions)
            //    {
            //        if (session.min_age_limit <= 20 /*&& session.available_capacity > 0*/)
            //        {
            //            fileData += session.date + " " + center.name + " " + center.address + " " + center.pincode + " " + session.available_capacity + " " + DateTime.Now.ToString() + "\t";
            //            fileData += "\n";
            //            AvailableCenter availableCenter = new AvailableCenter
            //            {
            //                Id = center.center_id,
            //                AvailableVaccines = session.available_capacity,
            //                Date = session.date,
            //                District = center.district_name,
            //                MinimumAge = session.min_age_limit,
            //                Name = center.name,
            //                State = center.state_name
            //            };                        
            //        }
            //    }
            //}
            //StreamWriter SW;
            //SW = System.IO.File.AppendText(@"E:\PROJECT\VaccineAvailability\Vaccine.txt");

            //SW.WriteLine(fileData + Environment.NewLine);
            //SW.Close();

            ///var item = data.centers.Where(x => x.sessions.Where(y=> y.min_age_limit <= 20 && y.available_capacity > 0).Any());

            return Ok();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
