
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kent_Henrik_Rymdpiraterna
{
	
	class SUPERELAK:Elakklass
	{
		public SUPERELAK(Texture2D tex):base(8)
		{
            speed = 5;
			texture = tex;
			position = new Vector2(ran.Next(0, 596-200), -200);
			hitBox = new Rectangle((int)position.X, (int)position.Y, 200, 200);
		}
	}
}

