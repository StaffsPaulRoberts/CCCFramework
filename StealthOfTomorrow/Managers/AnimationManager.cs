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
		
		public void LoadAnimation(int numSprites, string[] states, string[] filenames, Vector2i[] numTiles, Scene toSet, string id)
		{
			scene = toSet;
			Texture2D[] textures = new Texture2D[numSprites];
			TextureInfo[] infos = new TextureInfo[numSprites];
			SpriteTile[] tiles = new SpriteTile[numSprites];
			
			for(int i = 0; i < numSprites; i++)
			{
				textures[i] = new Texture2D(filenames[i], false);
				infos[i] = new TextureInfo(textures[i], numTiles[i]);
				tiles[i] = new SpriteTile(infos[i]);
				tiles[i].Quad.S = new Vector2((infos[i].TextureSizef.X / numTiles[i].X) * 5.0f, infos[i].TextureSizef.Y * 5.0f);
				tiles[i].CenterSprite();
				
				Dictionary<string, SpriteTile> dictTiles = new Dictionary<string, SpriteTile>(numSprites);
				Dictionary<string, Vector2i> dictNumTiles = new Dictionary<string, Vector2i>(numSprites);
				
				for(int j = 0; j < numSprites; j++)
				{
					dictTiles[states[j]] = tiles[j];
					dictNumTiles[states[j]] = numTiles[j];
				}
				
				AnimatedSprite newSprite = new AnimatedSprite(dictTiles, dictNumTiles, true);
				m_animations[id] = newSprite;
			}
		}
		
		 public void ActivateAnimation(string toActivate)
		{
			m_animations[toActivate].active = true;
			m_animations[toActivate].Activate(scene);
			m_activeAnimations.Add(toActivate, m_animations[toActivate]);
		}
		
		public void DeactivateAnimation(string toDeactivate)
		{
			m_animations[toDeactivate].active = false;
			m_animations[toDeactivate].Deactivate(scene);
			m_activeAnimations.Remove(toDeactivate);
		}
		
		public void UpdateAnimations()
		{
			foreach(AnimatedSprite a in m_activeAnimations.Values)
			{
				a.Update();
			}
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