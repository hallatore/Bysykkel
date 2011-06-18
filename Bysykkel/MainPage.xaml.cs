using System;
using System.ComponentModel;
using System.Device.Location;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Xml.Linq;
using Bysykkel.BysykkelApiModel;
using Bysykkel.Models;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Controls.Maps;

namespace Bysykkel
{
    public partial class MainPage : PhoneApplicationPage, INotifyPropertyChanged
    {
        private GeoCoordinateWatcher watcher;
        private Border currentPositionRectangle;

        // Constructor
        public MainPage()
        {
            InitializeComponent();

            watcher = new GeoCoordinateWatcher(GeoPositionAccuracy.High);
            watcher.PositionChanged += watcher_PositionChanged;
            watcher.Start();
        }

        void watcher_PositionChanged(object sender, GeoPositionChangedEventArgs<GeoCoordinate> e)
        {
            Model.CurrentPosition = e.Position.Location;

            if (currentPositionRectangle == null)
            {
                AddMyLocation();
            }
            else
            {
                currentPositionRectangle.SetValue(MapLayer.PositionProperty, Model.CurrentPosition);
            }
        }

        private void AddMyLocation()
        {
            currentPositionRectangle = GetCurrentLocationControl();

            myLayer.AddChild(currentPositionRectangle, Model.CurrentPosition);
            map.Center = Model.CurrentPosition;
            map.ZoomLevel = 15;
        }

