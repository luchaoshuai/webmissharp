using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ext.Net;

/**
 * 作者：陈杰
 * QQ ： 710782046
 * Email：ovenjackchain@gmail.com
 * Web：http://yj.ChinaCloudTech.com
 */
namespace BLL
{
    class CJSearchSql
    {
        public string GetConditonSQL(string conditions)
        {
            string _con = "";
            if (!string.IsNullOrEmpty(conditions))
            {
                FilterConditions fc = new FilterConditions(conditions);
                foreach (FilterCondition condition in fc.Conditions)
                {
                    Comparison comparison = condition.Comparison;
                    string field = condition.Name;
                    FilterType type = condition.FilterType;
                    switch (condition.FilterType)
                    {
                        case FilterType.Date:
                            if(comparison.ToString()=="Lt")
                                _con += "and " + field + " >= '" + condition.Value.Replace("'","''")+"'";
                            else if(comparison.ToString()=="Gt")
                                _con += "and " + field + " <= '" + condition.Value.Replace("'", "''") + "'";
                            else
                                _con += "and CONVERT(varchar(100), " + field + ", 111) = '" + condition.Value.Replace("'", "''") + "'";
                            break;
                        case FilterType.Numeric:
                            _con += "and " + field + " > " + condition.Value.Replace("'", "''");
                            break;
                        case FilterType.String:
                            _con += "and " + field + " like '%" + condition.Value.Replace("'", "''") + "%' ";
                            break;
                    }
                }
                _con = _con.Substring(3);
            }
            return _con;
        }
    }
}
