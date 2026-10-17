using Godot;
using System;

public partial class CyberGumba : Inimigo
{
	public CyberGumba(): base("Cyber Gumba", 50, 15, 20, 100){}
	public override string Atacar()
	{
		return $"{Nome} dispara um pulso de energia!";
	}
}
