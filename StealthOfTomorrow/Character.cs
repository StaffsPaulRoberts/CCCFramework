using System;


using Sce.PlayStation.Core;
using Sce.PlayStation.Core.Graphics;
using Sce.PlayStation.Core.Imaging;
using Sce.PlayStation.Core.Input;

using Sce.PlayStation.HighLevel.GameEngine2D;
using Sce.PlayStation.HighLevel.GameEngine2D.Base;

namespace StealthOfTomorrow
{
	enum AttackType
	{
		highPunch,
		highKick,
		punch,
		kick,
		lowKick,
		lowPunch
	}
	
	public class Character
	{
		private SpriteUV sprite;
		private TextureInfo textureInfo;
		
		private int health;
		private int energy;
		private AttackType attackType;
		
		private GamePadData gamePadData,gamePadData2;
		private bool isJumping;
		
		public Character (Scene scene,string path,int health, int energy)
		{
			
			textureInfo  = new TextureInfo(path);
			sprite = new SpriteUV(textureInfo);
			sprite.Quad.S = textureInfo.TextureSizef;
			sprite.Position = new Vector2(Director.Instance.GL.Context.GetViewport().Width/2,
			                              Director.Instance.GL.Context.GetViewport().Height /2);
			
			sprite.CenterSprite();
			
			isJumping = false;
			//this.health = health;
			//this.energy = energy;
			
			scene.AddChild(sprite);
		}
		
		public void Dispose()
		{
			textureInfo.Dispose();	
		}
		
		public void MovePlayer()
		{
			
		}
		
		public void Attack()
		{
			
		}
		
		public void TakeDamage(int dmg)
		{
			health -= dmg;
			if(health <= 0)
			{
				
			}
		}
		
		public void Update(float deltaTime)
		{
			 gamePadData = GamePad.GetData(0);
			
			int speed = 4;
			
			if((gamePadData.Buttons & GamePadButtons.Left) != 0 )
			{
			
			sprite.Position += new Vector2(-1 * speed,0);
			sprite.Scale = new Vector2(-1,1);	
				
			}
			else if((gamePadData.Buttons & GamePadButtons.Right) != 0)
			{
		
			sprite.Position += new Vector2(1 * speed,0);
				sprite.Scale = new Vector2(1,1);	
			}
			else if((gamePadData.Buttons & GamePadButtons.Up) != 0)
			{
				
			sprite.Position += new Vector2(0,1 * speed);	
			}
			else if((gamePadData.Buttons & GamePadButtons.Down) != 0)
			{
				
			sprite.Position += new Vector2(0,-1 * speed);	
			}
			
			if(!isJumping)
			{
				//if((gamePadData.Buttons & GamePadButtons.Cross) != 0 && Input2.GamePad0.Cross.)		
				if(Input2.GamePad0.Cross.Press)
				{
					isJumping = true;
					//Console.WriteLine("isJumping = " + isJumping.ToString());/
					Console.WriteLine("Jumped");
					
				}
				
			}
			
			if(Input2.GamePad0.Cross.Release)
			{
				isJumping = false;
				if(isJumping)
					Console.WriteLine("Not Jumped");
			}
//			
			
			
		}
		
		
	}
}

