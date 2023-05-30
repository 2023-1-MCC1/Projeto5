using Godot;
using System;

public partial class player : Node2D
{
	public PackedScene gameover = GD.Load<PackedScene>("res://scenes/gameover.tscn");
	public double saude, estresse, sono, atk, nivelDeEstresse, dinheiro;
	public double saudeOriginal , estresseOriginal , atkOriginal;

	public int powerup1, powerup2, powerup3;
	public inimigo inimigo;
	public NodePath caminho;	
	public background menu;	
	public int vezes;

	public void PowerUp1Regen()
	{
		if (this.saude < 100)
		{
			this.saude = this.saude + (this.powerup1 * 1);
		}
		if (this.estresse > 0)
		{
			this.estresse = this.estresse - (this.powerup1 * 1 );
		}	
	}
	public void PowerUp2AumentarAtaque()
	{
		this.atk = this.atkOriginal + (this.powerup2 * 2);
	}
	
	public void PowerUp3DanoPassivo(inimigo inimigo)
	{
		inimigo.vida = inimigo.vida - (this.powerup3 * 1);
		if (inimigo.vida <= 0)
			{
				GD.Print("O inimigo morreu!");
				this.dinheiro += inimigo.recompensa;
				GD.Print("Você recebeu " + inimigo.recompensa);
				inimigo.redefinirVidaERecompensa();
			}
	}
	//trabalhar faz o progresso do trabalho e o estresse subir 
	public void trabalhar(inimigo inimigo)
	{
		inimigo.vida = inimigo.vida - this.atk;
			if (inimigo.vida <= 0)
			{
				GD.Print("O inimigo morreu!");
				this.dinheiro += inimigo.recompensa;
				GD.Print("Você recebeu " + inimigo.recompensa);
				inimigo.redefinirVidaERecompensa();
			}
			else
			{
				GD.Print("A vida do inimigo foi para " + inimigo.Get("vida"));						
			}		
		this.estresse = this.estresse + nivelDeEstresse;		
	}
	
	public override void _Ready()
	{	
		inimigo inimigo = this.GetParent().GetNode<inimigo>("Inimigo");		
		vezes = 0;
		powerup1 = 0;
		powerup2 = 0;
		powerup3 = 0;
		saudeOriginal = 100.0;
		saude = saudeOriginal;
		estresseOriginal = 0.0;
		estresse = estresseOriginal;
		sono = 0.0;
		atkOriginal = 10.0;
		atk = atkOriginal;
		nivelDeEstresse = 2.0;
		dinheiro = 0;
		// trabalhar(this.GetNode<inimigo>("Sprite2D"));
	}
	public override void _Process(double delta)
	{	
		
		if(this.saude <= 0 && vezes<1)	
		{			
			var instance = gameover.Instantiate();			
			GetParent().AddChild(instance);	
			vezes++;	
		}

	}	

}
