using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kent_Henrik_Rymdpiraterna
{
    class Basklass
    {
        protected Texture2D texture;
        protected Vector2 position;
        protected Rectangle hitBox;
        protected float speed = 10;
        protected bool isDead = false;

        public Rectangle HitBox
        {
            get { return hitBox; }
        }

        public virtual void Update() { }
    }
}
