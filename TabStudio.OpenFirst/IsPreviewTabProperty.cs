namespace AddinsCommon
{
    class IsPreviewTabProperty
    {
        public bool IsPreviewTab(System.Windows.UIElement tab)
        {
            if (isPreviewTabDescriptor == null)
                isPreviewTabDescriptor = System.ComponentModel.DependencyPropertyDescriptor.FromName(
                    "IsPreviewTab", tab.GetType(), tab.GetType());

            return (bool)isPreviewTabDescriptor.GetValue(tab);
        }

        private System.ComponentModel.DependencyPropertyDescriptor isPreviewTabDescriptor;
    }
}
