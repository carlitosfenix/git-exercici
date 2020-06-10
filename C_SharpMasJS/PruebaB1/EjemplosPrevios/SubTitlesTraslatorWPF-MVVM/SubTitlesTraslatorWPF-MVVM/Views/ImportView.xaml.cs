using Microsoft.Win32;
using SubTitlesTraslatorWPF_MVVM.Models;
using SubTitlesTraslatorWPF_MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace SubTitlesTraslatorWPF_MVVM.Views
{
    /// <summary>
    /// Lógica de interacción para ImportView.xaml
    /// </summary>
    public partial class ImportView : UserControl
    {
        public ImportViewModel ViewModel { get; set; }
       

        public ImportView()
        {
            InitializeComponent();
            //La vista ha de ser conocedora de su ViewModel
            ViewModel = new ImportViewModel();
         
            ViewModel.GetSubtitlesFilesAction = GetSubtitlesFiles;
            ViewModel.GetFileTextLinesAction = (path) =>  File.ReadAllLines(path).ToList();
       
            DataContext = ViewModel;
        }

      

        private List<string> GetSubtitlesFiles()
        {
            var output = new List<string>();

            var ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "Subtitles Files Video Text Tracks(*.vtt)|*.vtt|Subtitles Files SubRip (*.srt)|*.srt|All files (*.*)|*.*"; //Sólo ficheros de subtítulos
            ofd.ShowDialog();
            output.AddRange(ofd.FileNames);
            return output;
        }



        private void BtnAnimation_Click(object sender, RoutedEventArgs e)
        {
            RotateTransform animatedRotateTransform = new RotateTransform();
            animatedRotateTransform.Angle = 45;
            DoubleAnimation angleAnimation =
              new DoubleAnimation(0, 360, TimeSpan.FromSeconds(5));
            angleAnimation.RepeatBehavior = RepeatBehavior.Forever;
            animatedRotateTransform.BeginAnimation(
                RotateTransform.AngleProperty, angleAnimation);
            animatedRotateTransform.GetAnimationBaseValue(RotateTransform.AngleProperty);
        }
    }
}
