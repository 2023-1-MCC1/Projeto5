using Godot;
using System;

public partial class status : Control
{
	// Called when the node enters the scene tree for the first time.
	public double vida, estresse,sono,dinheiro, aumento;
	public player gato;
	public background tela;
	public RichTextLabel  menuEstresse, menuSono, menuDinheiro, menuNumeroDaFase,menuSaude;	
	public inimigo enemy;

	public void atualizarMenu()
	{
		enemy = this.GetParent().GetNode<inimigo>("Inimigo");		
		tela = this.GetParent<background>();
		RichTextLabel menuNumeroDaFase = this.GetNode<RichTextLabel>("FaseEInimigo/NumeroDaFase");
		RichTextLabel menuSaude = this.GetNode<RichTextLabel>("VidaGato/vidaGato");
		RichTextLabel menuEstresse = this.GetNode<RichTextLabel>("boxEstresse/Estresse");
		RichTextLabel menuSono = this.GetNode<RichTextLabel>("boxSono/Sono");
		RichTextLabel menuDinheiro = this.GetNode<RichTextLabel>("boxDinheiro/Dinheiro");
		vida = gato.saude;
		estresse = gato.estresse;
		sono = gato.sono;
		dinheiro = gato.dinheiro;

		enemy.barraDeVidaInimigoTexto.Text = "[center]" + Math.Round(enemy.vida,2) + "/ " + Math.Round(enemy.vidaMaxima,2) + "[/center]";		
		enemy.barraDeVidaInimigo.Value = enemy.vida;
		this.GetNode<TextureProgressBar>("VidaGato").Value = vida;
		menuNumeroDaFase.Text = "[center]" + enemy.fase + "-" + (enemy.idInimigo + 1) + "[/center]";
		menuSaude.Text = "[center]" + vida + "/100 [/center]";
		menuEstresse.Text =  estresse.ToString();
		menuSono.Text = sono.ToString();
		menuDinheiro.Text = dinheiro.ToString();
	}

	
	public override void _Ready()
	{
		

		aumento = 0.0;		
		gato = this.GetParent().GetNode<player>("player");
		vida = gato.saude;
		estresse = gato.estresse;
		sono = gato.sono;
		dinheiro = gato.dinheiro;		

		
		// RichTextLabel menuSaude = this.GetNode<RichTextLabel>("boxSaúde/Saúde");
		RichTextLabel menuEstresse = this.GetNode<RichTextLabel>("boxEstresse/Estresse");
		RichTextLabel menuSono = this.GetNode<RichTextLabel>("boxSono/Sono");
		RichTextLabel menuDinheiro = this.GetNode<RichTextLabel>("boxDinheiro/Dinheiro");

		// menuSaude.Text = "Vida: " + vida;
		menuEstresse.Text = "Estresse: " + estresse;
		menuSono.Text = "Sono: " + sono;
		menuDinheiro.Text = dinheiro.ToString();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{		
	}	
}

