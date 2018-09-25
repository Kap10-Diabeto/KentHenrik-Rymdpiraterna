using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kent_Henrik_Rymdpiraterna
{
	class Xion
	{
		Texture2D xion;
		Vector2 xionpos;
		Rectangle hitBox;
		Random ran = new Random();
		float speed = 1;
		bool isDead = false;
		int hp = 70;

		public Rectangle HitBox
		{
			get { return hitBox; }
		}

		public bool IsDead
		{
			get { return isDead; }
			set { isDead = value; }
		}

		public Xion(Texture2D tex)
		{
			xion = tex;
			xionpos = new Vector2(ran.Next(0, 596 - 560), -700);
			hitBox = new Rectangle((int)xionpos.X, (int)xionpos.Y, 532, 532);
		}
		public void update()
		{
			xionpos.Y += speed;
			hitBox.Y = (int)xionpos.Y;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(xion, hitBox, Color.White);
		}
		public void TaSkada()
		{
			hp--;
			if (hp <= 0)
				isDead = true;
		}
	}
}
