using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MalenkijMelo.Services
{
    public class AdminIdSaveService
    {
        private static AdminIdSaveService _instance;
        public static AdminIdSaveService Instance => _instance ??= new AdminIdSaveService();

        public string AdminId { get; set; } = string.Empty;

        private AdminIdSaveService() { }
    }
}
