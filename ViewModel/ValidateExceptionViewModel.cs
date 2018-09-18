using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMLightDemo.ViewModel
{
    public class ValidateExceptionViewModel:ViewModelBase
    {
        public ValidateExceptionViewModel()
        {

        }

        private String userNameEx;

        public string UserNameEx
        {
            get { return userNameEx; }
            set
            {
                userNameEx = value;
                RaisePropertyChanged(() => UserNameEx);
                if (string.IsNullOrEmpty(value))
                {
                    throw new ApplicationException("該字段不能爲空！");
                }
            }
        }
    }
}
