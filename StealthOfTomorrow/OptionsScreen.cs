using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.HighLevel.UI;

namespace StealthOfTomorrow
{
	public class OptionsScreen : Sce.PlayStation.HighLevel.GameEngine2D.Scene
	{
		TextureInfo tiBG;
		Texture2D texBG;
		SpriteUV spriteBG;
		OptionsUI.OptionsScene uiScene;
		
		public OptionsScreen ()
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
			
			/*VVV - This UIComposer Implementation should work, but a NullReferenceException is causing it to fail. - VVV*/
			uiScene = new OptionsUI.OptionsScene();
			UISystem.SetScene(uiScene);
			
			Scheduler.Instance.ScheduleUpdateForTarget(this,0,false);
			this.RegisterDisposeOnExitRecursive();
			
		}
		
		~OptionsScreen()
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
		}
	}
}
