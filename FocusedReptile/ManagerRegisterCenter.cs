using System;
using System.Collections.Concurrent;
using System.Collections.Generic;

namespace FocusedReptile
{
    public class ManagerRegisterCenter
    {
        #region Protect Members

        protected static ConcurrentDictionary<string, ConcurrentDictionary<string, object>> KeyValuePairsCluster { get; set; } = new ConcurrentDictionary<string, ConcurrentDictionary<string, object>>();

        //用于以后扩展，请勿修改
        //需要获取ManagerRegister类内所有静态类型
        //在不明确指定注入接口的实例时，在此处可利用反射和特性...等用来识别最终需要注入接口的类型
        //请求方通过以上述要求注册中央管理器返回符合预期行为的类型
        protected static event EventHandler InitializationService = delegate { };

        protected ManagerRegisterCenter() { }

        #endregion

        #region Others

        public const string DefaultClusterKey = "DEFAULT";
        public static Func<string, string> ToUpper = (input) => input.ToUpper();

        #endregion

        #region Static Construction

        static ManagerRegisterCenter()
        {
            KeyValuePairsCluster.AddOrUpdate(DefaultClusterKey, new ConcurrentDictionary<string, object>(), (key, value) => value);
            InitializationService.Invoke(null, null);
        }

        #endregion

        #region Registration

        public static bool RegistrationCluster(string registersCluster = DefaultClusterKey, bool compelKey = false)
        {
            registersCluster = ToUpper(registersCluster);
            Func<bool> change = () =>
            {
                KeyValuePairsCluster.AddOrUpdate(registersCluster, new ConcurrentDictionary<string, object>(), (key, value) => value);
                return KeyValuePairsCluster.ContainsKey(registersCluster);
            };
            Func<bool> add = () => KeyValuePairsCluster.TryAdd(registersCluster, new ConcurrentDictionary<string, object>());
            bool? result = (KeyValuePairsCluster.ContainsKey(registersCluster) == true ? (compelKey == true ? change : null) : add)?.Invoke();
            return result == null ? false : result.Value;
        }

        public static bool RegistrationTarget(string registersKey, object registersTarget, bool compelTarget = false, string registersCluster = DefaultClusterKey, bool compelCluster = false)
        {
            registersKey = ToUpper(registersKey);
            registersCluster = ToUpper(registersCluster);
            Func<bool> change = () => KeyValuePairsCluster[registersCluster].TryUpdate(registersKey, registersTarget, (KeyValuePairsCluster.TryGetValue(registersCluster, out var valuePairs) == true ? (valuePairs.TryGetValue(registersKey, out var value) == true ? value : null) : null));
            Func<bool> addTarget = () => KeyValuePairsCluster[registersCluster].TryAdd(registersKey, registersTarget);
            Func<bool> addCluster = () => KeyValuePairsCluster.TryAdd(registersCluster, new ConcurrentDictionary<string, object>()) == true ? (KeyValuePairsCluster.TryGetValue(registersCluster, out var valuePairs) == true ? (valuePairs.TryAdd(registersKey, registersTarget)) : false) : false;
            bool? result = (KeyValuePairsCluster.ContainsKey(registersCluster) == true ? (KeyValuePairsCluster[registersCluster].ContainsKey(registersKey) == true ? (compelTarget == true ? change : null) : addTarget) : (compelCluster == true ? addCluster : null))?.Invoke();
            return result == null ? false : result.Value;
        }

        public static IEnumerable<bool> RegistrationTarget(IEnumerable<(string, object)> registers, bool compelKey = false, string registersCluster = DefaultClusterKey)
        {
            foreach (var register in registers) yield return RegistrationTarget(register.Item1, register.Item2, compelKey, registersCluster);
        }

        #endregion

        #region Recaption

        public static RegisterTarget RecaptionTarget<RegisterTarget>(string registersKey, string registersCluster = DefaultClusterKey) where RegisterTarget : class
        {
            registersKey = ToUpper(registersKey);
            registersCluster = ToUpper(registersCluster);
            return KeyValuePairsCluster.TryGetValue(registersCluster, out var valuePairs) == true ? valuePairs.TryGetValue(registersKey, out var value) == true ? (RegisterTarget)value : null : null;
        }

        #endregion

        #region Unregistration 

        public static bool UnregistrationTarget(string registersKey, string registersCluster = DefaultClusterKey)
        {
            registersKey = ToUpper(registersKey);
            registersCluster = ToUpper(registersCluster);
            return KeyValuePairsCluster.ContainsKey(registersCluster) == true ? (KeyValuePairsCluster.TryGetValue(registersCluster, out var valuePairs) == true ? (valuePairs.ContainsKey(registersKey) == true ? (valuePairs.TryRemove(registersKey, out var value) == true ? true : false) : false) : false) : false;
        }

        public static IEnumerable<bool> UnregistrationTarget(IEnumerable<string> registersKeys, string registersCluster = DefaultClusterKey)
        {
            foreach (var register in registersKeys) yield return UnregistrationTarget(register, registersCluster);
        }

        #endregion
    }
}