using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Szofttech_GyakDemo01.Properties;

namespace Szofttech_GyakDemo01
{   
    public partial class MainMenu : DevExpress.XtraBars.FluentDesignSystem.FluentDesignForm
    {
        #region MainMenuConfiguration
        public MainMenu()
        {
            InitializeComponent();            
            if (Settings.Default.isMaximized == true)
            {
                this.WindowState = FormWindowState.Maximized;
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
            }            
            //Temporary! Delete when database is added!
            checkedListBoxControl1.Items.Add("Hamburger");
            checkedListBoxControl1.Items.Add("Pizza");
            checkedListBoxControl1.Items.Add("Spagetti");
            checkedListBoxControl1.Items.Add("Sültkrumpli");

            checkedListBoxControl2.Items.Add("Hamburgermenü");
            checkedListBoxControl2.Items.Add("Pizza menü");
            checkedListBoxControl2.Items.Add("Gyros Menü");

            listBoxControl1.Items.Add("Tóth Dániel Márk");
            listBoxControl1.Items.Add("Kerekes Krisztofer");
            listBoxControl1.Items.Add("Teszt Lajos");
            //Temporary stuff ends here! Do not delete any stuff below this comment!
        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult result = MessageBox.Show("Biztosan ki szeretne lépni?", "Kilépés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Szofttech_GyakDemo01.Properties.Settings.Default.Save();
                Application.ExitThread();
            }
        }

        private void MainMenu_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                Settings.Default.isMaximized = true;
            }
            else
            {
                Settings.Default.isMaximized = false;
            }
        }

        private void accordionControlElement1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region OrderType
        private void accordionControlElement2_Click(object sender, EventArgs e)
        {
            NewOrder order = new NewOrder();
            order.Owner = this;
            order.ShowDialog();
            if (order.DialogResult == DialogResult.Yes)
            {
                fluentDesignFormContainer1.Visible = true;
                //fluentDesignFormContainer2.Visible = false;
            }
            else if (order.DialogResult == DialogResult.No)
            {
                fluentDesignFormContainer1.Visible = false;
                //fluentDesignFormContainer2.Visible = true;
            }
        }
        #endregion
        
        #region PriceCalculate
        private void checkedListBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Termék hozzáadása egy listához, és ezzel együtt a termék szerinti árszámítás a végösszeghez!
        }

        private void checkedListBoxControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Menü hozzáadása egy listához, és ezzel együtt a termék szerinti árszámítás a végösszeghez!
        }

        private void checkedListBoxControl3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Előző rendelés hozzáadása egy listához, és ezzel együtt a termék szerinti árszámítás a végösszeghez!
        }

        public void ChangePrice(int prodprice)
        {
            string[] price = labelControl2.Text.Split(' ');
            int finalprice = Convert.ToInt32(price[1]) + prodprice;
            labelControl2.Text = "Végösszeg: " + finalprice + " Ft";
        }
        #endregion

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Szeretné leadni a rendelést?", "Rendelés", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                try
                {
                    //Rendelésleadás metódus/class meghívás
                }
                catch (Exception)
                {
                    MessageBox.Show("Hiba történt leadás közben! Ellenőrizze az adatokat!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                MessageBox.Show("A rendelést sikeresen leadta!", "Rendelés", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }


        private void listBoxControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Temporary! Delete when database is added!
            checkedListBoxControl3.Items.Clear();
            switch (listBoxControl1.SelectedIndex)
            {
                case 0:
                    checkedListBoxControl3.Items.Add("Hamburgermenü");
                    checkedListBoxControl3.Items.Add("Spagetti");
                    checkedListBoxControl3.Items.Add("Pizza menü");
                    break;
                case 1:
                    checkedListBoxControl3.Items.Add("Pizza menü");
                    checkedListBoxControl3.Items.Add("Hamburgermenü");
                    break;
                case 2:
                    checkedListBoxControl3.Items.Add("Sültkrumpli");
                    checkedListBoxControl3.Items.Add("Hamburgermenü");
                    checkedListBoxControl3.Items.Add("Gyros menü");
                    break;
                default:
                    break;
            }
            //Temporary stuff ends here! Do not delete any stuff below this comment!
        }
    }
}
