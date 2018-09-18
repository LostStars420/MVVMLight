using System;
using MVVMLightDemo.Model;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;
using System.Collections;
using System.Collections.ObjectModel;
using GalaSoft.MvvmLight.Command;

namespace MVVMLightDemo.ViewModel
{
    public class BindingAdvancedViewModel : ViewModelBase
    {
        public BindingAdvancedViewModel()
        {
            InitCombbox();
            InitSingleRadio();
            InitCompRadio();
            InitCompCheck();
            InitTreeInfo();
            InitListBoxList();
            InitUCList();
        }

        #region 下拉框相关
        private ComplexInfoModel combboxItem;
        /// <summary>
        /// 下拉框选中信息
        /// </summary>
        public ComplexInfoModel CombboxItem
        {
            get { return combboxItem; }
            set { combboxItem = value; RaisePropertyChanged(() => CombboxItem); }
        }

        private List<ComplexInfoModel> combboxList;
        /// <summary>
        /// 下拉框列表
        /// </summary>
        public List<ComplexInfoModel> CombboxList
        {
            get { return combboxList; }
            set { combboxList = value;RaisePropertyChanged(() => CombboxItem); }
        }
        #endregion


        #region 单选框相关
        private String singleRadio;
        /// <summary>
        /// 单选框相关
        /// </summary>
        public String SingleRadio
        {
            get { return singleRadio; }
            set { singleRadio = value;RaisePropertyChanged(() => SingleRadio); }
        }

        private Boolean isSingleRadioCheck;
        /// <summary>
        /// 是否选中单选框 
        /// </summary>
        public Boolean IsSingleRadioCheck
        {
            get { return isSingleRadioCheck; }
            set { isSingleRadioCheck = value;RaisePropertyChanged(() => IsSingleRadioCheck); }
        }
        #endregion

        #region 组合单选框
        private List<CompBottonModel> radioButtons;
        /// <summary>
        /// 组合单选框列表
        /// </summary>
        public List<CompBottonModel> RadioButtons
        {
            get { return radioButtons; }
            set { radioButtons = value;RaisePropertyChanged(() => RadioButtons); }
        }

        private CompBottonModel radioButton;
        /// <summary>
        /// 组合单选框 选中值
        /// </summary>
        public CompBottonModel RadioButton
        {
            get { return radioButton; }
            set { radioButton = value;RaisePropertyChanged(() => RadioButton); }
        }
        #endregion

        #region 复选框
        private List<CompBottonModel> checkButtons;
        /// <summary>
        /// 组合复选框
        /// </summary>
        public List<CompBottonModel> CheckButtons
        {
            get { return checkButtons; }
            set { checkButtons = value;RaisePropertyChanged(() => CheckButtons); }
        }

        private String checkInfo;
        /// <summary>
        /// 确认框选中信息
        /// </summary>
        public String CheckInfo
        {
            get { return checkInfo; }
            set { checkInfo = value;RaisePropertyChanged(() => CheckInfo); }
        }
        #endregion

        #region 树
        private List<TreeNodeModel> treeInfo;

        public List<TreeNodeModel> TreeInfo
        {
            get { return treeInfo; }
            set { treeInfo = value;RaisePropertyChanged(() => TreeInfo); }
        }
        #endregion

        #region ListBox模板
        private IEnumerable listBoxData;
        /// <summary>
        /// ListBox数据模板
        /// </summary>
        public IEnumerable ListBoxData
        {
            get { return listBoxData; }
            set { listBoxData = value;RaisePropertyChanged(() => ListBoxData); }
        }

        #endregion

        #region 用户控件信息列表

        private ObservableCollection<FruitInfoViewModel> fiList;
        /// <summary>
        /// 用户控件数据
        /// </summary>
        public ObservableCollection<FruitInfoViewModel> FiList
        {
            get { return fiList; }
            set { fiList = value;RaisePropertyChanged(() => FiList); }
        }

        #endregion

        #region 命令

        private RelayCommand radioCheckCommand;
        /// <summary>
        /// 单选框命令
        /// </summary>
        public RelayCommand RadioCheckCommand
        {
            get
            {
                if (radioCheckCommand == null)
                    radioCheckCommand = new RelayCommand(() => ExcuteRadioCommand());
                return radioCheckCommand;

            }
            set { radioCheckCommand = value; }
        }
        private void ExcuteRadioCommand()
        {
            RadioButton = RadioButtons.Where(p => p.IsCheck).First();
        }


