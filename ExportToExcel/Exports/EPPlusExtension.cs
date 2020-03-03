using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml.Packaging;
using OfficeOpenXml.Table;
using System.IO;
using OfficeOpenXml;
using EF_CONFIG.Models;
using EF_CONFIG.Data;

namespace EF_CONFIG.Exports
{
    public class EPPlusExtension
    {
        public static string CreateNewReportFile(string destination, bool directly = false, bool open = false)
        {
            try
            {
                string newPath = "";
                IEnumerable<string> folderList = Directory.EnumerateDirectories(destination);

                if (folderList.Count() == 0)
                {
                    newPath = $"{destination}\\{DateTime.Now.ToString("MM_yyyy")}";
                    Directory.CreateDirectory(newPath);
                }

                bool foundFolder = false;
                foreach (var scheduleFilePath in folderList)
                {
                    Console.WriteLine(scheduleFilePath);

                    string fname = GetFolderName(scheduleFilePath);
                    if (fname != DateTime.Now.ToString("MM_yyyy"))
                        continue;

                    newPath = scheduleFilePath;
                    foundFolder = true;
                }

                if (!foundFolder)
                {
                    newPath = $"{destination}\\{DateTime.Now.ToString("MM_yyyy")}";
                    Directory.CreateDirectory(newPath);
                }

                if (directly)
                {
                    newPath = destination;
                }

                DirectoryInfo Directorys = new DirectoryInfo(newPath);//Assuming Test is your Folder
                FileInfo[] Files = Directorys.GetFiles("*.xlsx"); //Getting Text files

                string ExcelName = DateTime.Now.ToString("dd_MM_yyyy");

                if (Files != null)
                {
                    if (Files.Where(i => i.Name == $"{ExcelName}.xlsx").Count() > 0)
                    {
                        if (directly)
                        {
                            File.Delete(Files.Where(i => i.Name == $"{ExcelName}.xlsx").First().FullName);
                        }
                        else
                            return Files.Where(i => i.Name == $"{ExcelName}.xlsx").First().FullName;
                    }
                }

                string path = $"{newPath}\\{ExcelName}.xlsx";

                CreadFile(path);

                if (open)
                    System.Diagnostics.Process.Start(path);

                return path;
            }
            catch (Exception e)
            { return null; }
        }
        public static bool UpdateDataToExcel(AreaCollectedData data, string path)
        {
            try
            {
                string newPath = "";
                string CurrentExcelFile = "";
                IEnumerable<string> folderList = Directory.EnumerateDirectories(path);

                if (folderList.Count() == 0)
                {
                    newPath = $"{path}\\{DateTime.Now.ToString("MM_yyyy")}";
                    Directory.CreateDirectory(newPath);
                }

                bool foundFolder = false;
                foreach (var scheduleFilePath in folderList)
                {
                    Console.WriteLine(scheduleFilePath);

                    string fname = GetFolderName(scheduleFilePath);
                    if (fname != DateTime.Now.ToString("MM_yyyy"))
                        continue;

                    newPath = scheduleFilePath;
                    foundFolder = true;
                }

                if (!foundFolder)
                {
                    CurrentExcelFile = CreateNewReportFile(path, false, false);
                }
                else
                {
                    DirectoryInfo Directorys = new DirectoryInfo(newPath);//Assuming Test is your Folder
                    FileInfo[] Files = Directorys.GetFiles("*.xlsx"); //Getting Text files

                    string ExcelName = DateTime.Now.ToString("dd_MM_yyyy");

                    if (Files != null)
                    {
                        if (Files.Where(i => i.Name == $"{ExcelName}.xlsx").Count() > 0)
                        {
                            CurrentExcelFile = Files.Where(i => i.Name == $"{ExcelName}.xlsx").First().FullName;
                        }
                        else
                            CurrentExcelFile = CreateNewReportFile(path, false, false);
                    }
                    else
                    {
                        CurrentExcelFile = CreateNewReportFile(path, false, false);
                    }
                }

                //FileInfo CurrentExcel = new FileInfo(CurrentExcelFile);

                UpdateExcectlyToExcel(data, CurrentExcelFile);

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static bool UpdateExcectlyToExcel(AreaCollectedData data, string path)
        {
            FileInfo CurrentExcel = new FileInfo(path);
            DateTime Time = DateTime.Now;
            int currentHour = Time.Hour;
            try
            {
                using (ExcelPackage excelPackage = new ExcelPackage(CurrentExcel))
                {
                    for (int i = 0; i < data.CheckAreas.Count; i++)
                    {
                        var area = data.CheckAreas[i];

                        ExcelWorksheet currentSheet = excelPackage.Workbook.Worksheets[i + 1];

                        if (area.Exception != Exception_t.RESP_OK)
                            continue;

                        for (int checkItem = 0; checkItem < area.ItemDatas.Count; checkItem++)
                        {
                            int currentTime = 0;
                            for (int timeLine = 0; timeLine < 12; timeLine++)
                            {
                                if (currentHour == 0 && timeLine == 0)
                                {
                                    currentTime = 0;
                                    if (area.ItemDatas[checkItem].Status == 0xFF)
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
                                        if (area.ItemDatas[checkItem].Status == 0xFF)
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

                            if (area.Person != null)
                                currentSheet.Cells[area.ItemDatas.Count + 5, currentTime].Value = area.Person.Name;
                        }
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
        private static void CreadFile(string path)
        {
            using (ExcelPackage excelPackage = new ExcelPackage())
            {
                foreach (var item in ECheckingItem.ECheckAreaArray)
                {
                    CreateNewSheet(item, excelPackage);
                }

                FileInfo excelFile = new FileInfo(path);
                //save the changes
                excelPackage.SaveAs(excelFile);
            }
        }
        private static string GetFolderName(string folderPath)
        {
            try
            {
                string[] buf = folderPath.Split(new string[1] { "\\" }, StringSplitOptions.None);
                string name = buf[buf.Length - 1];
                return name;
            }
            catch { return null; }
        }

        private static void CreateNewSheet(ECheckAreaDef area, ExcelPackage excelPackage)
        {


            string sheetName = "";
            string sheetHeader = "";
            string sheetDate = $"Ngày: {DateTime.Now.ToString("dd/ MM/ yyyy")}";

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
    }
}
