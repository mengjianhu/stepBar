using HandyControl.Controls;
using HandyControl.Tools.Extension;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2023  All Rights Reserved.
 * 文 件 名:  Page2ViewModel
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2023-1-9 16:28:36
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2023-1-9 16:28:36
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace Shopping.ViewModels
{
    public class Page2ViewModel : BindableBase, INavigationAware
    {
        public DelegateCommand upStep { get; set; }
        IRegionManager regionManager;
        public Page2ViewModel(IRegionManager regionManager )
        {
           this. regionManager = regionManager;
            upStep = new DelegateCommand(upStep1);
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
          return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
           
        }
        private void upStep1()
        {
            MessageBox.Show("上一步");
            
            regionManager.Regions["test"].RequestNavigate( "UserControl1");
             
        }
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            NavigationParameters pairs = navigationContext.Parameters;
            if (pairs.Keys.Contains("name"))
            {
                if (pairs.Count > 0)
                    MessageBox.Show(pairs["name"].ToString());
            }
          
        }
    }
}
