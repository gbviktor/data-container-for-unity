namespace com.gbviktor.DataContainer
{
    public class EmptyDataContainer : IData
    {
        public DataContainer BindContainer { get; set; }

        public EmptyDataContainer()
        {
            this.InitDataContainer();
        }
    }
}