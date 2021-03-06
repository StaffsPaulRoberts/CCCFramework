using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace StealthOfTomorrow
{
	public class GameScene : Scene
	{
		string 		_text;
		TextureInfo _ti;
		Texture2D 	_texture;
		
		TextureInfo tiFlag;
		Texture2D 	textureFlag;
		Character 	player1, player2, player3;
		
		BaseLevel 	baseLevel;
		
		public GameScene (string text, ImageColor textcolor, int textSize)
		{
			_text = text;
			var screenSize = Director.Instance.GL.Context.GetViewport();
			var textImage  = new Image(ImageMode.Rgba, new ImageSize(screenSize.Width, screenSize.Height), new ImageColor(0,0,0,0));
			textImage.Decode();
			
			Font font = new Font(FontAlias.System, textSize,FontStyle.Regular);
			textImage.DrawText (text, 
			                    textcolor, 
			                    new Font(FontAlias.System, textSize, FontStyle.Regular), 
			                    new ImagePosition((screenSize.Width - font.GetTextWidth(text))/2, screenSize.Height/2 - textSize/2));
			_texture = new Texture2D(screenSize.Width, screenSize.Height, false, PixelFormat.Rgba);
			_texture.SetPixels(0, textImage.ToBuffer());
			textImage.Dispose();
			
			_ti = new TextureInfo(_texture);
			
			SpriteUV sprite = new SpriteUV(_ti);
			sprite.Pivot    = new Vector2(0.5f, 0.5f);
			sprite.Position = new Vector2(screenSize.Width/2, screenSize.Height/2);
			sprite.Scale    = _ti.TextureSizef;
			
//			//Flag code
//			textureFlag = new Texture2D("/Application/saltire.jpg", false);
//			tiFlag = new TextureInfo(textureFlag);
//			
//			SpriteUV flag = new SpriteUV(tiFlag);
//			flag.Quad.S = _ti.TextureSizef;
//			flag.Position = new Vector2(0, 0);
//			this.AddChild(flag);
			
			this.Camera.SetViewFromViewport();
			this.AddChild(sprite);
			
			Scheduler.Instance.ScheduleUpdateForTarget(this,0,false);
			this.RegisterDisposeOnExitRecursive();
			
			//Base Level Class code
			baseLevel = new BaseLevel(this);
			
			// Animated Sprite loading + activation
			AnimationManager.Instance.LoadAnimation(4, new string[4]{"Idle", "Walk", "Jump", "Kick"}, "/Application/Assets/Animations/testChar.png", new Vector2i(2, 4), this, "testChar");
			AnimationManager.Instance.SetSpriteState("testChar", "Idle");
			AnimationManager.Instance.ActivateAnimation("testChar", this);
			
			//Player Code
			player1 = new Character(this,AnimationManager.Instance.GetAnimatedSprite("testChar"),4,100,100);
			player2 = new Character(this,AnimationManager.Instance.GetAnimatedSprite("testChar"),4,70,100);
			player3 = new Character(this,AnimationManager.Instance.GetAnimatedSprite("testChar"),4,70,10);
			List<Character> players = new List<Character> {player1 , player2, player3};
			
			Console.WriteLine("Created Players");
			
			// Example (test) player UI
			Sce.PlayStation.HighLevel.UI.UISystem.SetScene(new GameHUD(players), null);
		}
		
		public override void OnEnter()
		{
		}
		
		public override void Update (float dt)
		{
			player1.Update(dt);
			base.Update (dt);
			
			
		}
		
		~GameScene()
		{
			_ti.Dispose();
			_texture.Dispose();
		}
	}
}

