
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web._Shared
{
    public class GameConfigsTypeHelper
    {
        public static bool IsCrashTurn(byte gameConfigsType)
        {
            return gameConfigsType == (byte)GameConfigsType.Crash ||
                   gameConfigsType == (byte)GameConfigsType.CrashTurnBase ||
                   gameConfigsType == (byte)GameConfigsType.FixedStepsCrashTurnBase;
        }
    }
}
