using Newtonsoft.Json;
using Prism.Commands;
using Prism.Mvvm;
using SEPAL_2.x.x_WellsCreatedApplication.Model;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;

namespace SEPAL_2.x.x_WellsCreatedApplication.ViewModel
{
    public class WellCreatedViewModel:BindableBase
    {
        public WellCreatedViewModel()
        {
            ListenCommand = new DelegateCommand(ListenCommandAction);
            WellModel = new ObservableCollection<WellModel>();
        }

        public DelegateCommand ListenCommand { get; set; }
        private void ListenCommandAction()
        {
            Status = $" Listening to {channel}";
            var sub = connection.GetSubscriber();
            sub.SubscribeAsync(channel, (channel, message) =>
            {
                var wellmodelObject = JsonConvert.DeserializeObject<WellModel>(message);
                _wellModel = new WellModel
                {

                    WellName = wellmodelObject.WellName,
                    DrainagePoint= wellmodelObject.DrainagePoint,
                    CreatedBy= wellmodelObject.CreatedBy,
                    FieldName= wellmodelObject.FieldName,
                };

                Application.Current.Dispatcher.Invoke(() =>
                {
                    WellModel.Add(_wellModel);
                });
            });
        }

        private const string redisConnectionString = "127.0.0.1,6379";
        private string channel = "Channel1";
        private WellModel _wellModel;
        private ConnectionMultiplexer connection = ConnectionMultiplexer.Connect(redisConnectionString);
        

        private string status;
        public string Status
        {
            get { return status; }
            set { status = value; RaisePropertyChanged(); }
        }

        private ObservableCollection<WellModel> wellModel;
        public ObservableCollection<WellModel> WellModel
        {
            get { return wellModel; }
            set { wellModel = value; RaisePropertyChanged(); }
        }
    }
}
