using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Threading;
using BilibiliDM_PluginFramework;

namespace Bililive_dm
{
    /// <summary>
    /// App.xaml 的互动逻辑
    /// </summary>
    public partial class App : Application
    {
        [DllImport("kernel32", EntryPoint = "SetDllDirectoryW", CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool SetDllDirectory(string lpPathName);

        public App()
        {
            AddArchSpecificDirectory();
            Application.Current.DispatcherUnhandledException += App_DispatcherUnhandledException;
            
        }

        private void AddArchSpecificDirectory()
        {
            string archPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                           IntPtr.Size == 8 ? "x64" : "Win32");
            SetDllDirectory(archPath);
        }

        private void App_DispatcherUnhandledException(object sender,
            DispatcherUnhandledExceptionEventArgs e)
        {
            MessageBox.Show(
                "遇到了不明错误: 日志已经保存在桌面, 请有空发给 copyliu@gmail.com ");
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);


                using (StreamWriter outfile = new StreamWriter(path + @"\B站弹幕姬错误报告.txt"))
                {
                    outfile.WriteLine("请有空发给 copyliu@gmail.com 谢谢");
                    outfile.WriteLine(DateTime.Now +"");
                    outfile.Write(e.Exception.ToString());
                    outfile.WriteLine("-------插件列表--------");
                    foreach (var dmPlugin in Plugins)
                    {
                        outfile.WriteLine($"{dmPlugin.PluginName}\t{dmPlugin.PluginVer}\t{dmPlugin.PluginAuth}\t{dmPlugin.PluginCont}\t启用:{dmPlugin.Status}");
                    }


                }
            }
            catch (Exception)
            {
            }
        }

        public static  readonly ObservableCollection<DMPlugin> Plugins = new ObservableCollection<DMPlugin>();
    }
}