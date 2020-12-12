using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmongUs
{
    class Map 
    {
        public string _map;
        private List<string> _mapInfo;

        public string map
        {
            get { return _map; }
        }

        public List<string> mapInfo
        {
            get { return _mapInfo; }
        }
    }

}
