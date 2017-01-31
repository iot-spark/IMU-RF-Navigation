using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms.Integration;
using System.Windows.Input;
using System.Windows.Interactivity;
using ZedGraph;

namespace kf_ga_modelling.Behaviors
{
    public class ZedGraphBehavior : Behavior<WindowsFormsHost>
    {
        #region Fields
        ZedGraphControl _zg = null;
        LineItem _lineChart = null;
        Random _rnd = new Random();
        int _chartLng = 100000;
        #endregion

        #region Properties

        public string FilePath
        {
            get { return (string)GetValue(FilePathProperty); }
            set { SetValue(FilePathProperty, value); }
        }

        public static readonly DependencyProperty FilePathProperty =
            DependencyProperty.Register("FilePath", typeof(string), typeof(ZedGraphBehavior), new PropertyMetadata(string.Empty));

        public int TrackLength
        {
            get { return (int)GetValue(TrackLengthProperty); }
            set { SetValue(TrackLengthProperty, value); }
        }

        public static readonly DependencyProperty TrackLengthProperty =
            DependencyProperty.Register("TrackLength", typeof(int), typeof(ZedGraphBehavior), new PropertyMetadata(10000));

        public ICommand ShowAxCommand
        {
            get { return (ICommand)GetValue(ShowAxCommandProperty); }
            set { SetValue(ShowAxCommandProperty, value); }
        }

        public static readonly DependencyProperty ShowAxCommandProperty =
            DependencyProperty.Register("ShowAxCommand", typeof(ICommand), typeof(ZedGraphBehavior), new PropertyMetadata(null));

        public ICommand ShowAyCommand
        {
            get { return (ICommand)GetValue(ShowAyCommandProperty); }
            set { SetValue(ShowAyCommandProperty, value); }
        }

        public static readonly DependencyProperty ShowAyCommandProperty =
            DependencyProperty.Register("ShowAyCommand", typeof(ICommand), typeof(ZedGraphBehavior), new PropertyMetadata(null));

        public ICommand ShowAzCommand
        {
            get { return (ICommand)GetValue(ShowAzCommandProperty); }
            set { SetValue(ShowAzCommandProperty, value); }
        }

        public static readonly DependencyProperty ShowAzCommandProperty =
            DependencyProperty.Register("ShowAzCommand", typeof(ICommand), typeof(ZedGraphBehavior), new PropertyMetadata(null));

        public ICommand ShowGxCommand
        {
            get { return (ICommand)GetValue(ShowGxCommandProperty); }
            set { SetValue(ShowGxCommandProperty, value); }
        }

        public static readonly DependencyProperty ShowGxCommandProperty =
            DependencyProperty.Register("ShowGxCommand", typeof(ICommand), typeof(ZedGraphBehavior), new PropertyMetadata(null));

        public ICommand ShowGyCommand
        {
            get { return (ICommand)GetValue(ShowGyCommandProperty); }
            set { SetValue(ShowGyCommandProperty, value); }
        }

        public static readonly DependencyProperty ShowGyCommandProperty =
            DependencyProperty.Register("ShowGyCommand", typeof(ICommand), typeof(ZedGraphBehavior), new PropertyMetadata(null));

        public ICommand ShowGzCommand
        {
            get { return (ICommand)GetValue(ShowGzCommandProperty); }
            set { SetValue(ShowGzCommandProperty, value); }
        }

        public static readonly DependencyProperty ShowGzCommandProperty =
            DependencyProperty.Register("ShowGzCommand", typeof(ICommand), typeof(ZedGraphBehavior), new PropertyMetadata(null));


        #endregion

        #region .ctors
        public ZedGraphBehavior()
        {
            ShowAxCommand = new AsyncDelegateCommand(ShowAxCommandExecute);
            ShowAyCommand = new AsyncDelegateCommand(ShowAyCommandExecute);
            ShowAzCommand = new AsyncDelegateCommand(ShowAzCommandExecute);
            
            ShowGxCommand = new AsyncDelegateCommand(ShowGxCommandExecute);
            ShowGyCommand = new AsyncDelegateCommand(ShowGyCommandExecute);
            ShowGzCommand = new AsyncDelegateCommand(ShowGzCommandExecute);
        }

        #endregion

        #region Private Methods

