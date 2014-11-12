using System;

namespace StealthOfTomorrow
{
	public class GameManager
	{
		private static GameManager instance;
		public static GameManager Instance
		{
			get
			{
				if(instance == null)
				{
					instance = new GameManager();	
				}
				return instance;
			}
		}
		
		//Audio
		private float musicVolume;
		private float soundVolume;
		
		public float MusicVol{
			get{return musicVolume;}
			set{
				if (value < 0)
					musicVolume = 0;
				else if (value > 1)
					musicVolume = 1;
				else
					musicVolume = value;
			}
		}
		public float SoundFXVol{
			get{return soundVolume;}
			set{
				if (value < 0)
					soundVolume = 0;
				else if (value > 1)
					soundVolume = 1;
				else
					soundVolume = value;
			}
		}
		
		//Video
		private float brightness;
		private float contrast;
		
		public float Brightness{
			get{return brightness;}
			set{
				if (value < 0)
					brightness = 0;
				else if (value > 1)
					brightness = 1;
				else
					brightness = value;
			}
		}
		public float Contrast{
			get{return contrast;}
			set{
				if (value < 0)
					contrast = 0;
				else if (value > 1)
					contrast = 1;
				else
					contrast = value;
			}
		}
		
		//Gameplay Settings
		private int difficulty;
		private bool itemsOn;		
		
		public int Difficulty{
			get{return difficulty;}
			set{difficulty = value;}
		}
		public bool ItemsOn{
			get{return itemsOn;}
			set{itemsOn=value;}
		}
		
		private GameManager ()
		{
			musicVolume = 1.0f;
			soundVolume = 1.0f;
			
			brightness = 0.0f;
			contrast = 0.0f;
			
			difficulty = 1;
			itemsOn = true;
		}
	}
}

