using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KancolleModify
{
    public class ConfigMeta
    {
        // 铭牌
        public static string Fleet1NamePlateNormal = "Fleet1NamePlateNormal";
        public static string Fleet1NamePlateDmg = "Fleet1NamePlateDmg";
        public static string Fleet1NamePlateLost = "Fleet1NamePlateLost";
        public static string Fleet2NamePlateNormal = "Fleet2NamePlateNormal";
        public static string Fleet2NamePlateDmg = "Fleet2NamePlateDmg";
        public static string Fleet2NamePlateLost = "Fleet2NamePlateLost";

        // 补给
        public static string SupplyNormal = "SupplyNormal";
        public static string SupplyDmg = "SupplyDmg";

        // 卡牌
        public static string CardNormal = "CardNormal";
        public static string CardDmg = "CardDmg";

        // 图鉴
        public static string AlbumTitle = "AlbumTitle";
        public static string AlbumFull = "AlbumFull";
        public static string AlbumFullDmg = "AlbumFullDmg";
        public static string AlbumHalf = "AlbumHalf";
        public static string AlbumHalfDmg = "AlbumHalfDmg";

        // 立绘
        public static string VertDrawingNormal = "VertDrawingNormal";
        public static string VertDeawingDmg = "VertDrawingDmg";

        // 改装
        public static string RemodelNormal = "RemodelNormal";
        public static string RemodelDmg = "RemodelDmg";

    }

    // config.ini
    public class ConfigIniMeta
    {
        public static string KanmusuName = "ship_name";
        public static string PortNormalLeft = "boko_n_left";
        public static string PortNormalTop = "boko_n_top";
        public static string PortDmgLeft = "boko_d_left";
        public static string PortDmgTop = "boko_d_top";
        public static string EquipmentNormalLeft = "kaisyu_n_left";
        public static string EquipmentNormalTop = "kaisyu_n_top";
        public static string EquipmentDmgLeft = "kaisyu_n_left";
        public static string EquipmentDmgTop = "kaisyu_d_top";
        public static string RemodelNormalLeft = "kaizo_n_left";
        public static string RemodelNormalTop = "kaizo_n_top";
        public static string RemodelDmglLeft = "kaizo_d_left";
        public static string RemodelDmgTop = "kaizo_d_top";
        public static string ExerciseNormalLeft = "ensyuf_n_left";
        public static string ExerciseNormalTop = "ensyuf_n_top";
        public static string ExerciseDmgLeft = "ensyuf_d_left";
        public static string ExerciseDmgTop = "ensyuf_d_top";
        public static string BattleNormalLeft = "battle_n_left";
        public static string BattleNormalTop = "battle_n_top";
        public static string BattleDmgLeft = "battle_d_left";
        public static string BattleDmgTop = "battle_d_top";
        public static string FaceWidth = "wedb_left";
        public static string FaceHeight = "wedb_top";
        public static string FaceX = "weda_left";
        public static string FaceY = "weda_right";
    }

    class Config
    {
        public static Dictionary<string, string> PicturePaths = new Dictionary<string, string>();
        public static Dictionary<string, string> ConfigIni = new Dictionary<string, string>();

        public static string ShimakazeGoCachePath = "";
        public static string ACGPowerCachePath = "";
        public static string CachePath = "";

        public static IniConfigLoader Configure;

        public class Meta
        {
            public static string ShimakazeGoCachePath = "config.shimakaze_cache";
            public static string ACGPowerCachePath = "config.acgpower_cache";
        }
    }


}
