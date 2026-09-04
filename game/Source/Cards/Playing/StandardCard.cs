using Godot;
using SnapBattle.Source.Core.Cards;

namespace SnapBattle.Source.Cards.Playing;

[GlobalClass]
public partial class StandardCard: CardBase
{
    [Export] public string Label { get; set; } = string.Empty;
    [Export] public Label BigIcon { get; set; }
    [Export] public Label TopRightNumber { get; set; }
    [Export] public Label BottomLeftNumber { get; set; }
    [Export] public Color Color { get; set; } = Colors.Black;

    public override void _Ready()
    {
        BigIcon?.Text = Label;
        BigIcon?.LabelSettings?.FontColor = Color;
        TopRightNumber?.Text = Label;
        TopRightNumber?.LabelSettings?.FontColor = Color;
        BottomLeftNumber?.Text = Label;
        BottomLeftNumber?.LabelSettings?.FontColor = Color;
    }
}