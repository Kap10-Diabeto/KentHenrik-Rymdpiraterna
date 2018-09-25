using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Kent_Henrik_Rymdpiraterna
{
	class Bullet
	{
		Texture2D BULLET;
		Vector2 BULLETPos;
		Rectangle hitBox;
		float speed = 20;
		bool isDead;

		public Rectangle HitBox
		{
			get { return hitBox; }
		}

		public bool IsDead
		{
			get { return isDead; } 
			set { isDead = value; }
		}
	public Bullet(Texture2D tex ,Vector2 pos)
		{
			BULLET = tex;
			BULLETPos = pos;
			hitBox = new Rectangle((int)BULLETPos.X, (int)BULLETPos.Y, 20,20);
		}

		public void update()
		{
			BULLETPos.Y -= speed;
			hitBox.Y = (int)BULLETPos.Y;
		}


		public void draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(BULLET, hitBox, Color.White);
		}

	}
}
