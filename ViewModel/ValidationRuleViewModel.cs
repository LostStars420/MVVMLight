using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMLightDemo.ViewModel
{
    public class ValidationRuleViewModel:ViewModelBase
    {
        public ValidationRuleViewModel()
        {

        }

        #region 屬性

        private String userName;
        /// <summary>
        /// 用戶名
        /// </summary>
        public String UserName
        {
            get { return userName; }
            set { userName = value;RaisePropertyChanged(() => UserName); }
        }

        private String userEmail;
        /// <summary>
        /// 用戶郵箱
        /// </summary>
        public String UserEmail
        {
            get { return userEmail; }
            set { userEmail = value;RaisePropertyChanged(() => UserEmail); }
        }

        #endregion
    }
}
