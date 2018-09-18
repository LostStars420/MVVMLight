using GalaSoft.MvvmLight;
using MVVMLightDemo.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMLightDemo.ViewModel
{
    public class BothWayBindViewModel : ViewModelBase
    {
        public BothWayBindViewModel()
        {
            userInfo = new UserInfoModel();
        }

        private UserInfoModel userInfo;
        /// <summary>
        /// 用户信息
        /// </summary>
        public UserInfoModel UserInfo
        {
            get { return userInfo; }
            set { userInfo = value;RaisePropertyChanged(() => UserInfo); }
        }
    }
}
