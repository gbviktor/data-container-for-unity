namespace com.gbviktor.DataContainer
{
    public class EmptyDataContainer : IData
    {
        DataContainer BindContainer { get; set; }

        public EmptyDataContainer()
        {
            BindContainer.InitDataContainer();
        }
    }
}