/*************************************************
Author: Leo Shao      
Generated Date: 2015-02-26
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
using System.Threading;

namespace Com.Framework.Core.Generics
{
    /// <summary>
    /// 泛型参数线程
    /// Added by Leo Shao 2015-02-26
    /// </summary>
    public struct TThread<parameterType>
    {
        #region Define
        /// <summary>
        /// 线程委托
        /// </summary>
        private Action<parameterType> _Action;
        /// <summary>
        /// 线程委托（无参数，额外添加）
        /// </summary>
        private Action _Handler;
        /// <summary>
        /// 线程委托，当主体事件完成后执行的动作
        /// </summary>
        private Action _OnCompleted;
        /// <summary>
        /// 线程委托，当主体事件强制结束时执行的动作
        /// </summary>
        private Action<Exception> _OnAbort;

        /// <summary>
        /// 线程参数
        /// </summary>
        private parameterType _Parameter;
        /// <summary>
        /// 线程名称
        /// </summary>
        private string _ThreadName;
        /// <summary>
        /// 线程优先级
        /// </summary>
        private ThreadPriority _Priority;
        /// <summary>
        /// 是否未后台线程
        /// </summary>
        private bool _IsBackground;
        #endregion

        #region Instance
        /// <summary>
        /// 初始化 泛型参数线程
        /// </summary>
        /// <param name="action">线程委托</param>
        /// <param name="parameter">线程参数</param>
        /// <param name="onAbort">主体事件强制结束时执行的线程委托动作</param>
        /// <param name="onCompleted">主体事件完成后执行的线程委托动作</param>
        /// <param name="threadName">线程名称，未指定时自动取一个GUID编码</param>
        /// <param name="priority">线程优先级，默认为ThreadPriority.Normal</param>
        /// <param name="isBackground">是否未后台线程，默认为true后台线程</param>
        public TThread(Action<parameterType> action, parameterType parameter, Action<Exception> onAbort = null, Action onCompleted = null
           , string threadName = null, ThreadPriority priority = ThreadPriority.Normal, bool isBackground = true)
        {
            if (action == null) throw new Exception("缺少线程委托");

            _Action = action;
            _Handler = null;
            _Parameter = parameter;
            _OnAbort = onAbort;
            _OnCompleted = onCompleted;

            _ThreadName = (string.IsNullOrEmpty(threadName) ? Guid.NewGuid().ToString() : threadName);
            _Priority = priority;
            _IsBackground = isBackground;
        }
        /// <summary>
        /// 初始化 泛型参数线程（无参数，额外添加）
        /// </summary>
        /// <param name="action">线程委托</param>
        /// <param name="onAbort">主体事件强制结束时执行的线程委托动作</param>
        /// <param name="onCompleted">主体事件完成后执行的线程委托动作</param>
        /// <param name="threadName">线程名称，未指定时自动取一个GUID编码</param>
        /// <param name="priority">线程优先级，默认为ThreadPriority.Normal</param>
        /// <param name="isBackground">是否未后台线程，默认为true后台线程</param>
        public TThread(Action action, Action<Exception> onAbort = null, Action onCompleted = null
        , string threadName = null, ThreadPriority priority = ThreadPriority.Normal, bool isBackground = true)
        {
            if (action == null) throw new Exception("缺少线程委托");

            _Action = null;
            _Handler = action;
            _Parameter = default(parameterType);
            _OnAbort = onAbort;
            _OnCompleted = onCompleted;

            _ThreadName = (string.IsNullOrEmpty(threadName) ? Guid.NewGuid().ToString() : threadName);
            _Priority = priority;
            _IsBackground = isBackground;
        }
        #endregion

        #region Method
        /// <summary>
        /// 启动线程并返回线程句柄
        /// </summary>
        /// <returns>线程句柄</returns>
        public Thread Start()
        {
            Thread th = new Thread(ParameterThread);
            if (_Handler == null)
                th = new Thread(ParameterThread);
            else
                th = new Thread(NoParameterThread);
            th.Name = _ThreadName;
            th.Priority = _Priority;
            th.IsBackground = _IsBackground;
            th.Start();

            return th;
        }
        /// <summary>
        /// 构造Thread
        /// </summary>
        /// <returns></returns>
        public Thread BuildThread()
        {
            Thread th = new Thread(ParameterThread);
            if (_Handler == null)
                th = new Thread(ParameterThread);
            else
                th = new Thread(NoParameterThread);
            th.Name = _ThreadName;
            th.Priority = _Priority;
            th.IsBackground = _IsBackground;

            return th;
        }
        /// <summary>
        /// 延迟执行
        /// </summary>
        /// <param name="th"></param>
        public void DelayStart(Thread th)
        {
            th.Start();
        }

        /// <summary>
        /// 调用线程委托
        /// </summary>
        private void ParameterThread()
        {
            try
            {
                _Action(_Parameter);
            }
            catch (ThreadAbortException exp)
            {
                if (_OnAbort != null)
                    _OnAbort(exp);
            }
            finally
            {
                if (_OnCompleted != null)
                    _OnCompleted();
            }
        }
        /// <summary>
        /// 调用线程委托（无参数，额外添加）
        /// </summary>
        private void NoParameterThread()
        {
            try
            {
                _Handler();
            }
            catch (ThreadAbortException exp)
            {
                if (_OnAbort != null)
                    _OnAbort(exp);
            }
            finally
            {
                if (_OnCompleted != null)
                    _OnCompleted();
            }
        }
        #endregion

        #region Interface
        /// <summary>
        /// 启动线程并返回线程句柄
        /// </summary>
        /// <param name="action">线程委托</param>
        /// <param name="parameter">线程参数</param>
        /// <param name="onAbort">主体事件强制结束时执行的线程委托动作</param>
        /// <param name="onCompleted">主体事件完成后执行的线程委托动作</param>
        /// <param name="threadName">线程名称，未指定时自动取一个GUID编码</param>
        /// <param name="priority">线程优先级，默认为ThreadPriority.Normal</param>
        /// <param name="isBackground">是否未后台线程，默认为true后台线程</param>
        /// <returns>线程句柄</returns>
        public static Thread Start(Action<parameterType> action, parameterType parameter, Action<Exception> onAbort = null, Action onCompleted = null
           , string threadName = null, ThreadPriority priority = ThreadPriority.Normal, bool isBackground = true)
        {
            return new TThread<parameterType>(action, parameter, onAbort, onCompleted, threadName, priority, isBackground).Start();
        }
        /// <summary>
        /// 启动线程并返回线程句柄（无参数，额外添加）
        /// </summary>
        /// <param name="action">线程委托</param>
        /// <param name="onAbort">主体事件强制结束时执行的线程委托动作</param>
        /// <param name="onCompleted">主体事件完成后执行的线程委托动作</param>
        /// <param name="threadName">线程名称，未指定时自动取一个GUID编码</param>
        /// <param name="priority">线程优先级，默认为ThreadPriority.Normal</param>
        /// <param name="isBackground">是否未后台线程，默认为true后台线程</param>
        /// <returns>线程句柄</returns>
        public static Thread Start(Action action, Action<Exception> onAbort = null, Action onCompleted = null
            , string threadName = null, ThreadPriority priority = ThreadPriority.Normal, bool isBackground = true)
        {
            return new TThread<parameterType>(action, onAbort, onCompleted, threadName, priority, isBackground).Start();
        }
        #endregion
    }

    /// <summary>
    /// 带返回值的泛型参数线程
    /// Added by Leo Shao 2014-04-18
    /// </summary>
    /// <typeparam name="parameterType">参数类型</typeparam>
    /// <typeparam name="returnType">返回值类型</typeparam>
    public struct TThread<parameterType, returnType>
    {
        #region Define
        /// <summary>
        /// 线程委托
        /// </summary>
        private Func<parameterType, returnType> _Func;
        /// <summary>
        /// 线程参数
        /// </summary>
        private parameterType _Parameter;
        /// <summary>
        /// 返回值处理委托
        /// </summary>
        private Action<returnType> _OnReturn;
        /// <summary>
        /// 线程优先级
        /// </summary>
        private ThreadPriority _Priority;
        /// <summary>
        /// 是否未后台线程
        /// </summary>
        private bool _IsBackground;
        #endregion

        #region Instance
        /// <summary>
        /// 初始化 带返回值的泛型参数线程
        /// </summary>
        /// <param name="func">线程委托</param>
        /// <param name="parameter">线程参数</param>
        /// <param name="onReturn">返回值处理委托</param>
        /// <param name="priority">线程优先级，默认为ThreadPriority.Normal</param>
        /// <param name="isBackground">是否未后台线程，默认为true后台线程</param>
        public TThread(Func<parameterType, returnType> func, parameterType parameter, Action<returnType> onReturn
            , ThreadPriority priority = ThreadPriority.Normal, bool isBackground = true)
        {
            if (func == null) throw new Exception("缺少线程委托");

            _Func = func;
            _Parameter = parameter;
            _OnReturn = onReturn;
            _Priority = priority;
            _IsBackground = isBackground;
        }
        #endregion

        #region Method
        /// <summary>
        /// 启动线程并返回线程句柄
        /// </summary>
        /// <returns>线程句柄</returns>
        public Thread Start()
        {
            Thread thread = new Thread(ParameterThread);
            thread.Priority = _Priority;
            thread.IsBackground = _IsBackground;
            thread.Start();

            return thread;
        }

        /// <summary>
        /// 调用线程委托
        /// </summary>
        private void ParameterThread()
        {
            returnType returnValue = default(returnType);
            try
            {
                returnValue = _Func(_Parameter);
            }
            catch
            {
                throw;
            }
            finally
            {
                if (_OnReturn != null) _OnReturn(returnValue);
            }
        }
        #endregion

        #region Interface
        /// <summary>
        /// 启动线程并返回线程句柄
        /// </summary>
        /// <param name="func">线程委托</param>
        /// <param name="parameter">线程参数</param>
        /// <param name="onReturn">返回值处理委托</param>
        /// <param name="priority">线程优先级，默认为ThreadPriority.Normal</param>
        /// <param name="isBackground">是否未后台线程，默认为true后台线程</param>
        /// <returns>线程句柄</returns>
        public static Thread Start(Func<parameterType, returnType> func, parameterType parameter, Action<returnType> onReturn
            , ThreadPriority priority = ThreadPriority.Normal, bool isBackground = true)
        {
            return new TThread<parameterType, returnType>(func, parameter, onReturn, priority, isBackground).Start();
        }
        #endregion
    }
}
