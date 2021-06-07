using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVMLightDemo.ViewModel
{
    public class UI2ViewModel : ViewModelBase
    {
        private RelayCommand btnCommand;
        public RelayCommand BtnCommand
        {
            get
            {
                if (btnCommand == null)
                    btnCommand = new RelayCommand(() => ExcuteBtnCommand());
                return btnCommand;

            }
            set { btnCommand = value; }
        }

        private void ExcuteBtnCommand()
        {
            Messenger.Default.Send<string>("我是UI2！\n", "Log");//向Log发送消息 （追加文本）
        }
    }
}
