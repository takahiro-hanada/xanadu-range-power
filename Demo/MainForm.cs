using System;
using System.Linq;
using System.Windows.Forms;
using Xanadu;

namespace Demo
{
    public partial class MainForm : Form
    {
        readonly RangePower zoomManager;

        public MainForm()
        {
            InitializeComponent();

            zoomManager = new RangePower(1.2, 0.25, 5);
            zoomManager.ValueChanged += (sender, e) =>
            {
                _reportViewer.ZoomPercent = (int)(zoomManager.Value * 100);

                _zoomUpButton.Enabled = zoomManager.CanUp;

                _zoomDownButton.Enabled = zoomManager.CanDown;
            };
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            _usersBindingSource.DataSource = Enumerable
                .Range(1, 1000)
                .Select(i => new User() { Name = $"{nameof(User)}{i}" })
                .ToList()
                ;
            _reportViewer.RefreshReport();
        }

        void _zoomUpButton_Click(object _, EventArgs __) => zoomManager.Up();

        void _zoomDownButton_Click(object _, EventArgs __) => zoomManager.Down();
    }
}
