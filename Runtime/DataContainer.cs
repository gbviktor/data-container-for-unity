namespace com.gbviktor.DataContainer
{
    public class DataContainer : IDisposable
    {
        readonly Dictionary<Type, IData> datas = new Dictionary<Type, IData>();
        public bool AttachIfNotExistOrNull(IData obj)
        {
            if (datas.ContainsKey(obj.GetType()))
                if (datas[obj.GetType()] != null)
                    return false;

            datas[obj.GetType()] = obj;
            return true;
        }
        public void Attach<T>(IData obj)
        {
            try
            {
                Detach(datas[typeof(T)]);
            } catch { }

            datas[typeof(T)] = obj;
            obj.BindContainer = this;
        }

        public void Detach<T>()
        {
            datas.Remove(typeof(T));
        }
        public void Detach(IData obj)
        {
            datas.Remove(obj.GetType());
            obj.BindContainer = this;
        }
        public bool Get<T>(out T data) where T : IData
        {
            data = (T)datas.GetValueOrDefault(typeof(T));
            return data != null;
        }
        public void Dispose()
        {
            datas.Clear();
        }
    }
}