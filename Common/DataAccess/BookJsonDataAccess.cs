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
        }

        public void InputDataFileFile()
        {
            using (StreamReader r = new StreamReader(FILE_NAME))
            {
                string json = r.ReadToEnd();
                m_books = JsonConvert.DeserializeObject<List<BookDTO>>(json);
            }
        }
        
        public void InsertBook(BookDTO book)
        {
            m_books.Add(book);
            WriteFile();
        }

        public bool RemoveBook(BookDTO bookDto)
        {
            var book = m_books.FirstOrDefault(b => b.Id == bookDto.Id);
            if (book!=null)
            {
                m_books.Remove(book);
                WriteFile();
                return true;
            }

            return false;
        }

        public BookDTO UpdateBook(BookDTO bookDto)
        {
            var book = m_books.FirstOrDefault(b => b.Id == bookDto.Id);
            if (book != null)
            {
                m_books.Remove(book);
                m_books.Add(bookDto);

                WriteFile();
            }
            return book;
        }

        public BookDTO GetOne(int id)
        {
            return m_books.FirstOrDefault(x => x.Id == id);
        }

        public List<BookDTO> GetAll()
        {
            return m_books;
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
