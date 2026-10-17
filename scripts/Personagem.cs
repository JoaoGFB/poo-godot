using Godot;
using System;

public abstract class Personagem
{
	public string Nome {get; private set; }
	public int Vida {get; private set; }
	public int VidaMaxima {get; private set; }
	public int Ataque {get; private set; }
	public int Defesa {get; private set; }
	
	protected Personagem(string nome, int vida, int ataque, int defesa)
	{
		Nome = nome;
		Vida = vida;
		VidaMaxima = vida;
		Ataque = ataque;
		Defesa = defesa;
	}
	
	public int ReceberDano(int dano)
	{
		int vidaAntes = Vida;
		Vida -= dano;
		if (Vida < 0)
			Vida = 0;
		return vidaAntes - Vida;
	}

	public void Curar(int quantidade)
	{
		Vida += quantidade;
		if (Vida > VidaMaxima)
			Vida = VidaMaxima;
	}

	public bool EstaVivo()
	{
		return Vida > 0;
	}

	public abstract string Atacar();
	
	public string ObterStatus()
	{
		return $"Nome: {Nome}\n vida: {VidaMaxima}\n Ataque: {Ataque}\n Defesa: {Defesa}";
	}
}
