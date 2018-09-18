using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVMLightDemo.Model
{
    public class CompBottonModel : ObservableObject
    {
        public CompBottonModel()
        {

        }

        private String content;
        /// <summary>
        /// 单选框内容
        /// </summary>
        public String Content
        {
            get { return content; }
            set { content = value;RaisePropertyChanged(() => Content); }
        }

        private Boolean isCheck;
        /// <summary>
        /// 单选框是否选中
        /// </summary>
        public Boolean IsCheck
        {
            get { return isCheck; }
            set { isCheck = value;RaisePropertyChanged(() => IsCheck); }
        }

    }
}
