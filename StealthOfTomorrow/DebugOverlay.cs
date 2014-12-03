using System;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.Core;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Input;


namespace StealthOfTomorrow
{
	public class DebugOverlay : Scene
	{
		#region Member Properties - Labels
		private Label lblTopLeft;
		private Label lblTopRight;
		private Label lblBottomLeft;
		private Label lblBottomRight;
		
		#endregion
		
		#region Screen dimensions
		private int screenWidth;
		private int screenHeight;
		#endregion
		
		#region Fonts
		Font font;		
		FontMap debugFont;
		#endregion
		
		private SpriteUV 		bgSprite;
		private TextureInfo		bgTextInfo;
		
		private float elapsedTime = 0;
		
		private bool transitionStarted;
		public DebugOverlay ()
		{
			this.Camera.SetViewFromViewport();	// Check documentation - defines a 2D view that matches the viewport(viewport == display region, in our case, the vita screen)
			
			#region Set screen width and height variables
			screenWidth = Director.Instance.GL.Context.Screen.Width;
			screenHeight = Director.Instance.GL.Context.Screen.Height;
			#endregion
			
			#region Instantiate Fonts
			font = new Font(FontAlias.System, 20, FontStyle.Bold);
			debugFont = new FontMap(font, 20);
			
			// Reload the font becuase FontMap disposes of it
			font = new Font(FontAlias.System, 20, FontStyle.Bold);
			#endregion
			#region Instantiate label objects
			lblTopLeft = new Label();
			
			lblTopRight = new Label();
			lblBottomLeft = new Label();
			lblBottomRight = new Label();
			#endregion
			
			#region Assign label values
			lblTopLeft.FontMap = debugFont;
			lblTopLeft.Text = "Top Left";
			lblTopLeft.Position = new Vector2 (0, screenHeight - debugFont.CharPixelHeight);
			
			lblTopRight.FontMap = debugFont;
			lblTopRight.Text = "Top Right";
			lblTopRight.Position = new Vector2(screenWidth - font.GetTextWidth(lblTopRight.Text) - 10, screenHeight - font.Size);
			
			lblBottomLeft.FontMap = debugFont;
			lblBottomLeft.Text = "Bottom Left";
			lblBottomLeft.Position = new Vector2(0, 0);
			
			lblBottomRight.FontMap = debugFont;
			lblBottomRight.Text = "Bottom Right";
			lblBottomRight.Position = new Vector2(screenWidth - font.GetTextWidth(lblBottomRight.Text) - 10, 0);
			#endregion
			
			bgTextInfo = new TextureInfo("/Application/Assets/Backgrounds/MainMenu.png");
			bgSprite = new SpriteUV(bgTextInfo);
			bgSprite.Quad.S = bgTextInfo.TextureSizef;
			bgSprite.Position = new Vector2(0f,0f);
		
			#region Add labels to scene (Debug Overlay)
			this.AddChild(lblTopLeft);
			this.AddChild(lblTopRight);
			this.AddChild(lblBottomLeft);
			this.AddChild(lblBottomRight);
			this.AddChild(bgSprite);
			#endregion
			
			
			Scheduler.Instance.ScheduleUpdateForTarget(this, 1, false);	// Tells the director that this "node" (a.k.a scene - see doc) requires to be updated
			Director.Instance.DebugFlags = Director.Instance.DebugFlags | DebugFlags.DrawGrid;
			this.DrawGridStep = 20.0f;
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);
			
			var touches = Touch.GetData(0);
			//Input2.GamePad0.Start.Press && !transitionStarted || 
			if(touches.Count > 0 && !transitionStarted && touches[0].Status == TouchStatus.Down)
			{
				float screenheight = Director.Instance.GL.Context.GetViewport().Height;
				float screenwidth = Director.Instance.GL.Context.GetViewport().Width;
				float screenx = (touches[0].X +0.5f) * screenwidth;
				float screenY = (touches[0].Y +0.5f) * screenheight;
				

				if(screenx >= 169 && screenx <= 391
		   			&& screenY >= 227 && screenY <= 303)		
				{
					transitionStarted = true;
					Touch.GetData(0).Clear();	
					SceneManager.Instance.SendSceneToFront(new CharacterSelectScreen(new ImageColor(255, 0, 0, 255), 38), SceneManager.SceneTransitionType.CrossFade, 3.0f);
				}	
				else if(screenx >= 568 && screenx <= 793
		   			&& screenY >= 227 && screenY <= 303)		
				{
					Console.WriteLine("Options");
				}	
				else if(screenx >= 370 && screenx <= 593
		   			&& screenY >= 397 && screenY <= 474)		
				{
					
					AppMain.GAMERUNNING = false;
				}	
				else
					Console.WriteLine(screenx + " " + screenY );

				
				//SceneManager.Instance.SendSceneToFront(new FrontEnd(), SceneManager.SceneTransitionType.CrossFade, 3.0f);
			}
		}
	}
}

