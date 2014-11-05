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
		public AnimatedSprite (SpriteTile tile, int tiles)
		{
			spriteSheet = tile;
			numTiles = tiles;
			spriteSheet.Position = new Vector2(50.0f, 50.0f);
		}
		
		public SpriteTile spriteSheet;
		public bool active;
		private int currIndex = 0;
		private int numTiles;
		
		public void Update()
		{
			if(!active) return;
			currIndex++;
			if(currIndex >= numTiles) currIndex = 0;
			spriteSheet.TileIndex1D = currIndex;
			spriteSheet.DebugDrawTransform();
		}
		
	}
}