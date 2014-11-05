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
			
			#region Add labels to scene (Debug Overlay)
			this.AddChild(lblTopLeft);
			this.AddChild(lblTopRight);
			this.AddChild(lblBottomLeft);
			this.AddChild(lblBottomRight);
			#endregion
			
			
			Scheduler.Instance.ScheduleUpdateForTarget(this, 1, false);	// Tells the director that this "node" (a.k.a scene - see doc) requires to be updated
			Director.Instance.DebugFlags = Director.Instance.DebugFlags | DebugFlags.DrawGrid;
			this.DrawGridStep = 20.0f;
		}
		
		public override void Update (float dt)
		{
			base.Update (dt);
			
			//var touches = Touch.GetData(0);
			if(Input2.GamePad0.Start.Press && !transitionStarted)
			{
				transitionStarted = true;
				Touch.GetData(0).Clear();
				SceneManager.Instance.SendSceneToFront(new OptionsScreen(), SceneManager.SceneTransitionType.CrossFade, 3.0f);
			}
		}
	}
}

