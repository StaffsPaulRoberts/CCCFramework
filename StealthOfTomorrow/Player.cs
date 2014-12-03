using System;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.Core;

namespace StealthOfTomorrow
{
	public class Player
	{
		TextureInfo tiGuy;
		Texture2D textureGuy;
		SpriteUV guy;
		Vector2 position;
		
		public Player (GameScene scene)
		{
			var screenSize = Director.Instance.GL.Context.GetViewport();
			
			textureGuy = new Texture2D("/Application/guy.png", false);
			tiGuy = new TextureInfo(textureGuy);
			
			guy = new SpriteUV(tiGuy);
			guy.Quad.S = tiGuy.TextureSizef;
			guy.Position = position = new Vector2(screenSize.Width / 2, screenSize.Height / 2);
			guy.CenterSprite();
			scene.AddChild(guy);
		}
		
		public void Move(Vector2 movement)
		{
			position += movement;
			guy.Position = position;
			
			if(movement.LengthSquared() > 0.0f) guy.Angle = -movement.Angle(new Vector2(0.0f, 1.0f));
		}
	}
}

