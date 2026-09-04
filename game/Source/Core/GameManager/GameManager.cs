using Godot;
using SnapBattle.Source.Maps;

namespace SnapBattle.Source.Core.GameManager;

[GlobalClass]
public partial class GameManager: Node
{
    [Export] public GameState DefaultGameState { get; set; } = GameState.MainMenu;
    [Export] public PackedScene MainMenu { get; set; }
    [Export] public PackedScene QuickPlay { get; set; }
    
    private GameState CurrentGameState { get; set; }
    private Node CurrentScene { get; set; }

    public override void _Ready()
    {
        PackedScene defaultScene = GetSceneFromState(DefaultGameState);
        var sceneNode = defaultScene.Instantiate<MainMenu>();
        AddChild(sceneNode);
        
        sceneNode.ChangeGameState += ChangeGameState;
        CurrentScene = sceneNode;
        CurrentGameState = DefaultGameState;
    }

    public override void _ExitTree()
    {
        if (CurrentScene is MainMenu mainMenuScene)
        {
            mainMenuScene.ChangeGameState -= ChangeGameState;
            return;
        }
    }

    private PackedScene GetSceneFromState(GameState gameState)
    {
        return gameState switch
        {
            GameState.QuickPlay => QuickPlay,
            _ => MainMenu
        };
    }

    private void ChangeGameState(GameState gameState)
    {
        RemoveChild(CurrentScene);
        PackedScene defaultScene = GetSceneFromState(gameState);

        switch (gameState)
        {
            case GameState.QuickPlay:
            {
                var sceneNode = defaultScene.Instantiate<QuickPlay>();
                AddChild(sceneNode);
                CurrentScene = sceneNode;
                break;
            }
            default:
            {
                var sceneNode = defaultScene.Instantiate<MainMenu>();
                AddChild(sceneNode);
                sceneNode.ChangeGameState += ChangeGameState;
                CurrentScene = sceneNode;
                break;
            }
        }
        CurrentGameState = gameState;
    }
}