using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmongUs
{
    class Collider
    {
        public bool enabled = true;

  

        public virtual void OnCollision(GameObject collider) { }
    }
}
