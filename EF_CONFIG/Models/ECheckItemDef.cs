using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CONFIG.Models
{
    public enum ECheckItemDef
    {
        UAC_DC_SWITCH_STATUS,               //Trạng thái của các thiết bị đóng cắt tại các tủ phân phối UAC, DC
        TRNFORMER_SKIN,                     //Bề mặt sơn máy biến áp
        UAC_CABINET_DURABILITY,             //Độ vững chắc của các tủ phân phối nguồn UAC (HK103EP1 đến HK103EP2)
        ACCU_OUTSIZE,                       //Hình dạng bên ngoài của Accu
        AC_OPERATING_ROOM_TEMP,             //Hoạt động của điều hòa, nhiệt độ trong phòng
        OPERATION_OF_SYNCHRONOUS_SYSTEM,    //Hoạt động của hệ thống hòa đồng bộ
        OPERATION_OF_TVSS_SYSTEM,           //Hoạt động của hệ thống TVSS
        OPERATION_OF_TVSS_SYSTEM_AT_UAC_DC, //Hoạt động của TVSS tại các tủ phân phối UAC, DC
        COMPENSATION_CABINET,               //Kiểm tra hệ thống tủ bù
        PCCC,                               //Kiểm tra PCCC
        FUEL_LEAKS_FUEL_LEVEL,              //Kiểm tra rò rỉ nhiên liệu và mức nhiên liệu
        BREAKER_NOISE,                      //Kiểm tra tiếng ồn máy cắt
        TRNSFORMER_FUEL_LEAKS,              //Sự rò rỉ dầu máy biến áp
        ACCU_STATUS,                        //Tình trạng của accu
        UPS_OPERATING_STATUS,               //Tình trạng hoạt động hệ thống UPS
        DC_POWER_OPERATING_STATUS,          //Tình trạng hoạt động tủ nguồn DC
        GENERATOR_ACB_OUTPUT_STATUS,      //Trạng thái của ACB đầu ra máy phát điện
        SEPAM_RELAY_STATUS,                 //Trạng thái của bộ bảo vệ relay Sepam
        GENERATOR_CONTROLLER_STATUS,      //Trạng thái của bộ điều khiển máy phát điện
        L_H_BREAKER_LAMP_STATUS,                //Trạng thái đèn báo pha và đèn báo trạng thái máy cắt tủ hạ thế/trung thế
        AC_CABINET_PHASE_LAMP_STATUS,       //Trạng thái đèn hiển thị pha của các tủ phân phối AC
        AC_UAC_CABINET_PHASE_LAMP_STATUS,   //Trạng thái đèn hiển thị pha của các tủ phân phối AC, UAC
        ME_LAMP_STATUS,                             //Trạng thái đèn hiển thị pha, đèn cảnh báo của các thiết bị cơ điện
        L_H_VOTLTAGE_TRANSFORMER_ROOM_ENVIRONMENT,  //Vệ sinh khu vực phòng hạ thế/trung thế/ máy biến áp
        LAB_ACCU_ROOM_ENVIROMENT,                   //Vệ sinh khu vực phòng Lab và phòng accu
        MACHINE_AREA_ENVIROMENT,                    //Vệ sinh khu vực phòng máy
        POWER_AREA_ENVIROMENT,                      //Vệ sinh khu vực phòng nguồn
        POWER_ACCU_ROOM_ENVIROMENT,                 //Vệ sinh khu vực phòng nguồn và phòng accu
        GENERATOR_AREA_ENVIROMENT,                  //Vệ sinh xung quanh khu vực máy phát điện
    }

    public enum ECheckAreaDef
    {
        ROOM_31 = 1,     //Phòng máy 3.1/3.2

        ROOM_32,     //Phòng máy 3.1/3.2

        POWER_ROOM_T3,  //Phòng Nguồn T3

        POWER_ROOM_T1,  //Phòng Nguồn T1

        GENERATOR,      //Máy phát điện

        L_H_VOLTAGE_TRANSFORMER,    //Phòng trung thế + Hạ thế + MBA

        LAB_ROOM        //Phòng LAB

    }

    public enum CheckingPersonDef
    {
        DAU_VAN_AN=1,       //Đậu Văn An
        NGUYEN_THE_ANH,     //Nguyễn Thế Anh
        HO_VAN_KHOA,        //Hồ Văn Khoa
        NGUYEN_VAN_NAM,     //Nguyễn Văn Nam
        VO_TAN_HAU,         //Võ Tấn Hậu
        VU_THANH_SON,       //Vũ Thanh Sơn
        NGUYEN_DINH_HUU,    //Nguyễn Đình Hữu
        NGUYEN_TRI_TINH,    //Nguyễn Tri Tình
    }

    public class ECheckingItem
    {
        public static ECheckItemDef[] Room_31_32 { get; set; } =
        {
            ECheckItemDef.UAC_DC_SWITCH_STATUS,         //Trạng thái của các thiết bị đóng cắt tại các tủ phân phối UAC, DC
            ECheckItemDef.AC_OPERATING_ROOM_TEMP,       //Hoạt động của điều hòa, nhiệt độ trong phòng
            ECheckItemDef.ME_LAMP_STATUS,               //Trạng thái đèn hiển thị pha, đèn cảnh báo của các thiết bị cơ điện
            ECheckItemDef.PCCC,                         //Kiểm tra PCCC
            ECheckItemDef.OPERATION_OF_TVSS_SYSTEM_AT_UAC_DC,   //Hoạt động của TVSS tại các tủ phân phối UAC, DC
            ECheckItemDef.UAC_CABINET_DURABILITY,               //Độ vững chắc của các tủ phân phối nguồn UAC (HK103EP1 đến HK103EP2)
            ECheckItemDef.MACHINE_AREA_ENVIROMENT,              //Vệ sinh khu vực phòng máy

        };

        public static ECheckItemDef[] PowerRoomT3 { get; set; } =
        {
            ECheckItemDef.AC_UAC_CABINET_PHASE_LAMP_STATUS,         //Trạng thái đèn hiển thị pha của các tủ phân phối AC, UAC
            ECheckItemDef.DC_POWER_OPERATING_STATUS,                //Tình trạng hoạt động tủ nguồn DC
            ECheckItemDef.UPS_OPERATING_STATUS,                     //Tình trạng hoạt động hệ thống UPS
            ECheckItemDef.ACCU_OUTSIZE,                             //Hình dạng bên ngoài của Accu
            ECheckItemDef.AC_OPERATING_ROOM_TEMP,                   //Hoạt động của điều hòa, nhiệt độ trong phòng
            ECheckItemDef.PCCC,                                     //Kiểm tra PCCC
            ECheckItemDef.POWER_ACCU_ROOM_ENVIROMENT,               //Vệ sinh khu vực phòng nguồn và phòng accu
        };

        public static ECheckItemDef[] PowerRoomT1 { get; set; } =
        {
            ECheckItemDef.AC_CABINET_PHASE_LAMP_STATUS,     //Trạng thái đèn hiển thị pha của các tủ phân phối AC
            ECheckItemDef.OPERATION_OF_SYNCHRONOUS_SYSTEM,  //Hoạt động của hệ thống hòa đồng bộ
            ECheckItemDef.OPERATION_OF_TVSS_SYSTEM,         //Hoạt động của hệ thống TVSS
            ECheckItemDef.PCCC,                             //Kiểm tra PCCC
            ECheckItemDef.COMPENSATION_CABINET,             //Kiểm tra hệ thống tủ bù
            ECheckItemDef.POWER_AREA_ENVIROMENT,            //Vệ sinh khu vực phòng nguồn

        };

        public static ECheckItemDef[] Generator { get; set; } =
        {
            ECheckItemDef.GENERATOR_CONTROLLER_STATUS,  //Trạng thái của bộ điều khiển máy phát điện
            ECheckItemDef.FUEL_LEAKS_FUEL_LEVEL,        //Kiểm tra rò rỉ nhiên liệu và mức nhiên liệu
            ECheckItemDef.GENERATOR_ACB_OUTPUT_STATUS,  //Trạng thái của ACB đầu ra máy phát điện
            ECheckItemDef.ACCU_STATUS,                  //Tình trạng của accu
            ECheckItemDef.PCCC,                         //Kiểm tra PCCC
            ECheckItemDef.GENERATOR_AREA_ENVIROMENT     //Vệ sinh xung quanh khu vực máy phát điện
        };

        public static ECheckItemDef[] LHVoltage { get; set; } =
        {
            ECheckItemDef.TRNSFORMER_FUEL_LEAKS,    //Sự rò rỉ dầu máy biến áp
            ECheckItemDef.TRNFORMER_SKIN,           //Bề mặt sơn máy biến áp
            ECheckItemDef.SEPAM_RELAY_STATUS,       //Trạng thái của bộ bảo vệ relay Sepam
            ECheckItemDef.L_H_BREAKER_LAMP_STATUS,  //Trạng thái đèn báo pha và đèn báo trạng thái máy cắt tủ hạ thế/trung thế
            ECheckItemDef.BREAKER_NOISE,            //Kiểm tra tiếng ồn máy cắt
            ECheckItemDef.PCCC,                     //Kiểm tra PCCC
            ECheckItemDef.L_H_VOTLTAGE_TRANSFORMER_ROOM_ENVIRONMENT,    //Vệ sinh khu vực phòng hạ thế/trung thế/ máy biến áp
        };

        public static ECheckItemDef[] LabRoom { get; set; } =
        {
            ECheckItemDef.AC_UAC_CABINET_PHASE_LAMP_STATUS,     //Trạng thái đèn hiển thị pha của các tủ phân phối AC, UAC
            ECheckItemDef.DC_POWER_OPERATING_STATUS,            //Tình trạng hoạt động tủ nguồn DC
            ECheckItemDef.UPS_OPERATING_STATUS,                 //Tình trạng hoạt động hệ thống UPS
            ECheckItemDef.ACCU_OUTSIZE,                         //Hình dạng bên ngoài của Accu
            ECheckItemDef.AC_OPERATING_ROOM_TEMP,               //Hoạt động của điều hòa, nhiệt độ trong phòng
            ECheckItemDef.OPERATION_OF_TVSS_SYSTEM_AT_UAC_DC,   //Hoạt động của TVSS tại các tủ phân phối UAC, DC
            ECheckItemDef.PCCC,                                 //Kiểm tra PCCC
            ECheckItemDef.LAB_ACCU_ROOM_ENVIROMENT,             //Vệ sinh khu vực phòng Lab và phòng accu
        };

        public static ECheckItemDef[][] CheckingAreas { get; set; } ={
            Room_31_32,
            PowerRoomT3,
            PowerRoomT1,
            Generator,
            LHVoltage,
            LabRoom
        };

        public static ECheckAreaDef[] ECheckAreaArray { get; set; } =
        {
            ECheckAreaDef.ROOM_31,     //Phòng máy 3.1/3.2

            ECheckAreaDef.ROOM_32,     //Phòng máy 3.1/3.2

            ECheckAreaDef.POWER_ROOM_T3,  //Phòng Nguồn T3

            ECheckAreaDef.POWER_ROOM_T1,  //Phòng Nguồn T1

            ECheckAreaDef.GENERATOR,      //Máy phát điện

            ECheckAreaDef.L_H_VOLTAGE_TRANSFORMER,    //Phòng trung thế + Hạ thế + MBA

            ECheckAreaDef.LAB_ROOM        //Phòng LAB
        };

        public static int TotalSlave { get; set; } = 100;


    }
    public enum ECheckState
    {
        OK = 0xFF,
        NOT_OK = 0x00,
    }

    public enum ServerFunctions
    {
        MASTER_TEST,
        SLAVER_TEST,
        GET_AREA_DATA,
        IDLE,
    }

    public enum Exception_t
    {
        RESP_TIMEOUT,
        RESP_DATA_ERROR,
        WAITING_RESP,
        RESP_OK,
    }
}
