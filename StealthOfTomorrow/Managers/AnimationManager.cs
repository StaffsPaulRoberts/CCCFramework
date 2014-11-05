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
		
		private static List<AnimatedSprite> m_animations = new List<AnimatedSprite>();
		private static List<AnimatedSprite> m_activeAnimations = new List<AnimatedSprite>();
		private Scene scene;
		
		public AnimatedSprite LoadAnimation(string filename, Vector2i numTiles, Scene toSet)
		{
			scene = toSet;
			Texture2D texture = new Texture2D(filename, false);
			TextureInfo info = new TextureInfo(texture, numTiles);
			SpriteTile tile = new SpriteTile(info);
			tile.Quad.S = new Vector2(info.TextureSizef.X / numTiles.X, info.TextureSizef.Y);
			tile.CenterSprite();
			AnimatedSprite newSprite = new AnimatedSprite(tile, numTiles.X);
			m_animations.Add(newSprite);
			return newSprite;
		}
		
		public void ActivateAnimation(AnimatedSprite toActivate)
		{
			m_activeAnimations.Add(toActivate);
			toActivate.active = true;
			scene.AddChild(toActivate.sprite);
		}
		
		public void DeactivateAnimation(AnimatedSprite toDeactivate)
		{
			m_activeAnimations.Remove(toDeactivate);
			toDeactivate.active = false;
			scene.RemoveChild(toDeactivate.sprite, false);
		}
		
		public void UpdateAnimations()
		{
			foreach(AnimatedSprite a in m_activeAnimations) a.Update();
		}
		
	}
}