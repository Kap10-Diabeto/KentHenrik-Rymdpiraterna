using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kent_Henrik_Rymdpiraterna
{
	class Xion:Basklass
	{
		
		Random ran = new Random();
		int hp = 70;

		public Xion(Texture2D tex)
		{
			texture = tex;
			position = new Vector2(ran.Next(0, 596 - 560), -700);
			hitBox = new Rectangle((int)position.X, (int)position.Y, 532, 532);
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
