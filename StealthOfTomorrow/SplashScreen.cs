using System;
using Sce.PlayStation.HighLevel.GameEngine2D;

namespace StealthOfTomorrow
{
	public class SplashScreen :Scene
	{
		private int screenWidth;
		private int screenHeight;
		public SplashScreen ()
		{
			/************* Needs to be refactored *****************************/
			this.Camera.SetViewFromViewport();	// Check documentation - defines a 2D view that matches the viewport(viewport == display region, in our case, the vita screen)
			
			#region Set screen width and height variables
			screenWidth = Director.Instance.GL.Context.Screen.Width;
			screenHeight = Director.Instance.GL.Context.Screen.Height;
			#endregion
			/******************************************************************/
		}
	}
}

