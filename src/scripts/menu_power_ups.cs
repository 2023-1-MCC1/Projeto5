using Godot;
using System;

public partial class menu_power_ups : Control
{
	public player gato;
	public Label lblPowerUp1, lblPowerUp2, lblPowerUp3, lblCons1,lblCons2,lblCons3;
	public RichTextLabel descPU1, descPU2, descPU3;
	public timer timer;
	public status menu;
	public int lvlpowerup1, lvlpowerup2, lvlpowerup3;
	public double preco1, preco2, preco3, preco4, preco5, preco6;


	public void atualizarNivelPowerUP(player gato)	
	{
		RichTextLabel textoPU1 = this.GetNode("PowerUP1").GetNode<RichTextLabel>("LvlPU1");
		RichTextLabel textoPU2 = this.GetNode("PowerUP2").GetNode<RichTextLabel>("LvlPU2");
		RichTextLabel textoPU3 = this.GetNode("PowerUP3").GetNode<RichTextLabel>("LvlPU3");
		textoPU1.Text = "Lvl: " + gato.powerup1;		
		textoPU2.Text = "Lvl: " + gato.powerup2;
		textoPU3.Text = "Lvl: " + gato.powerup3;
	}
	public void atualizarPreco()
	{
		lblPowerUp1.Text = "$ " + preco1;
		lblPowerUp2.Text = "$ " + preco2;
		lblPowerUp3.Text = "$ " + preco3;
	}
	public void aumentarPreco(string preco)
	{		
		double valor = this.Get(preco).As<double>() ;
		valor = Math.Round((valor * 1.2));
		this.Set(preco,valor);
	}
	public bool verificaDinheiro(player gato, double preco)
	{
		bool temDinheiro = false;
		if (gato.dinheiro >= preco)
		{
			temDinheiro = true;
		}
		return temDinheiro;
	}
	public void adicionarNivelPowerUP(player gato,string powerup,double preco)
	{
		int lvl = gato.Get(powerup).As<int>();
		lvl = lvl +1;		
		gato.Set(powerup,lvl);
		gato.dinheiro -= preco;
	}
	public void cliqueNoPowerup(player gato,string powerup,string preco)
	{		
		double valor = this.Get(preco).As<double>();		
		if (verificaDinheiro(gato,valor))
		{			
			adicionarNivelPowerUP(gato,powerup,valor);						
			atualizarNivelPowerUP(gato);
			aumentarPreco(preco);			
			menu.atualizarMenu();	
		}
		this.atualizarPreco();

	}
	public override void _Ready()
	{		
		lblPowerUp1 = this.GetNode("PowerUP1").GetNode<Label>("Label");
		lblPowerUp2 = this.GetNode("PowerUP2").GetNode<Label>("Label");
		lblPowerUp3 = this.GetNode("PowerUP3").GetNode<Label>("Label");
		lblCons1 = this.GetNode<Label>("Consumível1/Label");
		lblCons2 = this.GetNode<Label>("Consumível2/Label");
		lblCons3 = this.GetNode<Label>("Consumível3/Label");
		timer = this.GetParent().GetNode<timer>("Timer");
		menu = this.GetParent().GetNode<status>("Status");
		gato = this.GetParent().GetNode<player>("player");
		this.atualizarNivelPowerUP(gato);		
		preco1 = 15;
		preco2 = 20;
		preco3 = 25;
		preco4 = 15;
		preco5 = 20;
		preco6 = 20;
		lblCons1.Text = "-$" + preco4;
		lblCons2.Text = "-$" + preco5;
		lblCons3.Text = "-$" + preco6;
		this.atualizarPreco();	
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	private void _on_button_pu_1_pressed()
	{
		descPU1 = this.GetNode<RichTextLabel>("PowerUP1");
		cliqueNoPowerup(gato,"powerup1","preco1");
		descPU1.Text = "[b]Yoga[/b]\n-" + gato.powerup1 * 1 +" estresse/s";

	}
	private void _on_button_pu_2_pressed()
	{
		descPU2 = this.GetNode<RichTextLabel>("PowerUP2");
		
		if(verificaDinheiro(gato,this.preco2))
		{
			cliqueNoPowerup(gato,"powerup2","preco2");
			gato.PowerUp2AumentarAtaque();
			descPU2.Text = "[b]Produtividade[/b]\n+" + gato.powerup2 * 2 + " ataque";
		}				
	}
	private void _on_button_pu_3_pressed()
	{
		descPU3 = this.GetNode<RichTextLabel>("PowerUP3");
		if(verificaDinheiro(gato,this.preco3))
		{

		cliqueNoPowerup(gato,"powerup3","preco3");
		descPU3.Text = "[b]ChatGPT[/b]\n+" + gato.powerup3 * 1 + " dano/s";

		}
		
	}

	private void _on_button_cons_1_pressed()
	{		
		if (verificaDinheiro(gato,preco4))
		{
			if (gato.sono >=5)
			{
			gato.dinheiro = gato.dinheiro - preco4;
			gato.sono = gato.sono - 5;
			menu.atualizarMenu();	
			}
		}
	}
	private void _on_button_cons_2_pressed()
	{
		if (verificaDinheiro(gato,preco5))
		{
			if (gato.saude < 95)
			{
			gato.dinheiro = gato.dinheiro - preco5;
			gato.saude = gato.saude + 5;
			menu.atualizarMenu();
			}
		}
	}
	private void _on_button_cons_3_pressed()
	{
		if (verificaDinheiro(gato,preco6))
		{
			if (gato.estresse > 10)
			{
			gato.dinheiro = gato.dinheiro - preco6;
			gato.estresse = gato.estresse - 10;
			for(int contagem = 0;contagem < 6;contagem++)
			{
				timer.contarHoras();
			}
			menu.atualizarMenu();
			}
		}
	}
}
