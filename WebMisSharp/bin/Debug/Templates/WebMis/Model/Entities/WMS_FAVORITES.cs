using System;
using System.Collections;


/**
 * 作者：陈杰
 * QQ  : 710782046
 * Email:ovenjackchain@gmail.com
 * Web :http://yj.ChinaCloudTech.com
 */
namespace Model
{
    [TABLE(Name = "WMS_FAVORITES", AutoID = "Fid")]
    public class WMS_FAVORITES
    {
        public WMS_FAVORITES() { }

        #region 属性

        /// <summary>
        /// Fid
        /// </summary>
        public int Fid { get; set; }

        /// <summary>
        /// Funid
        /// </summary>
        public int Funid { get; set; }

        /// <summary>
        /// UserId
        /// </summary>
        public string UserId { get; set; }

        /// <summary>
        /// CreateDate
        /// </summary>
        public string CreateDate { get; set; }


        #endregion

    }
}
