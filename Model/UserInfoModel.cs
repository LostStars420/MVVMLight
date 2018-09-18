using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMLightDemo.Model
{
    public class UserInfoModel:ObservableObject
    {
        private String userName;
        /// <summary>
        /// 用户姓名
        /// </summary>
        public String UserName
        {
            get { return userName; }
            set { userName = value;RaisePropertyChanged(() => UserName); }
        }

        private Int64 userPhone;
        /// <summary>
        /// 用户电话
        /// </summary>
        public Int64 UserPhone
        {
            get { return userPhone; }
            set { userPhone = value;RaisePropertyChanged(() => UserPhone); }
        }

        private Int32 userSex;
        /// <summary>
        /// 用户性别
        /// </summary>
        public Int32 UserSex
        {
            get { return userSex; }
            set { userSex = value;RaisePropertyChanged(() => UserSex); }
        }

        private String userAddr;

        public String UserAddr
        {
            get { return userAddr; }
            set { userAddr = value;RaisePropertyChanged(() => UserAddr); }
        }
    }
}
