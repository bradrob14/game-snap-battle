using Godot;
using SnapBattle.Source.Core.GameManager;

namespace SnapBattle.Source.Maps;

[GlobalClass]
public partial class MainMenu: Control
{
    [Signal] public delegate void ChangeGameStateEventHandler(GameState gameState);
    
    [Export] public Button QuickPlay { get; set; }

    public override void _Ready()
    {
        QuickPlay?.Pressed += QuickPlayOnButtonDown;
    }

    public override void _ExitTree()
    {
        QuickPlay?.Pressed -= QuickPlayOnButtonDown;
    }

    private void QuickPlayOnButtonDown()
    {
        EmitSignalChangeGameState(GameState.QuickPlay);
    }
}