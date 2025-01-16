public static class DebugExtend
{
    public static T Dbg<T>(this T target, string before = "", string after = "")
    {
#if UNITY_EDITOR
        // System.Console.WriteLine($"{before}{target}{after}");
        UnityEngine.Debug.Log($"{before}{target}{after}");
#endif
        return target;
    }
}
