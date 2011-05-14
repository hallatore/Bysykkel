using System;
using System.ComponentModel;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Bysykkel.BysykkelApiModel
{
    public class Rack : INotifyPropertyChanged
    {
        private int id;
        public int Id
        {
            get { return id; }
            set
            {
                if (value != id)
                {
                    id = value;
                    NotifyPropertyChanged("Id");
                }
            }
        }

        private String description;
        public String Description
        {
            get { return description; }
            set
            {
                if (value != description)
                {
                    description = value;
                    NotifyPropertyChanged("Description");
                }
            }
        }

        private double latitude;
        public double Latitude
        {
            get { return latitude; }
            set
            {
                if (value != latitude)
                {
                    latitude = value;
                    NotifyPropertyChanged("Latitude");
                }
            }
        }

        private double longitude;
        public double Longitude
        {
            get { return longitude; }
            set
            {
                if (value != longitude)
                {
                    longitude = value;
                    NotifyPropertyChanged("Longitude");
                }
            }
        }

        private int emptyLocks;
        public int EmptyLocks
        {
            get { return emptyLocks; }
            set
            {
                if (value != emptyLocks)
                {
                    emptyLocks = value;
                    NotifyPropertyChanged("EmptyLocks");
                }
            }
        }

        private int bikes;
        public int Bikes
        {
            get { return bikes; }
            set
            {
                if (value != bikes)
                {
                    bikes = value;
                    NotifyPropertyChanged("Bikes");
                }
            }
        }

        private bool online;
        public bool Online
        {
            get { return online; }
            set
            {
                if (value != online)
                {
                    online = value;
                    NotifyPropertyChanged("Online");
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
