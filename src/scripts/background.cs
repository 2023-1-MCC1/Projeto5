using Godot;
using System;

public partial class background : Node2D
{
	PackedScene enemy = GD.Load<PackedScene>("res://scenes/inimigo.tscn");
	public menu_power_ups powerUpsMenu;
	public Timer temporizador;
	public status menu;
	public Node instance;
	public NodePath caminho;
	public bool mouseDentro;
	public player gato;
	public inimigo inimigo;
	public Vector2 posicaoSpawnInimigo = new Vector2(220,135);
	public double vidaMaximaInimigo = 100;		
	public override void _Ready()
	{
		temporizador = this.GetNode("Timer").GetNode<Timer>("Timer");
		gato = this.GetNode<player>("player");
		menu = this.GetNode<status>("Status");
		powerUpsMenu = this.GetNode<menu_power_ups>("menuPowerUps");
		inimigo = this.GetNode<inimigo>("Inimigo");
		
		
		menu.atualizarMenu();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("clique_esquerdo") && mouseDentro)
		{	
			gato.trabalhar(inimigo);
			menu.atualizarMenu();
		}
	}

	public void _on_area_de_click_mouse_entered()
	{
		mouseDentro = true;
	}

	public void _on_area_de_click_mouse_exited()
	{
		mouseDentro = false;
	}
}
