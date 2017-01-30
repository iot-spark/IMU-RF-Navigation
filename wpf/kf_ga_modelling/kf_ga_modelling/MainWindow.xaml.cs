using System;
using System.Drawing;
using System.Windows;
using ZedGraph;

namespace kf_ga_modelling
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Fields
        private ZedGraphControl _zg;
        #endregion

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            // 
            // zedGraphControl1
            // 
            _zg = new ZedGraphControl();

            zgHost.Child = _zg;

            _zg.Location = new System.Drawing.Point(0, 0);
            _zg.Name = "zedGraphControl1";
            _zg.Size = new System.Drawing.Size(680, 414);
            _zg.TabIndex = 0;

            _zg.IsShowPointValues = true;
            _zg.GraphPane.Title = "Test Case for C#";
            double[] x = new double[100];
            double[] y = new double[100];
            int i;
            for (i = 0; i < 100; i++)
            {
                x[i] = (double)i / 100.0 * Math.PI * 2.0;
                y[i] = Math.Sin(x[i]);
            }
            _zg.GraphPane.AddCurve("Sine Wave", x, y, Color.Red, SymbolType.None);
            _zg.AxisChange();
            _zg.Invalidate();
        }
    }
}
