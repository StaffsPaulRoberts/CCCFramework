using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace StealthOfTomorrow
{
	public class AnimatedSprite
	{
		public AnimatedSprite (SpriteTile tile, int tileAmount)
		{
			sprite = tile;
			numTiles = tileAmount;
		}
		
		public SpriteTile sprite;
		public bool active;
		private int currIndex = 0;
		private int numTiles;
		
		public void Update()
		{
			if(!active) return;
			currIndex++;
			if(currIndex >= numTiles) currIndex = 0;
			sprite.TileIndex1D = currIndex;
		}
		
		public void SetPosition(int x, int y)
		{
			sprite.Position = new Vector2(x, y);
		}
		
	}
}