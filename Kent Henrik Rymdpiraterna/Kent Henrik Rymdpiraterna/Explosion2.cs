﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Threading.Tasks;

namespace Kent_Henrik_Rymdpiraterna
{
	class Explosion2 { 
	public Texture2D Texture { get; set; }
	public int Rows { get; set; }
	public int Columns { get; set; }
	private int currentFrame;
	private int totalFrames;
	Vector2 location;
	bool remove = false;
		int frame = 0;

	public bool Remove
	{
		get { return remove; }
	}



	public Explosion2(Texture2D texture, int rows, int columns, Vector2 pos)
	{
		Texture = texture;
		Rows = rows;
		Columns = columns;
		currentFrame = 0;
		totalFrames = Rows * Columns;
		location = pos;
	}

	public void Update()
	{
			
			if((frame%2) ==0)
				currentFrame++;
			frame++;
		if (currentFrame == totalFrames)
			remove = true; ;
	}

	public void Draw(SpriteBatch spriteBatch)
	{

				int width = Texture.Width / Columns;
				int height = Texture.Height / Rows;
				int row = (int)((float)currentFrame / (float)Columns);
				int column = currentFrame % Columns;

		Rectangle sourceRectangle = new Rectangle(width * column, height * row, width, height);
		Rectangle destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width, height);

		spriteBatch.Begin();
		spriteBatch.Draw(Texture, destinationRectangle, sourceRectangle, Color.White);
		spriteBatch.End();
	}
}

	
}
