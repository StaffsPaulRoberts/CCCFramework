using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace StealthOfTomorrow
{
	public class AnimationManager
	{
		private AnimationManager () { }
		private static AnimationManager instance;
		public static AnimationManager Instance
		{
			get
			{
				if(instance == null) instance = new AnimationManager();
				return instance;
			}
		}
		
		private static Dictionary<string, AnimatedSprite> m_animations = new Dictionary<string, AnimatedSprite>();
		private static Dictionary<string, AnimatedSprite> m_activeAnimations = new Dictionary<string, AnimatedSprite>();
		private Scene scene;
		
		public void LoadAnimation(int numSprites, string[] states, string filename, Vector2i numTiles, Scene toSet, string id)
		{
			scene = toSet;
			Texture2D texture = new Texture2D(filename, false);
			TextureInfo info = new TextureInfo(texture, numTiles);
			SpriteTile tile = new SpriteTile(info);
			
			texture = new Texture2D(filename, false);
			info = new TextureInfo(texture, numTiles);
			tile = new SpriteTile(info);
			tile.Quad.S = new Vector2(info.TextureSizef.X / numTiles.X, info.TextureSizef.Y / numTiles.Y);
			tile.CenterSprite();
		
			AnimatedSprite newSprite = new AnimatedSprite(tile, states, true);
			newSprite.name = id;
			m_animations[id] = newSprite;
		}
		
		public void ActivateAnimation(string toActivate, Scene scene)
		{
			m_animations[toActivate].active = true;
			m_animations[toActivate].Activate(scene);
			m_activeAnimations.Add(toActivate, m_animations[toActivate]);
		}
		
		public void DeactivateAnimation(string toDeactivate, Scene scene)
		{
			m_animations[toDeactivate].active = false;
			m_animations[toDeactivate].Deactivate(scene);
			m_activeAnimations.Remove(toDeactivate);
		}
		
		public void UpdateAnimations()
		{
			foreach(AnimatedSprite a in m_activeAnimations.Values) a.Update();
		}
		
		public void SetSpriteState(string spriteID, string state)
		{
			m_animations[spriteID].SetState(state);
		}
		
		public AnimatedSprite GetAnimatedSprite(string id)
		{
			return m_animations[id];
		}
	}
}