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
		public AnimatedSprite(SpriteTile tile, string[] states, bool loops)
		{
			m_spriteTile = tile;
			loop = loops;
		}
		
		public bool active, loop;
		public Vector2 position { get { return m_position; } set { m_position = value; } }
		public Vector2 scale { get { return m_spriteTile.Scale; } set { m_spriteTile.Scale = value; } }
		
		private SpriteTile m_spriteTile;
		
		private Vector2i m_currIndex;
		private int m_stateTilesWidth;
		
		private Vector2 m_position;
		
		public void SetState(string state)
		{
			switch(state)
			{
			case "Idle": m_currIndex.Y = 3; m_stateTilesWidth = 1; break;
			case "Walk": m_currIndex.Y = 2; m_stateTilesWidth = 2; break;
			case "Jump": m_currIndex.Y = 1; m_stateTilesWidth = 2; break;
			case "Kick": m_currIndex.Y = 0; m_stateTilesWidth = 2; break;
			default: break;
			}
		}
		
		public void Update()
		{
			if(!active) return;
			
			m_currIndex.X++;
			if(m_currIndex.X >= m_stateTilesWidth)
			{
				if(loop) m_currIndex.X = 0;
				else m_currIndex.X--;
			}
			
			m_spriteTile.TileIndex2D = m_currIndex;
			m_spriteTile.Position = m_position;
		}
		
		public void Activate(Scene scene)
		{
			scene.AddChild(m_spriteTile);
		}
		
		public void Deactivate(Scene scene)
		{
			scene.RemoveChild(m_spriteTile, false);
		}
	}
}