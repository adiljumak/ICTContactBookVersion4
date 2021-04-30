using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.Sqlite;
using System.Data.SQLite;

namespace Week11
{
    public partial class Form1 : Form
    {
        
        public void F1()
        {
            string cs = "Data Source = :memory:";
            string stm = "SELECT SQLITE_VERSION()";

            var con = new SQLiteConnection(cs);

            con.Open();

            var cmd = new SQLiteCommand(stm, con);

            string res = cmd.ExecuteScalar().ToString();

            MessageBox.Show(res);

            con.Close();
        }

        public void F2()
        {
            string cs = @"URI=file:test.db";
            //SQLiteConnection.CreateFile("test2");
            using (var con = new SQLiteConnection(cs))
            {
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "DROP TABLE IF EXISTS cars";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE cars(id INTEGER PRIMARY KEY, name TEXT, price INT)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Audi',123)";

                cmd.ExecuteNonQuery();

                MessageBox.Show("OK!");
            }

        }

        public Form1()
        {
            InitializeComponent();

            F1();

        }
    }
}
