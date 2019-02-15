using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kent_Henrik_Rymdpiraterna
{
	class Xion:Elakklass
	{
		public Xion(Texture2D tex):base(30)
		{
            speed = 3;
			texture = tex;
			position = new Vector2(ran.Next(0, 596 - 560), -700);
			hitBox = new Rectangle((int)position.X, (int)position.Y, 532, 532);
		}
	}
}

