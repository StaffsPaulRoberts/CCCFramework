using System;

using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace StealthOfTomorrow
{
	public class BaseLevel
	{
		//Private variables
		//Platform variables
		private SpriteUV[] platforms = new SpriteUV[3];
		private TextureInfo platformMainTexInfo;
		private TextureInfo platformSideTexInfo;
		
		//Background variables
		private SpriteUV[] background = new SpriteUV[3];
		private TextureInfo[] backgroundTexInfo = new TextureInfo[3];
		
		public Vector2[] StartingPositions;
		
		public BaseLevel (Scene scene)
		{
			//Platform Code
			platformMainTexInfo = new TextureInfo("/Application/Assets/base_Platform_Main.png");
			platformSideTexInfo = new TextureInfo("/Application/Assets/base_Platform_Side.png");
			
			platforms[0] = new SpriteUV(platformMainTexInfo);
			platforms[0].Quad.S = platformMainTexInfo.TextureSizef;
			platforms[0].Position = new Vector2(30.0f, 3.0f);
			
			platforms[1] = new SpriteUV(platformSideTexInfo);
			platforms[1].Quad.S = platformSideTexInfo.TextureSizef;
			platforms[1].Position = new Vector2(-123.0f, 170.0f);
			
			platforms[2] = new SpriteUV(platformSideTexInfo);
			platforms[2].Quad.S = platformSideTexInfo.TextureSizef;
			platforms[2].Position = new Vector2(700.0f, 170.0f);
			
			//Background Code
			backgroundTexInfo[0] = new TextureInfo("/Application/Assets/Backgrounds/base_Layer_Back.png");
			backgroundTexInfo[1] = new TextureInfo("/Application/Assets/Backgrounds/base_Layer_Middle.png");
			backgroundTexInfo[2] = new TextureInfo("/Application/Assets/Backgrounds/base_Layer_Front.png");
			
			background[0] = new SpriteUV(backgroundTexInfo[0]);
			background[0].Quad.S = backgroundTexInfo[0].TextureSizef;
			background[0].Position = new Vector2(0.0f, 0.0f);
			
			background[1] = new SpriteUV(backgroundTexInfo[1]);
			background[1].Quad.S = backgroundTexInfo[1].TextureSizef;
			background[1].Position = new Vector2(0.0f, 0.0f);
			
			background[2] = new SpriteUV(backgroundTexInfo[2]);
			background[2].Quad.S = backgroundTexInfo[2].TextureSizef;
			background[2].Position = new Vector2(0.0f, 0.0f);
			
			scene.AddChild(background[0]);
			scene.AddChild(background[1]);
			scene.AddChild(background[2]);
			
			scene.AddChild(platforms[0]);
			scene.AddChild(platforms[1]);
		    scene.AddChild(platforms[2]);
			
			StartingPositions = new Vector2[4];
			StartingPositions[0] = new Vector2(100, platforms[1].Position.Y + 75);
			StartingPositions[1] = new Vector2(300, platforms[0].Position.Y + 75);
			StartingPositions[2] = new Vector2(660, platforms[0].Position.Y + 75);
			StartingPositions[3] = new Vector2(860, platforms[2].Position.Y + 75);
			
			Console.WriteLine(StartingPositions[0]);
			Console.WriteLine(StartingPositions[1]);
			Console.WriteLine(StartingPositions[2]);
			Console.WriteLine(StartingPositions[3]);
		}
		
		public void Dispose()
		{
			platformMainTexInfo.Dispose();
			platformSideTexInfo.Dispose();
			backgroundTexInfo[0].Dispose();
			backgroundTexInfo[1].Dispose();
			backgroundTexInfo[2].Dispose();
		}
	}
}