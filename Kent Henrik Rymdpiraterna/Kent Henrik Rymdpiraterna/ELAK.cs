using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kent_Henrik_Rymdpiraterna
{
	class ELAK:Basklass
	{ 
		Random ran = new Random();
		
		public bool IsDead
		{
			get { return isDead; }
			set { isDead = value; }
		}

		public ELAK(Texture2D tex)
		{
			texture = tex;
			position = new Vector2(ran.Next(0, 546),-50);
			hitBox = new Rectangle((int)position.X, (int)position.Y, 50, 50);
		}

		public override void Update()
		{
			position.Y += speed;
			hitBox.Y = (int)position.Y;
		}

		public void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, hitBox, Color.White);
		}
	}
}
