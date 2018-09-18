using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using GalaSoft.MvvmLight.Command;
using System.Windows;


namespace MVVMLightDemo.ViewModel
{
    [MetadataType(typeof(BindDataAnnotationsViewModel))]
    public class BindDataAnnotationsViewModel : ViewModelBase, IDataErrorInfo
    {
        public BindDataAnnotationsViewModel()
        {

        }

        #region 屬性
        /// <summary>
        /// 表單驗證錯誤集合
        /// </summary>
        private Dictionary<String, String> dataErrors = new Dictionary<string, string>();


        private String userName;
        /// <summary>
        /// 用戶名
        /// </summary>
        [Required]
        public String UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        private String userPhone;
        /// <summary>
        /// 用戶電話
        /// </summary>
        [Required]
        [RegularExpression(@"^[-]?[1-9]{8,11}\d*$|^[0]{1}$",ErrorMessage ="用戶電話必須為8-11位的數值")]
        public String UserPhone
        {
            get { return userPhone; }
            set { userPhone = value; }
        }

        private String userEmail;
        
        [Required]
        [StringLength(100,MinimumLength =2)]
        [RegularExpression("^\\s*([A-Za-z0-9_-]+(\\.\\w+)*@(\\w+\\.)+\\w{2,5})\\s*$",ErrorMessage ="請填寫正確的郵箱地址")]
        public String UserEmail
        {
            get { return userEmail; }
            set { userEmail = value; }
        }

        #endregion

        #region
        private RelayCommand validFormCommand;
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
             if (dataErrors.Count == 0)
                MessageBox.Show("验证通过！");
              else
                MessageBox.Show("验证失败！");
         }
         #endregion

        public string this[string columnName]
        {
            get
            {
                ValidationContext vc = new ValidationContext(this, null, null);
                vc.MemberName = columnName;
                var res = new List<ValidationResult>();
                var result = Validator.TryValidateProperty(this.GetType().GetProperty(columnName).GetValue(this, null), vc, res);
                if (res.Count > 0)
                {
                    AddDic(dataErrors, vc.MemberName);
                    return string.Join(Environment.NewLine, res.Select(r => r.ErrorMessage).ToArray());
                }
                RemoveDic(dataErrors, vc.MemberName);
                return null;
            }
        }

        public string Error
        {
            get
            {
                return null;
            }
        }

        #region 附屬方法

        /// <summary>
        /// 移除字典
        /// </summary>
        /// <param name="dics"></param>
        /// <param name="dicKey"></param>
        private void RemoveDic(Dictionary<string,string> dics,String dicKey)
        {
            dics.Remove(dicKey);
        }

        private void AddDic(Dictionary<string,string> dics,string dicKey)
        {
            if (!dics.ContainsKey(dicKey))
            {
                dics.Add(dicKey, "");
            }
        }
        #endregion

    }
}
