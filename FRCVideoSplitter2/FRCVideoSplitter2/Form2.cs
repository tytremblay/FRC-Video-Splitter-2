using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FRCVideoSplitter2
{
    public partial class Form2 : Form
    {
        TBAApi api = new TBAApi();

        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

            DateTime splitterEpoch = new DateTime(2015, 1, 1);
            DateTime now = DateTime.Now;

            for (int i = 0; splitterEpoch.AddYears(i).Year <= now.Year; i++)
            {
                int yearToAdd = splitterEpoch.AddYears(i).Year;
                comboBoxYear.Items.Add(yearToAdd);
                if (yearToAdd == now.Year)
                {
                    comboBoxYear.SelectedIndex = i;
                }
            }
            

        }

        private void setUpEventsList()
        {
            List<TBAApi.Event> events = api.getEventsList((int)comboBoxYear.SelectedItem).OrderBy(ev => ev.name).ThenBy(ev => ev.start_date).ToList();

            BindingSource bindingSource1 = new BindingSource();

            bindingSource1.DataSource = events;

            comboBoxEvents.DataSource = bindingSource1.DataSource;

            comboBoxEvents.DisplayMember = "name";
            comboBoxEvents.ValueMember = "start_date";
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            setUpEventsList();
        }
    }
}
