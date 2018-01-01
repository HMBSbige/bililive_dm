using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using JetBrains.Annotations;

namespace BilibiliDM_PluginFramework
{

   
    public  class DMPlugin: DispatcherObject,INotifyPropertyChanged
    {
        private bool _status = false;
        public event ReceivedDanmakuEvt ReceivedDanmaku;
        public event DisconnectEvt Disconnected;
        public event ReceivedRoomCountEvt ReceivedRoomCount;
        public event ConnectedEvt Connected;

         public  void MainConnected(int roomid)
         {
             this.RoomID = roomid;
            try
            {
                Connected?.Invoke(null, new ConnectedEvtArgs() { roomid = roomid });
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "插件" + PluginName + "遇到了不明错误: 日志已经保存在桌面, 请有空发给该插件作者 " + PluginAuth + ", 联系方式 " + PluginCont);
                try
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


                    using (StreamWriter outfile = new StreamWriter(path + @"\B站弹幕姬插件" + PluginName + "错误报告.txt"))
                    {
                        outfile.WriteLine("请有空发给联系方式 " + PluginCont + " 谢谢");
                        outfile.WriteLine(PluginName + " " + PluginVer);
                        outfile.Write(ex.ToString());
                    }

                }
                catch (Exception)
                {

                }
            }
            
         }

        public void MainReceivedDanMaku(ReceivedDanmakuArgs e)
        {
            try
            {
                ReceivedDanmaku?.Invoke(null, e);
            }
            catch (Exception ex)
            {

                MessageBox.Show(
                    "插件" + PluginName + "遇到了不明错误: 日志已经保存在桌面, 请有空发给该插件作者 " + PluginAuth + ", 联系方式 " + PluginCont);
                try
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


                    using (StreamWriter outfile = new StreamWriter(path + @"\B站弹幕姬插件" + PluginName + "错误报告.txt"))
                    {
                        outfile.WriteLine("请有空发给联系方式 " + PluginCont + " 谢谢");
                        outfile.WriteLine(PluginName + " " + PluginVer);
                        outfile.Write(ex.ToString());
                    }

                }
                catch (Exception)
                {

                }
            }
            
        }

        public void MainReceivedRoomCount(ReceivedRoomCountArgs e)
        {
            try
            {
                ReceivedRoomCount?.Invoke(null, e);
            }
            catch (Exception ex)
            {

                MessageBox.Show(
                    "插件" + PluginName + "遇到了不明错误: 日志已经保存在桌面, 请有空发给该插件作者 " + PluginAuth + ", 联系方式 " + PluginCont);
                try
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


                    using (StreamWriter outfile = new StreamWriter(path + @"\B站弹幕姬插件" + PluginName + "错误报告.txt"))
                    {
                        outfile.WriteLine("请有空发给联系方式 " + PluginCont + " 谢谢");
                        outfile.WriteLine(PluginName + " " + PluginVer);
                        outfile.Write(ex.ToString());
                    }

                }
                catch (Exception)
                {

                }
            }
           
        }

        public void MainDisconnected()
        {
            this.RoomID = null;
            try
            {
                Disconnected?.Invoke(null, null);
            }
            catch (Exception ex)
            {

                MessageBox.Show(
                    "插件" + PluginName + "遇到了不明错误: 日志已经保存在桌面, 请有空发给该插件作者 " + PluginAuth + ", 联系方式 " + PluginCont);
                try
                {
                    string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


                    using (StreamWriter outfile = new StreamWriter(path + @"\B站弹幕姬插件" + PluginName + "错误报告.txt"))
                    {
                        outfile.WriteLine("请有空发给联系方式 " + PluginCont + " 谢谢");
                        outfile.WriteLine(PluginName + " " + PluginVer);
                        outfile.Write(ex.ToString());
                    }

                }
                catch (Exception)
                {

                }
            }
           
        }

        /// <summary>
        /// 插件名称
        /// </summary>
        public string PluginName { get; set; } = "这是插件";

        /// <summary>
        /// 插件作者
        /// </summary>
        public string PluginAuth { get; set; } = "这是作者";

        /// <summary>
        /// 插件作者联系方式
        /// </summary>
        public string PluginCont { get; set; } = "这是联系方式";

        /// <summary>
        /// 插件版本号
        /// </summary>
        public string PluginVer { get; set; } = "这是版本号";
        /// <summary>
        /// 插件描述
        /// </summary>
        public string PluginDesc { get; set; } = "描述还没填";

        /// <summary>
        /// 插件描述, 已过期, 请使用PluginDesc
        /// </summary>
        [Obsolete("手滑产品, 请使用PluginDesc")]
        public string PlubinDesc
        {
            get { return this.PluginDesc; }
            set { this.PluginDesc = value; }
        }

        /// <summary>
        /// 插件状态
        /// </summary>
        public bool Status
        {
            get { return _status; }
            private set
            {
                if (value == _status) return;
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }
        /// <summary>
        /// 当前连接中的房间
        /// </summary>
        public int? RoomId => RoomID;

        private int? RoomID;

        public DMPlugin()
        {
                
        }
        /// <summary>
        /// 启用插件方法 请重写此方法
        /// </summary>
        public virtual void Start()
        {
            this.Status = true;
            Console.WriteLine(this.PluginName+" Start!");
        }
        /// <summary>
        /// 禁用插件方法 请重写此方法
        /// </summary>
        public virtual void Stop()
        {

            this.Status = false;
            Console.WriteLine(this.PluginName + " Stop!");
        }
        /// <summary>
        /// 管理插件方法 请重写此方法
        /// </summary>
        public virtual void Admin()
        {
            
        }
        /// <summary>
        /// 此方法在所有插件加载完毕后调用
        /// </summary>
        public virtual void Inited()
        {

        }
        /// <summary>
        /// 反初始化方法, 在弹幕姬主程序退出时调用, 若有需要请重写,
        /// </summary>
        public virtual void DeInit()
        {
            
        }
        /// <summary>
        /// 打日志
        /// </summary>
        /// <param name="text"></param>
        public void Log(string text)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                dynamic mw = Application.Current.MainWindow;
                mw.logging(this.PluginName + " " + text);

            }));
            
        }
        /// <summary>
        /// 弹幕姬是否是以Debug模式启动的
        /// </summary>
        public bool DebugMode
        {
            get
            {
                return (Application.Current.MainWindow as dynamic).debug_mode;
            }
        }
        /// <summary>
        /// 打弹幕
        /// </summary>
        /// <param name="text"></param>
        /// <param name="fullscreen"></param>
        public void AddDM(string text, bool fullscreen = false)
        {

            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                dynamic mw = Application.Current.MainWindow;
                mw.AddDMText(this.PluginName, text, true, fullscreen);

            }));
           
        }
        /// <summary>
        /// 发送伪春菜脚本, 前提是用户有打开伪春菜并允许弹幕姬和伪春菜联动(默认允许)
        /// </summary>
        /// <param name="text">Sakura Script脚本</param>
        public void SendSSPMsg(string text)
        {
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() =>
            {
                dynamic mw = Application.Current.MainWindow;
                mw.SendSSP(text);

            }));
            
        }
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }

  
}
