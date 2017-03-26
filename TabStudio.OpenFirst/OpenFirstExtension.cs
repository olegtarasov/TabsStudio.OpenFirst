using AddinsCommon;
using EnvDTE80;
using TabsStudioExt;

namespace TabStudio.OpenFirst
{
    public class OpenFirstExtension : ITabsStudioAddin2
    {
        private readonly IsPreviewTabProperty _isPreviewTab = new IsPreviewTabProperty();

        private ITabsStudioEngine _engine;


        public void OnConnection(ITabsStudioEngine engine, DTE2 dte, IVsPackage package)
        {
            _engine = engine;
            _engine.TabCreated += EngineOnTabCreated;
        }

        private void EngineOnTabCreated(object sender, TabEventArgs e)
        {
            if (_isPreviewTab.IsPreviewTab(e.Tab.TabItem))
                return;

            var container = e.Tabs.TabPanel2.Children;
            if (ReferenceEquals(container[0], e.Tab.TabItem))
                return;

            container.Remove(e.Tab.TabItem);
            container.Insert(0, e.Tab.TabItem);
        }

        public void OnDisconnection()
        {
        }
    }
}
