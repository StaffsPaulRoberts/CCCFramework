using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace StealthOfTomorrow
{
	public class BaseLevel
	{
		//Private variables
		//Platform sprite
		private SpriteUV[] platforms = new SpriteUV[3];
		
		private TextureInfo platformTex;
		
		public BaseLevel (Scene scene)
		{
			//Shared platform texture
			platformTex = new TextureInfo("/Application/Assets/base_platform_main.png");
			
			platforms[0] = new SpriteUV(platformTex);
			platforms[0].Quad.S = platformTex.TextureSizef;
			platforms[0].Position = new Vector2(30.0f, 3.0f);
			
			platforms[1] = new SpriteUV(platformTex);
			platforms[1].Quad.S = platformTex.TextureSizef;
			platforms[1].Position = new Vector2(60.0f, 0.0f);
			
			platforms[2] = new SpriteUV(platformTex);
			platforms[2].Quad.S = platformTex.TextureSizef;
			platforms[2].Position = new Vector2(60.0f, 0.0f);
			
			scene.AddChild(platforms[0]);
		}
		
		public void Dispose()
		{
			platformTex.Dispose();
		}
	}
}