using HandyControl.Controls;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2023  All Rights Reserved.
 * 文 件 名:  Page3ViewModel
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2023-1-9 16:50:26
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2023-1-9 16:50:26
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace Shopping.ViewModels
{
    public class Page3ViewModel : BindableBase, INavigationAware
    {
        private string _testValue;

        public string testValue
        {
            get { return _testValue; }
            set { _testValue = value; RaisePropertyChanged(); }
        }

        public Page3ViewModel()
        {

        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            NavigationParameters pairs = navigationContext.Parameters;
            if (pairs.Count > 0)
                MessageBox.Show(pairs["xxx"].ToString());

        }
    }
}
