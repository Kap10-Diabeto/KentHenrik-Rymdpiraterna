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
	class SNEL
	{
		Texture2D ZNEL;
		Texture2D BULLETtex;
		Vector2 ZNELPos;
		Rectangle hitBox;
		float fireRate = 0.1f;
		float reloading = 0;
		List<Bullet> BULLETS = new List<Bullet>();
		int HP = 3;

		public int Health
		{
			get { return HP; }
		}

		public List<Bullet> Bullets
		{
			get { return BULLETS; }
		}

		public SNEL(Texture2D tex, Texture2D bulletTex)
		{
			ZNEL = tex;
			BULLETtex = bulletTex;
			ZNELPos = new Vector2(265,900);
			hitBox = new Rectangle((int)ZNELPos.X, (int)ZNELPos.Y, 60, 60);
		}
		public void Update(GameTime gameTime,GameWindow window)
		{
			KeyboardState state = Keyboard.GetState();
			/*if (state.IsKeyDown(Keys.Right)&& ZNELPos.X+hitBox.Width < window.ClientBounds.Width)
				ZNELPos.X += 10;
			if (state.IsKeyDown(Keys.Left)&& ZNELPos.X>0)
				ZNELPos.X -= 10;
			if (state.IsKeyDown(Keys.Up)&& ZNELPos.Y>0)
				ZNELPos.Y -= 10;
			if (state.IsKeyDown(Keys.Down)&& ZNELPos.Y+hitBox.Height < window.ClientBounds.Height)
				ZNELPos.Y += 10;
				*/
			ZNELPos = Mouse.GetState().Position.ToVector2();
			if (ZNELPos.X < 0)
				ZNELPos.X = 0;
			if (ZNELPos.X + hitBox.Width > 596)
				ZNELPos.X = 596 - hitBox.Width;
			if (ZNELPos.Y + hitBox.Height > 960)
				ZNELPos.Y = 960 - hitBox.Height;
			/*
			if (ZNELPos.Y + hitBox.Height > 0)
				ZNELPos.Y = 0 - hitBox.Height;
				*/


			if (Mouse.GetState().LeftButton == ButtonState.Pressed && reloading >= fireRate)
			{
				BULLETS.Add(new Bullet(BULLETtex, new Vector2(ZNELPos.X + hitBox.Size.X / 2 - 5, ZNELPos.Y)));
				reloading = 0;
			}
			else
			{
				reloading += (float)gameTime.ElapsedGameTime.TotalSeconds;
			}

			for (int i = 0; i < BULLETS.Count; i++)
			{
				BULLETS[i].update();
			}
			hitBox.X = (int)ZNELPos.X;
			hitBox.Y = (int)ZNELPos.Y;
			RemoveBullets();
		}


		public void Draw(SpriteBatch spriteBatch)
		{
			foreach (var item in BULLETS)
			{
				item.draw(spriteBatch);

			}
			spriteBatch.Draw(ZNEL,hitBox, Color.White);
		}
		public void RemoveBullets()
		{
			List<Bullet> temp = new List<Bullet>();
			for (int i = 0; i < BULLETS.Count; i++)
			{
				if (!Bullets[i].IsDead)
					temp.Add(BULLETS[i]);
			}
			BULLETS = temp;
		}
		 
		public void LHP()
		{
			HP--;
		}

	}
}
