using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace StealthOfTomorrow
{
	public class OptionsScene : Scene
	{
		TextureInfo tiBG;
		Texture2D texBG;
		SpriteUV spriteBG;
		
		public OptionsScene ()
		{
			var screenSize = Director.Instance.GL.Context.GetViewport();
			this.Camera.SetViewFromViewport();
			
			texBG = new Texture2D("/Application/gamepopper-logo.png", false);
			tiBG = new TextureInfo(texBG);
			spriteBG = new SpriteUV(tiBG);
			spriteBG.Quad.S = tiBG.TextureSizef;
			spriteBG.Position = new Vector2(screenSize.Width/2, screenSize.Height/2);
			spriteBG.CenterSprite();
			
			this.AddChild(spriteBG);
			
			Scheduler.Instance.ScheduleUpdateForTarget(this,0,false);
			this.RegisterDisposeOnExitRecursive();
			
		}
		
		~OptionsScene()
		{
			tiBG.Dispose();
			texBG.Dispose();
		}
		
		public override void OnEnter ()
		{
			base.OnEnter ();
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);
			
			Vector2 position = spriteBG.Position;
			
			if (Input2.GamePad0.Up.Down)
			{
				this.Scale += dt;
			}
			if (Input2.GamePad0.Down.Down)
			{
				this.Scale -= dt;
			}
			
			spriteBG.Position = position;
		}
	}
}

