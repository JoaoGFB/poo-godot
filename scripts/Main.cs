using Godot;
using System;
using System.Collections.Generic;
public partial class Main : Control
{
	private Label labelJogador, labelInimigo, labelXp;
	private ProgressBar barraJogador, barraInimigo;
	private RichTextLabel log;
	private OptionButton seletorTipo;
	private Button botaoIniciar, botaoAtacar, botaoDefender, botaoItem, botaoHabilidade;
	
	public override void _Ready()
	{
		labelJogador = GetNode<Label>("%LabelJogador");
		labelInimigo = GetNode<Label>("%LabelInimigo");
		labelXp = GetNode<Label>("%LabelXp");
		barraJogador = GetNode<ProgressBar>("%BarraJogador");
		barraInimigo = GetNode<ProgressBar>("%BarraInimigo");
		log = GetNode<RichTextLabel>("%Log");
		seletorTipo = GetNode<OptionButton>("%SeletorTipo");
		botaoIniciar = GetNode<Button>("%BotaoIniciar");
		botaoAtacar = GetNode<Button>("%BotaoAtacar");
		botaoDefender = GetNode<Button>("%BotaoDefender");
		botaoItem = GetNode<Button>("%BotaoItem");
		botaoHabilidade = GetNode<Button>("%BotaoHabilidade");
		
		seletorTipo.AddItem("Unidade de Combate");
		seletorTipo.AddItem("Unidade de Suporte");
		
		botaoIniciar.Pressed += OnIniciar;
		botaoAtacar.Pressed += OnAtacar;
		botaoDefender.Pressed += OnDefender;
		botaoItem.Pressed += OnItem;
		botaoHabilidade.Pressed += OnHabilidade;
		
	}
	
	private Personagem jogador;
	private Inimigo inimigo;
	private bool turnoJogador = true;
	private void OnAtacar()
	{
		if (!turnoJogador || jogador == null || !jogador.EstaVivo() || !inimigo.EstaVivo())
			return;

		Escrever(jogador.Atacar());
		int dano = inimigo.ReceberDano(jogador.Ataque);
		Escrever($"{inimigo.Nome} sofreu {dano} de dano.");

		FinalizarTurnoJogador();
	}

	private void FinalizarTurnoJogador()
	{
		turnoJogador = false;
		AtualizarInterface();

		if (inimigo.EstaVivo())
			TurnoInimigo();
		else
			VerificarFimDeBatalha();
	}

	private void TurnoInimigo()
	{
		Escrever(inimigo.Atacar());

		int dano = jogador.ReceberDano(inimigo.Ataque);
		Escrever($"{jogador.Nome} sofreu {dano} de dano.");

		turnoJogador = true;
		AtualizarInterface();
		VerificarFimDeBatalha();
	}
	
	private void OnDefender(){}
	private void OnItem(){}
	private void OnHabilidade(){}
	
	private void OnIniciar()
	{
		if (seletorTipo.Selected == 0)
			jogador = new UnidadeCombate();
		else
			jogador = new UnidadeSuporte();

		Escrever($"{jogador.Nome} entrou na batalha!");
		AtualizarInterface();
		inimigo = new CyberGumba();
		Escrever($"{inimigo.Nome} Apareceu");
	}

	private void AtualizarInterface()
	{
		if (jogador != null)
		{
			labelJogador.Text   = $"JOGADOR   {jogador.Nome}   ATK {jogador.Ataque}   DEF {jogador.Defesa}";
			barraJogador.MaxValue = jogador.VidaMaxima;
			barraJogador.Value    = jogador.Vida;
		}
		if (inimigo != null)
		{
			labelInimigo.Text   = $"INIMIGO   {inimigo.Nome}   ATK {inimigo.Ataque}   DEF {inimigo.Defesa}";
			barraInimigo.MaxValue = inimigo.VidaMaxima;
			barraInimigo.Value    = inimigo.Vida;
		}
	}

	private void Escrever(string mensagem)
	{
		log.AppendText(mensagem + "\n");
	}
	
}
