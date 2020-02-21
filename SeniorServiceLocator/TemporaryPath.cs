using System;

namespace SeniorServiceLocator
{
    public class TemporaryPath : IStoragePathType
    {
        Func<string> getStorageType = () =>
        {
            string temporaryPath = string.Empty;
            /*
             * 省略的代码
             */
            temporaryPath = "此处未执行任何代码操作，所以返回一个无效的值";
            return temporaryPath;
        };

        public Func<string> GetStorageType()
        {
            return getStorageType;
        }
    }
}