using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVMLightDemo.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMLightDemo.ViewModel
{
    public class MessengerRegisterViewModel : ViewModelBase
    {
        public MessengerRegisterViewModel()
        {
            Messenger.Default.Register<String>(this, "Message", ShowReceiveInfo);
        }

        #region 属性

        private String receiveInfo;
        /// <summary>
        /// 接收到信史传递过来的值
        /// </summary>
        public String ReceiveInfo
        {
            get { return receiveInfo; }
            set { receiveInfo = value;RaisePropertyChanged(() => ReceiveInfo); }
        }

        #endregion

        #region 启动新窗口

        private RelayCommand showSenderWindow;

        public RelayCommand ShowSenderWindow
        {
            get
            {
                if (showSenderWindow == null)
                {
                    showSenderWindow = new RelayCommand(() => ExcuteShowSenderWindow());
                }
                return showSenderWindow;
            }
            set { showSenderWindow = value; }
        }

        private void ExcuteShowSenderWindow()
        {
            MessengerSendView sender = new MessengerSendView();
            sender.Show();
        }

        #endregion

        #region 辅助函数
        /// <summary>
        /// 显示接收的信息
        /// </summary>
        /// <param name="mas"></param>
        private void ShowReceiveInfo(String mas)
        {
            ReceiveInfo += mas + "\n";
        }

        #endregion
    }
}
