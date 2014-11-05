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
		public AnimatedSprite (SpriteTile tile)
		{
			spriteSheet = tile;
			spriteSheet.Position = new Vector2(50, 50);
		}
		
		public SpriteTile spriteSheet;
		public bool active;
		private int currIndex = 0;
		
		public void Update()
		{
			if(!active) return;
			currIndex++;
			if(currIndex > 3) currIndex = 0;
			spriteSheet.TileIndex1D = currIndex;
		}
		
	}
}