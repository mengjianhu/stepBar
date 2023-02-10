using HandyControl.Controls;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using static ImTools.ImMap;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2023  All Rights Reserved.
 * 文 件 名:  Page1ViewModel
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2023-1-9 15:57:08
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2023-1-9 15:57:08
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace Shopping.ViewModels
{
    public class Page1ViewModel : BindableBase, INavigationAware
    {
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; RaisePropertyChanged();}
        }
        private Color _background1;

        public Color  background1
        {
            get { return _background1; }
            set { _background1 = value;RaisePropertyChanged(); }
        }
       
        
        public DelegateCommand upStep { get; set; }
        public DelegateCommand nextStep { get; set; }
        IRegionManager regionManager;
        public Page1ViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            upStep = new DelegateCommand(upStep1);

            nextStep = new DelegateCommand(nextStep1);
           
            _background1 = (Color)ColorConverter.ConvertFromString("#827bff");
        }

        private void nextStep1()
        {
            NavigationParameters pairs = new NavigationParameters();
            pairs.Add("name", name);
            regionManager.Regions["test"].RequestNavigate("Page2View", pairs);

        }

        private void upStep1()
        {
            MessageBox.Show("上一步");
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {

        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            NavigationParameters keyValuePairs = navigationContext.Parameters;
        }
    }
}
