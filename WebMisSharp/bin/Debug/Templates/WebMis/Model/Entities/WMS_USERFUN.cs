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
    [TABLE(Name = "WMS_USERFUN", AutoID = "funid")]
    public class WMS_USERFUN
    {
        public WMS_USERFUN() { }
		
        #region 属性
		/// <summary>
		/// 节点ID
		/// </summary>
		public int funid { get; set; }
		
		/// <summary>
		/// 功能链接
		/// </summary>
		public string funno { get; set; }
		
		/// <summary>
		/// 功能名称
		/// </summary>
		public string funname { get; set; }
		
		/// <summary>
		/// 父节点
		/// </summary>
		public int fatherid { get; set; }
		

        #endregion
    }
}
