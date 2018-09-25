using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kent_Henrik_Rymdpiraterna
{
	class ELAK
	{
		Texture2D ELAK1;
		Vector2 ELAKpos;
		Rectangle hitBox;
		Random ran = new Random();
		float speed = 10;
		bool isDead = false;

		public Rectangle HitBox
		{
			get { return hitBox; }
		}

		public bool IsDead
		{
			get { return isDead; }
			set { isDead = value; }
		}

		public ELAK(Texture2D tex)
		{
			ELAK1 = tex;
			ELAKpos = new Vector2(ran.Next(0, 546),-50);
			hitBox = new Rectangle((int)ELAKpos.X, (int)ELAKpos.Y, 50, 50);
		}

		public void update()
		{
			ELAKpos.Y += speed;
			hitBox.Y = (int)ELAKpos.Y;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(ELAK1, hitBox, Color.White);
		}
	}
}
