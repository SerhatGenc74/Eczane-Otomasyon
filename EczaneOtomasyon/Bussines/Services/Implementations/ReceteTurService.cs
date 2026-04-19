using EczaneOtomasyon.Bussines.Services.Interfaces;
using EczaneOtomasyon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EczaneOtomasyon.Bussines.Services.Implementations
{
    public class ReceteTurService : IReceteTurService
    {
        public Dictionary<int, string> ReceteTur = new Dictionary<int, string>();

        public List<ReceteTur> GetReceteTurleri()
        {
            throw new NotImplementedException();
        }
    }
}
