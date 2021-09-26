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
using Common.Entity;

namespace BookStoreApp
{
    public partial class Form1 : Form
    {
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(nameof(Form1));
        private List<BookEntity> _books;
        public Form1()
        {
            log.Info("Start application");
            InitializeComponent();
            loadData();
        }

        private void loadData()
        {
            log.Info("Load data");
            IoC.Get<IBookBusiness>(Constants.MODE[0]).InputDataFileFile();
            var listData = IoC.Get<IBookBusiness>(Constants.MODE[0]).GetAll();
            _books = listData;
            dataGridView1.DataSource = listData;
        }
        private void insert_Click(object sender, EventArgs e)
        {
            log.Info(nameof(insert_Click));
            var business = IoC.Get<IBookBusiness>(Constants.MODE[0]);
            business.InsertBook(new BookDTO(){Id = int.Parse(id.Text), Name = name.Text, Price = int.Parse(price.Text), Stock = int.Parse(stock.Text) });
            loadData();
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
            log.Info(nameof(update_Click));
            var business = IoC.Get<IBookBusiness>(Constants.MODE[0]);
            business.UpdateBook(new BookDTO() { Id = int.Parse(id.Text), Name = name.Text, Price = int.Parse(price.Text), Stock = int.Parse(stock.Text) });
            ResetValue();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            log.Info(nameof(delete_Click));
            var business = IoC.Get<IBookBusiness>(Constants.MODE[0]);
            business.RemoveBook(new BookDTO() { Id = int.Parse(id.Text), Name = name.Text, Price = int.Parse(price.Text), Stock = int.Parse(stock.Text) });

            ResetValue();
        }
    }
}
