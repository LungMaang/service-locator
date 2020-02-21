using FocusedReptile;

namespace SeniorServiceLocator
{
    public class DataPathHelper : IDataPathHelper
    {
        public IStoragePathType DataPath
        {
            get => ManagerRegisterCenter.RecaptionTarget<IStoragePathType>(ManagerRegister.DataPathKey);
            set => ManagerRegisterCenter.RegistrationTarget(ManagerRegister.DataPathKey, value, true);
        }
        public IStoragePathType DeploymentPath
        {
            get => ManagerRegisterCenter.RecaptionTarget<IStoragePathType>(ManagerRegister.DeploymentPathKey);
            set => ManagerRegisterCenter.RegistrationTarget(ManagerRegister.DeploymentPathKey, value, true);
        }
        public IStoragePathType TemporaryPath
        {
            get => ManagerRegisterCenter.RecaptionTarget<IStoragePathType>(ManagerRegister.TemporaryPathKey);
            set => ManagerRegisterCenter.RegistrationTarget(ManagerRegister.TemporaryPathKey, value, true);
        }
    }
}