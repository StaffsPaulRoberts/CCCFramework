using System;
using StealthOfTomorrow;
using Sce.PlayStation.HighLevel.UI;

namespace CustomButtons
{
	public class ButtonMenu : Button
	{
		public ButtonMenu ()
		{
			
		}
		
		protected override void OnPressStateChanged (PressStateChangedEventArgs e)
		{
			base.OnPressStateChanged (e);
			UISystem.SetScene(null);
			SceneManager.Instance.SendSceneToFront(new DebugOverlay(), SceneManager.SceneTransitionType.CrossFade, 3.0f);
		}
	}
}

