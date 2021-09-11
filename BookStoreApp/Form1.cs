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
            comboBoxMode.DataSource = Constants.MODE;
            listViewData.Columns.Add("Id");
            listViewData.Columns.Add("Name");
            listViewData.Columns.Add("Price");
            listViewData.Columns.Add("Stock");
            IoC.Get<IBookBusiness>(Constants.MODE[1]).InputDataFileFile();
            var listData = IoC.Get<IBookBusiness>(Constants.MODE[1]).GetAll();

            foreach (var item in listData)
            {
                ListViewItem item3 = new ListViewItem();
                item3.Text = item.Id.ToString();
                item3.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Name });
                item3.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Price.ToString() });
                item3.SubItems.Add(new ListViewItem.ListViewSubItem() { Text = item.Stock.ToString() });
                listViewData.Items.Add(item3);
            }
        }

        private void insert_Click(object sender, EventArgs e)
        {
            var business = IoC.Get<IBookBusiness>(Constants.MODE[1]);
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

        }

        private void delete_Click(object sender, EventArgs e)
        {

        }
    }
}
