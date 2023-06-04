using System;
using UnityEngine;

namespace BinaryEyes.Common.Extensions
{
    /// <summary>
    /// Extends the unity component object with common log methods.
    /// </summary>
    public static class ComponentLoggingExtensions
    {
        public static void LogWakingUp(this Component c) => c.LogMessage("WakingUp");
        public static void LogStarting(this Component c) => c.LogMessage("Starting");
        public static void LogEnabling(this Component c) => c.LogMessage("Enabling");
        public static void LogInitializing(this Component c) => c.LogMessage("Initializing");
        public static void LogDisabling(this Component c) => c.LogMessage("Disabling");
        public static void LogDestroying(this Component c) => c.LogMessage("Destroying");
        public static void LogDisposing(this Component c) => c.LogMessage("Disposing");

        public static void Assert(this Component component, bool condition, string message)
        {
            var text = $"{component.GetType().Name}: {message} [{component.name}]";
            Debug.Assert(condition, text);
        }

        public static T LogMessage<T>(this Component component, string format, params object[] args) where T : Component
        {
#if UNITY_EDITOR || DEBUG || FORCE_LOG
            var message = string.Format(format, args);
            Debug.Log($"{component.GetType().Name}: {message} [{component.name}]");
#endif
            return (T)component;
        }

        public static T LogError<T>(this Component component, string format, params object[] args) where T : Component
        {
#if UNITY_EDITOR || DEBUG || FORCE_LOG
            var message = string.Format(format, args);
            Debug.LogError($"{component.GetType().Name}: {message} [{component.name}]");
#endif
            return (T)component;
        }

        public static T LogWarning<T>(this Component component, string format, params object[] args) where T : Component
        {
#if UNITY_EDITOR || DEBUG || FORCE_LOG
            var message = string.Format(format, args);
            Debug.LogWarning($"{component.GetType().Name}: {message} [{component.name}]");
#endif
            return (T)component;
        }

        public static void LogNullException(this Component component, string format, params object[] args)
        {
            var message = string.Format(format, args);
            Debug.LogError($"{component.GetType().Name}: {message} [{component.name}]");
            throw new NullReferenceException(message);
        }
    }
}
