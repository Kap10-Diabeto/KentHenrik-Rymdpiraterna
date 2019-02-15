using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kent_Henrik_Rymdpiraterna
{
	class ELAK:Elakklass
	{

		public ELAK(Texture2D tex):base(1)
		{
			texture = tex;
			position = new Vector2(ran.Next(0, 546),-50);
			hitBox = new Rectangle((int)position.X, (int)position.Y, 50, 50);
		}

	}
}
