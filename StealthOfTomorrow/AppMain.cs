using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace StealthOfTomorrow
{
	public class AppMain
	{
		private static GraphicsContext graphics;
		
		public static void Main (string[] args)
		{
			Initialize();

			while (true) {
				SystemEvents.CheckEvents ();	// We check system events (such as pressing PS button, pressing power button to sleep, major and unknown crash!!)
				
				Director.Instance.Update();
				Director.Instance.Render();
				
				AnimationManager.Instance.UpdateAnimations();
				
				Director.Instance.GL.Context.SwapBuffers(); // Swap between back and front buffer
				Director.Instance.PostSwap(); // Must be called after swap buffers - not 100% sure, imagine it resets back buffer to black/white, unallocates tied resources for next swap
			}
			Director.Terminate();	// Kill (terminate) the director, hence ending 2D scene program, once we are done with the scene (clicking red X button)
		}
		
		
		public static void Initialize()
		{
			Director.Initialize(); // Initialises the GameEngine2D supplied by Sony. This will ALWAYS be done if you plan on using the 2D Director
			
			GameScene scnDebug = new GameScene("Not a game", new ImageColor(0, 0, 0, 255), 24);	// Create our new Debug Scene			
			
			AnimatedSprite testSprite = AnimationManager.Instance.LoadAnimation("/Application/testAnim.png", new Vector2i(4, 1), scnDebug);
			AnimationManager.Instance.ActivateAnimation(testSprite);
			
			Director.Instance.RunWithScene(scnDebug, true);	// Tell the Director to run the scene
		}
		
		/*********** No need for these methods, Director takes care of it for us now *************************
		public static void Update ()
		{
			// Query gamepad for current state
			var gamePadData = GamePad.GetData (0);
		}

		public static void Render ()
		{
			// Clear the screen
			graphics.SetClearColor (0.0f, 0.0f, 0.0f, 0.0f);
			graphics.Clear ();

			// Present the screen
			graphics.SwapBuffers ();
		}
		******************************************************************************************************/
	}
}