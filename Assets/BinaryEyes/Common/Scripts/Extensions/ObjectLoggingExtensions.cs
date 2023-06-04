using System;
using Debug = UnityEngine.Debug;

namespace BinaryEyes.Common.Extensions
{
    /// <summary>
    /// Extends the base object class with common logging operations.
    /// </summary>
    public static class ObjectLoggingExtensions
    {
        public static void Assert(this object entry, bool condition, string message)
        {
            var text = $"{entry.GetType().Name}::{message}";
            Debug.Assert(condition, text);
        }

        public static T LogMessage<T>(this T entry, string format, params object[] args)
        {
#if UNITY_EDITOR || DEBUG || FORCE_LOG
            var message = string.Format(format, args);
            Debug.Log($"{entry.GetType().Name}::{message}");
#endif
            return entry;
        }

        public static object LogError(this object entry, string format, params object[] args)
        {
#if UNITY_EDITOR || DEBUG || FORCE_LOG
            var message = string.Format(format, args);
            Debug.LogError($"{entry.GetType().Name}::{message}");
#endif
            return entry;
        }

        public static object LogWarning(this object entry, string format, params object[] args)
        {
#if UNITY_EDITOR || DEBUG || FORCE_LOG
            var message = string.Format(format, args);
            Debug.LogWarning($"{entry.GetType().Name}::{message}");
#endif
            return entry;
        }

        public static void LogNullException(this object entry, string format, params object[] args)
        {
            var message = string.Format(format, args);
            Debug.LogError($"{entry.GetType().Name}::{message}");
            throw new NullReferenceException(message);
        }
    }
}