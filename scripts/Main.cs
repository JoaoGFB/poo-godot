using Godot;
using System;

public partial class Main : Node
{
	[Export] public string NomeEntrada = "JoãoG";
	[Export] public int VidaEntrada = 100;
	[Export] public int AtaqueEntrada = 20;
	[Export] public int DefesaEntrada = 10;
	
	public override void _Ready()
	{
		GD.Print("		BATALHA CIBERNÉTICA		");
		Personagem jogador = new Personagem(NomeEntrada, VidaEntrada, AtaqueEntrada, DefesaEntrada);
		GD.Print(jogador.ObterStatus());
	}
}
