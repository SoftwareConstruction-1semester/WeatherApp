using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Windows.Data.Xml.Dom;
using Windows.Networking.Sockets;
using WeatherApp.Annotations;
using WeatherApp.model;
using WpfApplication.ViewModel;

namespace WeatherApp.viewmodel
{
    class weatherviewmodel : INotifyPropertyChanged
    {
        private weathermodel _weather;
        private string _city;
        private ICommand _setCityCommand;

        public weatherviewmodel()
        {
            _city = "Roskilde";
            _weather = new weathermodel();
            _setCityCommand = new RelayCommand(SetCityCommand) { IsEnabled = true };
            loadXML();
        }

        public async void loadXML()
        {
            try
            {
                Uri weatherUrl =
                    new Uri("http://api.openweathermap.org/data/2.5/weather?q=Roskilde,DK&mode=xml&units=metric");

                XmlDocument doc = await XmlDocument.LoadFromUriAsync(weatherUrl);

                _weather.Temperature = doc.GetElementsByTagName("temperature")[0].Attributes[0].NodeValue.ToString();
                _weather.Humidity = doc.GetElementsByTagName("humidity")[0].Attributes[0].NodeValue.ToString();
                _weather.Wind = doc.GetElementsByTagName("speed")[0].Attributes[1].NodeValue.ToString();
                _weather.Sunrise = doc.GetElementsByTagName("sun")[0].Attributes[0].NodeValue.ToString().Substring(11);
                _weather.Sunset = doc.GetElementsByTagName("sun")[0].Attributes[1].NodeValue.ToString().Substring(11);
                _weather.Cloudiness = doc.GetElementsByTagName("clouds")[0].Attributes[1].NodeValue.ToString();
                OnPropertyChanged("Weather");
            }
            catch (Exception)
            {

            }
        }

        public String City
        {
            get
            {
                return _city;
            }
        }

        public ICommand SetCity
        {
            get
            {
                return _setCityCommand;
            }
        }

        public weathermodel Weather
        {
            get
            {
                return _weather;
            }
        }

        private void SetCityCommand()
        {
            // set city stuff
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
