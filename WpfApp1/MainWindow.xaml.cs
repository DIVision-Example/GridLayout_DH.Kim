using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.VisualBasic;


namespace WpfApp1 {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        struct Block {
            public int width;
            public int height;
        }

        struct Tile {
            public int width;
            public int height;
        }

        Tile tile;

        String[] blockname = new string[7];

        Block[] blocks = new Block[7];
        TextBlock[] TxtBlocks = new TextBlock[7];

        TextBlock[] TableX = new TextBlock[7];
        TextBlock[] TableY = new TextBlock[7];
        TextBlock[] TableSize = new TextBlock[7];
        TextBlock[] TableTiles = new TextBlock[7];

        public String BlockName;

        bool btnFlags = false;

        public MainWindow() {
            InitializeComponent();

            TxtBlocks[0] = lbsizeofBlock1;
            TxtBlocks[1] = lbsizeofBlock2;
            TxtBlocks[2] = lbsizeofBlock3;
            TxtBlocks[3] = lbsizeofBlock4;
            TxtBlocks[4] = lbsizeofBlock5;
            TxtBlocks[5] = lbsizeofBlock6;
            TxtBlocks[6] = lbsizeofBlock7;

            TableX[0] = x1;
            TableX[1] = x2;
            TableX[2] = x3;
            TableX[3] = x4;
            TableX[4] = x5;
            TableX[5] = x6;
            TableX[6] = x7;

            TableY[0] = y1;
            TableY[1] = y2;
            TableY[2] = y3;
            TableY[3] = y4;
            TableY[4] = y5;
            TableY[5] = y6;
            TableY[6] = y7;

            TableSize[0] = size1;
            TableSize[1] = size2;
            TableSize[2] = size3;
            TableSize[3] = size4;
            TableSize[4] = size5;
            TableSize[5] = size6;
            TableSize[6] = size7;

            TableTiles[0] = t1;
            TableTiles[1] = t2;
            TableTiles[2] = t3;
            TableTiles[3] = t4;
            TableTiles[4] = t5;
            TableTiles[5] = t6;
            TableTiles[6] = t7;

            TileWidth.Text = TileHeight.Text = "";

            for(int i = 0; i < blockname.Length; i++) {
                blockname[i] = "Block" + (i + 1);
            }

            CheckBlocks();
        }

        private void CheckBlocks() {
            int TileSize;

            // lstitle.Title = lstitle.ActualHeight.ToString();

            for (int i = 0; i < blocks.Length; i++) {
                blocks[i].width = (int)Math.Ceiling(TxtBlocks[i].ActualWidth);
                blocks[i].height = (int)Math.Ceiling(TxtBlocks[i].ActualHeight);
            }

            // display data
            for (int i = 0; i < TxtBlocks.Length; i++) {
                // blockname[i] = "Block" + (i + 1);
                // TxtBlocks[i].Text = $"{blockname[i]} : {blocks[i].width} * {blocks[i].height} ";
                TxtBlocks[i].Text = $"{blockname[i]}";

                TableX[i].Text = $"{blocks[i].width} pixel";
                TableY[i].Text = $"{blocks[i].height} pixel";

                TableSize[i].Text = $"{blocks[i].width * blocks[i].height} pixel²";
                if(btnFlags) {
                    tile.width = Int32.Parse(TileWidth.Text);
                    tile.height = Int32.Parse(TileHeight.Text);

                    checktiles();
                }
            }
        }

        private void Grid_SizeChanged(object sender, SizeChangedEventArgs e) {
            CheckBlocks();
        }

        private void checktiles() {
            int TileSize;
            int minwidth;
            int minheight;

            bool flags1, flags2;

            for (int i = 0; i < TableTiles.Length; i++) {

                if (blocks[i].width % tile.width == 0) {
                    minwidth = (int)(blocks[i].width / tile.width);
                    flags1 = false;
                } else {
                    minwidth = (int)(blocks[i].width / tile.width) + 1;
                    flags1 = true;
                }

                if (blocks[i].height % tile.height == 0) {
                    minheight = (int)(blocks[i].height / tile.height);
                    flags2 = false;
                } else {
                    minheight = (int)(blocks[i].height / tile.height) + 1;
                    flags2 = true;
                }
                if (flags1 && flags2) minheight -= 1;
                TableTiles[i].Text = $"{minwidth + minheight}";
            }
        }

        private void btnSetTiles_Click(object sender, RoutedEventArgs e) {
            if(btnFlags) {
                btnSetTiles.Content = "Set";

                TileWidth.IsEnabled = true;
                TileHeight.IsEnabled = true;

                btnFlags = false;
            } else {
                if (TileWidth.Text == "" || TileHeight.Text == "") MessageBox.Show("Type size of Tile", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                else {
                    try {
                        tile.width = Int32.Parse(TileWidth.Text);
                        tile.height = Int32.Parse(TileHeight.Text);

                        checktiles();



                        TileWidth.IsEnabled = false;
                        TileHeight.IsEnabled = false;
                        btnFlags = true;
                        btnSetTiles.Content = "Reset";
                    } catch(DivideByZeroException ex) {
                        Console.WriteLine("Zero Division Exception Accured..");
                        MessageBox.Show("Cannot enter value. '0'", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }                
            }
            CheckBlocks();
        }

        private void ShowBlockName(object sender, MouseButtonEventArgs e) {
            FrameworkElement fe = e.Source as FrameworkElement;
            String temp = "";

            MessageBox.Show(((TextBlock)fe).Text);
            String input = Interaction.InputBox("Type new name of block.", "Change");

            ((TextBlock)fe).Text = input;
            // Changer ch = new Changer(fe);
            // ch.ShowDialog();
        }
    }
}
