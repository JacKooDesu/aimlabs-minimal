using ALM.Common;

namespace ALM.Screens.Base
{
    public struct TickTiming
    {
        public class ConstFixed : ITickTiming { }
        public class ConstRender : ITickTiming { }

        public class ManagedFixed : ITickTiming { }
        public class ManagedRender : ITickTiming { }
    }

    // Render
    public interface IManagedConstTickable : ITickable<TickTiming.ConstRender> { }
    public interface IManagedTickable : ITickable<TickTiming.ManagedRender> { }

    // Fixed Tick
    public interface IManagedConstFixedTickable : ITickable<TickTiming.ConstFixed> { }
    public interface IManagedFixedTickable : ITickable<TickTiming.ManagedFixed>
    {
        public static int ComparePriority(IManagedFixedTickable a, IManagedFixedTickable b)
        {
            return (a, b) switch
            {
                (IManagedFixedTickablePriority aPriority, IManagedFixedTickablePriority bPriority) => aPriority.Priority.CompareTo(bPriority.Priority),
                (IManagedFixedTickablePriority _, _) => -1,
                (_, IManagedFixedTickablePriority _) => 1,
                _ => 0
            };
        }
    }
    public interface IManagedFixedTickablePriority : IManagedFixedTickable
    {
        int Priority { get; }
    }
}