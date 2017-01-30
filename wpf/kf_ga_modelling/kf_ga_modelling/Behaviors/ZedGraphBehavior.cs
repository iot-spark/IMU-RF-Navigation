using System;
using System.Windows.Forms.Integration;
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

        public ZedGraphBehavior()
        {
        }

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

            _lineChart = _zg.GraphPane.AddCurve("Sine Wave", x, y, System.Drawing.Color.Red, SymbolType.None);
            _zg.AxisChange();
            _zg.Invalidate();
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();

            this.AssociatedObject.Dispose();
        }
    }
}
