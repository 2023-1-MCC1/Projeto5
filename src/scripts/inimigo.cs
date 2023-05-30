using Godot;
using System;

public partial class inimigo : Node2D
{
	public double  vida, recompensa, recompensaInicial,  vidaMaxima, vidaInicial;
	public int idInimigo,lvlInimigo,fase;	
	public RichTextLabel menuVidaInimigo;
	public background tela;
	public status menu;
	public player gato;
	public TextureProgressBar barraDeVidaInimigo;
	public RichTextLabel barraDeVidaInimigoTexto;
	public timer timer;
	public Godot.Collections.Array<string> sprites ;
	public Godot.Collections.Array<int>  ordemDeLvl ;
	public Sprite2D spriteInimigo;
	
	// Called when the node enters the scene tree for the first time.

	public void redefinirVidaERecompensa()
	{	
		if (lvlInimigo +1 >= ordemDeLvl.Count)
		{
			lvlInimigo = 0;

			fase++;
		}

		if(idInimigo + 1 >= sprites.Count)
		{
			idInimigo = 0;
		}
		else
		{
			this.idInimigo++;
		}

		this.lvlInimigo++;
		this.vidaMaxima = vidaInicial + (fase* (ordemDeLvl[lvlInimigo] * 0.2) * vidaInicial);
		this.vida = this.vidaMaxima;
		this.recompensa = Math.Round(fase * (this.recompensaInicial + (ordemDeLvl[lvlInimigo] * 0.2) * this.recompensaInicial ));
		barraDeVidaInimigo.MaxValue = Math.Round(this.vidaMaxima);
		barraDeVidaInimigo.Value = Math.Round(this.vidaMaxima);

		this.spriteInimigo.Texture = GD.Load<Texture2D>(sprites[idInimigo]);
		
	}
	public override void _Ready()
		{
		
		ordemDeLvl = new Godot.Collections.Array<int>
		{
			1,2,3,4,7,5,6,7,8,10
		};
		sprites = new Godot.Collections.Array<string>
		{ 
			"res://sprites/prancheta2.png",
			"res://sprites/planilha excel.png",
			"res://sprites/monitor.png",
			"res://sprites/livro.png",
			"res://sprites/miniboss2.png"

		};

		// ordemDeLvl = new Godot.Collections.Array<string>(1);

		spriteInimigo = this.GetNode<Sprite2D>("Sprite2D");
		menu = GetParent().GetNode<status>("Status");
		menuVidaInimigo = menu.GetNode<RichTextLabel>("boxVidaInimigo/vidaInimigo");
		gato = GetParent().GetNode<player>("player");
		tela = GetParent<background>();	
		barraDeVidaInimigo = this.GetNode<TextureProgressBar>("TextureProgressBar");
		barraDeVidaInimigoTexto = barraDeVidaInimigo.GetNode<RichTextLabel>("RichTextLabel");

		fase = 1;
		vidaMaxima = 10;
		vidaInicial = 10;
		recompensaInicial = 50;
		recompensa = recompensaInicial;
		lvlInimigo = 0;
		idInimigo = 0;		
		vida = vidaMaxima;
		spriteInimigo.Texture = GD.Load<Texture2D>(sprites[idInimigo]);		
		barraDeVidaInimigo.MaxValue = this.vidaMaxima;

		menu.atualizarMenu();
		
	}
	public override void _Process(double delta)
	{
	}	
	
}
