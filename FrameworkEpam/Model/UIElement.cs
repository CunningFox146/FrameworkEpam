namespace FrameworkEpam.Model
{
    public class UIElement
    {
        public string Selector { get; set; }

        public UIElement(string selector)
        {
            Selector = selector;
        }
    }
}
