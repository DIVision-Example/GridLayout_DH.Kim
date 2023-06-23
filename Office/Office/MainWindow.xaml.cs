using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;

namespace Office {
    /// <summary>
    /// Interaction logic for MainWindow.xaml 홍길동
    /// </summary>
    /// 

    /*
    public class Space {
        public TextBlock Room;  // obj

        public int Width {
            get {
                return (int)Room.ActualWidth;
            }
        }
        public int Height {
            get {
                return (int)Room.ActualHeight;
            }
        }

        public string Name {
            get {
                return Room.Text;
            }
        }
        public int TileCount { 
            get {
                return Tile.GetCount(Width, Height);
            }
        }

        // Constructor
        public Space(TextBlock space) {
            this.Room = space;
        }
    }

    public class Tile {
        public int Width;
        public int Height;

        static public int GetCount(int width, int height) {
            // 계산하는 로직 출력
            return 0;
        }
    }
    */

    public partial class MainWindow : Window {
        /*
        ObservableCollection<Space> Rooms { get; set; }
        public MainWindow() {
            InitializeComponent();

            Rooms = new ObservableCollection<Space> {
                new Space(Office1),
                new Space(Office2),
                new Space(Office3)
            };

        }
        */
        
        private void refresh() {
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e) {
            refresh();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e) {
            List<Office> Rooms = new List<Office>();
            Rooms.Add(new Office { Name = "이지원", Width = 10, Height = 10, Area = 100, Tiles = 10 });
            Rooms.Add(new Office { Name = "김동휘", Width = 20, Height = 10, Area = 100, Tiles = 10 });
            Rooms.Add(new Office { Name = "박연택", Width = 30, Height = 10, Area = 100, Tiles = 10 });

            OfficeList.ItemsSource = Rooms;
        }
    }

    public class Office {
        public string Name { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Area { get; set; }
        public int Tiles { get; set; }
    }
}
