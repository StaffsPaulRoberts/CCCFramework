using System;
using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using System.Collections.Generic;

namespace StealthOfTomorrow
{
	public class AnimatedSprite
	{
		public AnimatedSprite (Dictionary<string, SpriteTile> tiles, Dictionary<string, Vector2i> tileAmount, bool loops)
		{
			dictSprites = tiles;
			dictTileIndices = tileAmount;
			loop = loops;
		}
		
		public bool active, loop;
		public Vector2 position { get { return currentSprite.Position; } set { currentSprite.Position = value; } }
		
		private Dictionary<string, SpriteTile> dictSprites;
		private SpriteTile currentSprite;
		private Dictionary<string, Vector2i> dictTileIndices;
		private Vector2i currentTiles;
		private int currIndex = 0;
		
		public void SetState(string state)
		{
			currentTiles = dictTileIndices[state];
			currentSprite = dictSprites[state];
			currIndex = 0;
		}
		
		public void Update()
		{
			if(!active) return;
			currIndex++;
			if(currIndex >= currentTiles.X)
			{
				if(loop)
				{
					currIndex = 0;
				} else currIndex--;
			}
			currentSprite.TileIndex1D = currIndex;
		}
		
		public void Activate(Scene scene)
		{
			scene.AddChild(currentSprite);
		}
		
		public void Deactivate(Scene scene)
		{
			scene.RemoveChild(currentSprite, false);
		}
	}
}