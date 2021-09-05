using System;
using System.Collections.Generic;
using System.Text;

namespace Common.DTO
{
    public class BookDTO
    {
        public BookDTO(string[] data)
        {
            Id = int.Parse(data[0]);
            Name = data[1];
            Price = int.Parse(data[2]);
            Stock = int.Parse(data[3]);
        }

        public override string ToString()
        {
            return $"{Id},{Name},{Price},{Stock}";
        }

        public BookDTO()
        {

        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Stock { get; set; }

    }
}
