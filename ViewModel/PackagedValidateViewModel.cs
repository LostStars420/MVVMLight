using MVVMLightDemo.Model;
using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight.Command;
using System.Windows;

namespace MVVMLightDemo.ViewModel
{
    public class PackagedValidateViewModel : ViewModelBase
    {
        public PackagedValidateViewModel()
        {
            validateUI = new ValidateUserInfo();
        }

        #region 屬性
        private ValidateUserInfo validateUI;

        public ValidateUserInfo ValidateUI
        {
            get
            {
                return validateUI;
            }
            set
            {
                validateUI = value;
                RaisePropertyChanged(() => ValidateUI);
            }
        }
        #endregion

        #region 全局命令

        private RelayCommand submitCmd;
        public RelayCommand SubmitCmd
        {
            get
            {
                if (submitCmd == null)
                {
                    return new RelayCommand(() => ExecuteValidForm());
                }
                return submitCmd;
            }
            set
            {
                submitCmd = value;
            }
        }

        #endregion

        #region 附屬方法
        /// <summary>
        /// 驗證表單
        /// </summary>
        private void ExecuteValidForm()
        {
            if (ValidateUI.IsValidated) MessageBox.Show("驗證通過!");
            else MessageBox.Show("驗證失敗!");
        }
        #endregion

    }
}
