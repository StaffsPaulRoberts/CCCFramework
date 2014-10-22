using System;
using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.Core.Input;

namespace StealthOfTomorrow
{
	public class SceneManager
	{
		public enum SceneTransitionType
		{
			// Add transition enums
			CrossFade,
			DirectionalFade,
			SolidFade,
		}
		private static SceneManager instance;
		
		public SceneManager ()
		{
			
		}
		
		/* You should all be familiar with this design pattern - known as the Singleton pattern. If not, do not be afraid to ask! */
		public static SceneManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new SceneManager();	
				}
				return instance;
			}
		}
		
		public void SendSceneToFront(Scene nextScene, SceneTransitionType sceneTransition, float duration)
		{
			Touch.GetData(0).Clear();
			switch(sceneTransition)
			{
			case SceneTransitionType.CrossFade:	
				TransitionCrossFade crossFade = new TransitionCrossFade(nextScene);
				crossFade.Duration = duration;
				crossFade.Tween = (x) => Sce.PlayStation.HighLevel.GameEngine2D.Base.Math.PowEaseOut(x, 3.0f);
				Director.Instance.ReplaceScene(crossFade);
				break;
				
			case SceneTransitionType.DirectionalFade:
				TransitionDirectionalFade directionalFade = new TransitionDirectionalFade(nextScene);
				directionalFade.Duration = duration;
				Director.Instance.ReplaceScene(directionalFade);
				break;
				
			case SceneTransitionType.SolidFade:
				TransitionSolidFade solidFade = new TransitionSolidFade(nextScene);
				solidFade.Duration = duration;
				
				Director.Instance.ReplaceScene(solidFade);
				break;
				
			default:
				throw new Exception("Expected to transition to a scene - something went wrong. Please check the stack trace to SceneManager.SendSceneToFront()");
				break;
			}
			
		}
	}
}

