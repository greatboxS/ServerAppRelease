using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_CONFIG.Models;

namespace EF_CONFIG.Data
{
    public class DataBaseInitialize
    {
        public static bool Begin()
        {
            using (var DataContext = new DataContext())
            {
                if (DataContext != null)
                {
                    if (!DataContext.Database.Exists())
                    {
                        Console.WriteLine("Creating database");

                        DataContext.Database.Create();

                        DataContext.Database.ExecuteSqlCommand("DROP TABLE [__MigrationHistory]");
                        DataContext.SaveChanges();

                        AddNewCheckNotes(DataContext);

                        Console.WriteLine("Add New Check Item");
                        AddNewCheckItem(DataContext);

                        Console.WriteLine("Add new area");
                        AddNewECheckArea(DataContext);

                        Console.WriteLine("Add new checking person");
                        AddNewCheckingPerson(DataContext);

                        Console.WriteLine("Config Echecking");
                        ConfigECheckArea(DataContext);

                        Console.WriteLine("Creating database complete");

                        return true;
                    }
                }
                return false;
            }
        }

        private static void AddNewCheckNotes( DataContext DataContext)
        {
            DataContext.ECheckNotes.AddRange( new ECheckNotes[]
            {
                new ECheckNotes{ NoteName="1" },
                new ECheckNotes{ NoteName="2" },
                new ECheckNotes{ NoteName="3" },
                new ECheckNotes{ NoteName="4" },
                new ECheckNotes{ NoteName="5" },
                new ECheckNotes{ NoteName="6" },
                new ECheckNotes{ NoteName="7" },
                new ECheckNotes{ NoteName="8" },
                new ECheckNotes{ NoteName="9" },
                new ECheckNotes{ NoteName="9" },
            });
            DataContext.SaveChanges();
        }

        private static void AddNewCheckItem(DataContext DataContext)
        {
            DataContext.ECheckItem.AddRange(new ECheckItem[]
            {
                new ECheckItem(ECheckItemDef.UAC_DC_SWITCH_STATUS,@"Trạng thái của các thiết bị đóng cắt tại các tủ phân phối UAC, DC"),

                new ECheckItem(ECheckItemDef.TRNFORMER_SKIN,@"Bề mặt sơn máy biến áp"),

                new ECheckItem(ECheckItemDef.UAC_CABINET_DURABILITY,@"Độ vững chắc của các tủ phân phối nguồn UAC (HK103EP1 đến HK103EP2)"),

                new ECheckItem(ECheckItemDef.ACCU_OUTSIZE,@"Hình dạng bên ngoài của Accu"),

                new ECheckItem(ECheckItemDef.AC_OPERATING_ROOM_TEMP,@"Hoạt động của điều hòa, nhiệt độ trong phòng"),

                new ECheckItem(ECheckItemDef.OPERATION_OF_SYNCHRONOUS_SYSTEM,@"Hoạt động của hệ thống hòa đồng bộ"),

                new ECheckItem(ECheckItemDef.OPERATION_OF_TVSS_SYSTEM,@"Hoạt động của hệ thống TVSS"),

                new ECheckItem(ECheckItemDef.OPERATION_OF_TVSS_SYSTEM_AT_UAC_DC,@"Hoạt động của TVSS tại các tủ phân phối UAC, DC"),

                new ECheckItem(ECheckItemDef.COMPENSATION_CABINET,@"Kiểm tra hệ thống tủ bù"),

                new ECheckItem(ECheckItemDef.PCCC,@"Kiểm tra PCCC"),

                new ECheckItem(ECheckItemDef.FUEL_LEAKS_FUEL_LEVEL,@"Kiểm tra rò rỉ nhiên liệu và mức nhiên liệu"),

                new ECheckItem(ECheckItemDef.BREAKER_NOISE,@"Kiểm tra tiếng ồn máy cắt"),

                new ECheckItem(ECheckItemDef.TRNSFORMER_FUEL_LEAKS,@"Sự rò rỉ dầu máy biến áp"),

                new ECheckItem(ECheckItemDef.ACCU_STATUS,@"Tình trạng của accu"),

                new ECheckItem(ECheckItemDef.UPS_OPERATING_STATUS,@"Tình trạng hoạt động hệ thống UPS"),

                new ECheckItem(ECheckItemDef.DC_POWER_OPERATING_STATUS,@"Tình trạng hoạt động tủ nguồn DC"),

                new ECheckItem(ECheckItemDef.GENERATOR_ACB_OUTPUT_STATUS,@"Trạng thái của ACB đầu ra máy phát điện"),

                new ECheckItem(ECheckItemDef.SEPAM_RELAY_STATUS,@"Trạng thái của bộ bảo vệ relay Sepam"),

                new ECheckItem(ECheckItemDef.GENERATOR_CONTROLLER_STATUS,@"Trạng thái của bộ điều khiển máy phát điện"),

                new ECheckItem(ECheckItemDef.L_H_BREAKER_LAMP_STATUS,@"Trạng thái đèn báo pha và đèn báo trạng thái máy cắt tủ hạ thế/trung thế"),

                new ECheckItem(ECheckItemDef.AC_CABINET_PHASE_LAMP_STATUS,@"Trạng thái đèn hiển thị pha của các tủ phân phối AC"),

                new ECheckItem(ECheckItemDef.AC_UAC_CABINET_PHASE_LAMP_STATUS,@"Trạng thái đèn hiển thị pha của các tủ phân phối AC, UAC"),

                new ECheckItem(ECheckItemDef.ME_LAMP_STATUS,@"Trạng thái đèn hiển thị pha, đèn cảnh báo của các thiết bị cơ điện"),

                new ECheckItem(ECheckItemDef.L_H_VOTLTAGE_TRANSFORMER_ROOM_ENVIRONMENT,@"Vệ sinh khu vực phòng hạ thế/trung thế/ máy biến áp"),

                new ECheckItem(ECheckItemDef.LAB_ACCU_ROOM_ENVIROMENT,@"Vệ sinh khu vực phòng Lab và phòng accu"),

                new ECheckItem(ECheckItemDef.MACHINE_AREA_ENVIROMENT,@"Vệ sinh khu vực phòng máy"),

                new ECheckItem(ECheckItemDef.POWER_AREA_ENVIROMENT,@"Vệ sinh khu vực phòng nguồn"),

                new ECheckItem(ECheckItemDef.POWER_ACCU_ROOM_ENVIROMENT,@"Vệ sinh khu vực phòng nguồn và phòng accu"),

                new ECheckItem(ECheckItemDef.GENERATOR_AREA_ENVIROMENT,@"Vệ sinh xung quanh khu vực máy phát điện"),

            });
            DataContext.SaveChanges();
        }

