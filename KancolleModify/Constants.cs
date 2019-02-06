using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KancolleModify
{
    class Constants
    {
        public const string ShipRelativePath = @"\kcs2\resources\ship\";
    }

    /// <summary>
    /// 立绘出现的场景
    /// </summary>
    public enum VertialDrawingSenses
    {
        /// <summary>
        /// 母港
        /// </summary>
        Port = 0,

        /// <summary>
        ///  战斗中
        /// </summary>
        InBattle,

        /// <summary>
        /// 海域地图中
        /// </summary>
        Map,

        /// <summary>
        /// 演习
        /// </summary>
        Exercise,

        /// <summary>
        /// 近代化改修
        /// </summary>
        Modernization,

        /// <summary>
        /// 改造
        /// </summary>
        Remodel,
    }
}
