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
			spriteBG.Position = new Vector2(3 * screenSize.Width/4, 2*screenSize.Height/3);
			spriteBG.CenterSprite();
			spriteBG.Scale = new Vector2(0.5f, 0.5f);
			
			this.AddChild(spriteBG);
			
			uiScene = new OptionsUI.OptionsScene();
			UISystem.SetScene(uiScene);
			
			uiScene.BrightnessSlider.Value = GameManager.Instance.Brightness * 100;
			uiScene.ContrastSlider.Value = GameManager.Instance.Contrast * 100;
			uiScene.musicVolSlider.Value = GameManager.Instance.MusicVol * 100;
			uiScene.soundVolSlider.Value = GameManager.Instance.SoundFXVol * 100;
			
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
			UISystem.Update(Touch.GetData(0));
			GameManager.Instance.Brightness = uiScene.BrightnessSlider.Value/100;
			GameManager.Instance.Contrast = uiScene.ContrastSlider.Value/100;
			GameManager.Instance.MusicVol = uiScene.musicVolSlider.Value/100;
			GameManager.Instance.SoundFXVol = uiScene.soundVolSlider.Value/100;
			
			base.Update (dt);
		}
		
		public override void Draw ()
		{
			base.Draw ();
		}
	}
}
