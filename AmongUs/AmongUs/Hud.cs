using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmongUs
{
    class Hud
    {
        public int panelWidth = 25;

        private string panel = "";
        public string Panel
        {
            get
            {
                if (CreateHudParent != null) 
                    panel = CreateHudParent();

                if (CreateHudChild() != null)
                    panel = CreateHudChild();

                return panel;
            }
            set { panel = value; }
        }

        private int layer = 0;
        public int Layer
        {
            get { return layer; }

            set
            {
                layer = value;
                huds.Remove(this);
                AddHud();
            }
        }

        public bool disabled = false;

        public Vector position = new Vector(0, 0);

        public static readonly List<Hud> huds = new List<Hud>();

        public Hud()
        {
            AddHud();
        }

        public Hud(string panel)
        {
            this.panel = panel;
            AddHud();
        }

        public Hud(string panel, int layer)
        {
            this.panel = panel;
            this.layer = layer;

            AddHud();
        }

        private void AddHud()
        {
            if (huds.Count == 0)
            {
                huds.Add(this);
                return;
            }

            foreach (var item in huds)
            {
                if (layer <= item.Layer)
                {
                    huds.Insert(huds.IndexOf(item), this);
                    return;
                }
            }
            huds.Add(this);
        }

        public Func<string> CreateHudParent;

        protected virtual string CreateHudChild() { return null; }
    }

}
