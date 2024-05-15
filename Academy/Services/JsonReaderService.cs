using Newtonsoft.Json;
using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Services
{
    public class JsonReaderService : IReaderService
    {
        public async Task<List<Student>> ReadStudents()
        {
            string directoryPath = @"..\..\..\Data";
            string filePath = directoryPath + @"\students.json";

            string fulltext = "";
            if (!File.Exists(filePath))
            {
                throw new Exception("File does not exist!");
            }
            using (StreamReader sr = new StreamReader(filePath, true))
            {
                fulltext = await sr.ReadToEndAsync();
            }
            var students = JsonConvert.DeserializeObject<List<Student>>(fulltext);
            return students;
        }
    }
}
