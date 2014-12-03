using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.UI;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace StealthOfTomorrow
{
	public class FrontEnd : Sce.PlayStation.HighLevel.GameEngine2D.Scene
	{
		
		private SpriteUV 	sprite;
		private TextureInfo	textureInfo;
		
		public FrontEnd ()
		{
			Console.WriteLine("INSIDE FRONTEND");
			sprite = new SpriteUV();
				
			textureInfo  		= new TextureInfo("/Application/saltire.jpg");
			sprite= new SpriteUV(textureInfo);
			sprite.Quad.S 	= textureInfo.TextureSizef;
			sprite.Position = new Vector2(50.0f, 0.0f);
			//sprite.Color = new Vector4(1f,1f,1f,1f);
			
			this.AddChild(sprite);
			
		
		}
	}
}

