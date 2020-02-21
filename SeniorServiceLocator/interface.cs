using System;
using System.IO;

namespace SeniorServiceLocator
{
    public interface IStorage { }

    public interface IStorageInfo { }

    public interface IStorageObject : IStorage { }

    public interface IStorageType : IStorageInfo { }

    public interface IStorageFile : IStorageObject
    {
        static FileInfo GetTargetFile(IStorageFileType storageFileType)
        {
            return storageFileType.GetStorageType().Invoke();
        }
    }

    public interface IStoragePath : IStorageObject
    {
        static string GetTargetPath(IStoragePathType storagePathType)
        {
            return storagePathType.GetStorageType().Invoke();
        }
    }

    public interface IStorageFileType : IStorageType
    {
        Func<FileInfo> GetStorageType();
    }

    public interface IStoragePathType : IStorageType
    {
        Func<string> GetStorageType();
    }

    /// <summary>
    /// 不是完整的接口继承
    /// </summary>
    public interface IHelperInfo { }

    public interface IDataPathHelper : IHelperInfo
    {
        public IStoragePathType DataPath { get; set; }
        public IStoragePathType DeploymentPath { get; set; }
        public IStoragePathType TemporaryPath { get; set; }
    }
}