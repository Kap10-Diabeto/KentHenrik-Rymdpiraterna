
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kent_Henrik_Rymdpiraterna
{
	
	class SUPERELAK
	{

		Texture2D SuperELAK;
		Vector2 SuperELAKpos;
		Rectangle hitBox;
		Random ran = new Random();
		float speed = 2;
		bool isDead = false;
		int hp = 20;

		public Rectangle HitBox
		{
			get { return hitBox; }
		}

		public bool IsDead
		{
			get { return isDead; }
			set { isDead = value; }
		}

		public SUPERELAK(Texture2D tex)
		{
			SuperELAK = tex;
			SuperELAKpos = new Vector2(ran.Next(0, 596-200), -200);
			hitBox = new Rectangle((int)SuperELAKpos.X, (int)SuperELAKpos.Y, 200, 200);
		}
		public void update()
		{
			SuperELAKpos.Y += speed;
			hitBox.Y = (int)SuperELAKpos.Y;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(SuperELAK, hitBox, Color.White);
		}
		public void TaSkada()
		{
			hp--;
			if (hp <= 0)
				isDead = true;
		}



	}
}

