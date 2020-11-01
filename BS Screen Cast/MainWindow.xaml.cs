using Microsoft.Win32;
using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BS_Screen_Cast
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {
            
            InitializeComponent();
           
        }
        private void Button_Click(object sender, EventArgs e)
        {
            string PathFileToSave;
            //Выбор пути куда сохранять файлы
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK) { }
                PathFileToSave = fbd.SelectedPath;

            FilesCreReadWri f = new FilesCreReadWri(); //Создание экземпляра класса для записи пути 
            f.Write(PathFileToSave);//Запись пути


        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            FilesCreReadWri f = new FilesCreReadWri();//Создание экземпляра класса для считывание файла
            string FSave = f.Read();//Считывание файла


            Bitmap printscreen = new Bitmap(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            Graphics graphics = Graphics.FromImage(printscreen as Image);
            graphics.CopyFromScreen(0, 0, 0, 0, printscreen.Size);
            String SetDateTime = DateTime.Now.ToString("yyyy.MM.dd_HH-mm-ss");
            printscreen.Save(FSave + "/" + SetDateTime + ".jpeg", System.Drawing.Imaging.ImageFormat.Jpeg);
        }
    }
}
