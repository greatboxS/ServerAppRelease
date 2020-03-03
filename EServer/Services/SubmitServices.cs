using EF_CONFIG.Data;
using EF_CONFIG.Exports;
using EF_CONFIG.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;
using System.IO;

namespace EServer.Services
{
    public class SubmitServices
    {
        private Data_Services Data_Services;
        public SubmitServices(DataContext DataContext, ECheckSubmit submit)
        {
            Data_Services = new Data_Services(DataContext);
            ServerExport ServerExport = new ServerExport(DataContext);
            try
            {
                Exception = ServerExport.Update_Database(submit);
                Success = true;
                AreadId = submit.Area_Id;
            }
            catch (Exception ex)
            {
                Success = false;
                Exception = ex.ToString();
            }
        }


        public string ReceivedObject { get; set; }
        public int AreadId { get; set; }
        public bool Success { get; set; }
        public string Exception { get; set; }
        public string UpdateTime { get; set; } = DateTime.Now.ToString("ddd, hh:MM tt, dd/MM/yyyy");
    }
}