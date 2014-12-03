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
	public class CharacterSelectScreen : Scene
	{
		private string titleText = "Character Select - Press X to start";
		private Texture2D m_titleTextTex;
		private TextureInfo m_titleTextTexInfo;
		private SpriteUV m_titleTextSprite;
		
		private TextureInfo m_selectBoxTexInfo;
		private SpriteUV m_selectBoxSprite;
		
		public CharacterSelectScreen(ImageColor textcolor, int textSize)
		{
			var screenSize = Director.Instance.GL.Context.GetViewport();
			var textImage = new Image(ImageMode.Rgba, new ImageSize(screenSize.Width, screenSize.Height), new ImageColor(0, 0, 0, 0));
			textImage.Decode();
			
			Font font = new Font(FontAlias.System, textSize,FontStyle.Regular);
			
			textImage.DrawText(titleText, textcolor, font, new ImagePosition((screenSize.Width - font.GetTextWidth(titleText)) / 2, screenSize.Height / 12 - textSize / 2));
			
			m_titleTextTex = new Texture2D(screenSize.Width, screenSize.Height, false, PixelFormat.Rgba);
			m_titleTextTex.SetPixels(0, textImage.ToBuffer());
			textImage.Dispose();
			
			m_titleTextTexInfo = new TextureInfo(m_titleTextTex);
			
			m_titleTextSprite = new SpriteUV(m_titleTextTexInfo);
			m_titleTextSprite.Pivot = new Vector2(0.5f, 0.5f);
			m_titleTextSprite.Position = new Vector2(screenSize.Width / 2, screenSize.Height / 2);
			m_titleTextSprite.Scale = m_titleTextTexInfo.TextureSizef;
			
			m_selectBoxTexInfo = new TextureInfo("Application/Assets/charSelectBox.png");
			m_selectBoxSprite = new SpriteUV(m_selectBoxTexInfo);
			
			m_selectBoxSprite.Quad.S = new Vector2(m_selectBoxTexInfo.TextureSizef.X, m_selectBoxTexInfo.TextureSizef.Y);
			m_selectBoxSprite.CenterSprite();
			m_selectBoxSprite.Position = new Vector2(screenSize.Width / 2, screenSize.Height / 2);
			
			this.Camera.SetViewFromViewport();
			this.AddChild(m_selectBoxSprite);
			this.AddChild(m_titleTextSprite);
			
			Scheduler.Instance.ScheduleUpdateForTarget(this, 0, false);
			this.RegisterDisposeOnExitRecursive();
		}
		
		public override void OnEnter()
		{
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);
			
			bool alreadyInput = false;
			
			GamePadData gpadData = GamePad.GetData(0);
			
			if(Input2.GamePad0.Cross.Press)
			{
				Touch.GetData(0).Clear();
				SceneManager.Instance.SendSceneToFront(new GameScene("Game", new ImageColor(255, 0, 0, 255), 220), SceneManager.SceneTransitionType.CrossFade, 3.0f);
			}
			
			if(Input2.GamePad0.Up.Press)
			{
				m_selectBoxSprite.Position = new Vector2(m_selectBoxSprite.Position.X, m_selectBoxSprite.Position.Y + m_selectBoxSprite.Quad.S.Y);
				alreadyInput = true;
			}
			
			if(Input2.GamePad0.Left.Press)
			{
				m_selectBoxSprite.Position = new Vector2(m_selectBoxSprite.Position.X - m_selectBoxSprite.Quad.S.X, m_selectBoxSprite.Position.Y);
				alreadyInput = true;
			}
			
			if(Input2.GamePad0.Down.Press)
			{
				m_selectBoxSprite.Position = new Vector2(m_selectBoxSprite.Position.X, m_selectBoxSprite.Position.Y - m_selectBoxSprite.Quad.S.Y);
				alreadyInput = true;
			}
			
			if(Input2.GamePad0.Right.Press)
			{
				m_selectBoxSprite.Position = new Vector2(m_selectBoxSprite.Position.X + m_selectBoxSprite.Quad.S.X, m_selectBoxSprite.Position.Y);
				alreadyInput = true;
			}
			
			//if(!alreadyInput && Input2.Touch00.Press) m_selectBoxSprite.Position = Input2.Touch00.Pos;
		}
		
		~CharacterSelectScreen()
		{
			m_titleTextTexInfo.Dispose();
			m_titleTextTex.Dispose();
			m_selectBoxTexInfo.Dispose();
		}
	}
}