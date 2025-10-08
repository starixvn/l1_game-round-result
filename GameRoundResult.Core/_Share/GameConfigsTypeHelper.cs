
using GameRoundResult.Core.Constants;

namespace GameRoundResult.Web._Shared
{
    public static class GameConfigsTypeHelper
    {
        public static bool IsCrashTurn(byte gameConfigsType)
        {
            return gameConfigsType == (byte)GameConfigsType.Crash ||
                   gameConfigsType == (byte)GameConfigsType.CrashTurnBase ||
                   gameConfigsType == (byte)GameConfigsType.FixedStepsCrashTurnBase;
        }

        public static bool IsCrashTurn(GameConfigsType gameConfigsType)
        {
            return gameConfigsType == GameConfigsType.CrashTurnBase ||
                   gameConfigsType == GameConfigsType.FixedStepsCrashTurnBase;
        }
    }
}
