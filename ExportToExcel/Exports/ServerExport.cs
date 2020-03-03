using EF_CONFIG.Data;
using EF_CONFIG.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CONFIG.Exports
{
    public class ServerExport
    {
        private readonly DataContext DataContext;
        private Data_Services Data_Services;

        public ServerExport(DataContext DataContext)
        {
            this.DataContext = DataContext;
            Data_Services = new Data_Services(this.DataContext);
        }

        public string Create_ExcelFile(DateTime date)
        {
            try
            {
                // save all data to desktop
                string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                IEnumerable<string> folderList = Directory.EnumerateDirectories(desktop_path);

                string main_folder = $"{desktop_path}\\ECheckListFiles";
                if (!folderList.Contains(main_folder))
                {
                    Directory.CreateDirectory(main_folder);
                }

                IEnumerable<string> month_folders = Directory.EnumerateDirectories(main_folder);

                string current_month = date.ToString("MM_yyyy");

                string current_month_folder = $"{main_folder}\\{current_month}";

                if (!month_folders.Contains(current_month))
                {
                    Directory.CreateDirectory(current_month_folder);
                }

                string fileName = $"{date.ToString("dd_MM_yyyy")}.xlsx";

                string[] files = Directory.GetFiles(current_month_folder, "*.xlsx");

                string FullFileName = $"{current_month_folder}\\{fileName}";

                if (!files.Contains(FullFileName))
                {
                    Create_ExcelFile(FullFileName, date);
                }

                return FullFileName;
            }
            catch (Exception e)
            { return null; }
        }

        public string Create_ExcelFile()
        {
            try
            {
                // save all data to desktop
                string desktop_path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                IEnumerable<string> folderList = Directory.EnumerateDirectories(desktop_path);

                string main_folder = $"{desktop_path}\\ECheckListFiles";
                if (!folderList.Contains(main_folder))
                {
                    Directory.CreateDirectory(main_folder);
                }

                IEnumerable<string> month_folders = Directory.EnumerateDirectories(main_folder);

                string current_month = DateTime.Now.ToString("MM_yyyy");

                string current_month_folder = $"{main_folder}\\{current_month}";

                if (!month_folders.Contains(current_month))
                {
                    Directory.CreateDirectory(current_month_folder);
                }

                string fileName = $"{DateTime.Now.ToString("dd_MM_yyyy")}.xlsx";

                string[] files = Directory.GetFiles(current_month_folder, "*.xlsx");

                string FullFileName = $"{current_month_folder}\\{fileName}";

                if (!files.Contains(FullFileName))
                {
                    Create_ExcelFile(FullFileName, DateTime.Now);
                }

                return FullFileName;
            }
            catch (Exception e)
            { return null; }
        }

        private void Create_ExcelFile(string path, DateTime date)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                excelPackage.Workbook.Protection.LockStructure = true;
                excelPackage.Workbook.Protection.LockWindows = true;
                excelPackage.Workbook.Protection.SetPassword("echecklist");

                foreach (var item in ECheckingItem.ECheckAreaArray)
                {
                    CreateNewSheet(item, excelPackage, date);
                }
                foreach (var sheet in excelPackage.Workbook.Worksheets)
                {
                    sheet.Protection.IsProtected = true;
                    sheet.Protection.SetPassword("echecklist");
                }
                FileInfo excelFile = new FileInfo(path);
                //save the changes
                excelPackage.SaveAs(excelFile);
            }
        }

        private void CreateNewSheet(ECheckAreaDef area, ExcelPackage excelPackage, DateTime date)
        {
            string sheetName = "";
            string sheetHeader = "";
            string sheetDate = $"Ngày: {date.ToString("dd/ MM/ yyyy")}";

            List<ECheckItemDef> CheckItem = new List<ECheckItemDef>();

            switch (area)
            {
                case ECheckAreaDef.ROOM_31:
                    sheetName = $"PM 3.1";
                    sheetHeader = @"CHECKLIST KIỂM TRA PHÒNG MÁY HKH9103-1";
                    CheckItem.AddRange(ECheckingItem.Room_31_32);
                    break;

                case ECheckAreaDef.ROOM_32:
                    sheetName = $"PM 3.2";
                    sheetHeader = @"CHECKLIST KIỂM TRA PHÒNG MÁY HKH9103-2";
                    CheckItem.AddRange(ECheckingItem.Room_31_32);
                    break;

                case ECheckAreaDef.POWER_ROOM_T3:
                    sheetName = $"P.Nguon T3";
                    sheetHeader = @"CHECKLIST KIỂM TRA PHÒNG NGUỒN + PHÒNG ACCU TẦNG 3";
                    CheckItem.AddRange(ECheckingItem.PowerRoomT3);
                    break;

                case ECheckAreaDef.POWER_ROOM_T1:
                    sheetName = $"P.Nguon T1";
                    sheetHeader = @"CHECKLIST KIỂM TRA PHÒNG NGUỒN TẦNG 1";
                    CheckItem.AddRange(ECheckingItem.PowerRoomT1);
                    break;

                case ECheckAreaDef.GENERATOR:
                    sheetName = $"MPĐ";
                    sheetHeader = @"CHECKLIST KIỂM TRA MÁY PHÁT ĐIỆN";
                    CheckItem.AddRange(ECheckingItem.Generator);
                    break;

                case ECheckAreaDef.L_H_VOLTAGE_TRANSFORMER:
                    sheetName = $"Day nha TBA";
                    sheetHeader = @"CHECKLIST KIỂM TRA DÃY NHÀ TRẠM BIẾN ÁP";
                    CheckItem.AddRange(ECheckingItem.LHVoltage);
                    break;

                case ECheckAreaDef.LAB_ROOM:
                    sheetName = $"Phong Lab";
                    sheetHeader = @"CHECKLIST KIỂM TRA PHÒNG LAB VÀ PHÒNG ACCU ";
                    CheckItem.AddRange(ECheckingItem.LabRoom);
                    break;

                default:
                    break;
            }
            var sheet = excelPackage.Workbook.Worksheets.Add(sheetName);
            // setup column width
            sheet.Column(1).Width = 46;
            sheet.Column(1).Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;

            //var namedStyle = excelPackage.Workbook.Styles.CreateNamedStyle("HyperLink");
            //namedStyle.Style.Font.Name = "Times New Roman";
            //namedStyle.Style.Font.Color.SetColor(Color.Blue);

            int headersize = 20;
            int titlesize = 13;
            int textsize = 14;

            ExcelRange header = sheet.Cells["A1:Y1"];
            ExcelRange contentHeader = sheet.Cells["A2:A4"];
            ExcelRange TimeHeader = sheet.Cells["B2:Y2"];

            header.Merge = true;
            contentHeader.Merge = true;
            TimeHeader.Merge = true;

            sheet.Row(1).Height = 45;
            sheet.Row(2).Height = 25;
            sheet.Row(3).Height = 25;
            sheet.Row(4).Height = 25;

            header.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Medium);
            contentHeader.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Medium);

            header.Value = sheetHeader;
            contentHeader.Value = "Nội dung kiểm tra";
            TimeHeader.Value = sheetDate;

            header.Style.Font.Size = headersize;
            TimeHeader.Style.Font.Size = titlesize;
            contentHeader.Style.Font.Size = titlesize;

            header.Style.Font.Bold = true;
            TimeHeader.Style.Font.Bold = true;
            contentHeader.Style.Font.Bold = true;

            //
            TimeHeader.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            header.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            contentHeader.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;

            //
            TimeHeader.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Medium);


            List<string> ItemList = new List<string>();

            using (var datacontext = new DataContext())
            {
                foreach (var item in CheckItem)
                {
                    var CItem = datacontext.ECheckItem.Where(i => i.ECheckItemCode == (int)item).First();
                    ItemList.Add(CItem.CheckName);
                }
            }

            int ContinueRow = 0;

            for (int i = 0; i < ItemList.Count; i++)
            {
                sheet.Row(i + 5).Height = 45;
                var cell = sheet.Cells[i + 5, 1];
                cell.Value = ItemList[i];
                cell.Style.WrapText = true;
                cell.Style.Font.Size = 14;
                sheet.Cells[i + 5, 1, i + 5, 25].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;

                ContinueRow = i + 5;
            }
            ContinueRow++;

            sheet.Cells[$"A{ContinueRow}"].Style.Border.Top.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
            sheet.Cells[$"A{ContinueRow}"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Cells[$"A{ContinueRow + 1}"].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Thin;
            sheet.Cells[$"A{ContinueRow + 1}"].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;

            sheet.Cells[$"A{ContinueRow}"].Style.Font.Size = 14;
            sheet.Cells[$"A{ContinueRow + 1}"].Style.Font.Size = 14;

            //Note 
            sheet.Cells[$"B{ContinueRow + 1}:Y{ ContinueRow + 1}"].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Top;
            sheet.Cells[$"B{ContinueRow + 1}:Y{ ContinueRow + 1}"].Merge = true;

            sheet.Row(ContinueRow).Height = 87;
            sheet.Cells[$"A{ContinueRow}"].Value = "Ký xác nhận\r\n(Ghi rõ họ và tên)";

            sheet.Row(ContinueRow + 1).Height = 87;
            sheet.Cells[$"A{ContinueRow + 1}"].Value = "Ghi chú \r\n(Ghi rõ thông tin trường hợp NOT OK)";


            int timevalue = 0;
            for (int i = 2; i <= 25; i += 2)
            {
                sheet.Column(i).Width = 8.5;
                sheet.Column(i + 1).Width = 8.5;

                ExcelRange checktime = sheet.Cells[3, i, 3, i + 1];

                checktime.Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Medium);
                checktime.Merge = true;
                checktime.Value = $"{timevalue}h";
                checktime.Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
                checktime.Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
                checktime.Style.Font.Bold = true;
                checktime.Style.Font.Size = titlesize;

                sheet.Cells[4, i, ContinueRow - 1, i].Style.Border.Left.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;
                sheet.Cells[4, i, ContinueRow - 1, i].Style.Border.Right.Style = OfficeOpenXml.Style.ExcelBorderStyle.Dotted;

                sheet.Cells[4, i, 4, i + 1].Style.Border.Bottom.Style = OfficeOpenXml.Style.ExcelBorderStyle.Medium;

                sheet.Cells[4, i].Value = "OK";
                sheet.Cells[4, i].Style.Font.Bold = true;
                sheet.Cells[4, i + 1].Value = "NOK";
                sheet.Cells[4, i + 1].Style.Font.Bold = true;

                sheet.Cells[ContinueRow, i, ContinueRow, i + 1].Merge = true;
                sheet.Cells[ContinueRow, i, ContinueRow, i + 1].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Medium);

                timevalue += 2;
            }

            sheet.Cells[1, 1, ContinueRow + 1, 25].Style.WrapText = true;

            sheet.Cells[1, 1, ContinueRow + 1, 25].Style.Border.BorderAround(OfficeOpenXml.Style.ExcelBorderStyle.Medium);
            sheet.Cells[1, 1, ContinueRow + 1, 25].Style.Font.Name = "Times New Roman";
            sheet.Cells[1, 1, ContinueRow + 1, 25].Style.VerticalAlignment = OfficeOpenXml.Style.ExcelVerticalAlignment.Center;
            sheet.Cells[1, 1, ContinueRow + 1, 25].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Center;
            sheet.Cells[5, 1, ContinueRow + 1, 1].Style.HorizontalAlignment = OfficeOpenXml.Style.ExcelHorizontalAlignment.Left;
        }

        public bool UpdateToExcel(ECheckSubmit AreaData, string path)
        {
            FileInfo CurrentExcel = new FileInfo(path);
            DateTime Time = DateTime.Now;
            int currentHour = Time.Hour;
            int Area_Id = AreaData.Area_Id;
            int Person_Id = AreaData.CheckPerson_Id;


            try
            {
                var ECheckPerson = Data_Services.Get_CheckPerson(Person_Id);

                using (ExcelPackage excelPackage = new ExcelPackage(CurrentExcel, "echecklist"))
                {
                    ExcelWorksheet currentSheet = excelPackage.Workbook.Worksheets[Area_Id];

                    for (int checkItem = 0; checkItem < AreaData.CheckItems.Count; checkItem++)
                    {
                        int currentTime = 0;
                        for (int timeLine = 0; timeLine < 12; timeLine++)
                        {
                            if (currentHour == 0 && timeLine == 0)
                            {
                                currentTime = 0;
                                if (AreaData.CheckItems[checkItem].Status == 0xFF)
                                {
                                    currentSheet.Cells[checkItem + 5, 1].Value = "X";
                                    currentSheet.Cells[checkItem + 5, 1].Style.Font.Bold = true;

                                    currentSheet.Cells[checkItem + 5, 2].Value = string.Empty;
                                }
                                else
                                {
                                    currentSheet.Cells[checkItem + 5, 1].Value = string.Empty;

                                    currentSheet.Cells[checkItem + 5, 2].Value = "X";
                                    currentSheet.Cells[checkItem + 5, 2].Style.Font.Bold = true;

                                }
                            }
                            else
                            {
                                if (currentHour / 2 == timeLine)
                                {
                                    currentTime = timeLine * 2 + 2;
                                    if (AreaData.CheckItems[checkItem].Status == 0xFF)
                                    {
                                        currentSheet.Cells[checkItem + 5, timeLine * 2 + 2].Value = "X";
                                        currentSheet.Cells[checkItem + 5, timeLine * 2 + 2].Style.Font.Bold = true;

                                        currentSheet.Cells[checkItem + 5, timeLine * 2 + 1 + 2].Value = string.Empty;
                                    }
                                    else
                                    {
                                        currentSheet.Cells[checkItem + 5, timeLine * 2 + 2].Value = string.Empty;

                                        currentSheet.Cells[checkItem + 5, timeLine * 2 + 1 + 2].Value = "X";
                                        currentSheet.Cells[checkItem + 5, timeLine * 2 + 1 + 2].Style.Font.Bold = true;
                                    }
                                }
                            }
                        }
                        if (ECheckPerson != null)
                            currentSheet.Cells[AreaData.CheckItems.Count + 5, currentTime].Value = ECheckPerson.Name;
                    }

                    excelPackage.Save();
                }
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string Update_Database(ECheckSubmit AreaData)
        {
            string Excp = string.Empty;
            Data_Services Data_Services = new Data_Services(DataContext);

            try
            {
                var area = Data_Services.Get_ECheckArea(AreaData.Area_Id);

                if (area == null)
                    return $"Can not find aread with id {AreaData.Area_Id}";

                if (area.ECheckings.Count != AreaData.CheckItems.Count)
                    return $"Total items not equal";

                var person = Data_Services.Get_CheckPerson(AreaData.CheckPerson_Id);
                if (person == null)
                    return $"Can not find person Id: {AreaData.CheckPerson_Id}";


                ESubmit ESubmit = new ESubmit
                {
                    AreaId = area.id,
                    PersonId = person.id,
                    Date = DateTime.Now,
                    UpdateTime = DateTime.Now.ToString("hh:mm tt, dd/MM/yy"),
                };

                // update new esubmit 
                Data_Services.Update_ESubmit(ESubmit);

                foreach (var item in AreaData.CheckItems)
                {
                    var CheckItem = Data_Services.Get_ECheckItem(item.Item);

                    var submit_data = new ECheckingDaily
                    {
                        ECheckAreaCode = area.AreaCode,
                        ECheckAreaId = area.id,
                        ECheckItemId = CheckItem.id,
                        ECheckItemCode = CheckItem.ECheckItemCode,
                        Status = item.Status,
                        Time = DateTime.Now,
                        CheckingPersonId = person.id,
                        ESubmitId = ESubmit.Id,
                    };

                    if (item.Status == 0x00)
                        submit_data.ECheckNotesId = item.Note;

                    if (!Data_Services.Update_ECheckDaily(submit_data))
                        Excp = $"Error when add item {item.Item} to database";
                }

                return Excp;
            }
            catch (Exception ex)
            { return ex.ToString(); }
        }

        public string ExportToExcel(ExcelPackage excelPackage, DateTime Date, ECheckAreaDef area)
        {
            try
            {
                string update_log = string.Empty;

                var submits = Data_Services.GetSubmitOnDate(Date, area);
                string areaNotes = string.Empty;

                foreach (var item in submits)
                {
                    bool excp = UpdateToExcel(item, excelPackage, ref areaNotes);

                    string update_excp = excp ? "Successfull" : "Fail";
                    update_log += $"Update submit: [area id: {item.AreaId}], " +
                        $"[person id:{item.PersonId}], [date: {item.UpdateTime}], [Update: {update_excp}]\r\n";

                }
                return update_log;
            }
            catch
            {
                return "Exception throw when export data to excel file\r\n";
            }
        }

        public bool UpdateToExcel(ESubmit ESubmit, ExcelPackage excelPackage, ref string Notes)
        {
            DateTime Time = ESubmit.Date;
            int currentHour = Time.Hour;
            int Area_Id = ESubmit.AreaId;
            int Person_Id = ESubmit.PersonId;

            try
            {
                var ECheckPerson = Data_Services.Get_CheckPerson(Person_Id);

                ExcelWorksheet currentSheet = excelPackage.Workbook.Worksheets[Area_Id];

                int currentTime = 0;
                bool reset_note_text = false;
                ExcelRange NoteCell;

                for (int checkItem = 0; checkItem < ESubmit.ECheckingDailys.Count; checkItem++)
                {
                    bool add_note = false;
                    for (int timeLine = 0; timeLine < 12; timeLine++)
                    {
                        if (currentHour == 0 && timeLine == 0)
                        {
                            currentTime = 0;
                            if (!reset_note_text)
                            {
                                currentSheet.Cells[ESubmit.ECheckingDailys.Count + 6, currentTime].Value = "";
                            }


                            reset_note_text = true;
                            if (ESubmit.ECheckingDailys[checkItem].Status == 0xFF)
                            {
                                currentSheet.Cells[checkItem + 5, 1].Value = "X";
                                currentSheet.Cells[checkItem + 5, 1].Style.Font.Bold = true;

                                currentSheet.Cells[checkItem + 5, 2].Value = string.Empty;
                            }
                            else
                            {
                                currentSheet.Cells[checkItem + 5, 1].Value = string.Empty;

                                currentSheet.Cells[checkItem + 5, 2].Value = "X";
                                currentSheet.Cells[checkItem + 5, 2].Style.Font.Bold = true;
                                add_note = true;

                            }
                        }
                        else
                        {
                            bool update = false;
                            if (currentHour / 2 == timeLine)
                            {
                                currentTime = timeLine * 2 + 2;
                                update = true;
                            }
                            else
                            if (currentHour == timeLine * 2 + 1)
                            {
                                currentTime = timeLine * 2 + 1;
                                update = true;
                            }

                            if (update)
                            {
                                if (!reset_note_text)
                                {
                                    currentSheet.Cells[ESubmit.ECheckingDailys.Count + 6, currentTime].Value = "";
                                }
                                reset_note_text = true;

                                if (ESubmit.ECheckingDailys[checkItem].Status == 0xFF)
                                {
                                    currentSheet.Cells[checkItem + 5, timeLine * 2 + 2].Value = "X";
                                    currentSheet.Cells[checkItem + 5, timeLine * 2 + 2].Style.Font.Bold = true;

                                    currentSheet.Cells[checkItem + 5, timeLine * 2 + 1 + 2].Value = string.Empty;
                                }
                                else
                                {
                                    currentSheet.Cells[checkItem + 5, timeLine * 2 + 2].Value = string.Empty;

                                    currentSheet.Cells[checkItem + 5, timeLine * 2 + 1 + 2].Value = "X";
                                    currentSheet.Cells[checkItem + 5, timeLine * 2 + 1 + 2].Style.Font.Bold = true;
                                    add_note = true;
                                }
                            }
                        }
                    }

                    if (add_note)
                    {
                        add_note = false;
                        int? note = ESubmit.ECheckingDailys[checkItem].ECheckNotesId;
                        if (note != null)
                        {
                            var ENote = Data_Services.Get_ECheckNote((int)note);

                            NoteCell = currentSheet.Cells[ESubmit.ECheckingDailys.Count + 6, 2];

                            string text = Notes;

                            text = $"{text}  [{ESubmit.Date.ToString("HH:mm")}->{ENote.NoteName}]";
                            NoteCell.Value = text;
                            Notes = text;
                        }

                    }
                }


                if (ECheckPerson != null)
                    currentSheet.Cells[ESubmit.ECheckingDailys.Count + 5, currentTime].Value = ECheckPerson.Name;

                excelPackage.Save();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public string ExportToExcel(DateTime Date)
        {
            string ExportLog = string.Empty;
            try
            {
                var areas = Data_Services.Get_ECheckAreas();
                if (areas == null)
                    return null;

                string FilePath = Create_ExcelFile(Date);

                FileInfo CurrentExcel = new FileInfo(FilePath);

                using (ExcelPackage excelPackage = new ExcelPackage(CurrentExcel))
                {
                    foreach (var area in areas)
                    {

                        string excp = ExportToExcel(excelPackage, Date, (ECheckAreaDef)area.id);

                        if (excp != null)
                            ExportLog += excp;
                    }
                    excelPackage.Save();
                }
                return ExportLog;
            }
            catch (Exception ex)
            {

                return null;
            }
        }
    }
}
