using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace MVVMLightDemo.ViewModel
{
    public class BindingFormViewModel : ViewModelBase,IDataErrorInfo
    {
        public BindingFormViewModel()
        {

        }

        #region 属性

        private String userName;
        /// <summary>
        /// 用户名
        /// </summary>
        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }



        private String userPhone;
        /// <summary>
        /// 用户电话
        /// </summary>
        public String UserPhone
        {
            get { return userPhone; }
            set { userPhone = value; }
        }



        private String userEmail;
        /// <summary>
        /// 用户邮件
        /// </summary>
        public String UserEmail
        {
            get { return userEmail; }
            set { userEmail = value; }
        }

        #endregion


        #region 命令

        /* private RelayCommand validFormCommand;
         /// <summary>
         /// 验证表单
         /// </summary>
         public RelayCommand ValidFormCommand
         {
             get
             {
                 if (validFormCommand == null)
                     return new RelayCommand(() => ExcuteValidForm());
                 return validFormCommand;
             }
             set { validFormCommand = value; }
         }
         /// <summary>
         /// 验证表单
         /// </summary>
         private void ExcuteValidForm()
         {
             if (IsValid) MessageBox.Show("验证通过！");
             else MessageBox.Show("验证失败！");
         }
         */
        #endregion


        private bool IsValid
        {
            get;
            set;
        }

        public String Error
        {
            get { return null; }
        }


        public String this[string columnName]
        {
            get
            {
                Regex digitalReg = new Regex(@"^[-]?[1-9]{8,11}\d*$|^[0]{1}$");
                Regex emailReg = new Regex("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$");

                if (columnName == "UserName" && String.IsNullOrEmpty(this.UserName))
                {
                    return "用户名不能为空";
                }

                if (columnName == "UserPhone" && !String.IsNullOrEmpty(this.UserPhone))
                {
                    if (!digitalReg.IsMatch(this.UserPhone.ToString()))
                    {
                        return "用户电话必须为8-11位的数值！";
                    }
                }

                if (columnName == "UserEmail" && !String.IsNullOrEmpty(this.UserEmail))
                {
                    if (!emailReg.IsMatch(this.UserEmail.ToString()))
                    {
                        return "用户邮箱地址不正确！";
                    }
                }

                return null;
            }
        }
    }
}
