using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Common.DTO;
using Newtonsoft.Json;

namespace Common.DataAccess
{
    public class BookJsonDataAccess : IBookDataAccess
    {
        private const string FILE_NAME = "D:\\Docs\\Training\\foudation\\core-api\\Common\\DataAccess\\Books.json";

        private List<BookDTO> m_books;
        public BookJsonDataAccess()
        {
            m_books = new List<BookDTO>();
            InputDataFileFile();
        }

        public void LoadJson()
        {
            using (StreamReader r = new StreamReader(FILE_NAME))
            {
                string json = r.ReadToEnd();
                m_books = JsonConvert.DeserializeObject<List<BookDTO>>(json);
            }
        }

        private void InputDataFileFile()
        {
            using (StreamReader r = new StreamReader(FILE_NAME))
            {
                string json = r.ReadToEnd();
                m_books = JsonConvert.DeserializeObject<List<BookDTO>>(json);
            }
        }

        private BookDTO ParseData(string data)
        {
            var dataConvert = data.Split(new string[] { "," }, StringSplitOptions.None);
            return new BookDTO(dataConvert);
        }

        public void InsertBook(BookDTO book)
        {
            m_books.Add(book);
        }

        public bool RemoveBook(BookDTO bookDto)
        {
            var book = m_books.FirstOrDefault(b => b.Id == bookDto.Id);
            if (book!=null)
            {
                m_books.Remove(book);
                return true;
            }

            return false;
        }

        public BookDTO UpdateBook(BookDTO bookDto)
        {
            var book = m_books.FirstOrDefault(b => b.Id == bookDto.Id);
            if (book != null)
            {
                book = bookDto;
            }

            return book;
        }

        public void WriteFile()
        {
            if (File.Exists(FILE_NAME))
            {
                File.WriteAllText(FILE_NAME, JsonConvert.SerializeObject(m_books));
            }
        }
    }
}
