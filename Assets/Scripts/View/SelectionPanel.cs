namespace View
{
    public class SelectionPanel : BasePanel
    {
        public void Activate(bool isActive)
        {
            gameObject.SetActive(isActive);
        }
    }
}
