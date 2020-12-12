using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmongUs
{
    class GameObject
    {
        protected Vector position;

        protected Collider _collider;

        public readonly static List<GameObject> gameObjects = new List<GameObject>();

        public GameObject()
        {
            AddGameObject(this);
        }

        public Collider collider
        {
            get { return collider; }
        }

        protected void AddGameObject(GameObject gameObject)
        {
            gameObjects.Add(gameObject);
        }

        public static void SetupGameObjects()
        {
            foreach (var item in gameObjects)
            {
                item.Setup();
            }
        }

        public static void UpdateGameObjects()
        {
            foreach (var item in gameObjects)
            {
                item.Update();
            }
        }

        public virtual void Setup() { }

        public virtual void Update() { }

    }
}
