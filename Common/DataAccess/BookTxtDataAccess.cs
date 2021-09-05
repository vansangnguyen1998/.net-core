using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Common.DTO;
using Newtonsoft.Json;

namespace Common.DataAccess
{
    public class BookTxtDataAccess : IBookDataAccess
    {
        private const string FILE_NAME = "D:\\Docs\\Training\\foudation\\core-api\\Common\\DataAccess\\Books.txt";

        private List<BookDTO> m_books;
        public BookTxtDataAccess()
        {
            m_books = new List<BookDTO>();
        }
        
        public void InputDataFileFile()
        {
            if (File.Exists(FILE_NAME))
            {
                using (var file = new StreamReader(FILE_NAME))
                {
                    var count = 0;
                    string readLine;
                    while ((readLine = file.ReadLine()) != null)
                    {
                        m_books.Add(ParseData(readLine));
                        count++;
                    }
                }
            }
        }

        public BookDTO GetOne(int id)
        {
            return m_books.FirstOrDefault(x => x.Id == id);
        }
        public List<BookDTO> GetAll()
        {
            return m_books;
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
            if (book != null)
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
                m_books.Remove(book);
                m_books.Add(bookDto);
            }

            return book;
        }

        public void WriteFile()
        {
            if (File.Exists(FILE_NAME))
            {
                using (StreamWriter sw = new StreamWriter(FILE_NAME))
                {

                    foreach (var s in m_books)
                    {
                        sw.WriteLine(s.ToString());
                    }
                }
            }
        }
    }
}
