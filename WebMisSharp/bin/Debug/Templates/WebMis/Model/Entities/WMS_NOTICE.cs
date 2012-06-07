using System;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

/**
 * 作者：陈杰
 * QQ  : 710782046
 * Email:ovenjackchain@gmail.com
 * Web :http://yj.ChinaCloudTech.com
 */
namespace Model
{
    [TABLE(Name = "WMS_NOTICE", AutoID = "nid")]
    public class WMS_NOTICE
    {
        public WMS_NOTICE() { }

        #region 属性

        /// <summary>
        /// nid
        /// </summary>
        public int nid { get; set; }

        /// <summary>
        /// ntitle
        /// </summary>
        public string ntitle { get; set; }

        /// <summary>
        /// ncontent
        /// </summary>
        public string ncontent { get; set; }

        /// <summary>
        /// ndate
        /// </summary>
        public string ndate { get; set; }

        /// <summary>
        /// nowner
        /// </summary>
        public string nowner { get; set; }

        /// <summary>
        /// norigin
        /// </summary>
        public string norigin { get; set; }

        /// <summary>
        /// nreceiver
        /// </summary>
        public string nreceiver { get; set; }


        #endregion
    }
}
