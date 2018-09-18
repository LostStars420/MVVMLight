using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using MVVMLightDemo.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace MVVMLightDemo.ViewModel
{
    public class CommandViewModel : ViewModelBase
    {
        public CommandViewModel()
        {
            ValidateUI = new ValidateUserInfo();
            List = new ObservableCollection<ValidateUserInfo>();
        }

        #region 全局屬性
     //   private ObservableCollection<ValidateUserInfo> list;
        /// <summary>
        /// 用戶數據列表
        /// </summary>
        public ObservableCollection<ValidateUserInfo> List
        {
            get;
            set;
        }

        private ValidateUserInfo validateUI;
        /// <summary>
        /// 當前操作的用戶信息
        /// </summary>
        public ValidateUserInfo ValidateUI
        {
            get { return validateUI; }
            set
            {
                validateUI = value;
                RaisePropertyChanged(() => ValidateUI);
            }
        }
        #endregion

        #region

        private RelayCommand submitCmd;
        /// <summary>
        /// 執行提交命令的方法
        /// </summary>
        public RelayCommand SubmitCmd
        {
            get
            {
                if (submitCmd == null) return new RelayCommand(() => ExcuteValidForm(), CanExcute);
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
        /// 執行提交方法
        /// </summary>
        private void ExcuteValidForm()
        {
            List.Add(new ValidateUserInfo() { UserEmail = ValidateUI.UserEmail, UserName = ValidateUI.UserName, UserPhone = ValidateUI.UserPhone });
        }

        private bool CanExcute()
        {
            return ValidateUI.IsValidated;
        }
        #endregion

    }
}
