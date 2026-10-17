using Godot;
using System;

public abstract class Inimigo : Personagem
{
	public int RecompensaXp { get; protected set; }

	protected Inimigo(string nome, int vida, int ataque, int defesa, int recompensaXp)
		: base(nome, vida, ataque, defesa)
	{
		RecompensaXp = recompensaXp;
	}
}
