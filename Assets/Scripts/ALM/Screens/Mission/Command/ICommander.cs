using System;

namespace ALM.Screens.Mission
{
    public interface Commander<T>
        where T : struct
    {
        Action<T> Executor { get; }
    }

    public static class ICommanderExtensions
    {
        public static Commander<T> ToCommander<T>(this Action<T> setter)
            where T : struct =>
            new _Commander<T> { Executor = setter };

        class _Commander<T> : Commander<T>
            where T : struct
        {
            public Action<T> Executor { get; set; }
        }
    }
}