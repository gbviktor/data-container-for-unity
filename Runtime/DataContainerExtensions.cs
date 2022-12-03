using UnityEngine;

namespace com.gbviktor.DataContainer
{
    public static class DataContainerExtensions
    {

        #region IData Extensions
        public static bool Get<T>(this IData self, out T data) where T : IData
        {
            if (self.BindContainer == null)
            {
                data = default;
                return false;
            }

            return self.BindContainer.Get(out data);
        }
        public static IData Attach<T>(this IData self, T data) where T : IData
        {
            if (self.BindContainer == null)
            {
                ErrorMsgNotInitializedContainer(self);
                return self;
            }

            self.BindContainer.Attach<T>(data);
            return self;
        }
        public static IData Detach<T>(this IData self, T data) where T : IData
        {
            if (self.BindContainer == null)
            {
                ErrorMsgNotInitializedContainer(self);
                return self;
            }

            self.BindContainer.Detach(data);
            return self;
        }

        public static IData Detach<T>(this IData self) where T : IData
        {
            if (self.BindContainer == null)
            {
                ErrorMsgNotInitializedContainer(self);
                return self;
            }
            self.BindContainer.Detach<T>();
            self.BindContainer = null;
            return self;
        }
        public static T InitDataContainer<T>(this T self) where T : IData
        {
            if (self.BindContainer != null)
            {
                Debug.LogError("BindContainer is already inited");
                return self;
            }
            self.BindContainer = new DataContainer();
            self.Attach(self);
            return self;
        }
        static void ErrorMsgNotInitializedContainer(IData self)
        {
            Debug.LogError($"BindContainer is null on Object {self}, call InitDataContainer() first or .Attach() Object to some other initialized  container");
        }
        #endregion

    }
}