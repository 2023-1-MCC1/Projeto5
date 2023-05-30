using Godot;
using System;

public partial class timer : Node2D
{
	background tela;
	public status status;
	public player gato;
	private Timer relogio;
	public Label lblTempo;
	public inimigo inimigo;
	public int minutos, horas,equivalencia;
	double penalidade, calma;
	private TextureProgressBar barraDeProgresso;

	// Called when the node enters the scene tree for the first time.

	public void contarHoras()
	{
		Label lblTempo = GetNode<Label>("Label");
		this.minutos = this.minutos + 5;

		if(this.minutos == 60)
		{
			this.horas++;
			this.minutos = 0;
		}
		if(this.horas == 24)
		{
			this.horas = 0;
		}

		lblTempo.Text = this.horas.ToString("D2") + ": " + this.minutos.ToString("D2");
		
	}
	public void verificarEstresse()

	{
		if (gato.estresse > 70)
		{
			gato.saude = gato.saude - penalidade;
			barraDeProgresso.Value = gato.saude;	
		}
		if (gato.estresse >= calma)
		{
			if(gato.estresse - calma > 0)
			{
				gato.estresse = gato.estresse - calma;
			}			
			else
			{
				gato.estresse = 0;
			}
		}
		
	}
	public void aumentaSonoEVerifica()
	{
		if(gato.sono < 100)
		{		
			gato.sono = gato.sono + 1;
		}
		if(gato.sono > 70 && gato.sono < 90)
		{
			gato.estresse = gato.estresse + 4;
		}
		else if(gato.sono >= 90)
		{
			gato.estresse = gato.estresse + 10;
		}
	}
	public override void _Ready()
	{
		background tela = this.GetParent<background>();		
		status = this.GetParent().GetNode<status>("Status");
		barraDeProgresso = status.GetNode<TextureProgressBar>("VidaGato");		
		gato = this.GetParent().GetNode<player>("player");
		Label lblTempo = GetNode<Label>("Label");
		Timer relogio = this.GetNode<Timer>("Timer");	
		inimigo = this.GetParent().GetNode<inimigo>("Inimigo");	
		minutos = 30;
		horas = 7;
		penalidade = 5.0;
		calma = 2.0;
		lblTempo.Text = this.horas.ToString("D2") + ": " +minutos.ToString("D2");		
		relogio.Start(2.0);		
		GD.Print(gato.saude);
		barraDeProgresso.MaxValue = gato.saude;
		barraDeProgresso.Value = gato.saude;		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{		
	}
	public void _on_timer_timeout()
	{
		contarHoras();
		aumentaSonoEVerifica();
		gato.PowerUp1Regen();
		verificarEstresse();		
		gato.PowerUp3DanoPassivo(inimigo);
		status.atualizarMenu();

	}
}
