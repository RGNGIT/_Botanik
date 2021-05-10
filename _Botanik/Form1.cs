using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _Botanik
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dataGridView2.Columns.Add("_Name", "Название растения");
            dataGridView2.Columns.Add("_Type", "Тип растения");
            dataGridView2.Columns.Add("_Empl", "Служащий");
            dataGridView2.Columns.Add("_Date", "Дата посадки");
            dataGridView2.Columns.Add("_Time", "Время полива");
            dataGridView2.Columns.Add("_Amount", "Кол-во поливов");
            dataGridView2.Columns.Add("_Litr", "Кол-во литров");
        }

        // Работа со справочником

        void UpdateBase()
        {
            comboBoxEmpl.Items.Clear();
            comboBoxType.Items.Clear();
            foreach(string i in Database.FIO)
            {
                comboBoxEmpl.Items.Add(i);
            }
            foreach(string i in Database.Type)
            {
                comboBoxType.Items.Add(i);
            }
        }

        private void buttonAddEmpl_Click(object sender, EventArgs e)
        {
            Database.FIO.Add(textBoxFIO.Text);
            Database.Phone.Add(textBoxPhone.Text);
            UpdateBase();
            DirUpdate();
        }

        private void AddType_Click(object sender, EventArgs e)
        {
            Database.Type.Add(textBoxPlantType.Text);
            UpdateBase();
            DirUpdate();
        }

        void DirUpdate()
        {
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            switch (tabControl2.SelectedIndex)
            {
                case 0: // Тип растения
                    dataGridView1.Columns.Add("_Type", "Тип растения");
                    foreach (string i in Database.Type)
                    {
                        dataGridView1.Rows.Add(i);
                    }
                    break;
                case 1: // Служащие
                    dataGridView1.Columns.Add("_FIO", "ФИО");
                    dataGridView1.Columns.Add("_Phone", "Телефон");
                    for (int i = 0; i < Database.FIO.Count; i++)
                    {
                        dataGridView1.Rows.Add(Database.FIO[i], Database.Phone[i]);
                    }
                    break;
            }
        }

        private void tabControl2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateBase();
            DirUpdate();
        }

        // Работа с главной базой

        private void buttonAddMain_Click(object sender, EventArgs e)
        {
            // Название/Тип (справочник)/Служащий (справочник)/Дата посадки (datePicker)/Время полива/Кол-во поливов/Литры воды
            dataGridView2.Rows.Add(
                textBoxPlantName.Text, 
                comboBoxType.SelectedItem.ToString(), 
                comboBoxEmpl.SelectedItem.ToString(), 
                dateTimePickerDatePlant.Value.ToString(), 
                textBoxPlantTime.Text, 
                textBoxWaterAmount.Text, 
                textBoxWaterLitres.Text);
        }

        // Работа с отчетом



    }
}
