using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Week11Example2
{
    public partial class Form1 : Form
    {

       // int pageNumber = 1;

        public Form1()
        {

            InitializeComponent();

            LoadContacts();
        }

        BLL bll = default(BLL);


        


        private void LoadContacts()
        {

            ContactDBMock contacts = new ContactDBMock();
            ContactDB contacts2 = new ContactDB();

            bll = new BLL(contacts2);

            bindingSource1.DataSource = bll.GetContacts();


            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = bll.GetContacts().Count.ToString();
            bindingSource1.DataSource = bll.GetContacts();
        }

        private void dataGridView1_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
            //MessageBox.Show("ok");

        }

        private void dataGridView1_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            // MessageBox.Show("dataGridView1_RowsAdded");

        }

        private void dataGridView1_RowLeave(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_RowValidated(object sender, DataGridViewCellEventArgs e)
        {
        }

        CreateContactForm createContactForm = new CreateContactForm();
        DeleteUpdateForm deleteUpdateForm = new DeleteUpdateForm();

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (createContactForm.ShowDialog() == DialogResult.OK)
            {
                CreateContactCommand command = new CreateContactCommand();
                command.Name = createContactForm.nameTxtBx.Text;
                command.Phone = createContactForm.phoneTxtBx.Text;
                command.Addr = createContactForm.addressTxtBx.Text;
                bll.CreateContact(command);
                bindingSource1.DataSource = bll.GetContacts();
            }
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            deleteUpdateForm.textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            deleteUpdateForm.textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            deleteUpdateForm.textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            deleteUpdateForm.textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            if(deleteUpdateForm.ShowDialog() == DialogResult.Cancel)
            {
                dataGridView1.Rows.RemoveAt(e.RowIndex);
                bll.DelecteContact(deleteUpdateForm.textBox1.Text);
                bindingSource1.DataSource = bll.GetContacts();
            } 
            else 
            {
                bll.UpdateContact(deleteUpdateForm.textBox1.Text, deleteUpdateForm.textBox2.Text, deleteUpdateForm.textBox3.Text, deleteUpdateForm.textBox4.Text);
                bindingSource1.DataSource = bll.GetContacts();
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string ans = "";
            DataGridViewRowCollection data = dataGridView1.Rows;
            for(int i = 0; i < data.Count; i++)
            {
                if(data[i].Cells[1].Value.ToString() == name)
                {
                    ans += (data[i].Cells[0].Value.ToString() + " " + data[i].Cells[1].Value.ToString() +
                            " " + data[i].Cells[2].Value.ToString() + " " + data[i].Cells[3].Value.ToString() + "\n");
                } 
            }
            MessageBox.Show(ans);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            bll.ExecuteCommand(textBox2.Text);
            bindingSource1.DataSource = bll.GetContacts();
        }
    }
}
