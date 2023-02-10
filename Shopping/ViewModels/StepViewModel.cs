using HandyControl.Controls;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Shopping.Views.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

/****************************************************************************************************************************************************************
 *
 * 版权所有: 2023  All Rights Reserved.
 * 文 件 名:  StepViewModel
 * 描    述:  
 * 创 建 者：  humengjian
 * 创建时间：  2023-1-9 16:09:53
 * 历史更新记录:
 * =============================================================================================
*修改标记
*修改时间：2023-1-9 16:09:53
*修改人： humengjian
*版本号： V1.0.0.0
*描述：
 * =============================================================================================

****************************************************************************************************************************************************************/
namespace Shopping.ViewModels
{
    public class StepViewModel : BindableBase
    {
        public int index { get; set; } = 0;
        private bool _isTrue = false;

        public bool isTrue
        {
            get { return _isTrue; }
            set { _isTrue = value; RaisePropertyChanged(); }
        }
        private bool _isNextTrue = true;

        public bool isNextTrue
        {
            get { return _isNextTrue; }
            set { _isNextTrue = value; RaisePropertyChanged(); }
        }
        private int _StepBarIndex;

        public int StepBarIndex
        {
            get { return _StepBarIndex; }
            set { _StepBarIndex = value; RaisePropertyChanged(); }
        }


        public List<string> stepList { get; set; }
        private readonly IRegionManager regionManager;
        public DelegateCommand textCommand { get; set; }
        public StepViewModel(IRegionManager regionManager)
        {
            textCommand = new DelegateCommand(testcommand);
            upStep = new DelegateCommand(upStep1);
            nextStep = new DelegateCommand(nextStep1);
            this.regionManager = regionManager;
            stepList = new List<string>();
            stepList.Add("Page1View");
            stepList.Add("Page2View");
            stepList.Add("Page3View");
        }

        private void testcommand()
        {

            regionManager.Regions["test"].RequestNavigate(stepList[index]);
        }



        public DelegateCommand upStep { get; set; }
        public DelegateCommand nextStep { get; set; }




        private void nextStep1()
        {

            MessageBox.Show("下一步");

            if (index >= 0)
            {
                index++;
                isTrue = true;

            }
            if (index == stepList.Count - 1)
            {
                isNextTrue = false;
            }
            NavigationParameters pairs = new NavigationParameters();
            pairs.Add("xxx", "123");
            regionManager.Regions["test"].RequestNavigate(stepList[index], pairs);

            StepBarIndex++;
        }

        private void upStep1()
        {
            MessageBox.Show("上一步");
            if (index > 0)
            {
                index--;
                if (index == 0)
                {
                    isTrue = false;
                    isNextTrue = true;
                }
                else
                {
                    isTrue = true;
                    isNextTrue = true;
                }
            }
            regionManager.Regions["test"].RequestNavigate(stepList[index]);
            if (StepBarIndex > 1)
            {
                StepBarIndex--;
            }

        }
    }
}