        private static void AddNewECheckArea(DataContext DataContext)
        {
            DataContext.ECheckArea.AddRange(new ECheckArea[]{
                new ECheckArea(ECheckAreaDef.ROOM_31, @"Phòng máy 3.1"),
                new ECheckArea(ECheckAreaDef.ROOM_32, @"Phòng máy 3.2"),
                new ECheckArea(ECheckAreaDef.POWER_ROOM_T3, @"Phòng Nguồn T3"),
                new ECheckArea(ECheckAreaDef.POWER_ROOM_T1, @"Phòng Nguồn T1"),
                new ECheckArea(ECheckAreaDef.GENERATOR, @"Máy phát điện"),
                new ECheckArea(ECheckAreaDef.L_H_VOLTAGE_TRANSFORMER, @"Phòng trung thế + Hạ thế + MBA"),
                new ECheckArea(ECheckAreaDef.LAB_ROOM, @"Phòng LAB"),
            });
            DataContext.SaveChanges();
        }

        private static void AddNewCheckingPerson(DataContext DataContext)
        {
            DataContext.CheckingPerson.AddRange(new CheckingPerson[]{
                new CheckingPerson{Name = "Đậu Văn An" },
                new CheckingPerson{Name = "Nguyễn Thế Anh"},
                new CheckingPerson{Name = "Hồ Văn Khoa"},
                new CheckingPerson{Name = "Nguyễn Văn Nam"},
                new CheckingPerson{Name = "Võ Tấn Hậu"},
                new CheckingPerson{Name = "Vũ Thanh Sơn"},
                new CheckingPerson{Name = "Nguyễn Đình Hữu"},
                new CheckingPerson{Name = "Nguyễn Tri Tình"},
            });
            DataContext.SaveChanges();
        }

        private static void ConfigECheckArea(DataContext DataContext)
        {
            for (int i = 0; i < ECheckingItem.Room_31_32.Length; i++)
            {
                DataContext.EChecking.Add(new EChecking(DataContext, ECheckingItem.Room_31_32[i], ECheckAreaDef.ROOM_31));
            }

            for (int i = 0; i < ECheckingItem.Room_31_32.Length; i++)
            {
                DataContext.EChecking.Add(new EChecking(DataContext, ECheckingItem.Room_31_32[i], ECheckAreaDef.ROOM_32));
            }

            for (int i = 0; i < ECheckingItem.PowerRoomT3.Length; i++)
            {
                DataContext.EChecking.Add(new EChecking(DataContext, ECheckingItem.PowerRoomT3[i], ECheckAreaDef.POWER_ROOM_T3));
            }

            for (int i = 0; i < ECheckingItem.PowerRoomT1.Length; i++)
            {
                DataContext.EChecking.Add(new EChecking(DataContext, ECheckingItem.PowerRoomT1[i], ECheckAreaDef.POWER_ROOM_T1));
            }

            for (int i = 0; i < ECheckingItem.Generator.Length; i++)
            {
                DataContext.EChecking.Add(new EChecking(DataContext, ECheckingItem.Generator[i], ECheckAreaDef.GENERATOR));
            }

            for (int i = 0; i < ECheckingItem.LHVoltage.Length; i++)
            {
                DataContext.EChecking.Add(new EChecking(DataContext, ECheckingItem.LHVoltage[i], ECheckAreaDef.L_H_VOLTAGE_TRANSFORMER));
            }

            for (int i = 0; i < ECheckingItem.LabRoom.Length; i++)
            {
                DataContext.EChecking.Add(new EChecking(DataContext, ECheckingItem.LabRoom[i], ECheckAreaDef.LAB_ROOM));
            }
            DataContext.SaveChanges();
        }
    }
}
