using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoBrick
{
    public partial class UserControlNoBlink : UserControl
    {
        public UserControlNoBlink()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.AllPaintingInWmPaint, true);

        }

        private void UserControlNoBlink_Load(object sender, EventArgs e)
        {

        }
    }
}