        private Border GetCurrentLocationControl()
        {
            return new Border
            {
                Height = 25,
                Width = 25,
                Background = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)),
                BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255)),
                BorderThickness = new Thickness(1),
                CacheMode = new BitmapCache(),
                Child = new Border
                {
                    CornerRadius = new CornerRadius(6),
                    Height = 13,
                    Width = 13,
                    Background = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0))
                },
                RenderTransform = new RotateTransform(){ Angle = 45}
            };
        }

        private MainPageModel model;
        public MainPageModel Model
        {
            get { return model; }
            set
            {
                if (value != model)
                {
                    model = value;
                    NotifyPropertyChanged("Model");
                }
            }
        }

        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            GeoCoordinate center = null;
            double zoomLevel = 0;

            if (State.ContainsKey("Model"))
            {
                Model = State["Model"] as MainPageModel;
                center = State["Center"] as GeoCoordinate;
                zoomLevel = (double)State["ZoomLevel"];
            }

            LoadPage(center, zoomLevel);
        }

        protected override void OnNavigatedFrom(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            State.Save("Model", Model);
            State.Save("Center", map.Center);
            State.Save("ZoomLevel", map.ZoomLevel);
        }

        private void LoadPage(GeoCoordinate center, double zoomLevel)
        {
            if (Model != null)
            {
                map.SetView(center, zoomLevel);
                AddMyLocation();

                foreach (var rack in Model.Racks)
                {
                    AddRackToMap(rack);
                }
            }
            else
            {
                Model = new MainPageModel();
                map.SetView(new GeoCoordinate(59.91786, 10.739735), 13);
            }

            Model.Racks.CollectionChanged += Racks_CollectionChanged;

            var service = new ClearChannelService.ClearChannelSoapClient();
            service.getRacksCompleted += service_getRacksCompleted;
            service.getRacksAsync();
        }

        void Racks_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Add)
            {
                foreach (Rack rack in e.NewItems)
                {
                    AddRackToMap(rack);
                }
            }
            else if (e.Action == System.Collections.Specialized.NotifyCollectionChangedAction.Remove)
            {
                foreach (Rack rack in e.OldItems)
                {
                    RemoveRackFromMap(rack);
                }
            }
        }

        private void RemoveRackFromMap(Rack rack)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                var item = myLayer.Children.FirstOrDefault(r => ((FrameworkElement) r).DataContext == rack);
                if (item != null)
                    myLayer.Children.Remove(item);
            });
        }

        private Random ran = new Random();

        private void AddRackToMap(Rack rack)
        {
            this.Dispatcher.BeginInvoke(() =>
            {
                //var pin = new Pushpin();
                //pin.Location = new GeoCoordinate(rack.Latitude, rack.Longitude);
                //pin.Content = rack.Id.ToString();
                //pin.CacheMode = new BitmapCache();
                //map.Children.Add(pin);

                myLayer.AddChild(GetRackControl(rack), new GeoCoordinate(rack.Latitude, rack.Longitude), new Point(pinSize / -2, pinSize / -2));
            });
        }

        private const int pinSize = 35;
        private FrameworkElement GetRackControl(Rack rack)
        {
            //var control = new Border
            //{
            //    Width = size,
            //    Height = size,
            //    Background = new SolidColorBrush(GetColorGradiant(rack.Bikes)),
            //    DataContext = rack,
            //    //CornerRadius = new CornerRadius(3),
            //    BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)),
            //    BorderThickness = new Thickness(1),
            //    CacheMode = new BitmapCache()
            //};

            //control.Child = new Border
            //{
            //    Width = size,
            //    Height = size / 2,
            //    Background = new SolidColorBrush(GetColorGradiant(rack.EmptyLocks)),
            //    Margin = new Thickness(0, size / 2 - 1, 0, 0),
            //    //CornerRadius = new CornerRadius(0,0,3,3),
            //    BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0)),
            //    BorderThickness = new Thickness(0,1,0,0)
            //};

            var control = new Ellipse
            {
                Fill = new SolidColorBrush(GetColorGradiant(rack.EmptyLocks)),
                Stroke = new SolidColorBrush(GetColorGradiant(rack.Bikes)),
                StrokeThickness = 7,
                Width = pinSize,
                Height = pinSize,
                DataContext = rack,
                VerticalAlignment = System.Windows.VerticalAlignment.Center,
                HorizontalAlignment = System.Windows.HorizontalAlignment.Center,
            };

            if (!rack.Online)
            {
                var brush = new SolidColorBrush(Color.FromArgb(255, 100, 100, 100));
                control.Fill = brush;
                control.Stroke = brush;
            }


            var button = new Button
            {
                Content = control,
                Margin = new Thickness(0),
                CacheMode = new BitmapCache(),
                Style = (Style)App.Current.Resources["TransparentButtonStyle"]
            };
            button.Click += button_Click;

            return button;
        }
        private Ellipse lastRack;

        void button_Click(object sender, RoutedEventArgs e)
        {
            if (lastRack != null)
            {
                var tmpRack = lastRack.DataContext as Rack;
                lastRack.Fill = new SolidColorBrush(GetColorGradiant(tmpRack.EmptyLocks));
                lastRack.Stroke = new SolidColorBrush(GetColorGradiant(tmpRack.Bikes));
            }

            lastRack = ((Ellipse) ((Button)sender).Content);
            var rack = lastRack.DataContext as Rack;

            if (rack == null) return;

            SetSummaryText(rack);

            lastRack.Fill = new SolidColorBrush(Color.FromArgb(255,255,255,255));
            lastRack.Stroke = new SolidColorBrush(Color.FromArgb(255, 55, 55, 55));
        }

        private void SetSummaryText(Rack rack)
        {
            string text = "";
            if (rack.Online)
            {
                text = rack.Bikes + " ";

                if (rack.Bikes == 1)
                    text += "sykkel - ";
                else
                    text += "sykler - ";

                text += rack.EmptyLocks + " ";

                if (rack.EmptyLocks == 1)
                    text += "plass";
                else
                    text += "plasser";
            }
            else
            {
                text = "Ukjent";
            }

            SummaryAmount.Text = text;

            if (!string.IsNullOrEmpty(rack.Description.Trim()))
                SummaryTitle.Text = rack.Description.Substring(3).Trim();
            else
                SummaryTitle.Text = string.Empty;

            //Summary.Visibility = System.Windows.Visibility.Visible;

            Storyboard popupStoryboard = (Storyboard)PopupGrid.Resources["PopupStoryBoard"];
            popupStoryboard.Begin();
        }

        private const int maxValue = 230;
        private Color GetColorGradiant(int count)
        {
            var value = (double)Math.Min(count, 6)/6* (maxValue*2);
            byte emptyLocksRed = (byte)(Math.Min(maxValue, (maxValue*2) - value));
            byte emptyLocksGreen = (byte)(Math.Min(maxValue, value));

            return Color.FromArgb(255, emptyLocksRed, emptyLocksGreen, 0);
        }

        void service_getRacksCompleted(object sender, ClearChannelService.getRacksCompletedEventArgs e)
        {
            var xmlDoc = XDocument.Parse("<racks>" + e.Result + "</racks>");

            var racks = from item in xmlDoc.Descendants("station")
                        select new Rack
                        {
                            Id = Convert.ToInt32(item.Value)
                        };

            var service = new ClearChannelService.ClearChannelSoapClient();
            service.getRackCompleted += service_getRackCompleted;

            foreach (var rack in racks)
            {
                service.getRackAsync(rack.Id, rack);
            }
        }

        void service_getRackCompleted(object sender, ClearChannelService.getRackCompletedEventArgs e)
        {
            try
            {
                var rack = (Rack)e.UserState;

                var xmlDoc = XDocument.Parse(e.Result.Replace("&", "&amp;"));

                var node = xmlDoc.Element("station");
                rack.Description = node.Element("description").Value;
                rack.Longitude = Convert.ToDouble(node.Element("longitute").Value);
                rack.Latitude = Convert.ToDouble(node.Element("latitude").Value);
                rack.Bikes = Convert.ToInt32(node.Element("ready_bikes").Value);
                rack.EmptyLocks = Convert.ToInt32(node.Element("empty_locks").Value);
                rack.Online = node.Element("online").Value == "1" ? true : false;


                Rack oldRack = Model.Racks.SingleOrDefault(r => r.Id == rack.Id);

                if (oldRack != null)
                    Model.Racks.Remove(oldRack);

                Model.Racks.Add(rack);
            }
            catch { }
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

        private void ApplicationBarIconButton_Click(object sender, EventArgs e)
        {
            if (Model.CurrentPosition != null)
                map.Center = Model.CurrentPosition;
        }

        private void ApplicationBarIconButton_Click_1(object sender, EventArgs e)
        {
            Summary.Visibility = Visibility.Collapsed;

            var service = new ClearChannelService.ClearChannelSoapClient();
            service.getRacksCompleted += service_getRacksCompleted;
            service.getRacksAsync();
        }
    }
}