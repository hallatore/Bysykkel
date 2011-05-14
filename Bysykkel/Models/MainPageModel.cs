using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Device.Location;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Bysykkel.BysykkelApiModel;
using Microsoft.Phone.Controls.Maps;

namespace Bysykkel.Models
{
    public class MainPageModel : INotifyPropertyChanged
    {
        public MainPageModel()
        {
            Racks = new ObservableCollection<Rack>();
        }

        private ObservableCollection<Rack> racks;
        public ObservableCollection<Rack> Racks
        {
            get { return racks; }
            set
            {
                if (value != racks)
                {
                    racks = value;
                    NotifyPropertyChanged("Racks");
                }
            }
        }

        private GeoCoordinate currentPosition;
        public GeoCoordinate CurrentPosition
        {
            get { return currentPosition; }
            set
            {
                if (value != currentPosition)
                {
                    currentPosition = value;
                    NotifyPropertyChanged("CurrentPosition");
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (null != handler)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
