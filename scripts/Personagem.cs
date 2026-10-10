using Godot;
using System;

public partial class Personagem
{
	public string Nome;
	public int Vida;
	public int Ataque;
	public int Defesa;
	
	public string ObterStatus()
	{
		return $"Nome: {Nome}\n vida: {Vida}\n Ataque: {Ataque}\n Defesa: {Defesa}";
	}
}
