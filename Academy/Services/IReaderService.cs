using Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Academy.Services
{
    public interface IReaderService
    {
        Task<List<Student>> ReadStudents();
    }
}