        private RelayCommand checkCommand;
        /// <summary>
        /// 复选框命令
        /// </summary>
        public RelayCommand CheckComand
        {
            get
            {
                if (checkCommand == null)
                    checkCommand = new RelayCommand(() => ExcuteCheckCommand());
                return checkCommand;

            }
            set { checkCommand = value; }
        }

        private void ExcuteCheckCommand()
        {
            CheckInfo = "";
            if (CheckButtons != null && CheckButtons.Count > 0)
            {
                var list = CheckButtons.Where(p => p.IsCheck);
                if (list.Count() > 0)
                {
                    foreach (var l in list)
                    {
                        CheckInfo += l.Content + ",";
                    }
                }
            }
        }
        #endregion

        public void InitCombbox()
        {
            CombboxList = new List<ComplexInfoModel>()
            {
                new ComplexInfoModel(){ Key="1",Text="Apple"},
                new ComplexInfoModel(){ Key="2",Text="Orange"},
                new ComplexInfoModel(){ Key="3",Text="Banana"},
                new ComplexInfoModel(){ Key="1",Text="Cherry"},
            };
        }

        public void InitSingleRadio()
        {
            singleRadio = "喜欢吃香蕉";
            isSingleRadioCheck = true;
        }

        public void InitCompRadio()
        {
            RadioButtons = new List<CompBottonModel>()
            {
                new CompBottonModel(){ Content="Apple", IsCheck=false },
                new CompBottonModel(){ Content="Banana", IsCheck=false },
                new CompBottonModel(){ Content="Cheery", IsCheck=false },
                new CompBottonModel(){ Content="pearl", IsCheck=false },
            };
        }

        public void InitCompCheck()
        {
            CheckButtons = new List<CompBottonModel>()
            {
                new CompBottonModel(){ Content="苹果", IsCheck = false },
                new CompBottonModel(){ Content="香蕉", IsCheck = false },
                new CompBottonModel(){ Content="梨", IsCheck = false },
                new CompBottonModel(){ Content="樱桃", IsCheck = false },
            };
        }

        public void InitTreeInfo()
        {
            TreeInfo = new List<TreeNodeModel>()
            {
                new TreeNodeModel()
                {
                    NodeID="1",NodeName="苹果",Children=new List<TreeNodeModel>()
                    {
                        new TreeNodeModel(){ NodeID="1.1", NodeName ="苹果A" },
                        new TreeNodeModel(){ NodeID="1.2", NodeName ="苹果B" },
                        new TreeNodeModel(){ NodeID="1.3", NodeName ="苹果C",Children = new List<TreeNodeModel>(){
                            new TreeNodeModel(){ NodeID="1.3.1", NodeName ="苹果C1" },
                            new TreeNodeModel(){ NodeID="1.3.2", NodeName ="苹果C2" },
                    } },
                    }
                },
                new TreeNodeModel(){
                  NodeID = "2", NodeName = "香蕉",Children=new List<TreeNodeModel>(){
                    new TreeNodeModel(){ NodeID="2.1", NodeName ="香蕉A" },
                    new TreeNodeModel(){ NodeID="2.2", NodeName ="香蕉B" },
                    new TreeNodeModel(){ NodeID="2.3", NodeName ="香蕉C" }
                  }
                }
            };
        }

        public void InitListBoxList()
        {
            ListBoxData = new ObservableCollection<dynamic>()
            {
                new { Img="/MVVMLightDemo;component/Images/鹿晗vivo.PNG",Info="鹿晗Vivo" },
                new { Img="/MVVMLightDemo;component/Images/鹿晗爱彼.PNG",Info="鹿晗爱彼" },
            };
        }

        public void InitUCList()
        {
            FiList = new ObservableCollection<FruitInfoViewModel>() {
                 new FruitInfoViewModel{ Img = "/MVVMLightDemo;component/Images/鹿晗vivo.png", Info= "鹿晗vivo"},
                 new FruitInfoViewModel{ Img = "/MVVMLightDemo;component/Images/鹿晗爱彼.png", Info = "鹿晗爱彼"}
            };
        }
    }
}
