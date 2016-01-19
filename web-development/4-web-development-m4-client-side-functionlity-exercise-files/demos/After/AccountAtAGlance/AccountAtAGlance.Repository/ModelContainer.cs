﻿using Microsoft.Practices.Unity;
using AccountAtAGlance.Model.Repository;

namespace AccountAtAGlance.Model
{
    //This is a simplified version of the code shown in the videos
    //The instance of UnityContainer is created in the constructor 
    //rather than checking in the Instance property and performing a lock if needed
    public static class ModelContainer
    {
        private static IUnityContainer _Instance;

        static ModelContainer()
        {
            _Instance = new UnityContainer();
        }

        public static IUnityContainer Instance
        {
            get
            {
                _Instance.RegisterType<IAccountRepository, AccountRepository>(new HierarchicalLifetimeManager());
                _Instance.RegisterType<ISecurityRepository, SecurityRepository>(new HierarchicalLifetimeManager());
                _Instance.RegisterType<IMarketsAndNewsRepository, MarketsAndNewsRepository>(new HierarchicalLifetimeManager());
                return _Instance;
            }
        }
    }
}
