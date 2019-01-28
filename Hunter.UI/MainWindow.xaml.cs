using Quacker_Hunter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MouseEventArgs = System.Windows.Input.MouseEventArgs;

namespace Hunter.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public LinearGradientBrush linearGradient = new LinearGradientBrush();
        public static DataModel records;

        public static LinearGradientBrush LinearGradient()
        {
            LinearGradientBrush linearGradient = new LinearGradientBrush();
            linearGradient.StartPoint = new Point(0.5, 0);
            linearGradient.EndPoint = new Point(0.5, 1);
            linearGradient.GradientStops.Add(new GradientStop(
                Color.FromArgb(Convert.ToByte("FF", 16), Convert.ToByte("FF", 16), Convert.ToByte("DC", 16), (Convert.ToByte("00", 16))), 0));
            linearGradient.GradientStops.Add(new GradientStop(
                Colors.Red, 1));
            return linearGradient;
        }

        public MainWindow()
        {
            InitializeComponent();
            records = DataModel.Load();
        }

        public static void AddToRecords()
        {
            
        }

        private void NewGame_MouseEnter(object sender, MouseEventArgs e)
        {
            NewGame.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        private void NewGame_MouseLeave(object sender, MouseEventArgs e)
        {
            NewGame.Foreground = LinearGradient();
        }

        private void ContinueGame_MouseEnter(object sender, MouseEventArgs e)
        {
            ContinueGame.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        private void ContinueGame_MouseLeave(object sender, MouseEventArgs e)
        {
            ContinueGame.Foreground = LinearGradient();
        }

        private void Records_MouseEnter(object sender, MouseEventArgs e)
        {
            Records.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        private void Records_MouseLeave(object sender, MouseEventArgs e)
        {
            Records.Foreground = LinearGradient();
        }

        private void NewGame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Form form = new GameWind(records);
            form.Show();
            form.FormClosing += Frm2_Closing;
            this.Hide();
        }

        private void Frm2_Closing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }


        private void ContinueGame_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Form form = new GameWind();
            form.Show();
            form.FormClosing += Frm2_Closing;
            this.Hide();
            Game dgame = DataSerializer.DeserializeItem("save.dat");
            Game.SCORE = dgame.scoreForSerialization;
            Game.KILLS = dgame.killsForSerialization;
            Game.MISS = dgame.missForSerialization;
        }

        private void Records_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid1.Opacity = 0.5;
            Grid1.IsEnabled = false;
            records = DataModel.Load();
            //Game recordsData = DataSerializer.DeserializeItem("saverecords.dat");
            //foreach(var game in records.Records)
            //   ProfileGrid.Items.Add(game);
            /*Game.SCORE = dgame.scoreForSerialization;
            Game.KILLS = dgame.killsForSerialization;
            Game.MISS = dgame.missForSerialization;*/
        }

        private void OK_MouseEnter(object sender, MouseEventArgs e)
        {
            OK.Foreground = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        private void OK_MouseLeave(object sender, MouseEventArgs e)
        {
            OK.Foreground = LinearGradient();
        }

        private void OK_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Grid1.Opacity = 1;
            Grid1.IsEnabled = true;
        }
    }
}