        private void BuildLineChart(int colIdx, string chartLabel, string yAxisTitle)
        {
            if (!File.Exists(FilePath))
            {
                return;
            }

            var x = new List<double>();
            var y = new List<double>();
            try
            {
                using (var rd = new StreamReader(FilePath))
                {
                    int idx = 0;
                    while (idx++ < TrackLength && !rd.EndOfStream)
                    {
                        var colStrings = rd.ReadLine().Split(" ;".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);

                        if (colStrings.Length != 8)
                        {
                            // Wrong file format
                            // Expected format: Time ; Ax ; Ay ; Az ; Gx ; Gy ; Gz ; Temp
                            // Log this error
                            break;
                        }

                        x.Add(double.Parse(colStrings[0]));
                        y.Add(double.Parse(colStrings[colIdx]));
                    }

                }
            }
            catch (FormatException)
            {
                // TODO: Show message about wrong format and Log this error
                return;
            }
            catch (IOException)
            {
                // TODO: Show message about File access issue and Log this error
                return;
            }

            _lineChart.Points = new PointPairList(x.ToArray(), y.ToArray());

            _lineChart.Label = chartLabel;

            _zg.GraphPane.YAxis.Title = yAxisTitle;

            _zg.AxisChange();
            _zg.Invalidate();
        }

        #endregion

        #region Command Handlers

        async
        private Task ShowAxCommandExecute(object o)
        {
            await Task.Delay(0).ContinueWith(t =>
            {
                // Build Ax line chart
                BuildLineChart(1, "Ax", "Acceleration, m/sec^2");

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        async
        private Task ShowAyCommandExecute(object o)
        {
            await Task.Delay(0).ContinueWith(t =>
            {
                // Build Ax line chart
                BuildLineChart(2, "Ay", "Acceleration, m/sec^2");

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        async
        private Task ShowAzCommandExecute(object o)
        {
            await Task.Delay(0).ContinueWith(t =>
            {
                // Build Ax line chart
                BuildLineChart(3, "Az", "Acceleration, m/sec^2");

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        async
        private Task ShowGxCommandExecute(object o)
        {
            await Task.Delay(0).ContinueWith(t =>
            {
                // Build Ax line chart
                BuildLineChart(4, "Gx", "Rotation, deg/sec");

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }

        async
        private Task ShowGyCommandExecute(object o)
        {
            await Task.Delay(0).ContinueWith(t =>
            {
                // Build Ax line chart
                BuildLineChart(5, "Gy", "Rotation, deg/sec");

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }


        async
        private Task ShowGzCommandExecute(object o)
        {
            await Task.Delay(0).ContinueWith(t =>
            {
                // Build Ax line chart
                BuildLineChart(6, "Gz", "Rotation, deg/sec");

            }, TaskScheduler.FromCurrentSynchronizationContext());
        }
        #endregion

        #region Attached / Detached
        protected override void OnAttached()
        {
            base.OnAttached();

            _zg = AssociatedObject.Child as ZedGraphControl;
            if (_zg == null)
            {
                _zg = new ZedGraphControl();
                AssociatedObject.Child = _zg;
            }

            _zg.Location = new System.Drawing.Point(0, 0);
            _zg.Name = "zedGraphControl1";
            _zg.Size = new System.Drawing.Size(800, 600);
            _zg.TabIndex = 0;
            //_zg.Font = new System.Drawing.Font("Segoe UI", 0.2f);

            _zg.IsShowPointValues = true;
            _zg.GraphPane.Title = "Test Case for C#";
            _zg.GraphPane.FontSpec.Family = "Segoe UI";
            _zg.GraphPane.FontSpec.Size = 2.0f * (_zg.Size.Height / 100.0f);

            _zg.GraphPane.XAxis.TitleFontSpec.Family = "Segoe UI";
            _zg.GraphPane.XAxis.TitleFontSpec.Size = 1.5f * (_zg.Size.Height / 100.0f);
            _zg.GraphPane.XAxis.ScaleFontSpec.Family = "Segoe UI";
            _zg.GraphPane.XAxis.ScaleFontSpec.Size = 1.5f * (_zg.Size.Height / 100.0f);

            _zg.GraphPane.YAxis.TitleFontSpec.Family = "Segoe UI";
            _zg.GraphPane.YAxis.TitleFontSpec.Size = 1.5f * (_zg.Size.Height / 100.0f);
            _zg.GraphPane.YAxis.ScaleFontSpec.Family = "Segoe UI";
            _zg.GraphPane.YAxis.ScaleFontSpec.Size = 1.5f * (_zg.Size.Height / 100.0f);

            _zg.GraphPane.Legend.FontSpec.Family = "Segoe UI";
            _zg.GraphPane.Legend.FontSpec.Size = 1.5f * (_zg.Size.Height / 100.0f);

            _zg.GraphPane.PaneGap = 0.1f * (_zg.Size.Height / 100.0f);

            double[] x = new double[_chartLng];
            double[] y = new double[_chartLng];
            int i;
            for (i = 0; i < _chartLng; i++)
            {
                x[i] = (double)i / 1000.0;
                y[i] = _rnd.NextDouble() * 10.0;
            }

            _zg.GraphPane.XAxis.Title = "Time, sec";

            _lineChart = _zg.GraphPane.AddCurve("Sine Wave", x, y, System.Drawing.Color.Red, SymbolType.None);
            _zg.AxisChange();
            _zg.Invalidate();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            this.AssociatedObject.Dispose();
        }
        #endregion
    }
}
