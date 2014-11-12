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
		//private SpriteUV sprite;
		private AnimatedSprite sprite;
		private TextureInfo textureInfo;
		
		private int lives;
		private int health;
		private int energy;
		private int jumpHeight;
		private AttackType attackType;
		
		private GamePadData gamePadData,gamePadData2;
		private bool isJumping;
		Vector2 origPos,jumpForce;
		
		private bool isFalling = false;
		public int Health{get {return this.health;}}
		public int Energy{get {return this.energy;}}
		public int Lives{get { return this.lives;}}
		
		
		public Character (Scene scene,AnimatedSprite animSprite,int lives,int health, int energy)
		{
			
//			textureInfo  = new TextureInfo(path);
//			sprite = new SpriteUV(textureInfo);
//			sprite.Quad.S = textureInfo.TextureSizef;
//			sprite.Position = new Vector2(Director.Instance.GL.Context.GetViewport().Width/2,
//			                              Director.Instance.GL.Context.GetViewport().Height /2);
//			
//			sprite.Pivot 	= new Vector2(0.5f,1.0f);
//			sprite.CenterSprite(TRS.Local.BottomCenter);
			this.sprite = animSprite;
			this.sprite.position = new Vector2(450,250);
			isJumping = false;
			this.jumpHeight = 40;
			this.health = health;
			this.energy = energy;
			this.lives = lives;
			//this.health = health;
			//this.energy = energy;
			
			//scene.AddChild(sprite);
		}
		
		public void Dispose()
		{
			textureInfo.Dispose();	
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
			
			Move(deltaTime);
			
			
			if(isJumping)
			{
				
				if(!isFalling)
				{
					if(sprite.position.Y - origPos.Y < 220)//jumpheight//220)
					{
						sprite.position = new Vector2(sprite.position.X + jumpForce.X, sprite.position.Y + jumpForce.Y);
						Console.WriteLine(sprite.position);
					}
					else
						isFalling = true;
				}
				
				
				else if(isFalling)
				{
					if(sprite.position.Y > origPos.Y)
					{
						 sprite.position = new Vector2(sprite.position.X + jumpForce.X, sprite.position.Y - jumpForce.Y);
					}
					else
					{
						sprite.position = new Vector2(sprite.position.X, origPos.Y);
						Console.WriteLine(sprite.position);
						isJumping = false;
						isFalling = false;
					}
				}
			}
			

		}
		
		private void Move(float deltaTime)
		{
			int speed = 200;
			
			if(!isJumping)
			{
				if((gamePadData.Buttons & GamePadButtons.Left) != 0 && (gamePadData.Buttons & GamePadButtons.Up) != 0)
				{
					Jump("Left",deltaTime,speed);
				}
				else if((gamePadData.Buttons & GamePadButtons.Right) != 0 && (gamePadData.Buttons & GamePadButtons.Up) != 0)
				{
					Jump("Right",deltaTime,speed);
				}
				
				else if((gamePadData.Buttons & GamePadButtons.Left) != 0 )
				{
				
				sprite.position += new Vector2(-1 * speed * deltaTime,0);
				//sprite.Scale = new Vector2(-1,1);	
					
				}
				else if((gamePadData.Buttons & GamePadButtons.Right) != 0)
				{
			
				sprite.position += new Vector2(1 * speed * deltaTime,0);
					//sprite.Scale = new Vector2(1,1);	
				}
				else if((gamePadData.Buttons & GamePadButtons.Up) != 0)
				{
					
				sprite.position += new Vector2(0,1 * speed * deltaTime);	
				}
				else if((gamePadData.Buttons & GamePadButtons.Down) != 0)
				{
					
				sprite.position += new Vector2(0,-1 * speed * deltaTime);	
				}
			}
			
		}
		
		private void Jump(string dir,float deltaTime,int speed)
		{
			
			
			if(!this.isJumping)
			{
				this.isJumping = true;
				this.origPos = sprite.position;
				switch (dir) 
				{
				case "Left":
					jumpForce = new Vector2(-1 * speed * deltaTime , 2 * speed * deltaTime);
					
					break;
				case "Right":
					jumpForce = new Vector2(1 * speed * deltaTime , 2 * speed * deltaTime);
					break;
				default:
					break;
				}
			}
		}
		
		
	}
}

