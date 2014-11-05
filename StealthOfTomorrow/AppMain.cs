using System;
using System.Collections.Generic;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Environment;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Input;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.UI;

namespace StealthOfTomorrow
{
	public class AppMain
	{
		
		public static void Main (string[] args)
		{
			
			Initialize();

			while (true) {
				SystemEvents.CheckEvents ();	// We check system events (such as pressing PS button, pressing power button to sleep, major and unknown crash!!)
				
				Director.Instance.Update();
				UISystem.Update(Touch.GetData(0)); // Update UI Manager
				Director.Instance.Render();
			    UISystem.Render(); // Render UI Manager
				Director.Instance.GL.Context.SwapBuffers(); // Swap between back and front buffer
				Director.Instance.PostSwap(); // Must be called after swap buffers - not 100% sure, imagine it resets back buffer to black/white, unallocates tied resources for next swap
			}
			Director.Terminate();	// Kill (terminate) the director, hence ending 2D scene program, once we are done with the scene (clicking red X button)
			Sce.PlayStation.HighLevel.UI.UISystem.Terminate();
		}
		
		
		public static void Initialize()
		{
			Director.Initialize(); // Initialises the GameEngine2D supplied by Sony. This will ALWAYS be done if you plan on using the 2D Director
			
			UISystem.Initialize(Director.Instance.GL.Context);
			UISystem.SetScene(new Sce.PlayStation.HighLevel.UI.Scene(), null);
			DebugOverlay scnDebug = new DebugOverlay();	// Create our new Debug Scene			
			
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
