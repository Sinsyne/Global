/*************************************************
Author: Leo Shao      
Generated Date: 2015-04-08
Project: 公用框架
Version: 1.0   
.Net Version: 3.5
Description:    // 模块功能描述（如功能、主要算法、内部各部分之间的关系、该文件与其它文件关系等）
Others:         // 其它内容的说明
History:        // 修改历史记录列表，每条修改记录应包括修改日期、修改者及修改内容简述
*************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.IO;
using System.Threading;
using System.Web.UI.HtmlControls;

namespace Com.Framework.Extra
{
    /// <summary>
    /// System.Web.UI.Page基类扩展
    /// </summary>
    public class BaseWebUIPage: System.Web.UI.Page
    {
        //将代码放入Basepage. 然后去处理页面viewstate的存放，文件，或者文件型数据库，或者缓存服务器
        #region ViewState 优化方案
        protected override object LoadPageStateFromPersistenceMedium()
        {
            var viewStateID = (string)((Pair)base.LoadPageStateFromPersistenceMedium()).Second;
            var stateStr = (string)Cache[viewStateID];
            if (stateStr == null)
            {
                Directory.CreateDirectory(Path.Combine(this.Request.PhysicalApplicationPath, @"App_Data/ViewState/"));
                var fn = Path.Combine(this.Request.PhysicalApplicationPath, @"App_Data/ViewState/" + viewStateID + ".txt");
                stateStr = File.ReadAllText(fn);
            }
            return new ObjectStateFormatter().Deserialize(stateStr);
        }

        protected override void SavePageStateToPersistenceMedium(object state)
        {
            var value = new ObjectStateFormatter().Serialize(state);
            var viewStateID = (DateTime.Now.Ticks + (long)this.GetHashCode()).ToString(); //产生离散的id号码
            var path = Path.Combine(this.Request.PhysicalApplicationPath, @"App_Data/ViewState/");
            Directory.CreateDirectory(path);
            var fn = Path.Combine(this.Request.PhysicalApplicationPath, @"App_Data/ViewState/" + viewStateID + ".txt");
            ThreadPool.QueueUserWorkItem(obj =>
                {
                    File.WriteAllText(fn, value);
                    CleareFileCachViewState(path);
                });
            Cache.Insert(viewStateID, value);
            base.SavePageStateToPersistenceMedium(viewStateID);
        }

        private void CleareFileCachViewState(string path)
        {
            Directory.CreateDirectory(path);
            var f = Directory.GetFiles(path, "*.txt");
            if (f != null)
            {
                f.ToList().ForEach(x =>
                    {
                        var ff = new FileInfo(x);
                        if ((DateTime.Now - ff.CreationTime).TotalHours > 24)
                            ff.Delete();
                    });
            }
        }
        #endregion
    }
}
