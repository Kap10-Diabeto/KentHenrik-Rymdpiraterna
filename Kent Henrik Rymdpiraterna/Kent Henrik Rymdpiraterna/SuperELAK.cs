
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kent_Henrik_Rymdpiraterna
{
	
	class SUPERELAK:Basklass
	{

		Random ran = new Random();
		int hp = 20;

		public SUPERELAK(Texture2D tex)
		{
			texture = tex;
			position = new Vector2(ran.Next(0, 596-200), -200);
			hitBox = new Rectangle((int)position.X, (int)position.Y, 200, 200);
		}
		public override void Update()
		{
            position.Y += speed;
			hitBox.Y = (int)position.Y;
		}

		public void TaSkada()
		{
			hp--;
			if (hp <= 0)
				isDead = true;
		}



	}
}

