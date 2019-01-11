using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kent_Henrik_Rymdpiraterna
{
	class SNEL:Basklass
	{ 
		Texture2D BULLETtex;
		float fireRate = 0.1f;
		float reloading = 0;
        int HP;
        
		public int Health
		{
			get { return HP; }
		}
        

		public SNEL(Texture2D tex, Texture2D bulletTex)
		{
			texture = tex;
			BULLETtex = bulletTex;
			position = new Vector2(265,900);
			hitBox = new Rectangle((int)position.X, (int)position.Y, 60, 60);
            HP = 3;
		}

		public void Update(GameTime gameTime,GameWindow window)
		{
			KeyboardState state = Keyboard.GetState();

            position = Mouse.GetState().Position.ToVector2();
			if (position.X < 0)
                position.X = 0;
			if (position.X + hitBox.Width > 596)
                position.X = 596 - hitBox.Width;
			if (position.Y + hitBox.Height > 960)
                position.Y = 960 - hitBox.Height;

			if (Mouse.GetState().LeftButton == ButtonState.Pressed && reloading >= fireRate)
			{
				Game1.ELAKLista.Add(new Bullet(BULLETtex, new Vector2(position.X + hitBox.Size.X / 2 - 5, position.Y)));
				reloading = 0;
			}
			else
			{
				reloading += (float)gameTime.ElapsedGameTime.TotalSeconds;
			}

			hitBox.X = (int)position.X;
			hitBox.Y = (int)position.Y;
		}

		public void LHP()
		{
			HP--;
		}

	}
}
