using Godot;
using System;

public partial class player : Node2D
{
	public PackedScene gameover = GD.Load<PackedScene>("res://scenes/gameover.tscn");
	public PackedScene marcadorDeDano = GD.Load<PackedScene>("res://scenes/marcador_de_dano.tscn");

	public PackedScene clique = GD.Load<PackedScene>("res://scenes/clique.tscn");


	public double saude, estresse, sono, atk, nivelDeEstresse, dinheiro;
	public double saudeOriginal , estresseOriginal , atkOriginal;
	public Vector2 posicaoJogador,posicaoInimigo;	
	public int powerup1, powerup2, powerup3;
	public inimigo inimigo;
	public NodePath caminho;	
	public background menu;	
	public Sprite2D spriteDoGato;
	public int vezes;
	public Tween shake;	
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
		
		shake = spriteDoGato.CreateTween();

		shake.TweenProperty(this,"global_position",posicaoJogador + new Vector2(63,-42), 0.05f);
		shake.TweenProperty(this,"global_position",posicaoJogador, 0.05f);
		shake.SetParallel(true);
		shake.TweenProperty(inimigo.spriteInimigo,"global_position",posicaoInimigo + new Vector2(38,0), 0.05f);		
		shake.SetParallel(false);
		shake.TweenProperty(inimigo.spriteInimigo,"global_position",posicaoInimigo + new Vector2(-12,0), 0.05f);
		shake.TweenProperty(inimigo.spriteInimigo,"global_position",posicaoInimigo, 0.05f);

		
		
		Node dano = marcadorDeDano.Instantiate();
		Node respostaClique = clique.Instantiate();


		GetParent().AddChild(dano);
		Label textoDano = GetParent().GetChild<Label>(-1);
		GetParent().AddChild(respostaClique);		
		Node2D resposta = GetParent().GetChild<Node2D>(-1);

		textoDano.Position = new Vector2(300.0f, 125.0f);
		resposta.Position = GetGlobalMousePosition();

		shake.SetParallel(true);
		shake.TweenProperty(textoDano,"position",new Vector2(300.0f, 135.0f), 0.05f);
		shake.SetParallel(false);
		shake.TweenProperty(textoDano,"position",new Vector2(300.0f, 130.0f), 0.05f);
		shake.TweenProperty(textoDano,"modulate:a", 0 , 0.05f);
		shake.TweenCallback(Callable.From(dano.QueueFree));
		shake.TweenCallback(Callable.From(respostaClique.QueueFree));
		inimigo.vida = inimigo.vida - this.atk;
			if (inimigo.vida <= 0)
			{				
				this.dinheiro += inimigo.recompensa;				
				inimigo.redefinirVidaERecompensa();
			}
			else
			{
										
			}		
		this.estresse = this.estresse + nivelDeEstresse;		
	}
	
	public override void _Ready()
	{	
		posicaoJogador = this.GlobalPosition;	
		inimigo inimigo = this.GetParent().GetNode<inimigo>("Inimigo");
		posicaoInimigo = inimigo.GetNode<Sprite2D>("Sprite2D").GlobalPosition;		
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
		spriteDoGato = this.GetNode<Sprite2D>("Sprite2D");
		
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