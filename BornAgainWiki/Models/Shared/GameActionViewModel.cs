using Ronin.Model.Definitions;
using Ronin.Model.GameActions;

namespace BornAgainWiki.Models.Shared
{
	public sealed class GameActionViewModel
	{
		public GameActionViewModel(IEnumerable<GameAction>? actions,
			ObjectDefinition? definition,
			bool onHit,
			bool constant,
			float scalar)
		{
			Actions = actions;
			Definition = definition;
			OnHit = onHit;
			Constant = constant;
			Scalar = scalar;
		}

		public IEnumerable<GameAction>? Actions { get; }
		public ObjectDefinition? Definition { get; }
		public bool OnHit { get; }
		public bool Constant { get; }
		public float Scalar { get; }
	}
}
