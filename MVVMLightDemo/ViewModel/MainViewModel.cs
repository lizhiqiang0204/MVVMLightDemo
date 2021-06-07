using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using MVVMLightDemo.View;
using System;
using System.Windows.Controls;

namespace MVVMLightDemo.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        #region ��Ա
        TextBox TextBoxLog = new TextBox();
        public UserControl UserUI1 = new UI1View();
        public UserControl UserUI2 = new UI2View();
        #endregion

        #region ���췽��
        public MainViewModel()
        {
            ///Messenger����ʹ
            ///Recipient���ռ���
            Messenger.Default.Register<string>(this, "Log", msg =>  //ע��Log��Ϣ ������������־�ı�׷���ı�
            {
                TextLog += msg;
            });
        }
        #endregion

        #region ������
        //��ҳ������ݳ�����
        private UserControl _content;
        public UserControl Content
        {
            get { return _content; }
            set { _content = value;RaisePropertyChanged(() => Content);}
        }
        //�ı���־
        private string textlog;
        public string TextLog
        {
            get { return textlog; }
            set { textlog = value; RaisePropertyChanged(() => TextLog); }
        }
        #endregion

        #region Button UI1����
        private RelayCommand ui1Command;
        public RelayCommand UI1Command
        {
            get
            {
                if (ui1Command == null)
                    ui1Command = new RelayCommand(() => ExcuteUI1Command());
                return ui1Command;

            }
            set { ui1Command = value; }
        }

        private void ExcuteUI1Command()
        {
            Content = UserUI1;
        }
        #endregion

        #region Button UI2����
        private RelayCommand ui2Command;
        public RelayCommand UI2Command
        {
            get
            {
                if (ui2Command == null)
                    ui2Command = new RelayCommand(() => ExcuteUI2Command());
                return ui2Command;

            }
            set { ui2Command = value; }
        }

        private void ExcuteUI2Command()
        {
            Content = UserUI2;
        }
        #endregion

        #region TextBox 
        private RelayCommand<TextBox> textBoxLoadedCommand;
        public RelayCommand<TextBox> TextBoxLoadedCommand
        {
            get
            {
                if (textBoxLoadedCommand == null)
                    textBoxLoadedCommand = new RelayCommand<TextBox>((p) => ExecuteTextBoxLoadedCommandCommand(p));
                return textBoxLoadedCommand;
            }
            set { textBoxLoadedCommand = value; }
        }

        private void ExecuteTextBoxLoadedCommandCommand(TextBox p)
        {
            TextBoxLog = (System.Windows.Controls.TextBox)p;//TextBox���ص�ʱ���������Ϊ�������ݵ�ViewModel������������������Ϳ�����ViewModel��ʹ�øÿؼ������Է����Լ��¼�
            TextBoxLog.IsReadOnly = true;//��Ϊֻ����ʹ�ÿؼ������ԣ�
            TextBoxLog.TextChanged += TextBoxLog_TextChanged;//����ı������ı���¼���ʹ�ÿؼ����¼���
        }

        private void TextBoxLog_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBoxLog.ScrollToEnd();//�ı������ı��ʱ�����ı��Զ������ײ���ʹ�ÿؼ��ķ�����
        }
        #endregion
    }
}