using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedSingleton
{
    public interface ISharedData
    {
        public void Enquque(string v);
        public string Dequque();
    }
}
