using Endpoint.Models;
using Endpoint.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System.Windows.Input;
using System.ComponentModel;
using System.Windows;
using System.Threading;

namespace Kliens.ViewModel
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private string errorMessage;

        public string ErrorMessage
        {
            get { return errorMessage; }
            set { SetProperty(ref errorMessage, value); }
        }

        public RestCollection<Message> Messages { get; set; }
        
        private Message selectedMessage;

        public Message SelectedMessage
        {
            get { return selectedMessage; }
            set 
            { 
                if (value != null)
                {
                    selectedMessage = new Message()
                    {
                        Msg = value.Msg,
                        DTStamp = value.DTStamp,
                        SenderName = value.SenderName
                    };
                    OnPropertyChanged();
                    //(DeleteMessageCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public ICommand CreateMessageCommand { get; set; }
        public ICommand GetAllMessageCommand { get; set; }
        public ICommand DeleteMessageCommand { get; set; }

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        public MainWindowViewModel()
        {
            //Thread.Sleep(8000); 

            if (!IsInDesignMode)
            {
                Messages = new RestCollection<Message>("http://localhost:14347/", "Message", "hub");
                CreateMessageCommand = new RelayCommand(() =>
                {
                    Messages.Add(new Message()
                    {
                        SenderName = SelectedMessage.SenderName,
                        DTStamp = DateTime.Now,
                        Msg = SelectedMessage.Msg
                    });
                });

                GetAllMessageCommand = new RelayCommand(() =>
                {
                    Messages.Add(new Message()
                    {
                        SenderName = SelectedMessage.SenderName,
                        DTStamp = DateTime.Now,
                        Msg = SelectedMessage.Msg
                    });
                });

                //DeleteMessageCommand = new RelayCommand(() =>
                //{
                //    Messages.Delete(SelectedMessage.MessageId);
                //},
                //() =>
                //{
                //    return SelectedMessage != null;
                //});
                SelectedMessage = new Message();
            }
        }
    }
}
