using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Common;
using Common.Business;
using Common.Constants;
using Common.DTO;

namespace BookStoreApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            IoC.Get<IBookBusiness>(Constants.MODE[0]).InputDataFileFile();
            var listData = IoC.Get<IBookBusiness>(Constants.MODE[0]).GetAll();
            dataGridView1.DataSource = listData;
        }
        private void insert_Click(object sender, EventArgs e)
        {
            var business = IoC.Get<IBookBusiness>(Constants.MODE[0]);
            business.InsertBook(new BookDTO(){Id = int.Parse(id.Text), Name = name.Text, Price = int.Parse(price.Text), Stock = int.Parse(stock.Text) });
            ResetValue();
        }

        private void ResetValue()
        {
            id.Text = "";
            name.Text = "";
            price.Text = "";
            stock.Text = "";
        }

        private void update_Click(object sender, EventArgs e)
        {
            var business = IoC.Get<IBookBusiness>(Constants.MODE[0]);
            business.UpdateBook(new BookDTO() { Id = int.Parse(id.Text), Name = name.Text, Price = int.Parse(price.Text), Stock = int.Parse(stock.Text) });
            ResetValue();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            var business = IoC.Get<IBookBusiness>(Constants.MODE[0]);
            business.RemoveBook(new BookDTO() { Id = int.Parse(id.Text), Name = name.Text, Price = int.Parse(price.Text), Stock = int.Parse(stock.Text) });

            ResetValue();
        }
    }
}
