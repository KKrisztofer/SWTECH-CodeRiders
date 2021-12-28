using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Szofttech_GyakDemo01
{
    public partial class NewOrder : DevExpress.XtraEditors.XtraForm
    {
        #region NewOrderConfiguration
        public NewOrder()
        {
            InitializeComponent();
        }

        #region SelectOrderType
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }

        private void simpleButton2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }
        #endregion

        #region BackButtonClickEvent
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        #endregion
    }
}