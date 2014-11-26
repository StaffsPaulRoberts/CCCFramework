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
		public AnimatedSprite(SpriteTile tile, Vector2i numTiles, string[] states, bool loops)
		{
			spriteTile = tile;
			tileIndices = numTiles;
			loop = loops;
		}
		
		public bool active, loop;
		public Vector2 position { get { return m_position; } set { m_position = value; } }
		
		private SpriteTile spriteTile;
		private Vector2i tileIndices;
		private int stateTilesWidth;
		private int currY;
		private int currIndex;
		private Vector2 m_position;
		
		public void SetState(string state)
		{
			int stateY = 0;
			
			switch(state)
			{
			default: stateTilesWidth = 2; break;
			}
			
			currY = stateY;
		}
		
		public void Update()
		{
			if(!active) return;
			
			currIndex++;
			if(currIndex >= stateTilesWidth)
			{
				if(loop) currIndex = 0;
				else currIndex--;
			}
			
			spriteTile.TileIndex2D = new Vector2i(currIndex, currY);
			spriteTile.Position = m_position;
		}
		
		public void Activate(Scene scene)
		{
			scene.AddChild(spriteTile);
		}
		
		public void Deactivate(Scene scene)
		{
			scene.RemoveChild(spriteTile, false);
		}
	}
}