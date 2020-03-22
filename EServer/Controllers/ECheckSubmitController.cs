using EF_CONFIG.Data;
using EF_CONFIG.Models;
using EServer.Services;
using EServer.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace ServerApp.Controllers
{
    public class ECheckSubmitController : ApiController
    {
        private readonly DataContext DataContext;
        private Data_Services Data_Services;
        public ECheckSubmitController()
        {
            DataContext = new DataContext();
            Data_Services = new Data_Services(DataContext);
        }

        [HttpPost]
        [Route("echecklist/post")]
        public IHttpActionResult ECheckListStation_Post([FromBody] ECheckSubmit ECheckSubmit)
        {
            SubmitServices submitServices = new SubmitServices(DataContext, ECheckSubmit);
            return Json(submitServices);
        }

        [HttpGet]
        [Route("area/{id}")]
        public IHttpActionResult Get_AreaData(int id)
        {
            return Json(Data_Services.Get_ECheckDaily(id));
        }

        [HttpGet]
        [Route("")]
        public IHttpActionResult HomePage()
        {
            //SubmitServices submitServices = new SubmitServices(new ECheckSubmit
            //{
            //    Area_Id = 1,
            //    CheckPerson_Id = 0,
            //    CheckItems = new List<EItem>()
            //});

            return Json("ECheck List API");
        }
    }
}
