using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BaseLibs;
using StaticConfigure;

namespace WebMisSharp
{
    public partial class Attributes : DockPanelUI.Docking.DockContent
    {
        public Attributes()
        {
            InitializeComponent();
        }
        //当内容被修改的时候,同步保存到xml
        private void PropertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {
            //Console log = (Console)Application.OpenForms["Console"];
            if (CboCurrentObject.Text == ObjectProperty.ObjectList.Project.ToString())
            {//如果是Project性质的项目
                if (e.ChangedItem.Label == "DBConStr"
                    && ((PropertyTable)PropertyGrid.SelectedObject)["DBType"].ToString() == ProjectDBType.DataBaseType.SQLSERVER2008.ToString()
                    &&!TryDBConnect.TryMSSQLConnect(e.ChangedItem.Value.ToString().Trim()))
                {
                        MessageBox.Show("连接串错误，无法连接到指定数据库！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                }
                if (e.ChangedItem.Label == "DBConStr"
                    && ((PropertyTable)PropertyGrid.SelectedObject)["DBType"].ToString() == ProjectDBType.DataBaseType.ORACLE.ToString()
                    && !TryDBConnect.TryOracleConnect(e.ChangedItem.Value.ToString().Trim()))
                {
                    MessageBox.Show("连接串错误，无法连接到指定数据库！", "警告", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
                XMLHelper.Update(XMLPaths.ProjectXml, "/Root/Project[@Name='" + ((PropertyTable)PropertyGrid.SelectedObject)["ProName"].ToString() + "']/" + e.ChangedItem.Label, "", e.ChangedItem.Value.ToString().Trim());
                ConsoleHelper.ShowConsole("成功修改了属性" + e.ChangedItem.Label + ":" + e.ChangedItem.Value.ToString().Trim());
            }
        }
    }
}
