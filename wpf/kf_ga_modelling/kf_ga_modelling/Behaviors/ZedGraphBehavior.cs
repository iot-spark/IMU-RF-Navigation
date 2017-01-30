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
            _zg.GraphPane.AddCurve("Sine Wave", x, y, System.Drawing.Color.Red, SymbolType.None);
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
